#pragma checksum "E:\project\Egy-Guide\EgyGuide\Areas\TourGuide\Views\TripDays\OfferedCreateDone.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4da9f21e25cacfced0a5aec5dff10d7176c18fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TourGuide_Views_TripDays_OfferedCreateDone), @"mvc.1.0.view", @"/Areas/TourGuide/Views/TripDays/OfferedCreateDone.cshtml")]
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
#nullable restore
#line 1 "E:\project\Egy-Guide\EgyGuide\Areas\TourGuide\Views\_ViewImports.cshtml"
using EgyGuide;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\project\Egy-Guide\EgyGuide\Areas\TourGuide\Views\_ViewImports.cshtml"
using EgyGuide.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4da9f21e25cacfced0a5aec5dff10d7176c18fa", @"/Areas/TourGuide/Views/TripDays/OfferedCreateDone.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da94f91bf55f607904a0334e49f022a705c8c3a4", @"/Areas/TourGuide/Views/_ViewImports.cshtml")]
    public class Areas_TourGuide_Views_TripDays_OfferedCreateDone : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EgyGuide.Models.TripDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/Breadcrumb.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\project\Egy-Guide\EgyGuide\Areas\TourGuide\Views\TripDays\OfferedCreateDone.cshtml"
  
    ViewData["Title"] = "Create Tour Done";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- start breadcrumb -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c4da9f21e25cacfced0a5aec5dff10d7176c18fa3861", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <!-- end breadcrumb -->

    <div class=""pt-50 pb-50"">

        <div class=""container"">

            <div class=""create-done-wrapper"">

                <div class=""row"">

                    <div class=""col-xs-12 col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2"">

                        <div class=""icon"">
                            <div class=""icon-inner"">
                                <i class=""ti-check""></i>
                            </div>
                        </div>

                        <h1 class=""text-lowercase"">Congratulation!</h1>
                        <p class=""lead"">Your tour have been successfully created</p>
                        <h3>");
#nullable restore
#line 30 "E:\project\Egy-Guide\EgyGuide\Areas\TourGuide\Views\TripDays\OfferedCreateDone.cshtml"
                       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 957, "\"", 997, 2);
            WriteAttributeValue("", 964, "/offered-details?id=", 964, 20, true);
#nullable restore
#line 31 "E:\project\Egy-Guide\EgyGuide\Areas\TourGuide\Views\TripDays\OfferedCreateDone.cshtml"
WriteAttributeValue("", 984, Model.TripId, 984, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-wide\">View</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1068, "\"", 1107, 2);
            WriteAttributeValue("", 1075, "/offered-create?id=", 1075, 19, true);
#nullable restore
#line 32 "E:\project\Egy-Guide\EgyGuide\Areas\TourGuide\Views\TripDays\OfferedCreateDone.cshtml"
WriteAttributeValue("", 1094, Model.TripId, 1094, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-wide btn-border\">Edit</a>\r\n\r\n                    </div>\r\n\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EgyGuide.Models.TripDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
