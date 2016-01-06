using Hangerd.Bootstrapper;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;
using dTemplate.Domain.Repositories;
using dTemplate.Infrastructure.EF.Repositories;

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
			_container.RegisterType<dTemplateDbContext>();

			//Repository
			_container.RegisterTypeAsSingleton<IAccountRepository, AccountRepository>();
		}
	}
}
