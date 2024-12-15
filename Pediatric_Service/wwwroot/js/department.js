var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/admin/department/getall',
        },
        "columns": [
            {
                data: 'name',
                "width": "20%"
            },
            {
                data: 'numberOfBeds',
                "width": "7.5%"
            },
            {
                data: 'currentCapacity',
                "width": "7.5%"
            },
            {
                data: 'doctor.fullName', 
                "width": "10%"
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group w-100" role="group">
                        <a href="/admin/department/upsert?id=${data}" class="btn btn-primary mx-2"> 
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
        Delete(`/admin/department/delete/${id}`); 
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
                },
                error: function (xhr, status, error) {
                    toastr.error("An error occurred while deleting the department.");
                }
            });
        }
    });
}
