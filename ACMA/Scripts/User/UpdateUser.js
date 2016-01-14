var UpdateUser = (function () {
    'use strict';

    var inicializarPlugins = function () {
        var celPhone = $("#Phone").val();
        $("#Phone").mask("(99) 9999-9999");
        $("#Phone").val(celPhone);
        $('#Phone').trigger('input')

        $('#IdSelectListProfile').chosen();
        window.setTimeout(function () {
            $("#Blocked").bootstrapSwitch('_width');
            $("#Active").bootstrapSwitch('_width');
        }, 1);

        
    };

    var inicializarEventosDaPagina = function () {

    };

    var updateUser = function (form) {
        var modal = new Modal(),
        dados = Common.getFormData(form),
        loader = new Loader(form);

        formatFields(dados);

        $.ajax({
            url: window.urlBase + 'User/UpdateUser',
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
        window.location.href = window.urlBase;
    }

    var formatFields = function (dados) {
        dados.Phone = Common.removeNoNumerics(dados.Phone);
        dados.Blocked = Common.checkBoxSwitchState('#Blocked');
        dados.Active = Common.checkBoxSwitchState('#Active');

    };

    var init = function () {
        inicializarPlugins();
        inicializarEventosDaPagina();
        Validate.configUpdateUserForm(updateUser);
    };

    return {
        init: init
    };
}());
