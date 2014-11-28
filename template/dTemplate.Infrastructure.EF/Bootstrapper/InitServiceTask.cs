namespace dTemplate.Infrastructure.EF.Bootstrapper
{
	using dTemplate.Infrastructure.EF.Migrations;
	using Hangerd.Bootstrapper;
	using HPVP.Infrastructure.EF;
	using Microsoft.Practices.Unity;
	using System.Data.Entity;

    public class InitServiceTask : InitServiceBootstrapperTask
    {
        public InitServiceTask(IUnityContainer container) : base(container) { }

		public override void Execute()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<dTemplateUnitOfWork, Configuration>());
		}
    }
}
