using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BitirmeOdev.Extensions;
using BitirmeOdev.Models;

namespace BitirmeOdev.Filters
{
    public class AuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.HttpContext.Session.Keys.Any())
            {
                var kullanici = filterContext.HttpContext.Session.GetObject<Kullanici>("kullanici");
                if (kullanici.Admin)
                    filterContext.Result = new RedirectResult("/Home/Index");
            }
            else
                filterContext.Result = new RedirectResult("/Home/Index");
        }
    }
}
