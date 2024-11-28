var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/admin/departmentP/getall',
        },
        "columns": [
            {
                data: 'name',
                "width": "20%"
            },
            {
                data: 'numberOfBeds',
                "width": "20%"
            },
            {
                data: 'currentCapacity',
                "width": "20%"
            },
            {
                data: 'doctor.fullName',
                "width": "20%"
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group w-100" role="group">
                        <a href="/admin/departmentP/upsert?id=${data}" class="btn btn-primary mx-2"> 
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a href="javascript:void(0);" class="btn btn-danger mx-2 delete-btn" data-id="${data}">
                            <i class="bi bi-trash-fill"></i> Delete
                        </a>
                    </div>`;
                },
                "width": "20%"
            }
        ]
    });
    $('#tblData').on('click', '.delete-btn', function () {
        var id = $(this).data('id');
        Delete(`/admin/departmentP/delete/${id}`);
    });
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