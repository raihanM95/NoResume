var colorArray = ["#003f5c", "#2f4b7c", "#665191", "#a05195", "#d45087", "#f95d6a", "#ff7c43", "#ffa600", "#00876c", "#439880", "#69a995", "#8bbaab", "#accbc0", "#cdddd7", "#eeeeee", "#efd2d2", "#eeb7b6", "#ea9b9c", "#e57e82", "#dd6069", "#d43d51", "#004c6d", "#255e7e", "#3d708f", "#5383a1", "#6996b3", "#7faac6", "#94bed9", "#abd2ec", "#c1e7ff",
    "#003f5c", "#2f4b7c", "#665191", "#a05195", "#d45087", "#f95d6a", "#ff7c43", "#ffa600", "#00876c", "#439880", "#69a995", "#8bbaab", "#accbc0", "#cdddd7", "#eeeeee", "#efd2d2", "#eeb7b6", "#ea9b9c", "#e57e82", "#dd6069", "#d43d51", "#004c6d", "#255e7e", "#3d708f", "#5383a1", "#6996b3", "#7faac6", "#94bed9", "#abd2ec", "#c1e7ff"];

// CodeForces Initiative
var requestToCodeForces;
var cf_api_url = 'https://codeforces.com/api/';
var cf_handle;
var cf_problems_attempt_solved = {};
var cf_verdicts = {};
var cf_languages = {};
var cf_tags = {};
var cf_attempt_level_quality = {};
var cf_attempt_rating_quality = {};

// Uhunt Initiative
var requestToUhunt;
var requestToUhunt2;
var requestToUhunt3;
var requestToUhunt4;
var requestToUHunt5;
var requestToUHunt6;

var uva_api_url = 'https://uhunt.onlinejudge.org/api/';
var uvaHandle;
var uvaAllSubmissions = [];
var uvaVerdicts = {
    "SubmissionError": 0,
    "CantBeJudged": 0,
    "InQueue": 0,
    "CompileError": 0,
    "RestrictedFunction": 0,
    "RuntimeError": 0,
    "OutputLimit": 0,
    "TimeLimit": 0,
    "MemoryLimit": 0,
    "WrongAnswer": 0,
    "PresentationError": 0,
    "Accepted": 0
};
var uvaVerdictsAbove = {
    "SubmissionError": 0,
    "CantBeJudged": 0,
    "InQueue": 0,
    "CompileError": 0,
    "RestrictedFunction": 0,
    "RuntimeError": 0,
    "OutputLimit": 0,
    "TimeLimit": 0,
    "MemoryLimit": 0,
    "WrongAnswer": 0,
    "PresentationError": 0,
    "Accepted": 0
};
var uvaVerdictsBelow = {
    "SubmissionError": 0,
    "CantBeJudged": 0,
    "InQueue": 0,
    "CompileError": 0,
    "RestrictedFunction": 0,
    "RuntimeError": 0,
    "OutputLimit": 0,
    "TimeLimit": 0,
    "MemoryLimit": 0,
    "WrongAnswer": 0,
    "PresentationError": 0,
    "Accepted": 0
};
var rankingInfo = {
    "rankingOfQueried" : 0,
    "rankingOfAboveOfQueried" : 0,
    "rankingOfBelowOfQueried" : 0
};


var uvaLanguages = {
    "ANSI_C" : 0,
    "Java" : 0,
    "C++" : 0,
    "Pascal" : 0,
    "C++11" : 0,
    "Python" : 0
};
var uvaSubmissionRank = {};
var maxKeySubmissionRank = 0;
var minKeySubmissionRank = 0;

var regressionDataArray = [];
var uhDIVRegression;
var uhDivRegressionLoader;

// GitHub initiative
var requestToGH1;
var requestToGH2;
var requestToGH3;
var requestToGH4;
var requestToGH5;
var requestToGH6;
var requestToGH7;
var requestToGH8;

var gitHubApiURL = "https://api.github.com/users/";
var githubUsername = "";
var gitHubShortProfile = {};
var languagesOfRepositories = {};
var optimizedLanguages = {};
var pieChartGitHub;


