using ItVis.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ItVis.TagHelpers
{
    public class ReviewTagHelper : TagHelper
    {
        public List<ReviewViewModel>? Reviews { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;

            foreach (var item in Reviews)
            {
                TagBuilder infoBlock = new TagBuilder("div");
                TagBuilder userNameBlock = new TagBuilder("div");
                TagBuilder dateBlock = new TagBuilder("div");
                TagBuilder commentBlock = new TagBuilder("div");
                TagBuilder userNameContent = new TagBuilder("p");

                infoBlock.AddCssClass("review-info");
                userNameBlock.AddCssClass("user-name");
                dateBlock.AddCssClass("review-date");
                commentBlock.AddCssClass("review-comment");

                userNameContent.InnerHtml.Append(item.UserName);
                userNameBlock.InnerHtml.AppendHtml(userNameContent);
                infoBlock.InnerHtml.AppendHtml(userNameBlock);

                dateBlock.InnerHtml.Append(item.CommentDate.ToString("d"));               
                infoBlock.InnerHtml.AppendHtml(dateBlock);

                commentBlock.InnerHtml.Append(item.Comment);
                infoBlock.InnerHtml.AppendHtml(commentBlock);

                output.Content.AppendHtml(infoBlock);
            }
        }
    }
}
