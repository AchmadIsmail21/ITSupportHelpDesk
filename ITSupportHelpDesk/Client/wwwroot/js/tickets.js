$(document).ready(function () {
    $('#inputConvertationMessage').summernote();
    $('tableTickets').DataTable({
        ajax: {
            url: 'https://localhost:44358/DashBoard/GetTicketsUser',
            dataSrc: ''
        },
        columns: [
            {
                "data": null, "sortable": false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
        ]
    })
})