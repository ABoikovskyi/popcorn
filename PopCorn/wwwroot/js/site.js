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

    $(document).on("click", "[type='checkbox']", function(e) {
        if (this.checked) {
            $(this).attr("value", "true");
        } else {
            $(this).attr("value","false");}
    });
});