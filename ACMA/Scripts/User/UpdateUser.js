var UpdateUser = (function () {
    'use strict';

    var inicializarPlugins = function () {
        $("#Phone").mask("(99) 9999-9999");
    };

    var formatarCampos = function (dados) {

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

    var inicializarEventosDaPagina = function () {
        $('#IdSelectListProfile').chosen();
    };

    var init = function () {
        inicializarPlugins();
        inicializarEventosDaPagina();
        Validate.configRegisterUserForm();
    };

    return {
        init: init
    };
}());
