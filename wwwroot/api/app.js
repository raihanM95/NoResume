var colorArray = ["#003f5c", "#2f4b7c", "#665191", "#a05195", "#d45087", "#f95d6a", "#ff7c43", "#ffa600", "#00876c", "#439880", "#69a995", "#8bbaab", "#accbc0", "#cdddd7", "#eeeeee", "#efd2d2", "#eeb7b6", "#ea9b9c", "#e57e82", "#dd6069", "#d43d51", "#004c6d", "#255e7e", "#3d708f", "#5383a1", "#6996b3", "#7faac6", "#94bed9", "#abd2ec", "#c1e7ff",
    "#003f5c", "#2f4b7c", "#665191", "#a05195", "#d45087", "#f95d6a", "#ff7c43", "#ffa600", "#00876c", "#439880", "#69a995", "#8bbaab", "#accbc0", "#cdddd7", "#eeeeee", "#efd2d2", "#eeb7b6", "#ea9b9c", "#e57e82", "#dd6069", "#d43d51", "#004c6d", "#255e7e", "#3d708f", "#5383a1", "#6996b3", "#7faac6", "#94bed9", "#abd2ec", "#c1e7ff"];

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


$(document).ready(function () {
    Chart.defaults.global.defaultFontColor = "#fff";
    var cfDIV = $("#CForcesResume");
    var gitDIV = $("#GithubResume");
    var uhDIV = $("#UHuntResume");
    cfDIV.hide();
    gitDIV.hide();
    uhDIV.hide();

    var cfPreload = $('#CForcesPreloader');
    cfPreload.hide();

    var uhuntPreload = $('#UhuntPreloader');
    uhuntPreload.hide();
    /*
    ** Initially hide div #resume
    ** Show when controller response successfully
     */
    $("#resume").hide();


    /*
    ** Initially hide preloader #intLoader
    ** Show when user post a form and hide again after result arrives
     */
    $("#intLoader").hide();


    /*
    ** On form submit, post the searched user name and
    ** Send it to /Home/Index(IFormCollection formFields)
     */

    $("#formDevUname").submit(function (e) {
        e.preventDefault();

        // Hide resume div again after a form is re-submitted
        $("#resume").fadeOut();
        // Show preloader on form post
        $("#intLoader").show();

        try {
            $.post('', $('#formDevUname').serialize(), function (response) {
                if (response === null || response === "" || response === "null") {
                    showErrorToast("Invalid Username");
                }
                else {
                    _initBioCardDev(response[0]);
                    $("#resume").fadeIn();
                    cfPreload.show();

                    var WorkingProfile = response[1];

                    // CodeForces Resume Maker
                    if (WorkingProfile.codeforcesUsername != null) {
                        cf_handle = WorkingProfile.codeforcesUsername;
                        requestToCodeForces = $.get(cf_api_url + 'user.status', { handle: cf_handle }, function (data, status) {
                            if (data.result.length < 1) {
                                showErrorToast("No Submissions on CodeForces");
                            } else {
                                CodeForcesDataProcessor(data);

                                // Set Pie Chart : VERDICT
                                var verdictDataArray = $.map(cf_verdicts, function (v) { return v; });
                                CodeForcesCreateCharts(Object.keys(cf_verdicts), verdictDataArray, 'pie', $('#verdicts_codeForces_pie'), 'Verdicts of ' + cf_handle);

                                // Set Pie Chart : Languages
                                var languageDataArray = $.map(cf_languages, function (v) { return v; });
                                CodeForcesCreateCharts(Object.keys(cf_languages), languageDataArray, 'pie', $('#languages_codeForces_pie'), 'Languages used by ' + cf_handle);

                                // Set Doughnut Chart : Tags
                                var tagsDataArray = $.map(cf_tags, function (v) { return v; });
                                CodeForcesCreateCharts(Object.keys(cf_tags), tagsDataArray, 'doughnut', $('#tags_codeForces_doughnut'), 'Tags of problems solved by ' + cf_handle);

                                // Set Bar Chart : Levels
                                cf_attempt_level_quality = sortObjects(cf_attempt_level_quality);
                                var levelsDataArray = $.map(cf_attempt_level_quality, function (v) { return v; });
                                CodeForcesCreateBarCharts(Object.keys(cf_attempt_level_quality), levelsDataArray, $('#levels_codeForces_bar'), 'Level of problems solved by ' + cf_handle);

                                // Set Bar Chart : Tags
                                var ratingsDataArray = $.map(cf_attempt_rating_quality, function (v) { return v; });
                                CodeForcesCreateBarCharts(Object.keys(cf_attempt_rating_quality), ratingsDataArray, $('#problem_rating_codeForces_bar'), 'Rating of problems solved by ' + cf_handle);

                                CodeForcesEffortSummary();
                                cfDIV.show();
                            }
                            cfPreload.hide();
                        })
                    } else {
                        cfPreload.hide();
                        cfDIV.hide();
                        showUserDefinedToast("CodeForces is Private", "indigo darken-2 rounded");
                    }

                    // UVA Resume Maker
                    uhuntPreload.show();

                    if (WorkingProfile.uhuntUsername != null) {
                        uvaHandle = WorkingProfile.uhuntUsername;
                        requestToUhunt = $.get(uva_api_url + 'uname2uid/' + uvaHandle, function (data, status) {
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

                    // GitHub Resume Maker
                    if (WorkingProfile.githubUsername != null) {

                    }
                }

                $("#intLoader").hide();
            });
        }
        catch (e) {
            showErrorToast("Invalid Username");
            $("#intLoader").hide();
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
        var value = sortedArray[i][1];
        newObject[key] = value;

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
            mainAspectRatio: false
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