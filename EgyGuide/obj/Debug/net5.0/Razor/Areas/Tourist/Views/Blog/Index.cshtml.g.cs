#pragma checksum "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78f35c490245e908ea74530fc0b2668f2bd3c84c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Tourist_Views_Blog_Index), @"mvc.1.0.view", @"/Areas/Tourist/Views/Blog/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78f35c490245e908ea74530fc0b2668f2bd3c84c", @"/Areas/Tourist/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da94f91bf55f607904a0334e49f022a705c8c3a4", @"/Areas/Tourist/Views/_ViewImports.cshtml")]
    public class Areas_Tourist_Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EgyGuide.Models.ViewModels.BlogIndexVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/Breadcrumb.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("blog-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BlogSingle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-blog"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BlogCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lgg btn-block btn-border"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    int PostsNumber = 5;

    IEnumerable<Blog> latestPosts = Model.Blogs.OrderByDescending(b => b.Id)
                                               .Take(PostsNumber);
    IEnumerable<Blog> popularPosts = Model.Blogs.OrderByDescending(b => b.Views)
                                                .Take(PostsNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- start breadcrumb -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "78f35c490245e908ea74530fc0b2668f2bd3c84c6200", async() => {
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

            <div class=""row"">

                <div class=""col-xs-12 col-sm-8 col-sm-9"">

                    <div class=""blog-wrapper"">

                        <!-- start Blog Item -->
");
#nullable restore
#line 29 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                         foreach (var blog in Model.Blogs)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"blog-item\">\r\n\r\n                                <div class=\"blog-media\">\r\n                                    <div class=\"overlay-box\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78f35c490245e908ea74530fc0b2668f2bd3c84c8112", async() => {
                WriteLiteral("\r\n                                            <img");
                BeginWriteAttribute("src", " src=\"", 1276, "\"", 1296, 1);
#nullable restore
#line 36 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1282, blog.ImageURL, 1282, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1297, "\"", 1303, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                                            <div class=""image-overlay"">
                                                <div class=""overlay-content"">
                                                    <div class=""overlay-icon""><i class=""pe-7s-link""></i></div>
                                                </div>
                                            </div>
                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                                                                              WriteLiteral(blog.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n\r\n                                <div class=\"blog-content\">\r\n                                    <h3><a href=\"blog-single.html\" class=\"inverse\">");
#nullable restore
#line 47 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                                              Write(blog.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                                    <ul class=\"blog-meta\">\r\n                                        <li>by <a href=\"#\">Admin</a></li>\r\n                                        <li>by ");
#nullable restore
#line 50 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                          Write(blog.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                        <li>in <a href=\"#\">");
#nullable restore
#line 51 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                      Write(blog.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>, <a href=""#"">Backpack</a></li>
                                        <li>32 comments</li>
                                    </ul>
                                    <div class=""blog-entry"" style=""color: none;"">
                                        ");
#nullable restore
#line 55 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                   Write(Html.Raw(blog.Descripition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78f35c490245e908ea74530fc0b2668f2bd3c84c13466", async() => {
                WriteLiteral("Read More <i class=\"fa fa-long-arrow-right\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                                                        WriteLiteral(blog.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n\r\n                            </div>\r\n");
#nullable restore
#line 61 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <!-- end Blog Item -->

                        <div class=""pager-wrapper"">

                            <nav class=""pager-right"">
                                <ul class=""pagination"">
                                    <li>
                                        <a href=""#"" aria-label=""Previous"">
                                            <span aria-hidden=""true"">&laquo;</span>
                                        </a>
                                    </li>
                                    <li class=""active""><a href=""#"">1</a></li>
                                    <li><a href=""#"">2</a></li>
                                    <li><a href=""#"">3</a></li>
                                    <li><span>...</span></li>
                                    <li><a href=""#"">11</a></li>
                                    <li><a href=""#"">12</a></li>
                                    <li><a href=""#"">13</a></li>
                                    <li>
        ");
            WriteLiteral(@"                                <a href=""#"" aria-label=""Next"">
                                            <span aria-hidden=""true"">&raquo;</span>
                                        </a>
                                    </li>
                                </ul>
                            </nav>

                        </div>

                    </div>

                </div>

                <div class=""col-xs-12 col-sm-4 col-md-3 mt-50-xs"">

                    <aside class=""sidebar-wrapper"">

                        <div class=""sidebar-module"">
                            <div class=""sidebar-module-inner"">
                                <div class=""sidebar-mini-search"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78f35c490245e908ea74530fc0b2668f2bd3c84c18127", async() => {
                WriteLiteral("Create Blog");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>

                        <div class=""clear""></div>

                        <div class=""sidebar-module"">
                            <h4 class=""sidebar-title"">Categories</h4>
                            <div class=""sidebar-module-inner"">
                                <ul class=""sidebar-category"">
");
#nullable restore
#line 112 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                     foreach (var category in Model.Categories)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><a href=\"#\">");
#nullable restore
#line 114 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                   Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>(");
#nullable restore
#line 114 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                                        Write(Model.Blogs.Count(b => b.Category.Name == category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span></a></li>\r\n");
#nullable restore
#line 115 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </ul>
                            </div>
                        </div>

                        <div class=""clear""></div>

                        <div class=""sidebar-module"">
                            <h4 class=""sidebar-title"">Latest Posts</h4>
                            <div class=""sidebar-module-inner"">

                                <ul class=""sidebar-post"">
");
#nullable restore
#line 127 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                     foreach (var lastPost in latestPosts)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"clearfix\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 6139, "\"", 6174, 2);
            WriteAttributeValue("", 6146, "/blog-single?id=", 6146, 16, true);
#nullable restore
#line 130 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 6162, lastPost.Id, 6162, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <div class=\"image\">\r\n                                                    <img");
            BeginWriteAttribute("src", " src=\"", 6303, "\"", 6327, 1);
#nullable restore
#line 132 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 6309, lastPost.ImageURL, 6309, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Popular Post\" />\r\n                                                </div>\r\n                                                <div class=\"content\">\r\n                                                    <h6>");
#nullable restore
#line 135 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                   Write(lastPost.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                                    <p class=\"recent-post-sm-meta\"><i class=\"fa fa-clock-o mr-5\"></i>");
#nullable restore
#line 136 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                                                                                Write(lastPost.Date.ToString("dd/M/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                </div>\r\n                                            </a>\r\n                                        </li>\r\n");
#nullable restore
#line 140 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </ul>

                            </div>
                        </div>

                        <div class=""clear""></div>

                        <div class=""sidebar-module"">
                            <h4 class=""sidebar-title"">Popular Posts</h4>
                            <div class=""sidebar-module-inner"">

                                <ul class=""sidebar-post"">
");
#nullable restore
#line 153 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                     foreach (var popularPost in popularPosts)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"clearfix\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 7553, "\"", 7591, 2);
            WriteAttributeValue("", 7560, "/blog-single?id=", 7560, 16, true);
#nullable restore
#line 156 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 7576, popularPost.Id, 7576, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <div class=\"image\">\r\n                                                    <img");
            BeginWriteAttribute("src", " src=\"", 7720, "\"", 7747, 1);
#nullable restore
#line 158 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 7726, popularPost.ImageURL, 7726, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Popular Post\" />\r\n                                                </div>\r\n                                                <div class=\"content\">\r\n                                                    <h6>");
#nullable restore
#line 161 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                   Write(popularPost.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                                    <p class=\"recent-post-sm-meta\"><i class=\"fa fa-comments mr-5\"></i>");
#nullable restore
#line 162 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                                                                                                 Write(popularPost.Views);

#line default
#line hidden
#nullable disable
            WriteLiteral(" views</p>\r\n                                                </div>\r\n                                            </a>\r\n                                        </li>\r\n");
#nullable restore
#line 166 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Blog\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </ul>

                            </div>
                        </div>

                        <div class=""clear""></div>

                        <div class=""sidebar-module"">
                            <h4 class=""sidebar-title"">Archives</h4>
                            <div class=""sidebar-module-inner"">
                                <ul class=""sidebar-archives"">
                                    <li><a href=""#"">January 2015<span>(25)</span></a></li>
                                    <li class=""active""><a href=""#"">February 2015<span>(2)</span></a></li>
                                    <li><a href=""#"">March 2015<span>(14)</span></a></li>
                                    <li><a href=""#"">April 2015<span>(157)</span></a></li>
                                    <li><a href=""#"">June 2015<span>(87)</span></a></li>
                                </ul>
                            </div>
                        </div>

                    </aside>

");
            WriteLiteral("                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EgyGuide.Models.ViewModels.BlogIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
