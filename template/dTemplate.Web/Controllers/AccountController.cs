using System;
using System.Linq;
using System.Web.Mvc;
using dTemplate.Application.Dtos;
using Hangerd.Mvc;
using Hangerd.Mvc.Authentication;
using Hangerd.Mvc.ViewModels;
using dTemplate.Application.Services;
using dTemplate.Web.Authentication;
using dTemplate.Web.Models;

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
			if (AccountLoginContext.Current != null)
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

			return OperationJsonResult(success, result.Message);
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

			return OperationJsonResult(result);
		}

		#endregion
	}
}