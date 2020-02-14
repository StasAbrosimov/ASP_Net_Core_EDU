using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVCFilters.Filters
{
    public class AsyncIEResourceFilter : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            bool canGo = true;

            string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
            if (Regex.IsMatch(userAgent, "MSIE|Trident|Presto"))
            {
                context.Result = new ContentResult { Content = "Ваш браузер устарел" };
                canGo = false;
            }
            else if (Regex.IsMatch(userAgent, "YaBrowser")) 
            {
                context.Result = new ContentResult { Content = "Ваш браузер дерьмо" };
                canGo = false;
            }
            else if(Regex.IsMatch(userAgent, "(mail.ru)", RegexOptions.IgnoreCase))
            {
                canGo = false;
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            } else
                await next();            
        }
    }
}
