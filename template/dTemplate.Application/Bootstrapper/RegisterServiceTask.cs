namespace dTemplate.Application.Bootstrapper
{
	using dTemplate.Application.Services;
	using dTemplate.Application.Services.Implementation;
	using Hangerd.Bootstrapper;
	using Hangerd.Extensions;
	using Microsoft.Practices.Unity;

	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container) { }

		public override void Execute()
		{
			//application services
			container.RegisterTypeAsPerResolve<IAccountService, AccountService>();
		}
	}
}
