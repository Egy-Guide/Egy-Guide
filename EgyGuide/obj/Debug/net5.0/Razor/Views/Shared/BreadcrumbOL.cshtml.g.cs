#pragma checksum "C:\Users\M&G\Source\Repos\Egy-Guide\EgyGuide\Views\Shared\BreadcrumbOL.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe56cda55cde2f9249e94f76068f879beefdb56d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_BreadcrumbOL), @"mvc.1.0.view", @"/Views/Shared/BreadcrumbOL.cshtml")]
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
#line 1 "C:\Users\M&G\Source\Repos\Egy-Guide\EgyGuide\Views\_ViewImports.cshtml"
using EgyGuide;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\M&G\Source\Repos\Egy-Guide\EgyGuide\Views\_ViewImports.cshtml"
using EgyGuide.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe56cda55cde2f9249e94f76068f879beefdb56d", @"/Views/Shared/BreadcrumbOL.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"311a2a442e1cf4ea2f8e62aef0c024c74e5803e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_BreadcrumbOL : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\M&G\Source\Repos\Egy-Guide\EgyGuide\Views\Shared\BreadcrumbOL.cshtml"
   
    var links = (Context.Request.Path.Value).ToString().TrimStart('/').Split("/").ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ol class=\"breadcrumb\" style=\"text-transform:capitalize\">\r\n");
#nullable restore
#line 6 "C:\Users\M&G\Source\Repos\Egy-Guide\EgyGuide\Views\Shared\BreadcrumbOL.cshtml"
     foreach (var link in links)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li><a>");
#nullable restore
#line 8 "C:\Users\M&G\Source\Repos\Egy-Guide\EgyGuide\Views\Shared\BreadcrumbOL.cshtml"
          Write(link);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 9 "C:\Users\M&G\Source\Repos\Egy-Guide\EgyGuide\Views\Shared\BreadcrumbOL.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ol>");
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
