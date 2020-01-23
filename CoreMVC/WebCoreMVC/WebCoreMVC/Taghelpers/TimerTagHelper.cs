using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreMVC.Taghelpers
{
    public class TimerTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h1";
            output.Content.SetContent($"local time is:{DateTime.Now.ToLongTimeString()}");
        }
    }

    public class DateTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetContent($"Текущая дата: {DateTime.Now.ToString("dd/mm/yyyy")}");
        }
    }
    public class SummaryTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            // получаем вложенный контекст из дочерних tag-хелперов
            var target = await output.GetChildContentAsync();
            var content = "<h3>Общая информация</h3>" + target.GetContent();
            output.Content.SetHtmlContent(content);
        }
    }
}
