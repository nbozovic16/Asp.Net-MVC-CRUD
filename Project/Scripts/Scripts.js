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
                }
                else
                {
                    //error message
                }
            }
        }
        $.ajax(ajaxConfig);
    }
    return false;
}