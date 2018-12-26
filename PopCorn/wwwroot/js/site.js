$(function() {
    $('.data-table').each(function() {
        var currentTable = this;
        $('thead', this).append($('thead tr', this).clone(true));
        $('thead tr:eq(1) th', this).each(function(i) {
            var title = $(this).text();
            $(this).html('<input type="text" placeholder="поиск" />');

            $('input', this).on('keyup',
                function (e) {
                    var inputValue = this.value;
                    if (e.keyCode == 13 && table.column(i).search() !== inputValue) {
                        var isRegex = inputValue.includes("+");
                        if (isRegex) {
                            inputValue = inputValue.replace("+", "|");
                        }
                        table.column(i).search(inputValue, isRegex, false).draw();
                        sumFunction(currentTable);
                    }
                });
        });

        var noNeedExportButton = $(this).parent().hasClass('additional-data');
        var table = $(this).DataTable({
            paging: false,
            colReorder: true,
            orderCellsTop: true,
            fixedHeader: true,
            dom: noNeedExportButton ? '' : 'Bfrtip',
            buttons: noNeedExportButton
                ? []
                : [
                    'copyHtml5',
                    'excelHtml5'
                ]
        });

        sumFunction(currentTable);
    });

    $(document).on("click",
        "[type='checkbox']",
        function(e) {
            if (this.checked) {
                $(this).attr("value", "true");
            } else {
                $(this).attr("value", "false");
            }
        });

    $(".multiselect").chosen();
});

var sumFunction = function(table) {
    var sumTd = $('td.formula-sum', table);
    if (sumTd.length > 0) {
        var sum = 0;
        $('.amountColum').each(function() {
            var value = $(this).text();
            if (!isNaN(value) && value.length != 0) {
                sum += parseFloat(value);
            }
        });
        sumTd.html(sum);
    }
};