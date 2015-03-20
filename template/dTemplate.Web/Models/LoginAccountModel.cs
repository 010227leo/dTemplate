using dTemplate.Application.DataObjects;
using dTemplate.Application.Services;
using Hangerd.Components;
using Hangerd.Mvc.Authentication;
using System.Web;

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
