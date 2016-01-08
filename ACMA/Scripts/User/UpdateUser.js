var UpdateUser = (function () {
    'use strict';

    var inicializarPlugins = function () {
        $("#Phone").mask("(99) 9999-9999");
        $('#IdSelectListProfile').chosen();
        window.setTimeout(function () {
            $("#Blocked").bootstrapSwitch('_width');
            $("#Active").bootstrapSwitch('_width');
        }, 1);

    };

    var inicializarEventosDaPagina = function () {

    };

    var registerUser = function (form) {//DESENVOLVER MÉTODO DE FORMATAÇÃO PARA RETIRAR MASKARAS E DAR SUBMIT COM AJAX RETORNAND MENSAGEM
        //CRIAR MODAL PARA AS MENSAGENS -
        //CRIAR O LOADER PARA O SISTEMA -
        var modal = new Modal(),
        dados = Common.getFormData(form),
        loader = new Loader(form);

        formatFields(dados);

        $.ajax({
            url: window.urlBase + 'User/RegisterUser',
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
        //dados.Telefone = Comum.removerNaoNumericos(dados.Telefone);
        //dados.TelefoneDdd = dados.Telefone.substring(0, 2);
        //dados.Telefone = dados.Telefone.substring(2, 10);

        //dados.Celular = Comum.removerNaoNumericos(dados.Celular);
        //dados.CelularDdd = dados.Celular.substring(0, 2);
        //dados.Celular = dados.Celular.substring(2, 10);

        //dados.Cpf = Comum.removerNaoNumericos(dados.Cpf);
        //dados.Cep = Comum.removerNaoNumericos(dados.Cep);

        //dados.RendaMensal = $('#RendaMensal').maskMoney('unmasked')[0];

    };

    var init = function () {
        inicializarPlugins();
        inicializarEventosDaPagina();
        Validate.configRegisterUserForm(registerUser);
    };

    return {
        init: init
    };
}());
