using ItVis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ItVis.TagHelpers
{
    public class FilterTagHelper : TagHelper
    {
        public List<ProductFilters> ProductFilters { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<TagBuilder> values = new List<TagBuilder>();
            int i = -1;
            string propertyName = "";
            foreach(var filter in ProductFilters)
            {
                if(propertyName != filter.DisplayName)
                {
                    i++;
                    propertyName = filter.DisplayName;
                    if(values.Count != 0)
                    {
                        CreateFilterValues(values, output);
                    }
                    
                    CreateTag(output, filter);
                    values.Clear();
                }

                if(propertyName == filter.DisplayName)
                {
                    TagBuilder filterValue = new TagBuilder("p");
                    filterValue.InnerHtml.Append(filter.PropertyValue);
                    filterValue.InnerHtml.Append(filter.EngUnit);
                    values.Add(filterValue);
                }
            }
            TagBuilder submit = new TagBuilder("input");
            submit.MergeAttribute("type", "submit");
            submit.MergeAttribute("value", "Применить");
            output.Content.AppendHtml(submit);
        }
        private void CreateTag(TagHelperOutput output, ProductFilters filter)
        {
            TagBuilder displayName = new TagBuilder("div");
            displayName.AddCssClass("filter-name");
            displayName.InnerHtml.Append($"{filter.DisplayName}");

            output.Content.AppendHtml(displayName);
        }
        private void CreateFilterValues(List<TagBuilder> tags, TagHelperOutput output)
        {
            TagBuilder filterValues = new TagBuilder("div");
            filterValues.MergeAttribute("id", "filter-dropdown");
            filterValues.AddCssClass("filter-value");
            foreach (var tag in tags)
            {
                TagBuilder radio = new TagBuilder("input");
                radio.MergeAttribute("type", "radio");

                filterValues.InnerHtml.AppendHtml(radio);
                filterValues.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(filterValues);
        }
    }
}
