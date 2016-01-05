window.Loader = function (form) {
    'use strict';

    var botaoDeSubmit = $(form).find('button[type="submit"]'),
      textoDoBotao = botaoDeSubmit.data('texto'),
      textoDoLoader = "Enviando...";

    this.exibir = function () {
        botaoDeSubmit
          .addClass('disabled')
          .attr('disabled', true)
          .text(textoDoLoader);
    };

    this.remover = function () {
        botaoDeSubmit
          .removeClass('disabled')
          .removeAttr('disabled')
          .text(textoDoBotao);
    };
};