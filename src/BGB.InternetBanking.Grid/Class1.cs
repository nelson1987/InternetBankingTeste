using System;

namespace BGB.InternetBanking.Grid
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Text;

    [HtmlTargetElement("bg-grid")]
    public class MyCustomTagHelper : TagHelper
    {
        public string Name { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "CustumTagHelper";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat("<span>Hi! {0}</span>", this.Name);

            output.PreContent.SetHtmlContent(sb.ToString());
        }
    }
}
