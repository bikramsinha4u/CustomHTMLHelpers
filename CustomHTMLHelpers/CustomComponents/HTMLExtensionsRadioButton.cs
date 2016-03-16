using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace CustomHTMLHelpers
{
    public static class HTMLExtensionsRadioButton
    {
        public static MvcHtmlString BootstrapRadioButtonFor<TModel>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression, object value, object htmlAttributes = null)
        {
            StringBuilder sb = new StringBuilder(512);
            RouteValueDictionary rvd;

            rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));            

            sb.Append("<div class='radio'>");
            sb.Append("<label>");

            sb.Append(InputExtensions.RadioButtonFor(htmlHelper, expression, value, rvd));
            //sb.Append(text);

            sb.Append("</label>");
            sb.Append("</div>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
