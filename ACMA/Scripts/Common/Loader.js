window.Loader = function (form) {
    'use strict';

    var botaoDeSubmit = $(form).find('button[type="submit"]'),
      textoDoBotao = botaoDeSubmit.data('text'),
      textoDoLoader = "Enviando...";

    this.show = function () {
        botaoDeSubmit
          .addClass('disabled')
          .attr('disabled', true)
          .text(textoDoLoader);
    };

    this.remove = function () {
        botaoDeSubmit
          .removeClass('disabled')
          .removeAttr('disabled')
          .text(textoDoBotao);
    };
};