#pragma checksum "/home/shunjid/Documents/Project/NoResume/Views/Shared/_initHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2b7865028872d0ffe3495da1609ab29ab0fe5da"
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
#line 1 "/home/shunjid/Documents/Project/NoResume/Views/_ViewImports.cshtml"
using NoResume;

#line default
#line hidden
#line 2 "/home/shunjid/Documents/Project/NoResume/Views/_ViewImports.cshtml"
using NoResume.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2b7865028872d0ffe3495da1609ab29ab0fe5da", @"/Views/Shared/_initHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30811eb6fdc7e219bf37d0f73ea0aeaac307f593", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__initHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2307, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2b7865028872d0ffe3495da1609ab29ab0fe5da3324", async() => {
                BeginContext(35, 2258, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function(){
            
            $(""#resume"").hide();
            $(""#intLoader"").hide();
            
            $(""#formDevUname"").submit(function(e){
                e.preventDefault();
                $(""#resume"").hide();
                $(""#intLoader"").show();
                
                try {
                    $.post('', $('#formDevUname').serialize(), function (response) {
                        if(response === null || response === """" || response === ""null""){
                            showErrorToast(""Invalid Username"");
                        }
                        else{
                         _initBioCardDev(response[0]);
                          $(""#resume"").show();   
                        }
                        $(""#intLoader"").hide();
                    });  
                }
                catch (e) {
                  showErrorToast(""Invalid Username"");
                  $(""#intLoader"").hide();
          ");
                WriteLiteral(@"      }
            });        
        });
        
    function _initBioCardDev(response) {
      var _DevUsername = $('#_DeveloperName');
      var _DevCurrentCity = """";
      """"!==response.currentCity?_DevCurrentCity=response.currentCity:_DevCurrentCity=""CodeStagram"";
      _DevUsername.text(toTitleCase($('#developerUsername').val())+""(""+_DevCurrentCity+"")"");
      
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
      
      console.log(response);
    }   
        
     function showErrorToast(message) {
       M.toast({
         html: message,
         classes: 'red darken-1 rounded'
       });
     }   
        
    function toTitleCase(st");
                WriteLiteral("r) {\n        return str.replace(\n            /\\w\\S*/g,\n            function(txt) {\n                return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();\n            }\n        );\n    }\n    </script>\n");
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
