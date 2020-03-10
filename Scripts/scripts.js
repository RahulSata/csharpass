function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (result) {
                if (result.success == true) {   
                    $("#firsttab").html(result.html);
                    refreshaddnewtab($(form).attr('data-resturl'), true);  
                }
                else {
                    //$.notify(response.message, "error");
                }
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);
    }
    return false;
}

function refreshaddnewtab(resetUrl, showViewTab) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            $("#secondtab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showViewTab)
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
        }
    });
}


function Delete(url) {
    console.log("Hii "+ url);
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            console.log(response);
            console.log("Hello");
            $("#secondtab").html(response);
            $("#deleteid").show();
            $('ul.nav.nav-tabs a:eq(1)').html('Delete');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    });
}


function deleteCustomer(id) {
    
    $.ajax({
        type: 'Post',
        url: '/Customer/DeleteCustomer/',
        data: {id:id},
        success: function (response) {
            window.location = response.url;
        }
    });
}