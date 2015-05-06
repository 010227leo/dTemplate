using System.Web.Mvc;
using Hangerd.Mvc;

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
