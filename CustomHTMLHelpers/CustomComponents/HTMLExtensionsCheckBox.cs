using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace CustomHTMLHelpers
{
    public static class HTMLExtensionsCheckBox
    {
        public static MvcHtmlString BootstrapCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression, string text, object htmlAttributes = null)
        {
            StringBuilder sb = new StringBuilder(512);
            RouteValueDictionary rvd;

            rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            sb.Append("<div class='checkbox'>");
            sb.Append("<label>");

            sb.Append(InputExtensions.CheckBoxFor(htmlHelper, expression, rvd));
            sb.Append(text);

            sb.Append("</label>");
            sb.Append("</div>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
