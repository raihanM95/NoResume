$(document).ready(function(){
    $('.dropdown-trigger').dropdown({
        inDuration: 300,
        outDuration: 225,
        hover: true,
        belowOrigin: true,
        alignment: 'left'
    });
    $("#logoutbtn").click(function(){
        $("#logoutform").submit();
    });
});
