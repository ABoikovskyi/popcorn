using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PopCorn.Controllers
{
	public class BaseController : Controller
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			ViewBag.IsAdmin = User?.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value == "admin";
		}
	}
}