$(document).ready(function () {
    Chart.defaults.global.defaultFontColor = "#fff";
    Chart.defaults.global.defaultFontFamily = "'Quicksand'";
    Chart.defaults.global.defaultFontSize = 16;
    Chart.defaults.global.animation.duration = 1500;
    var intLoader = $('#intLoader');

    var cfDIV = $("#CForcesResume");
    var gitDIV = $("#GithubResume");
    var uhDIV = $("#UHuntResume");
    /*
    ** Initially hide 
    ** CodeForces, UVA and GitHub divisions and their preloaders
     */
    cfDIV.hide();
    gitDIV.hide();
    uhDIV.hide();

    var cfPreload = $('#CForcesPreloader');
    cfPreload.hide();

    var uhuntPreload = $('#UhuntPreloader');
    uhuntPreload.hide();

    var ghPreload = $('#GitHubPreloader');
    ghPreload.hide();

    /* Sub-Divisions Hidden */
    uhDIVRegression = $("#_regressionAnalytics");
    uhDivRegressionLoader = $("#customLoaderRegression");
    uhDIV.hide();
    uhDIVRegression.hide();


    /*
    ** Initially hide div #resume
    ** Show when controller response successfully
     */
    $("#resume").hide();


    /*
    ** Initially hide preloader #intLoader
    ** Show when user post a form and hide again after result arrives
     */
    intLoader.hide();


    /*
    ** On form submit, post the searched user name and
    ** Send it to /Home/Index(IFormCollection formFields)
     */

    $("#formDevUname").submit(function (e) {
        e.preventDefault();

        // Hide resume div again after a form is re-submitted
        $("#resume").fadeOut();
        // Show preloader on form post
        intLoader.show();

        try {
            $.post('', $('#formDevUname').serialize(), function (response) {
                if (response === null || response === "" || response === "null") {
                    showErrorToast("Invalid Username");
                }
                else {
                    /*
                    ** Clear all previous values of CodeForces, UVA and GitHub
                    ** Actually, for resubmission of a form for cleaning of dump data 
                     */
                    _initClearDumpValuesUVA();
                    _initClearDumpValuesCF();
                    _initClearDumpGH();

                    /**
                     ** Initiate the biography card
                     ** passing the JSONResult coming from /Home/Index
                     ** Effects : fade in and fade out
                     */
                    _initBioCardDev(response[0]);
                    $("#resume").fadeIn();

                    /*
                    ** When biography card is being loaded,
                    ** Start showing the CodeForces Preloader
                     */
                    cfPreload.show();
                    /*
                    ** WorkingProfile Contains
                    ** Username of : CodeForces, UVA and GitHub coming from /Home/Index
                    ** Privacy has been checked before passing from controller
                     */
                    var WorkingProfile = response[1];

                    /*
                    ** CodeForces Resume Maker starts
                    ** working based on codeForces username
                    */
                    
                    if (WorkingProfile.codeforcesUsername != null) {
                        cf_handle = WorkingProfile.codeforcesUsername;
                        requestToCodeForces = $.get(cf_api_url + 'user.status', { handle: cf_handle }, function (data, status) {
                            if (data.result.length < 1) {
                                showErrorToast("No Submissions on CodeForces");
                            } else {
                                CodeForcesDataProcessor(data);

                                // Set Pie Chart : VERDICT
                                var verdictDataArray = $.map(cf_verdicts, function (v) { return v; });
                                CodeForcesCreateCharts(Object.keys(cf_verdicts), verdictDataArray, 'pie', $('#verdicts_codeForces_pie'), '');

                                // Set Pie Chart : Languages
                                var languageDataArray = $.map(cf_languages, function (v) { return v; });
                                CodeForcesCreateCharts(Object.keys(cf_languages), languageDataArray, 'pie', $('#languages_codeForces_pie'), '');

                                // Set Doughnut Chart : Tags
                                var tagsDataArray = $.map(cf_tags, function (v) { return v; });
                                CodeForcesCreateCharts(Object.keys(cf_tags), tagsDataArray, 'doughnut', $('#tags_codeForces_doughnut'), '');

                                // Set Bar Chart : Levels
                                cf_attempt_level_quality = sortObjects(cf_attempt_level_quality);
                                var levelsDataArray = $.map(cf_attempt_level_quality, function (v) { return v; });
                                CodeForcesCreateBarCharts(Object.keys(cf_attempt_level_quality), levelsDataArray, $('#levels_codeForces_bar'), 'Levels of ' + cf_handle);

                                // Set Bar Chart : Tags
                                var ratingsDataArray = $.map(cf_attempt_rating_quality, function (v) { return v; });
                                CodeForcesCreateBarCharts(Object.keys(cf_attempt_rating_quality), ratingsDataArray, $('#problem_rating_codeForces_bar'), 'Ratings of ' + cf_handle);

                                CodeForcesEffortSummary();
                                cfDIV.show();
                            }
                            cfPreload.hide();
                        })
                    } else {
                        /*
                        ** This works when CodeForces username is being returned null from controller
                        ** Possible reason : User removed or, never provided/User made it private
                         */
                        cfPreload.hide();
                        cfDIV.hide();
                        showUserDefinedToast("CodeForces is Private", "indigo darken-2 rounded");
                    }

                    /*
                    ** When CodeForces Resume Maker Is Ready
                    ** Start showing UVA preloader
                     */
                    uhuntPreload.show();

                    if (WorkingProfile.uhuntUsername != null) {
                        uvaHandle = WorkingProfile.uhuntUsername;
                        requestToUhunt = $.get(uva_api_url + 'uname2uid/' + uvaHandle, function (data, status) {
                            /*
                            ** UVA username needs to be converted to user id first
                            ** If UVA returns 0, that means the username is invalid
                             */
                            if (data === 0) {
                                showErrorToast("Invalid Username");
                            } else {
                                requestToUhunt2 = $.get(uva_api_url + 'subs-user/' + data, function (Submission, SubmissionStatus) {
                                    uvaAllSubmissions = Submission.subs;

                                    // Check number of submissions
                                    if (uvaAllSubmissions.length < 1) {
                                        showErrorToast("Sorry, No Submission on UVA");
                                    } else {
                                        console.log(uvaAllSubmissions);
                                        UvaSubmissionProcessor(uvaAllSubmissions);

                                        // Regression
                                        requestToUhunt3 = $.get(uva_api_url + 'ranklist/' + data + '/1/1', function (ranksInfo, StatusRank) {
                                            requestToUhunt4 = $.get(uva_api_url + 'subs-user/' + ranksInfo[0].userid, function (SubmissionAbove, StatusAbove) {
                                                UvaAboveSubmissionProcessor(SubmissionAbove.subs);
                                            });
                                            requestToUHunt5 = $.get(uva_api_url + 'subs-user/' + ranksInfo[2].userid, function (SubmissionBelow, StatusBelow) {
                                                UvaBelowSubmissionProcessor(SubmissionBelow.subs);
                                                UVARankingProcessor(ranksInfo);

                                                // Regression
                                                uhDivRegressionLoader.show();
                                                regressionDatasetTableConstructor();

                                            });
                                        });

                                        uhDIV.show();
                                        wordCounter();
                                    }
                                });
                            }
                        });
                        uhuntPreload.hide();
                    } else {
                        uhuntPreload.hide();
                        uhDIV.hide();
                        showUserDefinedToast("UVA is Private", "amber darken-2 rounded");
                    }


                    /*
                    ** When UVA Resume Maker Is Ready
                    ** Start showing GitHUb preloader
                     */
                    ghPreload.show();


                    // GitHub Resume Maker
                    if (WorkingProfile.githubUsername != null) {
                        githubUsername = WorkingProfile.githubUsername;
                        requestToGH1 = $.get(gitHubApiURL + githubUsername, function (userInformation, userStatus) {
                            if(userStatus === "success"){
                                gitHubShortProfile = userInformation;

                                // Card Initiator
                                $("#_githubAvatar").attr("src",gitHubShortProfile.avatar_url);
                                $("#_githubDevName").text(gitHubShortProfile.name);
                                if(gitHubShortProfile.location === null || gitHubShortProfile.location === ""){
                                    $("#_githubDevLocation").text("CodeStaGram");
                                }else{
                                    $("#_githubDevLocation").text(gitHubShortProfile.location);
                                }

                                if(gitHubShortProfile.bio === null || gitHubShortProfile.bio === ""){
                                    $("#_githubDevBio").text("Hey, there. I am focusing on coding </>");
                                }else{
                                    $("#_githubDevBio").text(gitHubShortProfile.bio);
                                }

                                $('#_githubDevFollowers').text(gitHubShortProfile.followers);
                                $('#_githubDevFollowing').text(gitHubShortProfile.following);
                                $("#_gitHubDevURL").attr("href", gitHubShortProfile.html_url);
                                if(gitHubShortProfile.blog === null || gitHubShortProfile.blog === ""){
                                    $("#_gitHubDevPortfolioLink").attr("href", "");
                                }else{
                                    $("#_gitHubDevPortfolioLink").attr("href", gitHubShortProfile.blog);
                                }

                                $('#_githubDevPublicRepos').text(gitHubShortProfile.public_repos);
                                $('#_githubDevPublicGists').text(gitHubShortProfile.public_gists);

                                $('#_githubDevAccCreated').text(days_between(new Date(gitHubShortProfile.created_at), new Date()) + ' Days ago');
                                $('#_githubDevLastActive').text(days_between(new Date(gitHubShortProfile.updated_at), new Date()) + ' Days ago');

                                // Card Initiator End

                                // Repository Findings
                                requestToGH2 = $.get(gitHubApiURL + githubUsername + '/repos?page=1&per_page=10&sort=updated', function (repositories, status) {
                                    if(repositories.length < 1){
                                        showUserDefinedToast('Sorry, No Repositories on GitHub', "pink darken-2 rounded");
                                    }else{
                                        _initiateLanguages(repositories);
                                    }
                                });
                                gitDIV.show();
                            }else{
                                showUserDefinedToast("Failed to retrieve GitHub data", "red darken-1 rounded");
                            }
                        });
                        ghPreload.hide();
                    }else{
                        ghPreload.hide();
                        gitDIV.hide();
                        showUserDefinedToast("GitHub is Private", "amber darken-2 rounded");
                    }
                }

                intLoader.hide();
                $.when($('#_description').fadeOut(800))
                .then(function(){
                    scrollToResumeDivision();
                });
            });
        }
        catch (e) {
            showErrorToast("Invalid Username");
            intLoader.hide();
        }
    });
});

