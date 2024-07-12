using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsHub.Models
{
    public class CustomAuthentication : ActionFilterAttribute
    {
       

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (!context.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        // Redirect unauthenticated users to the forbidden page
        //        context.Result = new RedirectToActionResult("ForbiddenPage", "Login", null);
        //    }
        //    base.OnActionExecuting(context);
        //}
   
}
}
