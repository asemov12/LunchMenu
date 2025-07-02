using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LunchMenu.Web.Filters
{
    public class UserAuthorizationAttribute: Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var customerId = context.HttpContext.Session.GetInt32("CustomerId");

            if (customerId == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