function sortProperties(obj) {
    // convert object into array
    var sortable = [];
    for (var key in obj)
        if (obj.hasOwnProperty(key))
            sortable.push([key, obj[key]]); // each item is an array in format [key, value]

    // sort items by value
    sortable.sort(function (a, b) {
        return a[1] - b[1]; // compare numbers
    });
    return sortable; // array in format [ [ key1, val1 ], [ key2, val2 ], ... ]
}

function sortObjects(objects) {
    var newObject = {};

    var sortedArray = sortProperties(objects);
    for (var i = 0; i < sortedArray.length; i++) {
        var key = sortedArray[i][0];
        newObject[key] = sortedArray[i][1];
    }
    return newObject;
}

function sortPropertiesByAsc(obj) {
    // convert object into array
    var sortable = [];
    for (var key in obj)
        if (obj.hasOwnProperty(key))
            sortable.push([key, obj[key]]); // each item is an array in format [key, value]

    // sort items by value
    sortable.sort(function (a, b) {
        return b[1] - a[1];
    });
    return sortable;
}

function sortObjectsByAsc(objects) {
    var newObject = {};

    var sortedArray = sortPropertiesByAsc(objects);
    for (var i = 0; i < sortedArray.length; i++) {
        var key = sortedArray[i][0];
        newObject[key] = sortedArray[i][1];
    }
    return newObject;
}


