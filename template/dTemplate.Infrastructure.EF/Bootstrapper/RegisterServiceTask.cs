namespace dTemplate.Infrastructure.EF.Bootstrapper
{
	using dTemplate.Domain.Repositories;
	using dTemplate.Infrastructure.EF.Repositories;
	using Hangerd.Bootstrapper;
	using Hangerd.Extensions;
	using Hangerd.Repository;
	using HPVP.Infrastructure.EF;
	using Microsoft.Practices.Unity;

	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container) { }

		public override void Execute()
		{
			//unit of work
			container.RegisterTypeAsPerRequest<IRepositoryContext, dTemplateUnitOfWork>();

			//repositories
			container.RegisterTypeAsPerRequest<IAccountRepository, AccountRepository>();
		}
	}
}
