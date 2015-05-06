using System.Web;
using Hangerd.Components;
using Hangerd.Mvc.Authentication;
using dTemplate.Application.DataObjects;
using dTemplate.Application.Services;

namespace dTemplate.Web.Models
{
	public static class LoginAccountModel
	{
		private const string LoginAccountModelKey = "dTemplate.Web.Models.LoginAccountModelKey";

		public static AccountDto Current
		{
			get
			{
				if (HttpContext.Current == null)
					return null;

				var accountDto = HttpContext.Current.Items[LoginAccountModelKey] as AccountDto;

				if (accountDto != null)
					return accountDto;

				var currentAccountId = LoginHelper.GetUserId();

				if (string.IsNullOrWhiteSpace(currentAccountId))
					return null;

				var accountService = LocalServiceLocator.GetService<IAccountService>();

				accountDto = accountService.GetAccount(currentAccountId);

				if (accountDto != null)
					HttpContext.Current.Items.Add(LoginAccountModelKey, accountDto);

				return accountDto;
			}
		}
	}
}