function UvaSubmissionProcessor(data) {
    for (var i = 0; i < data.length; i++) {
        incrementVerdict(data[i][2]);
        incrementLanguages(data[i][5]);
        submissionRank(data[i][6]);
    }
    $('#_uvaTotalSubmissions').text(data.length);
    $('#_uvaAcceptedSubmissionNumber').text(uvaVerdicts["Accepted"]);
    $('#_uvaTotalWrongSubmissions').text(uvaVerdicts["WrongAnswer"]);
}

function incrementVerdict(verdictNumber) {
    if (verdictNumber === 10) { uvaVerdicts["SubmissionError"]++; }
    if (verdictNumber === 15) { uvaVerdicts["CantBeJudged"]++; }
    if (verdictNumber === 20) { uvaVerdicts["InQueue"]++; }
    if (verdictNumber === 30) { uvaVerdicts["CompileError"]++; }
    if (verdictNumber === 35) { uvaVerdicts["RestrictedFunction"]++; }
    if (verdictNumber === 40) { uvaVerdicts["RuntimeError"]++; }
    if (verdictNumber === 45) { uvaVerdicts["OutputLimit"]++; }
    if (verdictNumber === 50) { uvaVerdicts["TimeLimit"]++; }
    if (verdictNumber === 60) { uvaVerdicts["MemoryLimit"]++; }
    if (verdictNumber === 70) { uvaVerdicts["WrongAnswer"]++; }
    if (verdictNumber === 80) { uvaVerdicts["PresentationError"]++; }
    if (verdictNumber === 90) { uvaVerdicts["Accepted"]++; }
}


// Rank Superior Profile
function UVARankingProcessor(ranksInfo) {
    rankingInfo["rankingOfAboveOfQueried"] = ranksInfo[0].rank;
    rankingInfo["rankingOfQueried"] = ranksInfo[1].rank;
    rankingInfo["rankingOfBelowOfQueried"] = ranksInfo[2].rank;
    regressionDataConstructor(ranksInfo);
}

function regressionDataConstructor(ranksInfo){
    regressionDataArray.push({
        "name" : ranksInfo[0].name,
        "ranking" : ranksInfo[0].rank,
        "verdict" : uvaVerdictsAbove
    });
    regressionDataArray.push({
        "name" : ranksInfo[1].name,
        "ranking" : ranksInfo[1].rank,
        "verdict" : uvaVerdicts
    });
    regressionDataArray.push({
        "name" : ranksInfo[2].name,
        "ranking" : ranksInfo[2].rank,
        "verdict" : uvaVerdictsBelow
    });
}

