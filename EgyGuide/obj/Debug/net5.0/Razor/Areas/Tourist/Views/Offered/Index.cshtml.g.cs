#pragma checksum "E:\EgyGuide\EgyGuide\EgyGuide\Areas\Tourist\Views\Offered\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b458f517d32b143182d8878137bdb0ad8d29b0df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Tourist_Views_Offered_Index), @"mvc.1.0.view", @"/Areas/Tourist/Views/Offered/Index.cshtml")]
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
#line 1 "E:\EgyGuide\EgyGuide\EgyGuide\Areas\Tourist\Views\_ViewImports.cshtml"
using EgyGuide;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\EgyGuide\EgyGuide\EgyGuide\Areas\Tourist\Views\_ViewImports.cshtml"
using EgyGuide.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b458f517d32b143182d8878137bdb0ad8d29b0df", @"/Areas/Tourist/Views/Offered/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da94f91bf55f607904a0334e49f022a705c8c3a4", @"/Areas/Tourist/Views/_ViewImports.cshtml")]
    public class Areas_Tourist_Views_Offered_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/BreadcrumbHeader.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/Filter.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "OfferedDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap-tokenfield.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/typeahead.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ion.rangeSlider.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.bootstrap-touchspin.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/customs-result.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\EgyGuide\EgyGuide\EgyGuide\Areas\Tourist\Views\Offered\Index.cshtml"
  
    ViewData["Title"] = "Index";
    ViewData["AddClassToBodyTag"] = "transparent-header";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- start breadcrumb -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b458f517d32b143182d8878137bdb0ad8d29b0df7204", async() => {
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
            WriteLiteral("\r\n<!-- start breadcrumb -->\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b458f517d32b143182d8878137bdb0ad8d29b0df8354", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <div class=""pt-30 pb-50"">

        <div class=""container"">

            <div class=""trip-guide-wrapper"">

                <div class=""GridLex-gap-20 GridLex-gap-15-mdd GridLex-gap-10-xs"">

                    <div class=""GridLex-grid-noGutter-equalHeight"">

                        <div class=""GridLex-col-3_mdd-4_sm-6_xs-6_xss-12"">

                            <div class=""trip-guide-item"">

                                <div class=""trip-guide-image"">
                                    <img src=""images/trip/01.jpg"" alt=""images"" />
                                </div>

                                <div class=""trip-guide-content"">
                                    <h3>4 days tour in Cairo, Alexandria</h3>
                                    <p>Game of as rest time eyes with of this it. Add was music merry any truth since going...</p>
                                </div>

                                <div class=""trip-guide-bottom"">

                                  ");
            WriteLiteral(@"  <div class=""trip-guide-person clearfix"">
                                        <div class=""image"">
                                            <img src=""images/testimonial/01.jpg"" class=""img-circle"" alt=""images"" />
                                        </div>
                                        <p class=""name"">By: <a href=""#"">Shady Khalil</a></p>
                                        <p>Local expert from Egypt</p>
                                    </div>

                                    <div class=""trip-guide-meta row gap-10"">
                                        <div class=""col-xs-6 col-sm-6"">
                                            <div class=""rating-item"">
                                                <input type=""hidden"" class=""rating"" data-filled=""fa fa-star rating-rated"" data-empty=""fa fa-star-o"" data-fractions=""2"" data-readonly value=""4.5"" />
                                            </div>
                                        </div>
                       ");
            WriteLiteral(@"                 <div class=""col-xs-6 col-sm-6 text-right"">
                                            5 days 4 nights
                                        </div>
                                    </div>

                                    <div class=""row gap-10"">
                                        <div class=""col-xs-12 col-sm-6"">
                                            <div class=""trip-guide-price"">
                                                Starting at
                                                <span class=""number"">USD687.00</span>
                                            </div>
                                        </div>
                                        <div class=""col-xs-12 col-sm-6 text-right"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b458f517d32b143182d8878137bdb0ad8d29b0df12453", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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

                            </div>

                        </div>

                        <div class=""GridLex-col-3_mdd-4_sm-6_xs-6_xss-12"">

                            <div class=""trip-guide-item"">

                                <div class=""trip-guide-image"">
                                    <img src=""images/trip/02.jpg"" alt=""images"" />
                                </div>

                                <div class=""trip-guide-content"">
                                    <h3>The Museum Of Cairo and Giza pyramids</h3>
                                    <p>Egyptian Museum is the only Museum all over the world has monuments for only one civilization, which is ...</p>
                                </div>

                                <div class=""trip-guide-bottom"">

                                    <div class=""trip-guide-person clearfix""");
            WriteLiteral(@">
                                        <div class=""image"">
                                            <img src=""images/testimonial/01.jpg"" class=""img-circle"" alt=""images"" />
                                        </div>
                                        <p class=""name"">By: <a href=""guide-detail.html"">Shady Khalil</a></p>
                                        <p>Local expert from Egypt</p>
                                    </div>

                                    <div class=""trip-guide-meta row gap-10"">
                                        <div class=""col-xs-6 col-sm-6"">
                                            <div class=""rating-item"">
                                                <input type=""hidden"" class=""rating"" data-filled=""fa fa-star rating-rated"" data-empty=""fa fa-star-o"" data-fractions=""2"" data-readonly value=""4.5"" />
                                            </div>
                                        </div>
                                        <div cla");
            WriteLiteral(@"ss=""col-xs-6 col-sm-6 text-right"">
                                            6 hours
                                        </div>
                                    </div>

                                    <div class=""row gap-10"">
                                        <div class=""col-xs-12 col-sm-6"">
                                            <div class=""trip-guide-price"">
                                                Starting at
                                                <span class=""number"">USD 150.00</span>
                                            </div>
                                        </div>
                                        <div class=""col-xs-12 col-sm-6 text-right"">
                                            <a href=""offered-detail.html"" class=""btn btn-primary"">Details</a>
                                        </div>
                                    </div>

                                </div>

                            </div>

          ");
            WriteLiteral(@"              </div>

                        <div class=""GridLex-col-3_mdd-4_sm-6_xs-6_xss-12"">

                            <div class=""trip-guide-item"">

                                <div class=""trip-guide-image"">
                                    <img src=""images/trip/03.jpg"" alt=""images"" />
                                </div>

                                <div class=""trip-guide-content"">
                                    <h3>Islamic & Coptic Area - Private Tour</h3>
                                    <p>Betrayed cheerful declared end and. Questions we additions is extremely incommode...</p>
                                </div>

                                <div class=""trip-guide-bottom"">

                                    <div class=""trip-guide-person clearfix"">
                                        <div class=""image"">
                                            <img src=""images/testimonial/01.jpg"" class=""img-circle"" alt=""images"" />
                             ");
            WriteLiteral(@"           </div>
                                        <p class=""name"">By: <a href=""#"">Shady Khalil</a></p>
                                        <p>Local expert from Egypt</p>
                                    </div>

                                    <div class=""trip-guide-meta row gap-10"">
                                        <div class=""col-xs-6 col-sm-6"">
                                            <div class=""rating-item"">
                                                <input type=""hidden"" class=""rating"" data-filled=""fa fa-star rating-rated"" data-empty=""fa fa-star-o"" data-fractions=""2"" data-readonly value=""4.5"" />
                                            </div>
                                        </div>
                                        <div class=""col-xs-6 col-sm-6 text-right"">
                                            5 days 4 nights
                                        </div>
                                    </div>

                                   ");
            WriteLiteral(@" <div class=""row gap-10"">
                                        <div class=""col-xs-12 col-sm-6"">
                                            <div class=""trip-guide-price"">
                                                Starting at
                                                <span class=""number"">USD687.00</span>
                                            </div>
                                        </div>
                                        <div class=""col-xs-12 col-sm-6 text-right"">
                                            <a href=""#"" class=""btn btn-primary"">Details</a>
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>

                        <div class=""GridLex-col-3_mdd-4_sm-6_xs-6_xss-12"">

                            <div class=""trip-guide-item"">

                                <div class=""trip-guide-image"">
          ");
            WriteLiteral(@"                          <img src=""images/trip/04.jpg"" alt=""images"" />
                                </div>

                                <div class=""trip-guide-content"">
                                    <h3>4 days tour in Cairo, Alexandria</h3>
                                    <p>Savings her pleased are several started females met. Short her not among being any...</p>
                                </div>

                                <div class=""trip-guide-bottom"">

                                    <div class=""trip-guide-person clearfix"">
                                        <div class=""image"">
                                            <img src=""images/testimonial/01.jpg"" class=""img-circle"" alt=""images"" />
                                        </div>
                                        <p class=""name"">By: <a href=""#"">Shady Khalil</a></p>
                                        <p>Local expert from Egypt</p>
                                    </div>

         ");
            WriteLiteral(@"                           <div class=""trip-guide-meta row gap-10"">
                                        <div class=""col-xs-6 col-sm-6"">
                                            <div class=""rating-item"">
                                                <input type=""hidden"" class=""rating"" data-filled=""fa fa-star rating-rated"" data-empty=""fa fa-star-o"" data-fractions=""2"" data-readonly value=""4.5"" />
                                            </div>
                                        </div>
                                        <div class=""col-xs-6 col-sm-6 text-right"">
                                            5 days 4 nights
                                        </div>
                                    </div>

                                    <div class=""row gap-10"">
                                        <div class=""col-xs-12 col-sm-6"">
                                            <div class=""trip-guide-price"">
                                                Starting at
  ");
            WriteLiteral(@"                                              <span class=""number"">USD687.00</span>
                                            </div>
                                        </div>
                                        <div class=""col-xs-12 col-sm-6 text-right"">
                                            <a href=""#"" class=""btn btn-primary"">Details</a>
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>                        

                    </div>

                </div>

            </div>

            <div class=""pager-wrappper clearfix"">

                <div class=""pager-innner"">

                    <div class=""clearfix"">
                        Showing reslut 1 to 15 from 248
                    </div>

                    <div class=""clearfix"">
                        <nav class=""pager-center"">
                         ");
            WriteLiteral(@"   <ul class=""pagination"">
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
                                    <a href=""#"" aria-label=""Next"">
                                        <span aria-hidden=""true"">&raquo;</span>
                                    </a>
                                </li>
                   ");
            WriteLiteral("         </ul>\r\n                        </nav>\r\n                    </div>\r\n\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(" \r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b458f517d32b143182d8878137bdb0ad8d29b0df24956", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b458f517d32b143182d8878137bdb0ad8d29b0df26052", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b458f517d32b143182d8878137bdb0ad8d29b0df27148", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b458f517d32b143182d8878137bdb0ad8d29b0df28244", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b458f517d32b143182d8878137bdb0ad8d29b0df29340", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
