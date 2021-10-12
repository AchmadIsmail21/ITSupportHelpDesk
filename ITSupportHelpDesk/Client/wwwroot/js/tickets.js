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
                        var current_month = d.getMonth() + 1;
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
                        return `<button type="button" class="btn btn-outline-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal" data-placement="bottom" title="Chatting With Staff Admin Support"><i class="fas">Chat</button>`;
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
    });

    $('#tableHistoryTickets').DataTable({
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
        "ajax": {
            url: 'https://localhost:44358/Dashboard/GetHistoryTicketsUser',
            dataSrc: ''
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
                    if (data) {
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1
                        var curr_year = d.getFullYear();
                        var formatedDate = d.getDate() + '-' + d.getMonth() + '-' + d.getFullYear();
                        return formatedDate;
                    }
                    else
                        return data
                },
            },
            {
                "data": "endDateTime",
                "render": function (data, type, row) {
                    if (data) {
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1
                        var curr_year = d.getFullYear();
                        var formatedDate = d.getDate() + '-' + d.getMonth() + '-' + d.getFullYear();
                        return formatedDate;
                    }
                    else
                        return data
                },
            },
            {
                "data": "level",
                "render": function (data, type, row) {
                    if (row['level'] == 1) {
                        return 'Case Handle by Admin Support';
                    }
                    else if (row['level'] == 2) {
                        return 'Case Handle by IT Support';
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
                "data": "review",
                "render": function (data, type, row) {
                    if (row['review'] == 0) {
                        return '-';
                    }
                    else if (row['review'] == 1) {
                        return '&#9733';
                    }
                    else if (row['review'] == 2) {
                        return '&#9733' + '&#9733';
                    }
                    else if (row['review'] == 3) {
                        return '&#9733' + '&#9733' + '&#9733';
                    }
                    else if (row['review'] == 4) {
                        return '&#9733' + '&#9733' + '&#9733' + '&#9733';
                    }
                    else if (row['review'] == 5) {
                        return '&#9733' + '&#9733' + '&#9733' + '&#9733' + '&#9733';
                    }
                }
            },
            {
                "render": function (data, type, row) {
                    if (row['endDateTime'] == null) {
                        return `<button type="button" class="btn btn-outline-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal" data-placement="bottom" title="Chatting With Staff IT Support"><i class="fas">Chat</button>`;
                    } else {
                        if (row['review'] == 0) {
                            return `<button type="button" class="btn btn-outline-success" onclick="viewReviewTicket('${row['id']}')" data-toggle="modal" data-target="#viewReviewModal"  data-placement="bottom" title="Review"><i class="fas fa-star"></button>`;
                        } else {
                            return "-";
                        }
                    }
                }
            }
        ]
    });
});
//create ticket
function openCreateTicket() {
    $.ajax({
        url: 'https://localhost:44329/API/Categories/'
    }).done((result) => {
        var text = "";
        $.each(result, function (key, val) {
            text += `<option value="${val.id}">${val.name}</option>`
        });
        $("#inputCreateCategoryId").html(text);
    }).fail((error) => {
        console.log(error);
    });
}

function createTicket() {
    var obj = new Object();
    obj.UserId = parseInt($("#inputCreateUserId").val());
    obj.Description = $("#inputCreateDescription").val();
    obj.CategoryId = parseInt($("#inputCreateCategoryId").val());
    console.log(obj);
    
        $.ajax({
            url: 'https://localhost:44329/API/Cases/CreateTicket',
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(obj)
        }).done((result) => {
            Swal.fire({
                title: 'Error!',
                text: 'Failed add ticket',
                icon: 'error',
                confirmButtonText: 'OK'
            });
        }).fail((error) => {
            //alert(error);
            $('#tableTickets').DataTable().ajax.reload();
            Swal.fire({
                title: 'Success!',
                text: 'Success add Ticket',
                icon: 'success',
                confirmButtonText: 'OK'
            });
            $('#createModal').modal('hide');
        });
    }
//-------------------------------------------------------

//convertation
function viewConvertation(caseId) {
    $("#inputConvertationCaseId").val(parseInt(caseId));
    chatting(caseId);
}

function chatting(caseId) {
    $.ajax({
        url: `https://localhost:44329/API/Convertations/ViewConvertationCaseId/${caseId}`
    }).done((result) => {
        text = "";
        $.each(result, function (key, val) {
            if (val.userId == viewBagUserId) {
                text += `
                     <div class="direct-chat-msg right">
                        <div class="direct-chat-info clearfix">
                              <span class="direct-chat-name float-right">${val.userName}</span>
                              <span class="direct-chat-timestamp float-left">${val.dateTime}</span>
                        </div>
                        <!-- /.direct-chat-info -->
                        
                        
                        <div class="direct-chat-text">
                          ${val.message}
                        </div>
                    <!-- /.direct-chat-text -->
                  </div>
                `;
            } else {
                text += `
                            <div class="direct-chat-msg">
                                <div class="direct-chat-info clearfix">
                                  <span class="direct-chat-name float-left">${val.userName}</span>
                                  <span class="direct-chat-timestamp float-right">${val.dateTime}</span>
                                </div>
                                <!-- /.direct-chat-info -->
                                
                                <!-- /.direct-chat-img -->
                                <div class="direct-chat-text">
                                  ${val.message}
                                </div>
                                <!-- /.direct-chat-text -->
                              </div>
                        `;
            }
        });
        $("#chatMessages").html(text);
    }).fail((error) => {
        console.log(error);
    });
}

function createConvertation() {
    var obj = new Object();
    obj.UserId = parseInt($("#inputConvertationUserId").val());
    obj.CaseId = parseInt($("#inputConvertationCaseId").val());
    obj.Message = $("#inputConvertationMessage").val();
    console.log(obj);

    $.ajax({
        url: 'https://localhost:44329/API/Convertations/CreateConvertations',
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(obj)
    }).done((result) => {
        chatting(obj.CaseId);
        $('#tableTickets').DataTable().ajax.reload();
        $("#inputConvertationMessage").summernote();
        $('#viewConvertationModal').modal('hide');
    }).fail((error) => {
        console.log(error);
    })
}