function regressionDatasetTableConstructor(){
    // Regression Table Construction
    var _aboveRow = document.getElementById("_rankAboveRow");
    var _subjectRow = document.getElementById("_subjectRow");
    var _belowRow = document.getElementById("_rankBelowRow");
    _aboveRow.innerHTML = ''; _subjectRow.innerHTML = ''; _belowRow.innerHTML = '';

    var x = _aboveRow.insertCell(0);
    x.innerHTML = regressionDataArray[0].name;
    x = _aboveRow.insertCell(1);
    x.innerHTML = regressionDataArray[0].ranking;

    x= _subjectRow.insertCell(0);
    x.innerHTML = regressionDataArray[1].name;
    x = _subjectRow.insertCell(1);
    x.innerHTML = regressionDataArray[1].ranking;

    x= _belowRow.insertCell(0);
    x.innerHTML = regressionDataArray[2].name;
    x = _belowRow.insertCell(1);
    x.innerHTML = regressionDataArray[2].ranking;

    for(var i=0; i<regressionDataArray.length; i++){
        var tempVerdictArray = $.map(regressionDataArray[i].verdict, function (v) { return v; });
        for(var j=0; j<tempVerdictArray.length; j++){
            if(i === 0){
                x = _aboveRow.insertCell(j+2);
                x.innerHTML = tempVerdictArray[j];
            }
            if(i === 1){
                x = _subjectRow.insertCell(j+2);
                x.innerHTML = tempVerdictArray[j];
            }
            if(i === 2){
                x = _belowRow.insertCell(j+2);
                x.innerHTML = tempVerdictArray[j];
            }
        }
    }
    uhDivRegressionLoader.hide();
    uhDIVRegression.show();
}

function UvaAboveSubmissionProcessor(data) {
    for (var i = 0; i < data.length; i++) {
        incrementAboveVerdict(data[i][2]);
    }
}

function incrementAboveVerdict(verdictNumber) {
    if (verdictNumber === 10) { uvaVerdictsAbove["SubmissionError"]++; }
    if (verdictNumber === 15) { uvaVerdictsAbove["CantBeJudged"]++; }
    if (verdictNumber === 20) { uvaVerdictsAbove["InQueue"]++; }
    if (verdictNumber === 30) { uvaVerdictsAbove["CompileError"]++; }
    if (verdictNumber === 35) { uvaVerdictsAbove["RestrictedFunction"]++; }
    if (verdictNumber === 40) { uvaVerdictsAbove["RuntimeError"]++; }
    if (verdictNumber === 45) { uvaVerdictsAbove["OutputLimit"]++; }
    if (verdictNumber === 50) { uvaVerdictsAbove["TimeLimit"]++; }
    if (verdictNumber === 60) { uvaVerdictsAbove["MemoryLimit"]++; }
    if (verdictNumber === 70) { uvaVerdictsAbove["WrongAnswer"]++; }
    if (verdictNumber === 80) { uvaVerdictsAbove["PresentationError"]++; }
    if (verdictNumber === 90) { uvaVerdictsAbove["Accepted"]++; }
}

// Rank Inferior Profile
function UvaBelowSubmissionProcessor(data) {
    for (var i = 0; i < data.length; i++) {
        incrementBelowVerdict(data[i][2]);
    }
}

function incrementBelowVerdict(verdictNumber) {
    if (verdictNumber === 10) { uvaVerdictsBelow["SubmissionError"]++; }
    if (verdictNumber === 15) { uvaVerdictsBelow["CantBeJudged"]++; }
    if (verdictNumber === 20) { uvaVerdictsBelow["InQueue"]++; }
    if (verdictNumber === 30) { uvaVerdictsBelow["CompileError"]++; }
    if (verdictNumber === 35) { uvaVerdictsBelow["RestrictedFunction"]++; }
    if (verdictNumber === 40) { uvaVerdictsBelow["RuntimeError"]++; }
    if (verdictNumber === 45) { uvaVerdictsBelow["OutputLimit"]++; }
    if (verdictNumber === 50) { uvaVerdictsBelow["TimeLimit"]++; }
    if (verdictNumber === 60) { uvaVerdictsBelow["MemoryLimit"]++; }
    if (verdictNumber === 70) { uvaVerdictsBelow["WrongAnswer"]++; }
    if (verdictNumber === 80) { uvaVerdictsBelow["PresentationError"]++; }
    if (verdictNumber === 90) { uvaVerdictsBelow["Accepted"]++; }
}


