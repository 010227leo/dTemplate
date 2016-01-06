using dTemplate.Domain.Models;
using dTemplate.Domain.Repositories;

namespace dTemplate.Domain.Services
{
	public interface IAccountDomainService
	{
		/// <summary>
		/// 注册Account
		/// </summary>
		Account RegisterNewAccount(IAccountRepository repository, string loginName, string unencryptedPassword, string name);
	}
}
