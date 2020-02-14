using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace MVCFilters.Filters
{
    public class SimpleResourceFilter : Attribute, IResourceFilter
    {
        ILogger _logger;

        public SimpleResourceFilter(ILoggerFactory loggerF)
        {
            _logger = loggerF.CreateLogger("SimpleResourceFilter");
            _logger.LogInformation("SimpleResourceFilter new instance");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _logger.LogInformation($"OnResourceExecuted - {DateTime.Now}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {


            _logger.LogInformation($"OnResourceExecuting - {DateTime.Now}");
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd/MM/yyyy_HH-mm-ss"));
        }
    }
}
