using dTemplate.Domain.Models;
using dTemplate.Domain.Repositories;
using Hangerd;

namespace dTemplate.Domain.Services.Implementation
{
	public class AccountDomainService : IAccountDomainService
	{
		public Account RegisterNewAccount(IAccountRepository repository, string loginName, string unencryptedPassword, string name)
		{
			if (repository.ExistLoginName(loginName))
				throw new HangerdException("登录账号已存在");

			return new Account(loginName, unencryptedPassword, name);
		}
	}
}
