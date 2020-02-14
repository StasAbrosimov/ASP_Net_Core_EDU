using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFilters.Filters
{
    public class AutorizationFilter : Attribute, IAuthorizationFilter
    {
        int _id;
        string _token;
        public AutorizationFilter(int id, string token)
        {
            _id = id;
            _token = token;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.Headers.Add("Id", _id.ToString());
            context.HttpContext.Response.Headers.Add("Token", _token);
        }
    }
}
