function jQueryAjaxPost(form)
{
    $.validator.unobtrusive.parse(form);
    if ($(form).valid())
    {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                if (response.success) {
                    $("#firstTab").html(response.html);
                    //succes message
                    $.notify(response.message, "success")
                }
                else
                {
                    //error message
                    $.notify(response.message, "error")
                }
            }
        }
        $.ajax(ajaxConfig);
    }
    return false;
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    });

}