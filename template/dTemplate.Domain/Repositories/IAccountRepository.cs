using dTemplate.Domain.Models;
using Hangerd.Repository;

namespace dTemplate.Domain.Repositories
{
	public interface IAccountRepository : IRepository<Account>
	{
		bool ExistLoginName(string loginName);
	}
}
