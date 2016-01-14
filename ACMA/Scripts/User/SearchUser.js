var SearchUser = (function () {
    'use strict';

    var inicializarPlugins = function () {

    };

    var inicializarEventosDaPagina = function () {
        var data = loadUsersFromDB();
    };

    var loadUsersFromDB = function () {
        $.ajax({
            url: window.urlBase + 'User/GetUsers',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                loadGrid(data);
            },
            error: function (data) {
                var modal = new Modal();
                modal.setTitle(data.Title);
                modal.setMessage(data.Mensagem);
                modal.show();
                return;
            }
        });
    };

    var loadGrid = function (data) {
        var dataTablesFactory = new DataTablesFactory();
        dataTablesFactory.loadColumns([
               {
                   "data": "Id",
                   "visible": false,
               },
               {
                   "data": "FullName",
                   "visible": true,
               },
               {
                   "data": "Phone",
                   "visible": true,
               },
               {
                   "data": "Email",
                   "visible": true,
               },
               {
                   "data": "IdProfile",
                   "visible": true,
               },
               {
                   "data": "Blocked",
                   "visible": true,
               },
               {
                   "data": "Active",
                   "visible": true,
               },
               {
                   "data": null,
                   "render": function (data, type, full) {
                       return '<a class="btn btn-success btn-sm" href=#/' + data.Id + '>' + 'Editar' + '</a>' +
                              '<a class="btn btn-danger btn-sm" href=#/' + data.Id + '>' + 'Remover' + '</a>';
                   }
               }]);
        dataTablesFactory.setColumnsBool([5, 6]);
        dataTablesFactory.createGrid(JSON.parse(data));
    }

    var searchUser = function (form) {
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
        Validate.configSearchUserForm(searchUser);
    };

    return {
        init: init
    };
}());
