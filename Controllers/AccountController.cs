using Microsoft.AspNetCore.Mvc;

namespace LanchesJa.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
