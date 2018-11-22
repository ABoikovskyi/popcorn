$(function() {
    $(".data-table").each(function () {
        var noNeedExportButton = $(this).parent().hasClass('additional-data');
        $(this).DataTable({
            colReorder: true,
            fixedHeader: true,
            dom: noNeedExportButton ? '' :'Bfrtip',
            buttons: noNeedExportButton ? [] : [
                'copyHtml5',
                'excelHtml5'
            ],
            "columnDefs": [
                { "orderable": false, "targets": $('th', this).length - 1 }
            ]
        });
    });
});