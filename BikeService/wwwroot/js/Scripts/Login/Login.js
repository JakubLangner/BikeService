function loginToBikeService() {

    var data = $('#login-to-bikeservice-form').serialize();

    $.ajax({
        type: "POST",
        url: '/Login/Login',
        data: data,
        async: true,
        datatype: "application/json",
        success: function (response) {
            if (response.result) {
                toastr.info('Zalogowano pomyślnie');
                window.location.href = '/Home/Index/';
            } else {
                toastr.error(response.message)
            }
        },
        error: function (response) {
            
        }
    });
}

function registerToBikeService() {
    var data = new FormData(document.getElementById('create-account-form'));


    $.ajax({
        type: "POST",
        url: '/Login/Register',
        data: data,
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.result) {
                toastr.info('Zarejestrowano konto pomyślnie');
                window.location.href = '/Home/Index/';
            } else {
                toastr.error(response.message)
            }
        },
        error: function (response) {
            toastr.error(response.responseText);
        }
    });
}