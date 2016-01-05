window.Common = (function () {
    'use strict';

    var isDatePreviousNow = function (textoData) {
        var date = textoData.split('/');
        if (date.length === 3) {
            return new Date(date.reverse().join('-')) <= new Date();
        }
        return false;
    };

    var getFormData = function (form) {
        var dadosDoFormulario = {};
        $(form).serializeArray().map(function (item) {
            if (dadosDoFormulario[item.name]) {
                if (typeof (dadosDoFormulario[item.name]) === "string") {
                    dadosDoFormulario[item.name] = [dadosDoFormulario[item.name]];
                }
                dadosDoFormulario[item.name].push(item.value);
            } else {
                dadosDoFormulario[item.name] = item.value;
            }
        });
        return dadosDoFormulario;
    };

    var removeNoNumerics = function (input) {
        var regex = /[^\d]/g;
        return input.replace(regex, '');
    };

    var clearForm = function (form) {
        $(form).trigger('reset');
        $(form).validate().resetForm();
    };

    return {
        getFormData: getFormData,
        clearForm: clearForm,
        removeNoNumerics: removeNoNumerics,
        isDatePreviousNow: isDatePreviousNow
    };

}());