#pragma checksum "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ae3bf0ab778164086b21ecd81f903b96d8ae1dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departments_Create), @"mvc.1.0.view", @"/Views/Departments/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Departments/Create.cshtml", typeof(AspNetCore.Views_Departments_Create))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ae3bf0ab778164086b21ecd81f903b96d8ae1dc", @"/Views/Departments/Create.cshtml")]
    public class Views_Departments_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UniversityRegistrar.Models.Course>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
  
  Layout = "_Layout";

#line default
#line hidden
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(75, 52, true);
            WriteLiteral("\r\n<h1>Add Department</h1>\r\n\r\n<div class=\'content\'>\r\n");
            EndContext();
#line 10 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
   using(Html.BeginForm())
  {
    

#line default
#line hidden
            BeginContext(165, 34, false);
#line 12 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
Write(Html.LabelFor(model => model.Name));

#line default
#line hidden
            EndContext();
#line 12 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
                                       ;
    

#line default
#line hidden
            BeginContext(207, 36, false);
#line 13 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
Write(Html.TextBoxFor(model => model.Name));

#line default
#line hidden
            EndContext();
#line 13 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
                                         ;

    

#line default
#line hidden
            BeginContext(253, 36, false);
#line 15 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
Write(Html.LabelFor(model => model.Number));

#line default
#line hidden
            EndContext();
#line 15 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
                                         ;
    

#line default
#line hidden
            BeginContext(297, 63, false);
#line 16 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
Write(Html.EditorFor(model => model.Number, new { @type = "number" }));

#line default
#line hidden
            EndContext();
#line 16 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
                                                                    ;

    

#line default
#line hidden
            BeginContext(470, 60, true);
            WriteLiteral("    <input type=\"submit\" value=\"Add course\" class=\"btn\" />\r\n");
            EndContext();
#line 22 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
  }

#line default
#line hidden
            BeginContext(535, 36, true);
            WriteLiteral("</div>\r\n\r\n<div class=\'links\'>\r\n  <p>");
            EndContext();
            BeginContext(572, 35, false);
#line 26 "C:\Users\rache\desktop\projects\portfolio\university.solution\universityregistrar\Views\Departments\Create.cshtml"
Write(Html.ActionLink("Courses", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(607, 12, true);
            WriteLiteral("</p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UniversityRegistrar.Models.Course> Html { get; private set; }
    }
}
#pragma warning restore 1591
