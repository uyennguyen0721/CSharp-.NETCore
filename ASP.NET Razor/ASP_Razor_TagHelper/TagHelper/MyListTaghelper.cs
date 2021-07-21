using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASP_Razor_TagHelper.TagHelper 
{

    // thẻ sẽ là mylist
    [HtmlTargetElement("mylist")]
    public class MyListTagHelper : ITagHelper
    {
        public int Order => throw new NotImplementedException();

        // Thuộc tính sẽ là list-title
        public string ListTitle { get; set; }

        // Thuộc tính sẽ là list-items
        public List<string> ListItems { set; get; }

        public void Init(TagHelperContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";    // ul sẽ thay cho myul
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("class", "list-group");
            output.PreElement.AppendHtml($"<h2>{ListTitle}</h2>");


            StringBuilder content = new StringBuilder();
            foreach (var item in ListItems)
            {
                content.Append($@"<li class=""list-group-item"">{item}</li>");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }

}
