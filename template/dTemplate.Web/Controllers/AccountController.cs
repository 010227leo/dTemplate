using System;
using System.Linq;
using System.Web.Mvc;
using dTemplate.Application.DataObjects;
using dTemplate.Application.Services;
using dTemplate.Web.Models;
using Hangerd.Mvc;
using Hangerd.Mvc.Authentication;
using Hangerd.Mvc.ViewModels;

namespace dTemplate.Web.Controllers
{
	public class AccountController : HangerdController
    {
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		#region Login

		public ActionResult Login()
		{
			if (LoginAccountModel.Current != null)
				return RedirectToAction("Index", "Home");

			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginModel model)
		{
			var result = _accountService.GetAccountForLogin(model.LoginName, model.Password);
			var success = result.Value != null;

			if (success)
				LoginHelper.Login(result.Value.Id, string.Empty, DateTime.Now.AddHours(2));

			return JsonContent(new { Success = success, Message = result.Message });
		}

		public ActionResult SignOut()
		{
			LoginHelper.SignOut();

			return RedirectToAction("Login");
		}

		#endregion

		#region Register

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(AccountRegisterModel model)
		{
			if (!ModelState.IsValid)
			{
				var errorMessage = ModelState.Values.First(v => v.Errors.Count > 0).Errors.First().ErrorMessage;

				return JsonContent(new { Success = false, Message = errorMessage });
			}

			var result = _accountService.RegisterAccount(new AccountDto
			{
				LoginName = model.LoginName,
				Password = model.Password,
				Name = model.Name
			});

			return JsonContent(new { Success = result.Value, Message = result.Message });
		}

		#endregion
	}
}