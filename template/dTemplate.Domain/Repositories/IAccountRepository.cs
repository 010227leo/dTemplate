using Hangerd.Repository;
using dTemplate.Domain.Models;

namespace dTemplate.Domain.Repositories
{
	public interface IAccountRepository : IRepository<Account>
	{
		bool ExistLoginName(string loginName);
	}
}
