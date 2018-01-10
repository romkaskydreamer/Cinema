using System.Linq;
using System.Web.Mvc;

namespace CinemaBookingWeb.Filters
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public AdminAuthorizeAttribute() { }

        public AdminAuthorizeAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles.Select(x => x));
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            bool isAuthenticAttribute =
                (filterContext.ActionDescriptor.IsDefined(typeof(AdminAuthorizeAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AdminAuthorizeAttribute), true)) &&
                filterContext.HttpContext.User.Identity.IsAuthenticated;
            if (!isAuthenticAttribute) return;
            UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //
            }
            filterContext.Result =
                new RedirectResult(urlHelper.Action("Index", "Home", new { area = "" }));
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}