$(document).ready(function(){
    var postLoader = $('#postLoader');
    postLoader.hide();

    $("#BioEditorForm").submit(function(e){
        e.preventDefault();
        postLoader.show();

        $.post('', $('#BioEditorForm').serialize(), function (response) {
            if(response != null || response !== "" || response !== "null"){
                M.toast({
                    html: 'Data updated Successfully',
                    classes: 'green darken-1 rounded'
                });
                $('#DevCurrentCity').text(response.currentCity);
                $('#DevShortDescription').html(response.shortDescription);
                true === response.isAvailableForJob ? $("#DevJobAvailability").text("Yes"):$("#DevJobAvailability").text("No");
            }else{
                M.toast({
                    html: 'Something went wrong !',
                    classes: 'red darken-4 rounded'
                });
            }
            postLoader.hide();
        });
    });
});