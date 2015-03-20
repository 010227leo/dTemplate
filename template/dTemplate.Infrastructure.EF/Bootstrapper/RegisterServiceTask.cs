using dTemplate.Domain.Repositories;
using dTemplate.Infrastructure.EF.Repositories;
using Hangerd.Bootstrapper;
using Hangerd.Extensions;
using Hangerd.Repository;
using Microsoft.Practices.Unity;

namespace dTemplate.Infrastructure.EF.Bootstrapper
{
	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			//unit of work
			_container.RegisterTypeAsPerRequest<IRepositoryContext, dTemplateUnitOfWork>();

			//repositories
			_container.RegisterTypeAsPerRequest<IAccountRepository, AccountRepository>();
		}
	}
}
