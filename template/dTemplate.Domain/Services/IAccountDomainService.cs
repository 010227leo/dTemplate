namespace dTemplate.Domain.Services
{
	using dTemplate.Domain.Models;

	public interface IAccountDomainService
	{
		/// <summary>
		/// 注册Account
		/// </summary>
		Account RegisterNewAccount(string loginName, string unencryptedPassword, string name);
	}
}
