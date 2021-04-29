#pragma checksum "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\LatestPosts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e6baf970f30305b7fdc25d0a2e92dd23c8631d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Tourist_Views_Blog_LatestPosts), @"mvc.1.0.view", @"/Areas/Tourist/Views/Blog/LatestPosts.cshtml")]
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
#line 1 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\_ViewImports.cshtml"
using EgyGuide;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\_ViewImports.cshtml"
using EgyGuide.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e6baf970f30305b7fdc25d0a2e92dd23c8631d2", @"/Areas/Tourist/Views/Blog/LatestPosts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da94f91bf55f607904a0334e49f022a705c8c3a4", @"/Areas/Tourist/Views/_ViewImports.cshtml")]
    public class Areas_Tourist_Views_Blog_LatestPosts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\LatestPosts.cshtml"
  
    int PostsNumber = 5;
    IEnumerable<Blog> latestPosts = _unitOfWork.Blog.GetAll().OrderByDescending(b => b.Id)
                                               .Take(PostsNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ul class=\"sidebar-post\">\r\n");
#nullable restore
#line 10 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\LatestPosts.cshtml"
     foreach (var lastPost in latestPosts)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"clearfix\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 396, "\"", 431, 2);
            WriteAttributeValue("", 403, "/blog-single?id=", 403, 16, true);
#nullable restore
#line 13 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\LatestPosts.cshtml"
WriteAttributeValue("", 419, lastPost.Id, 419, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"image\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 496, "\"", 520, 1);
#nullable restore
#line 15 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\LatestPosts.cshtml"
WriteAttributeValue("", 502, lastPost.ImageURL, 502, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Popular Post\" />\r\n                </div>\r\n                <div class=\"content\">\r\n                    <h6>");
#nullable restore
#line 18 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\LatestPosts.cshtml"
                   Write(lastPost.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                    <p class=\"recent-post-sm-meta\"><i class=\"fa fa-clock-o mr-5\"></i>");
#nullable restore
#line 19 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\LatestPosts.cshtml"
                                                                                Write(lastPost.Date.ToString("dd/M/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 23 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\LatestPosts.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public EgyGuide.DataAccess.Repository.IRepository.IUnitOfWork _unitOfWork { get; private set; }
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