function incrementLanguages(languageNumber) {
    if (languageNumber === 1) { uvaLanguages["ANSI_C"]++; }
    else if (languageNumber === 2) { uvaLanguages["Java"]++; }
    else if (languageNumber === 3) { uvaLanguages["C++"]++; }
    else if (languageNumber === 4) { uvaLanguages["Pascal"]++; }
    else if (languageNumber === 5) { uvaLanguages["C++11"]++; }
    else { uvaLanguages["Python"]++; }
}

function submissionRank(rankNumber) {
    if(uvaSubmissionRank[rankNumber] === undefined){
        uvaSubmissionRank[rankNumber] = 1;
    }else{
        uvaSubmissionRank[rankNumber] += 1;
    }

    if(rankNumber > maxKeySubmissionRank){
        maxKeySubmissionRank = rankNumber;
    }
    if(rankNumber <minKeySubmissionRank){
        minKeySubmissionRank = rankNumber;
    }
}

// GitHub

function _initiateLanguages(repositories) {
    for (var i = 0; i <repositories.length; i++) {
        requestToGH3 = $.get(repositories[i].languages_url, function (languages, status) {
            var tempKeys = Object.keys(languages);

            for(var k=0; k<tempKeys.length; k++){
                if(languagesOfRepositories[tempKeys[k]] === undefined){
                    languagesOfRepositories[tempKeys[k]] = languages[tempKeys[k]];
                }else{
                    languagesOfRepositories[tempKeys[k]] += languages[tempKeys[k]];
                }

                if(k === tempKeys.length - 1){
                    if(pieChartGitHub != null){
                        pieChartGitHub.destroy();
                    }
                    _demonstrateLanguagesGitHub($('#languages_github'), 'doughnut', '');
                }
            }
        });
    }
}

function _demonstrateLanguagesGitHub(gitHubLanguageChart, chartType, titleText) {
    var tempLang = {};
    tempLang = sortObjectsByAsc(languagesOfRepositories);

    pieChartGitHub = new Chart(gitHubLanguageChart, {
        type: chartType,
        data: {
            labels: Object.keys(tempLang),
            datasets: [{
                label: 'Value',
                data: $.map(tempLang, function (v) { return v; }),
                backgroundColor: colorArray,
                borderColor: colorArray,
                borderWidth: 1
            }]
        },
        options: {
            title: {
                display: true,
                text: titleText,
                fontSize: 25
            },
            responsive: true,
            responsiveAnimationDuration: 500,
            mainAspectRatio: false
        }
    });
}


// CodeForces
function CodeForcesDataProcessor(data) {

    for (var i = data.result.length - 1; i >= 0; i--) {
        var submission = data.result[i];

        /*
        ** #problemId : Concatenates contestId (1110) and submissionID (A)
        ** Example    : 1110-A
        **
        ** cf_problems_attempt_solved[problemId] is checked firstly if it is defined or, not
        ** if cf_problems_attempt_solved[problemId] is not defined then attempt is set to 1
        ** and solved is set to 0
        **
        ** else it will be counting till the problem is solved
        ** the goal is to count how many attempts was taken before solved 
        */
        var problemId = submission.problem.contestId + '-' + submission.problem.index;

        if (cf_problems_attempt_solved[problemId] === undefined) {
            cf_problems_attempt_solved[problemId] = {
                attempts: 1,
                solved: 0
            };
        } else {
            if (cf_problems_attempt_solved[problemId].solved === 0) {
                cf_problems_attempt_solved[problemId].attempts++;
            }
        }

        /*
        ** #VERDICTS COUNTER
        ** 
        ** Counting number of each type of verdicts 
        ** Example: OK , COMPILATION_ERROR , MEMORY_LIMIT_EXCEEDED
         */
        if (cf_verdicts[submission.verdict] === undefined) {
            cf_verdicts[submission.verdict] = 1;
        } else {
            cf_verdicts[submission.verdict]++;
        }

        /*
        ** #Language COUNTER 
        * 
        ** Counting number of each type of languages
        ** Example: C++, Java, Kotlin
        */
        if (cf_languages[submission.programmingLanguage] === undefined) {
            cf_languages[submission.programmingLanguage] = 1;
        } else {
            cf_languages[submission.programmingLanguage]++;
        }


        /*
        ** #Counting Solved : HOW_MANY_WAYS
        ** It means number of times a problem is solved according to VERDICT == OK
        ** 
        ** It will increment cf_problems_attempt_solved[problemID].solved
        */
        if (submission.verdict === 'OK') {
            cf_problems_attempt_solved[problemId].solved++;
        }

        // Counting Tags, levels, Problem Rating at MIN[SOLVED]
        if (submission.verdict === 'OK' && cf_problems_attempt_solved[problemId].solved === 1) {
            /*
            ** Counting Tags
            ** solved is counted @@1 because
            ** if someone solves a problem so many times then we can take only one tag
            **/
            submission.problem.tags.forEach(function (currentValue) {
                if (cf_tags[currentValue] === undefined) {
                    cf_tags[currentValue] = 1;
                } else {
                    cf_tags[currentValue]++;
                }
            });

            // Level of quality problems being tried : A, B, B1 
            if (cf_attempt_level_quality[submission.problem.index] === undefined) {
                cf_attempt_level_quality[submission.problem.index] = 1;
            } else {
                cf_attempt_level_quality[submission.problem.index]++;
            }

            // Level of rating of problems being tried : 2100, 1500
            if (cf_attempt_rating_quality[submission.problem.rating] === undefined) {
                cf_attempt_rating_quality[submission.problem.rating] = 1;
            } else {
                cf_attempt_rating_quality[submission.problem.rating]++;
            }
            delete cf_attempt_rating_quality.undefined;

        }

    }
    // console.log(cf_problems_attempt_solved);
    // console.log(cf_verdicts);
    // console.log(cf_languages);
    // console.log(cf_problems_attempt_solved);
    // console.log(cf_tags);
    // console.log(cf_attempt_level_quality);
    // console.log(cf_attempt_rating_quality);
}

