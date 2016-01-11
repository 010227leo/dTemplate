using System.Linq;
using dTemplate.Domain.Models;
using dTemplate.Domain.Repositories;
using dTemplate.Domain.Specifications;
using Hangerd.EntityFramework;
using Hangerd.EntityFramework.Repository;

namespace dTemplate.Infrastructure.EF.Repositories
{
	public class AccountRepository : EfRepositoryBase<dTemplateDbContext, Account>, IAccountRepository
	{
		public AccountRepository(IDbContextProvider<dTemplateDbContext> dbContextProvider)
			: base(dbContextProvider)
		{
		}

		public bool ExistLoginName(string loginName)
		{
			var spec = DeletableSpecifications<Account>.NotDeleted() & AccountSpecifications.LoginNameEquals(loginName);

			return GetAll(spec, false).Any();
		}
	}
}
