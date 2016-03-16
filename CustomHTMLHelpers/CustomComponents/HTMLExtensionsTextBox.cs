using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace CustomHTMLHelpers
{
    public static class HTMLExtensionsTextBox
    {
        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TValue>> expression, string placeholder = "",
            HTMLExtensionsCommon.HTML5InputTypes type = HTMLExtensionsCommon.HTML5InputTypes.text, object htmlAttributes = null)
        {
            RouteValueDictionary rvd;

            // Creates the route value dictionary.
            rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            // Add other attributes here.
            rvd.Add("type", type.ToString());
            rvd.Add("placeholder", placeholder);

            return InputExtensions.TextBoxFor(htmlHelper, expression, rvd);
        }
    }
}
