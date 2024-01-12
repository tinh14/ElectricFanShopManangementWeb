$(document).ready(function () {
    $('.table').DataTable({
        order: [],
        columnDefs: [{
            targets: [0, 1],
            orderable: false
        }],
        searching: false, // Disable search bar
        lengthChange: false, // Disable "Show [X] entries" dropdown
        info: false, // Hide "Showing 1 to 10 of 10 entries"
        paging: false
    });
});
        