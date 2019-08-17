$(document).ready(function(){
    var loaderIntermediate = $('#postLoader');
    loaderIntermediate.hide();
    
    $("#formWorkingProfile").submit(function(e){
        loaderIntermediate.show();
        e.preventDefault();
        
        var isGithubPermissible = false;
        var isCFPermissible = false;

        var gitUna = $('#GithubUsername').val();
        var cfUna = $('#CodeforcesUsername').val();

        $.ajaxSetup({
            async: false
        });

        if(gitUna.trim() === ""){
            isGithubPermissible = true;
        }else{
            $.ajax({
                url: "https://api.github.com/users/"+$('#GithubUsername').val(),
                async: false,
                dataType: 'json',
                success: function(json, textStatus, xhr){
                    if(xhr.status === 200){
                        isGithubPermissible = true;
                    }
                }
            });
        }

        if(cfUna.trim() === ""){
            isCFPermissible = true;
        }else{
            $.ajax({
                url: "https://codeforces.com/api/user.info?handles="+$('#CodeforcesUsername').val(),
                async: false,
                dataType: 'json',
                success: function(json){
                    if(json.status === "OK"){
                        isCFPermissible = true;
                    }
                }
            });
        }
        
        if(isGithubPermissible === false || isCFPermissible === false){
            M.toast({
                html: 'Invalid Username',
                classes: 'red darken-1 rounded'
            });
            loaderIntermediate.hide();
        }else{
            $.post('', $('#formWorkingProfile').serialize(), function (response) {
                if(response != null || response !== "" || response !== "null"){
                    M.toast({
                        html: 'Data updated Successfully',
                        classes: 'green darken-1 rounded'
                    });
                }else{
                    M.toast({
                        html: 'Something went wrong !',
                        classes: 'red darken-4 rounded'
                    });
                }
            });
            loaderIntermediate.hide();
        }
    });
});