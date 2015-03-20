using Hangerd.Mvc;
using System.Web.Mvc;

namespace dTemplate.Web.Controllers
{
	public class HomeController : HangerdController
	{
		[AccountLoginAuth]
		public ActionResult Index()
		{
			return View();
		}
	}
}
