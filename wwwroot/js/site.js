var auditData = {};
$(document).ready(function(){
    // Initiating Materialize Features
    $('.tooltipped').tooltip();
    $('.sidenav').sidenav();

    var request = $.getJSON('http://www.geoplugin.net/json.gp', function (responseData, status) {
        auditData = {
            AuditDescription : "/Home/Index",
            IsExceptionThrown : false,
            DeveloperOrAnonymous : "Anonymous",
            TimeOfAction : new Date().getDate(),
            InternetProtocol : responseData.geoplugin_request,
            Country : responseData.geoplugin_countryName,
            CountryCode : responseData.geoplugin_countryCode,
            Latitude : responseData.geoplugin_latitude,
            Longitude : responseData.geoplugin_longitude
        };

        $.post('Home/Audit', { jObject: auditData }, function (responseData) {
            var auditMessage = $('#_auditMessage');
            auditMessage.html("<i class=\"fa fa-map-marker orange-text\" aria-hidden=\"true\"></i> "+responseData[responseData.length -1].country 
            + ' : Total visited :' + responseData.length);
        }, "json");
    });
});
