$(document).ready(function () {
    $('.table').DataTable({
        order: [],
        columnDefs: [{
            targets: [0],
            orderable: false
        }],
        searching: false,
        lengthChange: false,
        info: false,
        paging: false
    });
});
        