using dTemplate.Domain.Events;
using dTemplate.Domain.Events.Handlers;
using dTemplate.Domain.Services;
using dTemplate.Domain.Services.Implementation;
using Hangerd.Bootstrapper;
using Hangerd.Event;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;

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
			_container.RegisterMultipleTypesAsPerResolve<IDomainEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();
		}
	}
}
