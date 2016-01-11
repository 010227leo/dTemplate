using dTemplate.Domain.Repositories;
using dTemplate.Infrastructure.EF.Repositories;
using Hangerd.Bootstrapper;
using Hangerd.Extensions;
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
			//DbContext
			IocContainer.RegisterType<dTemplateDbContext>();

			//Repository
			IocContainer.RegisterTypeAsSingleton<IAccountRepository, AccountRepository>();
		}
	}
}
