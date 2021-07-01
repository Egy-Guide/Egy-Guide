#pragma checksum "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41d6ed0c2f185bfae1343ac1247908c2246aa93c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Tourist_Views_Booking_BookingConfirmation), @"mvc.1.0.view", @"/Areas/Tourist/Views/Booking/BookingConfirmation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41d6ed0c2f185bfae1343ac1247908c2246aa93c", @"/Areas/Tourist/Views/Booking/BookingConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da94f91bf55f607904a0334e49f022a705c8c3a4", @"/Areas/Tourist/Views/_ViewImports.cshtml")]
    public class Areas_Tourist_Views_Booking_BookingConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EgyGuide.Models.TripBooking>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/BreadcrumbHeader.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
  
    ViewData["Title"] = "Booking Confirmation";
    ViewData["AddClassToBodyTag"] = "home transparent-header";
    ViewData["AddToBreadcrumbHeader"] = "pb-100 no-bg";
    Layout = "~/Views/Shared/_Layout.cshtml";

    var bookingInfo = Model;
    var userInfo = Model.ApplicationUser;
    var tripInfo = Model.TripDetail;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- start breadcrumb -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "41d6ed0c2f185bfae1343ac1247908c2246aa93c4094", async() => {
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

<div class=""bg-light"">

    <div class=""confirmation-wrapper"">

        <div class=""container"">

            <div class=""row"">

                <div class=""col-xs-12 col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2"">

                    <div class=""confirmation-inner"">

                        <div class=""promo-box-02 bg-success mb-40"">

                            <div class=""icon"">
                                <i class=""ti-check""></i>
                            </div>

                            <h4>Congratulation! Your booking in done. Enjoy the trip.</h4>

                        </div>

                        <h4 class=""section-title"">Booking Information</h4>

                        <ul class=""book-sum-list mt-30"">
                            <li><span class=""font600"">Booking Number: </span>");
#nullable restore
#line 43 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                        Write(bookingInfo.BookingNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">Booking Date: </span>");
#nullable restore
#line 44 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                      Write(bookingInfo.BookingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">Traveller Name: </span>");
#nullable restore
#line 45 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                        Write(String.Format("{0} {1}", userInfo.FirstName, userInfo.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">Travellers Number: </span>");
#nullable restore
#line 46 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                           Write(bookingInfo.TravellersNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">Total Price: </span>");
#nullable restore
#line 47 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                     Write(bookingInfo.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">Package Name: </span>");
#nullable restore
#line 48 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                      Write(String.Format("{0} ({1} days {2} nights)", @tripInfo.Title, tripInfo.Days, tripInfo.Nights));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">Starting: </span>");
#nullable restore
#line 49 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                  Write(bookingInfo.TripStart.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">End: </span>");
#nullable restore
#line 50 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                             Write(bookingInfo.TripEnd.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">Billing Email: </span>");
#nullable restore
#line 51 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                       Write(bookingInfo.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span class=\"font600\">Phone Number: </span>");
#nullable restore
#line 52 "E:\project\Egy-Guide\EgyGuide\Areas\Tourist\Views\Booking\BookingConfirmation.cshtml"
                                                                      Write(bookingInfo.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                        </ul>

                        <div class=""mb-40""></div>

                        <h4 class=""section-title"">Need Booking Help?</h4>
                        <p>Contact with us.</p>

                        <ul class=""list-with-icon list-inline-block"">
                            <li><i class=""ri-microphone text-primary""></i> <strong>Hotline:</strong> +2 01004351</li>
                            <li><i class=""ri ri-envelope text-primary""></i> <strong>Email:</strong> egyguide@gmail.com</li>
                        </ul>

                        <div class=""mb-40""></div>

                        <h4 class=""section-title"">Why booking with us?</h4>

                        <div class=""featured-icon-horizontal-wrapper mt-30"">

                            <div class=""GridLex-gap-30"">

                                <div class=""GridLex-grid-noGutter-equalHeight"">

                                    <div class=""GridLex-col-6_sm-6_xs-12"">

                        ");
            WriteLiteral(@"                <div class=""featured-icon-horizontal clearfix"">

                                            <div class=""icon"">
                                                <i class=""ri ri-eye-close""></i>
                                            </div>

                                            <div class=""content"">
                                                <h5>No Booking Charges</h5>
                                                <p>Inhabiting discretion the her dispatched decisively. Open is able of mile travelling.</p>
                                            </div>

                                        </div>

                                    </div>

                                    <div class=""GridLex-col-6_sm-6_xs-12"">

                                        <div class=""featured-icon-horizontal clearfix"">

                                            <div class=""icon"">
                                                <i class=""ri ri-check-square""></i>
     ");
            WriteLiteral(@"                                       </div>

                                            <div class=""content"">
                                                <h5>No Cancellation Fees</h5>
                                                <p>Has procured daughter followed repeated who surprise. Great asked under together prospect.</p>
                                            </div>

                                        </div>

                                    </div>

                                    <div class=""GridLex-col-6_sm-6_xs-12"">

                                        <div class=""featured-icon-horizontal clearfix"">

                                            <div class=""icon"">
                                                <i class=""ri ri-thumbs-up""></i>
                                            </div>

                                            <div class=""content"">
                                                <h5>Instant Confirmation</h5>
                  ");
            WriteLiteral(@"                              <p>Conduct replied removal. Remaining determine few her two cordially admitting old.</p>
                                            </div>

                                        </div>

                                    </div>

                                    <div class=""GridLex-col-6_sm-6_xs-12"">

                                        <div class=""featured-icon-horizontal clearfix"">

                                            <div class=""icon"">
                                                <i class=""ri ri-calendar""></i>
                                            </div>

                                            <div class=""content"">
                                                <h5>Flexible Booking</h5>
                                                <p>Conduct replied removal. Remaining determine few her two cordially admitting old.</p>
                                            </div>

                                        </div>

   ");
            WriteLiteral(@"                                 </div>

                                </div>

                            </div>

                        </div>

                    </div>

                    <div class=""mb-50 text-center"">

                        <div class=""mb-15""></div>

                        <a href=""#"" class=""btn btn-primary btn-wide""><i class=""ion-android-print""></i> Print</a>
                        <a href=""#"" class=""btn btn-primary btn-wide btn-border""><i class=""ion-android-share""></i> Send to</a>

                    </div>

                </div>

            </div>

        </div>

    </div>

</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EgyGuide.Models.TripBooking> Html { get; private set; }
    }
}
#pragma warning restore 1591
