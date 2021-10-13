$(document).ready(function () {
    $('#inputConvertationMessage').summernote();
    $('#tableViewTickets').DataTable({
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
            "url": 'https://localhost:44358/Dashboard/GetTicketsByLevel',
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
                        var current_month = d.getMonth() + 1;
                        var current_year = d.getFullYear();
                        var formatedDate = current_year + '-' + current_month + '-' + current_date;
                        return formatedDate;
                    }
                    else {
                        return data;
                    }
                }
            },

            {
                "data": "level"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row['userName'] + ', ' + 'ID: ' + row['userId'];
                }
            },
            {
                "data": "priorityName",
                "render": function (data, type, row) {
                    if (row['priorityName'] == 'Low') {
                        return `<span class="badge badge-success">${row['priorityName']}</span>`;
                    } else if (row['priorityName'] == 'Medium') {
                        return `<span class="badge badge-warning">${row['priorityName']}</span>`;
                    } else {
                        return `<span class="badge badge-danger">${row['priorityName']}</span>`
                    }
                }
            },
            {
                "data": "categoryName"
            },
            {
                "render": function (data, type, row) {
                    if (row['staffId'] == null) {
                        return `<button type="button" class="left btn btn-outline-dark" onclick="handleTicket('${row['id']}','${userId}', '${staffId}')" title="Handle Ticket">Handle</button>`
                    } else {

                        return `<span class="right badge badge-pill badge-secondary">Handle by Staff ID: ${row['staffId']} </span>`;
                    }
                }
            }
        ]
    });

    $('#tableViewHandleTickets').DataTable({
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
            "url": 'https://localhost:44358/Dashboard/GetHandleTickets',
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
                        var current_month = d.getMonth() + 1;
                        var current_year = d.getFullYear();
                        var formatedDate = current_year + '-' + current_month + '-' + current_date;
                        return formatedDate;
                    }
                    else {
                        return data;
                    }
                }
            },
            {
                "data" : "level"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row['userName'] + ', ' + 'ID: ' + row['userId'];
                }
            },
            {
                "data": "priorityName",
                "render": function (data, type, row) {
                    if (row['priorityName'] == 'Low') {
                        return `<span class="badge badge-success">${row['priorityName']}</span>`;
                    } else if (row['priorityName'] == 'Medium') {
                        return `<span class="badge badge-warning">${row['priorityName']}</span>`;
                    } else {
                        return `<span class="badge badge-danger">${row['priorityName']}</span>`
                    }
                }
            },
            {
                "data": "categoryName"
            },
            {
                "render": function (data, type, row) {
                    if (row['endDateTime'] == null) {
                        if (row['level'] == viewBagLevel) {
                            return `<button type="button" class="btn btn-outline-info" onclick="askNextLevel('${row['id']}')"  data-placement="bottom" title="Ask Next Level to Help"><i class="fas">Next Level</i></button>
                                    <button type="button" class="btn btn-outline-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal"  data-placement="bottom" title="Chatting With Client"><i class="fas">Chat</i></button> 
                                    <button type="button" class="btn btn-outline-danger" onclick="closeTicket('${row['id']}','${viewBagUserId}')"  data-placement="bottom" title="Close Ticket"><i class="fas"></i>Close</button> 
                                    <button type="button" class="btn btn-outline-warning" onclick="viewPriority('${row['id']}')" data-toggle="modal" data-target="#viewPriorityModal" data-placement="bottom" title="Change Priority Ticket"><i class="fas"></i>Change Priority</button>`;
                        } else {
                            return null;
                        }
                    } else {
                        return null;
                    }
                }

            }
        ]
    });
})

function handleTicket(caseId, userId, staffId) {
    var obj = new Object();
    obj.CaseId = parseInt(caseId);
    obj.UserId = parseInt(userId);
    obj.StaffId = parseInt(staffId);
    console.log(obj);
    Swal.fire({
        title: 'Konfirmasi Penanganan Data',
        text: 'Apakan Anda yakin untuk menangani Case #' + caseId + 'oleh StaffId #' + staffId + ' ?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ya',
        cancelButtonText: 'Tidak'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44329/API/Cases/HandleTicket',
                type: "POST",
                contentType: 'application/json',
                data: JSON.stringify(obj)
            }).done((result) => {
                console.log(obj);
                console.log(result);
                Swal.fire({
                    title: 'Success!',
                    text: 'Berhasil menambahkan Case untuk ditangani Anda',
                    icon: 'success',
                    confirmButtonText: 'Oke'
                });
            }).fail((error) => {
                console.log(obj);
                console.log(error);
                Swal.fire({
                    title: 'Error!',
                    text: 'Gagal menambahkan Case untuk ditangani Anda',
                    icon: 'error',
                    confirmButtonText: 'Oke'
                });
            });
        }
    });

}