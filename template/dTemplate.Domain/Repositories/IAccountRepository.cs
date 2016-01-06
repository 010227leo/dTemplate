using dTemplate.Domain.Models;
using Hangerd.Domain.Repository;

namespace dTemplate.Domain.Repositories
{
	public interface IAccountRepository : IRepository<Account>
	{
		bool ExistLoginName(string loginName);
	}
}
