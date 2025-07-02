using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LunchMenu.Web.Filters
{
    public class UserRoleAttribute: Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var customerId = context.HttpContext.Session.GetInt32("CustomerId");
            var customerType = context.HttpContext.Session.GetString("Type");

            if (customerId == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            if (customerType == null || customerType != "special")
            {
                context.Result = new ForbidResult(); // or RedirectToAction("AccessDenied", "Home")
            }
        }
    
    }
}
