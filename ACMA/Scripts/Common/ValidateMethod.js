window.ValidateMethod = (function () {
    'use strict';

    var adicionarMetodoValidacaoCpf = function () {
        $.validator.addMethod("cpf", function (value) {
            var cpf = value.replace(/[.-]/g, '');
            var numeros, digitos, soma, i, resultado, digitos_iguais;
            digitos_iguais = 1;
            if (cpf.length < 11)
                return false;
            for (i = 0; i < cpf.length - 1; i++)
                if (cpf.charAt(i) != cpf.charAt(i + 1)) {
                    digitos_iguais = 0;
                    break;
                }
            if (!digitos_iguais) {
                numeros = cpf.substring(0, 9);
                digitos = cpf.substring(9);
                soma = 0;
                for (i = 10; i > 1; i--)
                    soma += numeros.charAt(10 - i) * i;
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(0))
                    return false;
                numeros = cpf.substring(0, 10);
                soma = 0;
                for (i = 11; i > 1; i--)
                    soma += numeros.charAt(11 - i) * i;
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(1))
                    return false;
                return true;
            }
            else {
                return false;
            }
        }, "CPF inválido");
    };

    var adicionarMetodoValidacaoCnpj = function () {
        $.validator.addMethod("cnpj", function (cnpj) {
            cnpj = cnpj.replace(/[-/.]/g, '');
            if (cnpj.length != 14)
                return false;

            if (cnpj == "00000000000000" ||
                cnpj == "11111111111111" ||
                cnpj == "22222222222222" ||
                cnpj == "33333333333333" ||
                cnpj == "44444444444444" ||
                cnpj == "55555555555555" ||
                cnpj == "66666666666666" ||
                cnpj == "77777777777777" ||
                cnpj == "88888888888888" ||
                cnpj == "99999999999999")
                return false;

            var tamanho = cnpj.length - 2;
            var numeros = cnpj.substring(0, tamanho);
            var digitos = cnpj.substring(tamanho);
            var soma = 0;
            var pos = tamanho - 7;
            for (var i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            var resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(0))
                return false;

            tamanho = tamanho + 1;
            numeros = cnpj.substring(0, tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(1))
                return false;

            return true;
        }, "CNPJ inválido");
    };

    var adicionarMetodoValidacaoFormatoData = function () {
        $.validator.addMethod("dateFormat", function (value, element) {
            return value.match(/^(0[1-9]|[12][0-9]|3[01])[- //.](0[1-9]|1[012])[- //.](19|20)\d\d$/);
        });
    };

    var adicionarMetodoValidacaoDataFutura = function () {
        $.validator.addMethod("dateFuture", function (value, element) {
            if (value === null) {
                return false;
            }

            return Comum.isDataAnteriorAAtual(value);
        });
    };

    var adicionarMetodoValidacaoCep = function () {
        $.validator.addMethod("cep", function (value, element) {
            return value.match(/^[0-9]{5}-[0-9]{3}$/);
        });
    };

    var AddMethodFullName = function () {
        $.validator.addMethod("fullName", function (value, element) {
            return value.match(/\w+\s+\w+/);
        });
    };

    var AddMethodSelectListRequired = function () {
        $.validator.setDefaults({ ignore: ":hidden:not(select)" });
        $.validator.addMethod("selectListRequired", function (value, element) {
            return value != null && value != '';
        });
    };

    var AddMethodPhoneRequired = function () {
        $.validator.addMethod("phone", function (value, element) {
            //removes placeholder from string
            value = value.split("_").join("");

            return value.length === 14;
        });
    };

    //var AddMethodCheckBoxRequired = function () {
    //    //$.validator.setDefaults({ ignore: ":hidden:not(select)" });
    //    $.validator.setDefaults({ ignore: "" });
    //    $.validator.addMethod("checkBoxRequired", function (value, element) {
    //        return value != null && value != '';
    //    });
    //};

    return {
        adicionarMetodoValidacaoCnpj: adicionarMetodoValidacaoCnpj,
        adicionarMetodoValidacaoCpf: adicionarMetodoValidacaoCpf,
        adicionarMetodoValidacaoFormatoData: adicionarMetodoValidacaoFormatoData,
        adicionarMetodoValidacaoCep: adicionarMetodoValidacaoCep,
        adicionarMetodoValidacaoDataFutura: adicionarMetodoValidacaoDataFutura,
        AddMethodFullName: AddMethodFullName,
        AddMethodSelectListRequired: AddMethodSelectListRequired,
        AddMethodPhoneRequired: AddMethodPhoneRequired
    };

}());