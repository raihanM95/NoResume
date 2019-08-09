#pragma checksum "/home/shunjid/Documents/Project/Version2/NoResume/Views/Shared/_WProfileQueriFy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d04c2ad1107fd9686239b4bbce8e8d54aee76c17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__WProfileQueriFy), @"mvc.1.0.view", @"/Views/Shared/_WProfileQueriFy.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_WProfileQueriFy.cshtml", typeof(AspNetCore.Views_Shared__WProfileQueriFy))]
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
#line 1 "/home/shunjid/Documents/Project/Version2/NoResume/Views/_ViewImports.cshtml"
using NoResume;

#line default
#line hidden
#line 2 "/home/shunjid/Documents/Project/Version2/NoResume/Views/_ViewImports.cshtml"
using NoResume.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d04c2ad1107fd9686239b4bbce8e8d54aee76c17", @"/Views/Shared/_WProfileQueriFy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30811eb6fdc7e219bf37d0f73ea0aeaac307f593", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__WProfileQueriFy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("exclude", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 3015, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d04c2ad1107fd9686239b4bbce8e8d54aee76c173702", async() => {
                BeginContext(35, 2966, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function(){
            var loaderIntermediate = $('#intLoader');
            loaderIntermediate.css(""display"", ""none"");

            $(""#formWorkingProfile"").submit(function(e){
                e.preventDefault();
                loaderIntermediate.css(""display"", ""block"");
                
                var isGithubPermittable = false;
                var isCFPermittable = false;
                
                var gitUname = $('#GithubUsername').val();
                var cfUname = $('#CodeforcesUsername').val();
                
                $.ajaxSetup({
                    async: false
                });
                
                if(gitUname.trim() === """"){
                    isGithubPermittable = true;   
                }else{
                    $.ajax({ 
                        url: ""https://api.github.com/users/""+$('#GithubUsername').val(),
                        async: false, 
                        dataType: 'json', 
 ");
                WriteLiteral(@"                       success: function(json, textStatus, xhr){ 
                            if(xhr.status === 200){
                                isGithubPermittable = true;
                            }
                        } 
                    });    
                }
                
                if(cfUname.trim() === """"){
                    isCFPermittable = true;
                }else{
                    $.ajax({ 
                        url: ""https://codeforces.com/api/user.info?handles=""+$('#CodeforcesUsername').val(),
                        async: false, 
                        dataType: 'json', 
                        success: function(json){ 
                            if(json.status === ""OK""){
                                isCFPermittable = true;
                            }
                        } 
                    });
                }
                loaderIntermediate.css(""display"", ""none"");
                
                if(isGithubPermittable === false || isCFPerm");
                WriteLiteral(@"ittable === false){
                    M.toast({
                    html: 'Invalid Username',
                    classes: 'red darken-1 rounded'
                    });
                }else{
                    $.post('', $('#formWorkingProfile').serialize(), function (response) {
                        if(response != null || response !== """" || response !== ""null""){
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
                }
            });
        });
        
    </script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3015, 3, true);
            WriteLiteral("\n\n\n");
            EndContext();
            BeginContext(3018, 2529, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d04c2ad1107fd9686239b4bbce8e8d54aee76c178149", async() => {
                BeginContext(3053, 2480, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function(){
            var loaderIntermediate = $('#intLoader');
            loaderIntermediate.css(""display"", ""none"");

            $(""#formWorkingProfile"").submit(function(e){
                e.preventDefault();
                loaderIntermediate.css(""display"", ""block"");
                
                var isGithubPermittable = false;
                var isCFPermittable = false;
                
                $.ajaxSetup({
                    async: false
                });
                
                $.ajax({ 
                    url: ""https://api.github.com/users/""+$('#GithubUsername').val(),
                    async: false, 
                    dataType: 'json', 
                    success: function(json, textStatus, xhr){ 
                        if(xhr.status === 200){
                            isGithubPermittable = true;
                        }
                    } 
                });
                
                $.aj");
                WriteLiteral(@"ax({ 
                    url: ""https://codeforces.com/api/user.info?handles=""+$('#CodeforcesUsername').val(),
                    async: false, 
                    dataType: 'json', 
                    success: function(json){ 
                        if(json.status === ""OK""){
                            isCFPermittable = true;
                        }
                    } 
                });
                
                loaderIntermediate.css(""display"", ""none"");
                if(isGithubPermittable === false || isCFPermittable === false){
                    M.toast({
                    html: 'Invalid Username',
                    classes: 'red darken-1 rounded'
                    });
                }else{
                    $.post('', $('#formWorkingProfile').serialize(), function (response) {
                        if(response != null || response !== """" || response !== ""null""){
                            M.toast({
                            html: 'Data updated Successfully',
           ");
                WriteLiteral(@"                 classes: 'green darken-1 rounded'
                            });    
                        }else{
                            M.toast({
                            html: 'Something went wrong !',
                            classes: 'red darken-4 rounded'
                            }); 
                        }
                    });    
                }
            });
        });
        
    </script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Exclude = (string)__tagHelperAttribute_1.Value;
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
