$(document).ready(function () {
    var endpointMapper = {
        "home_page.aspx": "homeLinkButton",
        "order_page.aspx": "orderLinkButton",
        "order_info.aspx": "orderLinkButton",
        "product_page.aspx": "productLinkButton",
        "product_info.aspx": "productLinkButton",
        "category_page.aspx": "categoryLinkButton",
        "category_info.aspx": "categoryLinkButton",
        "customer_page.aspx": "customerLinkButotn",
        "customer_info.aspx": "customerLinkButotn",
        "user_page.aspx": "userLinkButton",
        "user_info.aspx": "userLinkButton",
        "statistic_page.aspx": "statisticsLinkButton",
        "role_page.aspx": "roleLinkButton",
        "role_info.aspx": "roleLinkButton",
        "activities_log_page.aspx": "activityLogLinkButton",
        "activities_log_info.aspx": "activityLogLinkButton",
        "signin_page.aspx": "signoutLinkButton",
        "statistics_page.aspx": "statisticsLinkButton"
    };
    var path = window.location.pathname;
    var endpoint = path.substring(path.lastIndexOf('/') + 1);
    $('#sidebar a').addClass('btn-light text-secondary').removeClass('btn-primary active');
    $('#' + endpointMapper[endpoint]).removeClass('btn-light text-secondary').addClass(' btn-primary active');

    $('thead').addClass('thead-light');
});

$('table tbody tr').click(function () {
    var id = $(this).find('td:eq(2)').text();
});

$('#imageImage').on('click', function () {
    $('#imageInput').click();
});

$('#imageInput').on('change', function (e) {
    var fileInput = this;

    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.readAsDataURL(fileInput.files[0]);

        reader.onload = function (e) {
            var base64Image = e.target.result;
            $('#imageImage').attr('src', base64Image);
        };

        reader.onerror = function (error) {
            console.error("Error reading the file:", error);
        };
    }
});