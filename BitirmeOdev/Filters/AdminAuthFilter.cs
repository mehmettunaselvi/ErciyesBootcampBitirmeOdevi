using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BitirmeOdev.Models;
using BitirmeOdev.Extensions;

namespace BitirmeOdev.Filters
{
    public class AdminAuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.HttpContext.Session.Keys.Any())
            {
                var kullanici = filterContext.HttpContext.Session.GetObject<Kullanici>("kullanici");
                if (!kullanici.Admin)
                    filterContext.Result = new RedirectResult("/Home/Index");
            }
            else
                filterContext.Result = new RedirectResult("/Home/Index");
        }
    }
}