function CodeForcesCreateCharts(keys, dataArray, chartType, context, titleText) {
    var pieChart = new Chart(context, {
        type: chartType,
        data: {
            labels: keys,
            datasets: [{
                label: 'Value',
                data: dataArray,
                backgroundColor: colorArray,
                borderColor: colorArray,
                borderWidth: 1
            }]
        },
        options: {
            title: {
                display: true,
                text: titleText,
                fontSize: 25
            },
            responsive: true,
            responsiveAnimationDuration: 500,
            mainAspectRatio: false,
            legend: {
                display: false
            }
        }
    });
}

function CodeForcesCreateBarCharts(keys, dataArray, context, titleText) {
    var myChart = new Chart(context, {
        type: 'bar',
        data: {
            labels: keys,
            datasets: [{
                label: titleText,
                data: dataArray,
                backgroundColor: colorArray,
                borderColor: colorArray,
                borderWidth: 1
            }]
        },
        options: {
            title: {
                display: false,
                text: titleText,
                fontSize: 25
            },
            legend: {
                display : false
            },
            responsive: true,
            responsiveAnimationDuration: 500,
            scales: {
                xAxes: [{
                    ticks: {
                        maxRotation: 90,
                        minRotation: 80
                    }
                }],
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function CodeForcesEffortSummary() {
    var numberOfProblemsTried = 0;
    var numberOfProblemsSolved = 0;

    var maximumAttemptsBeforeSolvingAProblem = 0;
    var maximumProblemBeenAttempted = '';

    var OneSubmissionTry = 0;
    var problemsThatAreNotSolved = [];

    var maximumNumberAProblemAccepted = 0;
    var maximumAcceptedProblemInfo = '';

    for (var submissions in cf_problems_attempt_solved) {

        // For Each Submission : numberOfTimesTried increments to 1 
        numberOfProblemsTried += 1;

        // For Each Submission : count total number of problems been solved
        if (cf_problems_attempt_solved[submissions].solved > 0) {
            numberOfProblemsSolved += 1;
        }

        // Count Max Attempt Comparing With Each Attempt
        if (cf_problems_attempt_solved[submissions].attempts > maximumAttemptsBeforeSolvingAProblem) {
            maximumAttemptsBeforeSolvingAProblem = cf_problems_attempt_solved[submissions].attempts;
            maximumProblemBeenAttempted = submissions;
        }

        // Count Max Accepted Comparing With Each Solved
        if (cf_problems_attempt_solved[submissions].solved > maximumNumberAProblemAccepted) {
            maximumNumberAProblemAccepted = cf_problems_attempt_solved[submissions].solved;
            maximumAcceptedProblemInfo = submissions;
        }

        // One Submission Solved
        if (cf_problems_attempt_solved[submissions].solved === 1 && cf_problems_attempt_solved[submissions].attempts === 1) {
            OneSubmissionTry += 1;
        }
    }

    /*console.log(cf_problems_attempt_solved);
    console.log(numberOfProblemsTried);
    console.log(numberOfProblemsSolved);
    console.log(maximumAttemptsBeforeSolvingAProblem);
    console.log(maximumProblemBeenAttempted);
    console.log(maximumNumberAProblemAccepted);
    console.log(maximumAcceptedProblemInfo);
    console.log(OneSubmissionTry);*/
    $('#DevTriedProblems').text(numberOfProblemsTried);
    $('#DevSolvedProblems').text(numberOfProblemsSolved);
    $('#DevMaxAttemptedProblems').text(maximumAttemptsBeforeSolvingAProblem + "(" + maximumProblemBeenAttempted + ")");
    $('#DevMaxAcceptedProblems').text(maximumNumberAProblemAccepted + "(" + maximumAcceptedProblemInfo + ")");
    $('#DevAcceptedAtFirstTry').text(OneSubmissionTry);
}

function _initBioCardDev(response) {
    var _DevUsername = $('#_DeveloperName');
    var _DevCurrentCity = "";
    "" !== response.currentCity ? _DevCurrentCity = response.currentCity : _DevCurrentCity = "CodeStagram";
    _DevUsername.text(toTitleCase($('#developerUsername').val()) + "(" + _DevCurrentCity + ")");

    if (response.shortDescription !== "") {
        $('#_DeveloperDescription').html(response.shortDescription);
    } else {
        $('#_DeveloperDescription').html("Hey, there. I am focusing on Programming !");
    }

    if (response.isAvailableForJob) {
        $('#_DeveloperJobConfirmation').text("Available");
    } else {
        $('#_DeveloperJobConfirmation').text("Not Available");
    }
}

function showErrorToast(message) {
    M.toast({
        html: message,
        classes: 'red darken-1 rounded'
    });
}

function showUserDefinedToast(message, style) {
    M.toast({
        html: message,
        classes: style
    });
}

function toTitleCase(str) {
    return str.replace(
        /\w\S*/g,
        function (txt) {
            return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
        }
    );
}

function wordCounter(){
    $('.count').each(function () {
        $(this).prop('Counter',0).animate({
            Counter: $(this).text()
        }, {
            duration: 8000,
            easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now));
            }
        });
    });
}

function _initClearDumpValuesUVA(){
    uvaAllSubmissions = [];
    uvaVerdicts = {
        "SubmissionError": 0,
        "CantBeJudged": 0,
        "InQueue": 0,
        "CompileError": 0,
        "RestrictedFunction": 0,
        "RuntimeError": 0,
        "OutputLimit": 0,
        "TimeLimit": 0,
        "MemoryLimit": 0,
        "WrongAnswer": 0,
        "PresentationError": 0,
        "Accepted": 0
    };
    uvaVerdictsAbove = {
        "SubmissionError": 0,
        "CantBeJudged": 0,
        "InQueue": 0,
        "CompileError": 0,
        "RestrictedFunction": 0,
        "RuntimeError": 0,
        "OutputLimit": 0,
        "TimeLimit": 0,
        "MemoryLimit": 0,
        "WrongAnswer": 0,
        "PresentationError": 0,
        "Accepted": 0
    };
    uvaVerdictsBelow = {
        "SubmissionError": 0,
        "CantBeJudged": 0,
        "InQueue": 0,
        "CompileError": 0,
        "RestrictedFunction": 0,
        "RuntimeError": 0,
        "OutputLimit": 0,
        "TimeLimit": 0,
        "MemoryLimit": 0,
        "WrongAnswer": 0,
        "PresentationError": 0,
        "Accepted": 0
    };
    rankingInfo = {
        "rankingOfQueried" : 0,
        "rankingOfAboveOfQueried" : 0,
        "rankingOfBelowOfQueried" : 0
    };
    uvaLanguages = {
        "ANSI_C" : 0,
        "Java" : 0,
        "C++" : 0,
        "Pascal" : 0,
        "C++11" : 0,
        "Python" : 0
    };
    uvaSubmissionRank = {};
    maxKeySubmissionRank = 0;
    minKeySubmissionRank = 0;
    regressionDataArray = [];
}

function _initClearDumpValuesCF(){
    cf_problems_attempt_solved = {};
    cf_verdicts = {};
    cf_languages = {};
    cf_tags = {};
    cf_attempt_level_quality = {};
    cf_attempt_rating_quality = {};
}

function _initClearDumpGH(){
    gitHubApiURL = "https://api.github.com/users/";
    githubUsername = "";
    gitHubShortProfile = {};
    languagesOfRepositories = {};
    optimizedLanguages = {};
}

function days_between(date1, date2) {

    // The number of milliseconds in one day
    var ONE_DAY = 1000 * 60 * 60 * 24;

    // Convert both dates to milliseconds
    var date1_ms = date1.getTime();
    var date2_ms = date2.getTime();

    // Calculate the difference in milliseconds
    var difference_ms = Math.abs(date1_ms - date2_ms);

    // Convert back to days and return
    return Math.round(difference_ms/ONE_DAY);

}

function scrollToResumeDivision(){
    $('html, body').animate({
        scrollTop: $("#resume").offset().top
    }, 1300);
}