$(document).ready(function () {
    var endpointMapper = {
        "home.aspx": "homeLinkButton",
        "orders.aspx": "orderLinkButton",
        "grns.aspx": "GRNLinkButton",
        "products.aspx": "productLinkButton",
        "categories.aspx": "categoryLinkButton",
        "customers.aspx": "customerLinkButotn",
        "suppliers.aspx": "supplierLinkButton",
        "users.aspx": "userLinkButton",
        "statistics.aspx": "statisticsLinkButton",
        "roles.aspx": "roleLinkButton",
        "activities_log.aspx": "activityLogLinkButton",
        "operations_log.aspx": "operationLogLinkButton",
        "signin.aspx": "signoutLinkButton"
    };
    var path = window.location.pathname;
    var endpoint = path.substring(path.lastIndexOf('/') + 1);
    $('#sidebar a').addClass('btn-light text-secondary').removeClass('btn-primary active');
    $('#'+endpointMapper[endpoint]).removeClass('btn-light text-secondary').addClass(' btn-primary active');
});