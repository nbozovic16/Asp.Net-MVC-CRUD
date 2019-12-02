//Insert function
function jQueryAjaxPost(form)
{
    $.validator.unobtrusive.parse(form);
    if ($(form).valid())
    {
        var ajaxConfig =
        {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response)
            {
                if (response.success)
                {
                   $("#firstTab").html(response.html);
                    //RefreshAddNewTab($(form).attr('datarestUrl'), true);
                    $.notify(response.message, "success");
                }
                else
                {
                    $.notify(response.message, "error");
                }
            }
        }
        $.ajax(ajaxConfig); 
    }
    return false;
}

////refresh AddNewTab
//function RefreshAddNewTab(resetUrl, showViewTab)
//{
//    $.ajax({
//        type: 'GET',
//        url: resetUrl,
//        success: function (response) {
//            $("#secondTab").html(response);
//            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
//            if (showViewTab)
//            {
//                ('ul.nav.nav-tabs a:eq(0)').tab('show');
//            }
//        }
//    });
//}



//Edit function
function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').   html('Edit');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    });
}


//Delete function
function Delete(url) {
    if (confirm('Are u sure to delete this record ?') == true)
    {
        $.ajax({ 
            type: 'POST',
            url: url,
            success: function (response) {
                if (response.success) {
                    $("#firstTab").html(response.html);
                    $.notify(response.message, "warn");
                }
                else
                {
                    $.notify(response.message, "error");
                }
            }
        });
    }
}