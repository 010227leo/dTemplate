namespace dTemplate.Domain.Bootstrapper
{
	using dTemplate.Domain.Services;
	using dTemplate.Domain.Services.Implementation;
	using Hangerd.Bootstrapper;
	using Hangerd.Extensions;
	using Microsoft.Practices.Unity;

	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container) { }

		public override void Execute()
		{
			//domain services
			container.RegisterTypeAsPerResolve<IAccountDomainService, AccountDomainService>();

			//domain events
		}
	}
}
