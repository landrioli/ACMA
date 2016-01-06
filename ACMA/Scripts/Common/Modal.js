window.Modal = function (callbackCloseModalArg, callbackConfirmModalArg) {
    'use strict';

    var modal,

    callbackConfirmModal,

    callbackCloseModal = callbackCloseModalArg,

    tituloDaModal = null,

    mensagemDaModal = null,

    tamanhoDaModal = 'sm';

    if (typeof callbackConfirmModal === 'undefined') {
        modal = $('#modal-notification');
    } else {
        modal = $('#modal-confirmation');
        callbackConfirmModal = callbackConfirmModalArg;
    }

    this.setTitle = function (titulo) {
        tituloDaModal = titulo;
    };

    this.setMessage = function (mensagem) {
        mensagemDaModal = mensagem;
    };

    this.setSize = function (tamanho) {
        tamanhoDaModal = tamanho;
    };

    this.setCallbackOfClosing = function (callback) {
        callbackCloseModal = callback;
    };

    this.setCallbackConfirmModal = function (callback) {
        callbackConfirmModal = callbackConfirmModal;
    };

    this.show = function () {
        modal.find('.modal-title').text(tituloDaModal || '');
        modal.find('.modal-message').text(mensagemDaModal || '');
        modal.find('.modal-dialog').addClass('modal-' + tamanhoDaModal);
        modal.off('hidden.bs.modal');
        if (typeof callbackCloseModal == "function") {
            modal.on('hidden.bs.modal', callbackCloseModal);
        }
        if (typeof callbackConfirmModal !== 'undefined') {
            $('#modal-confirmation').on('click', function () {
                callbackConfirmModal;
            });
        }
        modal.modal('show');
    };

    this.hide = function () {
        modal.modal('hide');
    };

};