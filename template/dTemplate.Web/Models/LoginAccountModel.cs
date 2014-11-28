namespace dTemplate.Web.Models
{
	using dTemplate.Application.DataObjects;
	using dTemplate.Application.Services;
	using Hangerd.Components;
	using Hangerd.Mvc.Authentication;
	using System.Web;

	public class LoginAccountModel
	{
		private const string LOGIN_ACCOUNT_MODEL_KEY = "LOGIN_ACCOUNT_MODEL_KEY";

		private LoginAccountModel() { }

		public static AccountDto Current
		{
			get
			{
				if (HttpContext.Current == null)
				{
					return null;
				}

				var accountDto = HttpContext.Current.Items[LOGIN_ACCOUNT_MODEL_KEY] as AccountDto;

				if (accountDto == null)
				{
					var currentAccountId = LoginHelper.GetUserId();

					if (!string.IsNullOrWhiteSpace(currentAccountId))
					{
						var accountService = LocalServiceLocator.GetService<IAccountService>();

						accountDto = accountService.GetAccount(currentAccountId);

						if (accountDto != null)
						{
							HttpContext.Current.Items.Add(LOGIN_ACCOUNT_MODEL_KEY, accountDto);
						}
					}
				}

				return accountDto;
			}
		}
	}
}
