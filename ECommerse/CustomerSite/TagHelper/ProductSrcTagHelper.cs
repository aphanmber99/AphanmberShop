using CustomerSite;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AuthoringTagHelpers.TagHelpers
{
    [HtmlTargetElement(Attributes="product-src")]
    public class EmailTagHelper : TagHelper
    {
        public string ProductSrc {get;set;}
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var srcValue = Startup.ResProductUri + "/"+ ProductSrc;
           output.Attributes.SetAttribute("src",srcValue);
        }
    }
}
