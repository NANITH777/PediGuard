var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/admin/assistantnobet/getall',
        },
        "columns": [
            {
                data: 'date',
                "width": "10%",
                "render": function (data) {
                    return formatDate(data);
                }
            },
            {
                data: 'startTime',
                "width": "12.5%",
                "render": function (data) {
                    return formatTime(data);
                }
            },
            {
                data: 'endTime',
                "width": "12.5%",
                "render": function (data) {
                    return formatTime(data);
                }
            },
            {
                data: 'assistant.fullName',
                "width": "20%"
            },
            {
                data: 'department.name',
                "width": "20%"
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group w-100" role="group">
                        <a href="/admin/assistantnobet/upsert?id=${data}" class="btn btn-primary mx-2"> 
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a href="javascript:void(0);" class="btn btn-danger mx-2 delete-btn" data-id="${data}">
                            <i class="bi bi-trash-fill"></i> Delete
                        </a>
                    </div>`;
                },
                "width": "25%"
            }

        ]
    });
    $('#tblData').on('click', '.delete-btn', function () {
        var id = $(this).data('id');
        Delete(`/admin/assistantnobet/delete/${id}`);
    });
}

function formatDate(dateString) {
    var date = new Date(dateString);
    var year = date.getFullYear();
    var month = ('0' + (date.getMonth() + 1)).slice(-2);
    var day = ('0' + date.getDate()).slice(-2);
    return day + '-' + month + '-' + year;
}

function formatTime(timeString) {
    var time = new Date(timeString);
    var hours = ('0' + time.getHours()).slice(-2);
    var minutes = ('0' + time.getMinutes()).slice(-2);
    return hours + ':' + minutes;
}




function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}
