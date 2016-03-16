using CustomHTMLHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomHTMLHelpers
{
    public static class HTMLExtentionsButton
    {
        public static MvcHtmlString BootstrapButton(
            this HtmlHelper htmlHelper, string innerHtml, string cssClass, string name, string title, bool isFormNoValidate = false,
            bool isAutoFocus = false, HTMLExtensionsCommon.HtmlbuttonTypes buttonType = HTMLExtensionsCommon.HtmlbuttonTypes.submit, object htmlAttributes = null)
        {
            TagBuilder tb = new TagBuilder("button");

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                if (!cssClass.Contains("btn-"))
                    cssClass = "btn-primary" + cssClass;                    
            }
            else
                tb.AddCssClass("btn-primary");

            tb.AddCssClass(cssClass);
            tb.AddCssClass("btn");

            tb.InnerHtml = innerHtml;            

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = TagBuilder.CreateSanitizedId(name); // Any invalid character in the name is converted to 'underscore'.
                tb.GenerateId(name);
                tb.MergeAttribute("name", name);
            }

            if (!string.IsNullOrWhiteSpace(title))
            {                
                tb.MergeAttribute("name", name);
            }

            if (isFormNoValidate)
            {
                tb.MergeAttribute("isFormNoValidate", "isFormNoValidate");
            }

            if (isAutoFocus)
            {
                tb.MergeAttribute("isFormNoValidate", "isAutoFocus");
            }

            switch (buttonType)
            {
                case HTMLExtensionsCommon.HtmlbuttonTypes.submit:
                    tb.MergeAttribute("type", "submit");
                    break;
                case HTMLExtensionsCommon.HtmlbuttonTypes.button:
                    tb.MergeAttribute("type", "button");
                    break;
                case HTMLExtensionsCommon.HtmlbuttonTypes.reset:
                    tb.MergeAttribute("type", "reset");
                    break;
            }            

            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return MvcHtmlString.Create(tb.ToString());
        }
    }
}
