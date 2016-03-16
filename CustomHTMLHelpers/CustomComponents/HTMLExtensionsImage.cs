using System.Text;
using System.Web.Mvc;

// Dont use default name space, otherwise this html helper won't show up in razor view intellisence. so dont use(namespace CustomHTMLHelpers.CustomComponents)
namespace CustomHTMLHelpers
{
    public static class HTMLExtensionsImage
    {
        // Custom HTML Helper using StringBuilder class.
        public static MvcHtmlString Image(this HtmlHelper htmlHelper, string src, string altText)
        {
            StringBuilder sb = new StringBuilder(512);

            sb.AppendFormat("<img src='{0}' alt='{1}' />", src, altText);

            return MvcHtmlString.Create(sb.ToString());
        }

        // Custom HTML Helper using TagBuilder class.
        public static MvcHtmlString ImageTag(this HtmlHelper htmlHelper, string src, string altText, string cssClass, string name, object htmlAttributes = null)
        {
            TagBuilder tb = new TagBuilder("img");

            tb.MergeAttribute("src", src);
            tb.MergeAttribute("alt", altText);

            if(!string.IsNullOrWhiteSpace(cssClass))
                tb.AddCssClass(cssClass);

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = TagBuilder.CreateSanitizedId(name); // Any invalid character in the name is converted to underscore.
                tb.GenerateId(name);
                tb.MergeAttribute("name", name);
            }

            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
        }

        // Overloads of ImageTag method
        // Overload 1
        public static MvcHtmlString ImageTag(this HtmlHelper htmlHelper, string src, string altText, object htmlAttributes = null)
        {
            return HTMLExtensionsImage.ImageTag(htmlHelper, src, altText, string.Empty, string.Empty, htmlAttributes);
        }

        // Overloads of ImageTag method
        // Overload 2
        public static MvcHtmlString ImageTag(this HtmlHelper htmlHelper, string src, string altText, string cssClass, object htmlAttributes = null)
        {
            return HTMLExtensionsImage.ImageTag(htmlHelper, src, altText, cssClass, string.Empty, htmlAttributes);
        }

    }
}
