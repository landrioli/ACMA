window.Modal = function (callbackCloseModal, callbackConfirmModal) {
    'use strict';

    var modal,

    callbackConfirmModal,

    callbackDeFechamentoDaModal = callbackCloseModal,

    tituloDaModal = null,

    mensagemDaModal = null,

    tamanhoDaModal = 'sm';

    if (typeof callbackConfirmModal === 'undefined') {
        modal = $('#modal-notification');
    } else {
        modal = $('#modal-confirmation');
        callbackConfirmModal = callbackConfirmModal;
    }

    this.setTitulo = function (titulo) {
        tituloDaModal = titulo;
    };

    this.setMensagem = function (mensagem) {
        mensagemDaModal = mensagem;
    };

    this.setTamanho = function (tamanho) {
        tamanhoDaModal = tamanho;
    };

    this.setCallbackDeFechamento = function (callback) {
        callbackDeFechamentoDaModal = callbackCloseModal;
    };

    this.setCallbackConfirmModal = function (callback) {
        callbackConfirmModal = callbackConfirmModal;
    };

    this.exibir = function () {
        modal.find('.modal-title').text(tituloDaModal || '');
        modal.find('.modal-message').text(mensagemDaModal || '');
        modal.find('.modal-dialog').addClass('modal-' + tamanhoDaModal);
        modal.off('hidden.bs.modal');
        if (typeof callbackDeFechamentoDaModal == "function") {
            modal.on('hidden.bs.modal', callbackDeFechamentoDaModal);
        }
        if (typeof callbackConfirmModal === 'undefined') {
            $('#modal-confirmation').on('click', function () {
                callbackConfirmModal;
            });
        }
        modal.modal('show');
    };

    this.esconder = function () {
        modal.modal('hide');
    };

};