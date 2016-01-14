window.DataTablesFactory = function () {
    'use strict';

    var columns = null;
    var columnsBool = null;

    this.loadColumns = function (param) {
        this.columns = param;
    }

    this.setColumnsBool = function (param) {
        this.columnsBool = param;
    }

    this.createGrid = function (data) {
        $('#DataGridUsersSearch').DataTable({
            data: data,
            order: [[1, "asc"]],//"desc"
            columns: this.columns,
            columnDefs: [
                {
                    "render": function (data, type, row) {
                        return (data === true) ? '<span class="glyphicon glyphicon-ok"></span>' : '<span class="glyphicon glyphicon-remove"></span>';
                    },
                    "targets": this.columnsBool
                }
            ],
            pagingType: "full_numbers_no_ellipses",
            //l - length changing input control
            //f - filtering input
            //t - The table!
            //i - Table information summary
            //p - pagination control
            //r - processing display element
            //https://datatables.net/reference/option/dom
            //códigos da grid = frBtlpi
            dom: '<"row"<"col-md-6"<"pull-left"f>><"col-md-6"<"pull-right"B>>>\
                  <"row"<"col-md-12"tr>>\
                  <"row"<"col-md-4"i><"col-md-8"p>>',

            lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
            //https://datatables.net/extensions/buttons/examples/initialisation/className.html
            buttons: [
                { extend: 'copy', text: 'Copiar', className: 'btn btn-xs' },
                {
                    extend: 'collection', text: 'Exportar', className: 'btn btn-xs', buttons: [
                                                                          { extend: 'csv', text: 'Download CSV', className: 'btn btn-xs' },
                                                                          { extend: 'excel', text: 'Download Excel', className: 'btn btn-xs' },
                                                                          { extend: 'pdf', text: 'Download PDF', className: 'btn btn-xs' }
                    ]
                },
                { extend: 'print', text: 'Imprimir', className: 'btn btn-xs' },
            ],
            info: true,
            search: true,
            filter: true,
            lengthChange: false,
            paginate: true,
            processing: true,

            //https://datatables.net/reference/option/language.info
            //https://datatables.net/reference/option/language
            language: {
                "decimal": "",
                "emptyTable": "Nenhum dado disponível para visualização",
                "info": "Apresentando de _START_ à _END_ de _TOTAL_ registros",
                "infoEmpty": "Encontrado 0 a 0 de 0 registros",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Apresentar _MENU_ registros",
                "loadingRecords": "Carregando...",
                "processing": "Processando...",
                "search": "PESQUISAR:",
                "zeroRecords": "Nenhum registro encontrado",
                "paginate": {
                    "first": "Primeiro",
                    "last": "Último",
                    "next": "Próximo",
                    "previous": "Anterior"
                },
                "aria": {
                    "sortAscending": ": Ativar ordenação ascendente na coluna",
                    "sortDescending": ": Ativar ordenação descendente na coluna"
                },
                buttons: {
                    copyTitle: 'Copier au clipboard',
                    copyKeys: 'Appuyez sur <i>ctrl</i> ou <i>\u2318</i> + <i>C</i> pour copier les données de table à votre presse-papiers du système. <br><br>Pour annuler, cliquez sur ce message ou appuyez sur Echap.'
                }
            }
        });
    };
};
