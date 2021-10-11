$(document).ready(function () {
    $('#inputConvertationMessage').summernote();
    $('#tableTickets').DataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4]
                }
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4]
                }
            }
        ],
        "filter": true,
        "ajax": {
            "url": 'https://localhost:44358/Dashboard/GetTicketsUser',
            "dataSrc": ''
        },
        "columns": [
            {
                "data": null, "sortable": false,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "description"
            },
            {
                "data": "startDateTime",
                "render": function (data, type, row) {
                    console.log(data)
                    if (data) {
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var current_date = d.getDate();
                        var current_month = d.getMonth();
                        var current_year = d.getFullYear();
                        var formatedDate = current_date + '-' + current_month + '-' + current_year;
                        return formatedDate;
                    }
                    else {
                        return data;
                    }
                }
            },
            {
                "data": "level",
                "render": function (data, type, row) {
                    if (row['level'] == 1) {
                        return 'Case Handle by Admin Support';
                    }
                    else if (row['level'] == 2) {
                        return 'Case Handle by IT Support'
                    }
                }
            },
            {
                "data": "priorityName"
            },
            {
                "data": "categoryName"
            },
            {
                "render": function (data, type, row) {
                    if (row['endDateTime'] == null) {
                        return `<button type="button" class="btn btn-outline-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal" data-placement="bottom" title="Chatting With Staff IT Support Helpdesk"><i class="fas">Chat</button>`;
                    } else {
                        if (row['review'] == 0) {
                            return `<button type="button" class="btn btn-outline-success" onclick="viewReviewTicket('${row['id']}')" data-toggle="modal" data-target="#viewReviewModal"  data-placement="bottom" title="Review"><i class="fas">Review</button>`;
                        } else {
                            return "-";
                        }
                    }
                }
            }
        ]
    })
})