namespace dTemplate.Domain.Services.Implementation
{
	using dTemplate.Domain.Models;
	using dTemplate.Domain.Repositories;
	using Hangerd;

	public class AccountDomainService : IAccountDomainService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountDomainService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public Account RegisterNewAccount(string loginName, string unencryptedPassword, string name)
		{
			if (_accountRepository.ExistLoginName(loginName))
			{
				throw new HangerdException("登录账号已存在");
			}

			return new Account(loginName, unencryptedPassword, name);
		}
	}
}
