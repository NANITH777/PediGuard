var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/admin/emergency/getall',
            type: 'GET',
            datatype: 'json',
            error: function (xhr, error, thrown) {
                console.log(xhr.responseText);
            }
        },
        "columns": [
            {
                data: 'createdAt',
                "width": "15%",
                "render": function (data) {
                    return formatDateTime(data);
                }
            },
            {
                data: 'description',
                "width": "25%"
            },
            {
                data: 'location',
                "width": "20%"
            },
            {
                data: 'status',
                "width": "10%"
            },
            {
                data: 'department.name',
                "width": "15%"
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group w-100" role="group">
                        <a href="/admin/emergency/upsert?id=${data}" class="btn btn-primary mx-2"> 
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a href="javascript:void(0);" class="btn btn-danger mx-2 delete-btn" data-id="${data}">
                            <i class="bi bi-trash-fill"></i> Delete
                        </a>
                    </div>`;
                },
                "width": "15%"
            }
        ]
    });
    $('#tblData').on('click', '.delete-btn', function () {
        var id = $(this).data('id');
        Delete(`/admin/emergency/delete/${id}`);
    });
}

function formatDateTime(dateTimeString) {
    var date = new Date(dateTimeString);
    var year = date.getFullYear();
    var month = ('0' + (date.getMonth() + 1)).slice(-2);
    var day = ('0' + date.getDate()).slice(-2);
    var hours = ('0' + date.getHours()).slice(-2);
    var minutes = ('0' + date.getMinutes()).slice(-2);
    return day + '-' + month + '-' + year + ' ' + hours + ':' + minutes;
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