document.addEventListener('DOMContentLoaded', function () {
    function getStatusClass(status) {
        switch (status) {
            case 'Pending':
                return ['bg-warning', 'text-dark'];
            case 'In Progress':
                return ['bg-info', 'text-dark'];
            case 'Resolved':
                return ['bg-success'];
            case 'Cancelled':
                return ['bg-danger'];
            default:
                return ['bg-secondary'];
        }
    }

    document.querySelectorAll('[id^="status-"], [id^="modal-status-"]').forEach(function (element) {
        var status = element.textContent.trim();
        var classes = getStatusClass(status);
        element.classList.add(...classes);
    });

    window.filterEmergencies = function () {
        var searchInput = document.getElementById('searchInput').value.toLowerCase();
        var statusFilter = document.getElementById('statusFilter').value;
        var departmentFilter = document.getElementById('departmentFilter').value;

        var emergencyItems = document.getElementsByClassName('emergency-item');

        for (var i = 0; i < emergencyItems.length; i++) {
            var item = emergencyItems[i];
            var description = item.getAttribute('data-description').toLowerCase();
            var location = item.getAttribute('data-location').toLowerCase();
            var status = item.getAttribute('data-status');
            var department = item.getAttribute('data-department');

            var matchesSearch = description.includes(searchInput) || location.includes(searchInput);
            var matchesStatus = statusFilter === "" || status === statusFilter;
            var matchesDepartment = departmentFilter === "" || department === departmentFilter;

            if (matchesSearch && matchesStatus && matchesDepartment) {
                item.style.display = "";
            } else {
                item.style.display = "none";
            }
        }
    };

    document.getElementById('searchInput').addEventListener('input', filterEmergencies);
    document.getElementById('statusFilter').addEventListener('change', filterEmergencies);
    document.getElementById('departmentFilter').addEventListener('change', filterEmergencies);

    // Delete function
    window.Delete = function (url) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'DELETE',
                    url: url,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(data.message);
                            location.reload();
                        } else {
                            toastr.error(data.message);
                        }
                    }
                });
            }
        });
    };
});