#pragma checksum "/home/shunjid/Documents/WebApps/DotnetCore/NoResume/Views/Shared/_initHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "078e0152187716c0bf9fcba8beba7bd2a4e29aa0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__initHome), @"mvc.1.0.view", @"/Views/Shared/_initHome.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_initHome.cshtml", typeof(AspNetCore.Views_Shared__initHome))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/shunjid/Documents/WebApps/DotnetCore/NoResume/Views/_ViewImports.cshtml"
using NoResume;

#line default
#line hidden
#line 2 "/home/shunjid/Documents/WebApps/DotnetCore/NoResume/Views/_ViewImports.cshtml"
using NoResume.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"078e0152187716c0bf9fcba8beba7bd2a4e29aa0", @"/Views/Shared/_initHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30811eb6fdc7e219bf37d0f73ea0aeaac307f593", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__initHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/chartjs/chart.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 17600, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "078e0152187716c0bf9fcba8beba7bd2a4e29aa03955", async() => {
                BeginContext(35, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(40, 72, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "078e0152187716c0bf9fcba8beba7bd2a4e29aa04338", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 2 "/home/shunjid/Documents/WebApps/DotnetCore/NoResume/Views/Shared/_initHome.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(112, 10280, true);
                WriteLiteral(@"
    
    <script type=""text/javascript"">
    var colorArray=[""#003f5c"",""#2f4b7c"",""#665191"",""#a05195"",""#d45087"",""#f95d6a"",""#ff7c43"",""#ffa600"",""#00876c"",""#439880"",""#69a995"",""#8bbaab"",""#accbc0"",""#cdddd7"",""#eeeeee"",""#efd2d2"",""#eeb7b6"",""#ea9b9c"",""#e57e82"",""#dd6069"",""#d43d51"",""#004c6d"",""#255e7e"",""#3d708f"",""#5383a1"",""#6996b3"",""#7faac6"",""#94bed9"",""#abd2ec"",""#c1e7ff"",
    ""#003f5c"",""#2f4b7c"",""#665191"",""#a05195"",""#d45087"",""#f95d6a"",""#ff7c43"",""#ffa600"",""#00876c"",""#439880"",""#69a995"",""#8bbaab"",""#accbc0"",""#cdddd7"",""#eeeeee"",""#efd2d2"",""#eeb7b6"",""#ea9b9c"",""#e57e82"",""#dd6069"",""#d43d51"",""#004c6d"",""#255e7e"",""#3d708f"",""#5383a1"",""#6996b3"",""#7faac6"",""#94bed9"",""#abd2ec"",""#c1e7ff""];
    
    var requestToCodeForces;
    var cf_api_url = 'https://codeforces.com/api/';
    var cf_handle;
    var cf_problems_attempt_solved = {};
    var cf_verdicts = {};
    var cf_languages = {};
    var cf_tags = {};
    var cf_attempt_level_quality = {};
    var cf_attempt_rating_quality = {};
    
    
        $(document).ready(function(){
       ");
                WriteLiteral(@"     var cfDIV = $(""#CForcesResume"");
            var gitDIV = $(""#GithubResume"");
            var uhDIV = $(""#UHuntResume"");
            cfDIV.hide();
            gitDIV.hide();
            uhDIV.hide();
            
            var cfPreload = $('#CForcesPreloader');
            cfPreload.hide();
            /*
            ** Initially hide div #resume
            ** Show when controller response successfully
             */
            $(""#resume"").hide();
            
            
            /*
            ** Initially hide preloader #intLoader
            ** Show when user post a form and hide again after result arrives
             */
            $(""#intLoader"").hide();
            
            
            /*
            ** On form submit, post the searched user name and
            ** Send it to /Home/Index(IFormCollection formFields)
             */
            
            $(""#formDevUname"").submit(function(e){
                e.preventDefault();
                
                // Hide resume div ");
                WriteLiteral(@"again after a form is re-submitted
                $(""#resume"").fadeOut();
                // Show preloader on form post
                $(""#intLoader"").show();
                
                try {
                    $.post('', $('#formDevUname').serialize(), function (response) {
                        if(response === null || response === """" || response === ""null""){
                            showErrorToast(""Invalid Username"");
                        }
                        else{
                         _initBioCardDev(response[0]);
                          $(""#resume"").fadeIn();
                          cfPreload.show();
                          
                          var WorkingProfile = response[1];
                          
                          // CodeForces Resume Maker
                          if(WorkingProfile.codeforcesUsername != null){
                              cf_handle = WorkingProfile.codeforcesUsername;
                              requestToCodeForces = $.get(cf_api");
                WriteLiteral(@"_url + 'user.status', { handle : cf_handle }, function(data, status) {
                                if(data.result.length < 1){
                                    showErrorToast(""No Submissions on CodeForces"");
                                }else{
                                    CodeForcesDataProcessor(data);
                                    
                                    // Set Pie Chart : VERDICT
                                    var verdictDataArray = $.map(cf_verdicts,function(v){ return v; });
                                    CodeForcesCreateCharts(Object.keys(cf_verdicts), verdictDataArray, 'pie', $('#verdicts_codeForces_pie'), 'Verdicts of '+cf_handle);
                                    
                                    // Set Pie Chart : Languages
                                    var languageDataArray = $.map(cf_languages,function(v){ return v; });
                                    CodeForcesCreateCharts(Object.keys(cf_languages), languageDataArray, 'pie', $('#languag");
                WriteLiteral(@"es_codeForces_pie'), 'Languages used by '+cf_handle);
                                    
                                    // Set Doughnut Chart : Tags
                                    var tagsDataArray = $.map(cf_tags,function(v){ return v; });
                                    CodeForcesCreateCharts(Object.keys(cf_tags), tagsDataArray, 'doughnut', $('#tags_codeForces_doughnut'), 'Tags of problems solved by '+cf_handle);
                                    
                                    // Set Bar Chart : Levels
                                    cf_attempt_level_quality = sortObjects(cf_attempt_level_quality);
                                    var levelsDataArray = $.map(cf_attempt_level_quality,function(v){ return v; });
                                    CodeForcesCreateBarCharts(Object.keys(cf_attempt_level_quality), levelsDataArray, $('#levels_codeForces_bar'), 'Level of problems solved by '+cf_handle);
                                    
                                    // Set Ba");
                WriteLiteral(@"r Chart : Tags
                                    var ratingsDataArray = $.map(cf_attempt_rating_quality,function(v){ return v; });
                                    CodeForcesCreateBarCharts(Object.keys(cf_attempt_rating_quality), ratingsDataArray, $('#problem_rating_codeForces_bar'), 'Rating of problems solved by '+cf_handle);
                                    
                                    CodeForcesEffortSummary();
                                    cfDIV.show();
                                }
                                cfPreload.hide();
                              })
                          } else{
                            cfPreload.hide();
                            cfDIV.hide();
                            showUserDefinedToast(""CodeForces is Private"", ""indigo darken-2 rounded"");
                          }
                          
                          // GitHub Resume Maker
                          if(WorkingProfile.githubUsername != null){
                          ");
                WriteLiteral(@"      
                          }
                          
                          // UVA Resume Maker
                          if(WorkingProfile.uhuntUsername != null){
                                  
                          }
                         
                        }
                        
                        $(""#intLoader"").hide();
                    });  
                }
                catch (e) {
                  showErrorToast(""Invalid Username"");
                  $(""#intLoader"").hide();
                }
            });        
        });

     function sortProperties(obj)
      {
        // convert object into array
        var sortable=[];
        for(var key in obj)
          if(obj.hasOwnProperty(key))
            sortable.push([key, obj[key]]); // each item is an array in format [key, value]

        // sort items by value
        sortable.sort(function(a, b)
        {
          return a[1]-b[1]; // compare numbers
        });
        return sortable; // array in ");
                WriteLiteral(@"format [ [ key1, val1 ], [ key2, val2 ], ... ]
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

     
     function CodeForcesDataProcessor(data){
         
         for(var i = data.result.length - 1; i >= 0 ; i--) {
           var submission = data.result[i];
           
           /*
           ** #problemId : Concatenates contestId (1110) and submissionID (A)
           ** Example    : 1110-A
           **
           ** cf_problems_attempt_solved[problemId] is checked firstly if it is defined or, not
           ** if cf_problems_attempt_solved[problemId] is not defined then attempt is set to 1
           ** and solved is set to 0
           **
           ** else it will be counting till the probl");
                WriteLiteral(@"em is solved
           ** the goal is to count how many attempts was taken before solved 
           */
           var problemId = submission.problem.contestId + '-' + submission.problem.index;
           
           if(cf_problems_attempt_solved[problemId] === undefined){
               cf_problems_attempt_solved[problemId] = {
                 attempts : 1,
                 solved : 0  
               };
           } else{
              if(cf_problems_attempt_solved[problemId].solved === 0){
                  cf_problems_attempt_solved[problemId].attempts++; 
              } 
           }
           
           /*
           ** #VERDICTS COUNTER
           ** 
           ** Counting number of each type of verdicts 
           ** Example: OK , COMPILATION_ERROR , MEMORY_LIMIT_EXCEEDED
            */
           if(cf_verdicts[submission.verdict] === undefined){
               cf_verdicts[submission.verdict] = 1;
           } else{
               cf_verdicts[submission.verdict]++;
           }
           
   ");
                WriteLiteral(@"        /*
           ** #Language COUNTER 
           * 
           ** Counting number of each type of languages
           ** Example: C++, Java, Kotlin
           */
           if(cf_languages[submission.programmingLanguage] === undefined){
               cf_languages[submission.programmingLanguage] = 1;
           } else{
               cf_languages[submission.programmingLanguage]++;
           }
           
           
           /*
           ** #Counting Solved : HOW_MANY_WAYS
           ** It means number of times a problem is solved according to VERDICT == OK
           ** 
           ** It will increment cf_problems_attempt_solved[problemID].solved
           */
           if(submission.verdict === 'OK'){
               cf_problems_attempt_solved[problemId].solved++;
           }
           
           // Counting Tags, levels, Problem Rating at MIN[SOLVED]
           if(submission.verdict === 'OK' && cf_problems_attempt_solved[problemId].solved === 1){
               /*
               ** Counting T");
                WriteLiteral("ags\n               ** solved is counted ");
                EndContext();
                BeginContext(10393, 7193, true);
                WriteLiteral(@"@1 because
               ** if someone solves a problem so many times then we can take only one tag
               **/
               submission.problem.tags.forEach(function(currentValue) {
                 if(cf_tags[currentValue] === undefined){
                     cf_tags[currentValue] = 1;
                 }else{
                     cf_tags[currentValue]++;
                 }
               });
               
               // Level of quality problems being tried : A, B, B1 
               if(cf_attempt_level_quality[submission.problem.index] === undefined){
                   cf_attempt_level_quality[submission.problem.index] = 1;
               }else{
                   cf_attempt_level_quality[submission.problem.index]++;
               }
               
               // Level of rating of problems being tried : 2100, 1500
               if(cf_attempt_rating_quality[submission.problem.rating] === undefined){
                 cf_attempt_rating_quality[submission.problem.rating] = 1;  
           ");
                WriteLiteral(@"    } else{
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
           o");
                WriteLiteral(@"ptions: {
             title: {
               display: true,
               text: titleText,
               fontSize: 25
             },
             responsive: true,
             responsiveAnimationDuration: 500,
             mainAspectRatio : false
           }
       });
     }
     
     function CodeForcesCreateBarCharts(keys, dataArray, context, titleText) {
       var myChart = new Chart(context, {
          type: 'bar',
          data: {
            labels: keys[0],
            datasets: [{
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
            scales: {
              xAxes: [{
                ticks: {
                  maxRotation: 90,
                ");
                WriteLiteral(@"  minRotation: 80
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
        
        for(var submissions in cf_problems_attempt_solved){
            
            // For Each Submission : numberOfTimesTried increments to 1 
            numberOfProblemsTried += 1;
            
            // For Each Submission : count total number of problems been solved
            if(cf_problems_attempt_solved[submissions].solved > 0){
                numberO");
                WriteLiteral(@"fProblemsSolved += 1;
            }
            
            // Count Max Attempt Comparing With Each Attempt
            if(cf_problems_attempt_solved[submissions].attempts > maximumAttemptsBeforeSolvingAProblem){
                maximumAttemptsBeforeSolvingAProblem = cf_problems_attempt_solved[submissions].attempts;
                maximumProblemBeenAttempted = submissions;
            }
            
            // Count Max Accepted Comparing With Each Solved
            if(cf_problems_attempt_solved[submissions].solved > maximumNumberAProblemAccepted){
                maximumNumberAProblemAccepted = cf_problems_attempt_solved[submissions].solved;
                maximumAcceptedProblemInfo = submissions;
            }
            
            // One Submission Solved
            if(cf_problems_attempt_solved[submissions].solved === 1 && cf_problems_attempt_solved[submissions].attempts === 1){
                OneSubmissionTry+=1;
            }
        }
        
        /*console.log(cf_problems_attempt_sol");
                WriteLiteral(@"ved);
        console.log(numberOfProblemsTried);
        console.log(numberOfProblemsSolved);
        console.log(maximumAttemptsBeforeSolvingAProblem);
        console.log(maximumProblemBeenAttempted);
        console.log(maximumNumberAProblemAccepted);
        console.log(maximumAcceptedProblemInfo);
        console.log(OneSubmissionTry);*/
        $('#DevTriedProblems').text(numberOfProblemsTried);
        $('#DevSolvedProblems').text(numberOfProblemsSolved);
        $('#DevMaxAttemptedProblems').text(maximumAttemptsBeforeSolvingAProblem + ""("" + maximumProblemBeenAttempted + "")"");
        $('#DevMaxAcceptedProblems').text(maximumNumberAProblemAccepted + ""("" + maximumAcceptedProblemInfo + "")"");
        $('#DevAcceptedAtFirstTry').text(OneSubmissionTry);
      }
                
    function _initBioCardDev(response) {
      var _DevUsername = $('#_DeveloperName');
      var _DevCurrentCity = """";
      """"!==response.currentCity?_DevCurrentCity=response.currentCity:_DevCurrentCity=""CodeStagram"";
      _DevUs");
                WriteLiteral(@"ername.text(toTitleCase($('#developerUsername').val())+""(""+_DevCurrentCity+"")"");
      
      if(response.shortDescription !== """"){
          $('#_DeveloperDescription').html(response.shortDescription);
      }else{
          $('#_DeveloperDescription').html(""Hey, there. I am focusing on Programming !"");
      }
      
      if(response.isAvailableForJob){
          $('#_DeveloperJobConfirmation').text(""Available"");
      }else{
          $('#_DeveloperJobConfirmation').text(""Not Available"");
      }
    }   
        
     function showErrorToast(message) {
       M.toast({
         html: message,
         classes: 'red darken-1 rounded'
       });
     }   

     function showUserDefinedToast(message, style){
       M.toast({
         html: message,
         classes: style
       });
     }
        
    function toTitleCase(str) {
        return str.replace(
            /\w\S*/g,
            function(txt) {
                return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
            }
      ");
                WriteLiteral("  );\n    }\n    </script>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
