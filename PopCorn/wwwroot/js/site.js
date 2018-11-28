$(function () {
    $(".data-table").each(function () {
        //$('thead tr', this).clone(true).appendTo('thead', this);
        $('thead', this).append($('thead tr', this).clone(true));
        $('thead tr:eq(1) th', this).each(function (i) {
            var title = $(this).text();
            $(this).html('<input type="text" placeholder="Search ' + title + '" />');

            $('input', this).on('keyup', function (e) {
                if (e.keyCode == 13 && table.column(i).search() !== this.value) {
                    table
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        });

        var noNeedExportButton = $(this).parent().hasClass('additional-data');
        var table = $(this).DataTable({
            colReorder: true,
            orderCellsTop: true,
            fixedHeader: true,
            dom: noNeedExportButton ? '' :'Bfrtip',
            buttons: noNeedExportButton ? [] : [
                'copyHtml5',
                'excelHtml5'
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