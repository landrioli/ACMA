var RecoveryPassword = (function () {
    'use strict';

    var inicializarPlugins = function () {

    };

    var inicializarEventosDaPagina = function () {

    };

    var recoveryPassword = function (form) {
        var modal = new Modal(),
        dados = { email: $('#Email') },
        loader = new Loader(form);

        $.ajax({
            url: window.urlBase + 'Authorize/RecoveryPassword',
            type: 'POST',
            data: dados,
            dataType: 'json',
            beforeSend: function () {
                loader.show();
            },
            success: function (data) {
                if (data.Success) {
                    modal.setTitle(data.Title);
                    modal.setMessage(data.Message);
                    modal.setCallbackOfClosing(redirectHome);
                } else {
                    modal.setTitle(data.Title);
                    modal.setMessage(data.Mensagem);
                }
            },
            error: function (data) {
                modal.setTitle(data.Title);
                modal.setMessage(data.Mensagem);
            },
            complete: function () {
                modal.show();
                loader.remove();
            }
        });
    };

    var redirectHome = function () {
        window.location.href = window.urlBase + 'Authorize/Login';
    }

    var init = function () {
        inicializarPlugins();
        inicializarEventosDaPagina();
        Validate.configRegisterUserForm(recoveryPassword);
    };

    return {
        init: init
    };
}());
