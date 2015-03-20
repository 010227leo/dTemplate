using dTemplate.Domain.Models;

namespace dTemplate.Domain.Services
{
	public interface IAccountDomainService
	{
		/// <summary>
		/// 注册Account
		/// </summary>
		Account RegisterNewAccount(string loginName, string unencryptedPassword, string name);
	}
}
