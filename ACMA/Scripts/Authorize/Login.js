var Login = (function () {
    'use strict';

    var inicializarPlugins = function () {
    };

    var inicializarEventosDaPagina = function () {

    };

    var login = function (form) {
        var modal = new Modal(),
        loader = new Loader(form),
        dados = {
            UserName: $('#UserName').val(),
            Password: $('#Password').val(),
            PreviousUrl: document.referrer
        };

        $.ajax({
            url: window.urlBase + 'Authorize/Login',
            type: 'POST',
            data: dados,
            dataType: 'json',
            beforeSend: function () {
                loader.show();
            },
            success: function (data) {
                if (data.Success) {
                    redirectNextPage(dados.PreviousUrl);
                } else {
                    $("#LoginErrorMessage").addClass("login-error");
                }
            },
            error: function (data) {
                $("#LoginErrorMessage").addClass("login-error");
            },
            complete: function () {
                loader.remove();
            }
        });
    };

    var redirectNextPage = function (previousUrl) {
        if (previousUrl !== '') {
            window.location.href = previousUrl;
        } else {
            window.location.href = window.urlBase;
        }

    }

    var init = function () {
        inicializarPlugins();
        inicializarEventosDaPagina();
        Validate.configLoginForm(login);
    };

    return {
        init: init
    };
}());
