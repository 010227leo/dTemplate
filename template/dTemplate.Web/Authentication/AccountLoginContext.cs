using System.Web;
using dTemplate.Application.Dtos;
using dTemplate.Application.Services;
using Hangerd.Components;
using Hangerd.Mvc.Authentication;

namespace dTemplate.Web.Authentication
{
	public static class AccountLoginContext
	{
		private const string AccountCachingKey = "dTemplate.Web.AccountCachingKey";

		public static AccountDto Current
		{
			get
			{
				if (HttpContext.Current == null || !LoginHelper.IsLogin())
					return null;

				var account = HttpContext.Current.Items[AccountCachingKey] as AccountDto;

				if (account != null)
					return account;

				var accountService = LocalServiceLocator.GetService<IAccountService>();

				account = accountService.GetAccount(LoginHelper.GetUserId());

				if (account != null)
					HttpContext.Current.Items.Add(AccountCachingKey, account);

				return account;
			}
		}
	}
}
