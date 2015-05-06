using System.Linq;
using Hangerd.EntityFramework;
using Hangerd.Repository;
using dTemplate.Domain.Models;
using dTemplate.Domain.Repositories;
using dTemplate.Domain.Specifications;

namespace dTemplate.Infrastructure.EF.Repositories
{
	public class AccountRepository : EfRepository<Account>, IAccountRepository
	{
		public AccountRepository(IRepositoryContext context)
			: base(context)
		{
		}

		public bool ExistLoginName(string loginName)
		{
			var spec = DeletableSpecifications<Account>.NotDeleted() & AccountSpecifications.LoginNameEquals(loginName);

			return GetAll(spec, false).Any();
		}
	}
}
