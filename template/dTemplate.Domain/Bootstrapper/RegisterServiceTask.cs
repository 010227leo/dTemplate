using Hangerd.Bootstrapper;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;
using dTemplate.Domain.Services;
using dTemplate.Domain.Services.Implementation;

namespace dTemplate.Domain.Bootstrapper
{
	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			//domain services
			_container.RegisterTypeAsSingleton<IAccountDomainService, AccountDomainService>();

			//domain events
		}
	}
}
