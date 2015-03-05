namespace dTemplate.Infrastructure.EF.Repositories
{
	using dTemplate.Domain.Models;
	using dTemplate.Domain.Repositories;
	using dTemplate.Domain.Specifications;
	using Hangerd.EntityFramework;
	using Hangerd.Repository;
	using System.Linq;

	public class AccountRepository : EfRepository<Account>, IAccountRepository
	{
		public AccountRepository(IRepositoryContext context)
			: base(context)
		{ }

		public bool ExistLoginName(string loginName)
		{
			var spec = AccountSpecifications.NotDeleted() & AccountSpecifications.LoginNameEquals(loginName);

			return base.GetAll(spec, false).Count() > 0;
		}
	}
}
