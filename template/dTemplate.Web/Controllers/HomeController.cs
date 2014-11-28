namespace dTemplate.Web.Controllers
{
	using Hangerd.Mvc;
	using System.Web.Mvc;

    public class HomeController : HangerdController
    {
		[AccountLoginAuth]
        public ActionResult Index()
        {
            return View();
        }
	}
}