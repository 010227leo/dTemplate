using System.Web.Mvc;
using dTemplate.Web.Authentication;
using Hangerd.Mvc;

namespace dTemplate.Web.Controllers
{
	public class HomeController : HangerdController
	{
		[AccountAuth]
		public ActionResult Index()
		{
			return View();
		}
	}
}
