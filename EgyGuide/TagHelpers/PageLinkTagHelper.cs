using EgyGuide.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.TagHelpers
{
    [HtmlTargetElement("ul", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {       
        public PagingInfo PageModel { get; set; }
        public bool PageEnabled { get; set; }
        //public string PageClass { get; set; }
        //public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder tagDiv = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder result = new TagBuilder("li");
                TagBuilder tag = new TagBuilder("a");
                string url = PageModel.UrlParam.Replace(":", i.ToString());
                tag.Attributes["href"] = url;
                if (PageEnabled)
                {
                    result.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : null);
                }

                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
                tagDiv.InnerHtml.AppendHtml(result);
            }

            output.Content.AppendHtml(tagDiv.InnerHtml);
        }
    }
}
