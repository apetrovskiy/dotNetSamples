namespace SportsStore.WebUI.HtmlHelpers
{
    using SportsStore.WebUI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", pageUrl(i));
                tagBuilder.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tagBuilder.AddCssClass("selected");
                    tagBuilder.AddCssClass("btn-primary");
                }
                tagBuilder.AddCssClass("btn btn-default");
                result.Append(tagBuilder.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}