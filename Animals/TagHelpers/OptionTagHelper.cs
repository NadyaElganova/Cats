using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Animals.TagHelpers
{
    [HtmlTargetElement("option", Attributes = "cat")]
    public class OptionTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Context { get; set; }
        public OptionTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(Context);
            output.TagName = "option";
            output.Attributes.Add("class", "data-option");
            //output.Attributes.Add("href", $"/Home/Movie/{Cinema.imdbID}");

        }
    }
}
