namespace dTemplate.Domain.Repositories
{
	using dTemplate.Domain.Models;
	using Hangerd.Repository;

	public interface IAccountRepository : IRepository<Account>
	{
		bool ExistLoginName(string loginName);
	}
}
