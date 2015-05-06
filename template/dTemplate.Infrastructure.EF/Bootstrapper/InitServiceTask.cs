using System.Data.Entity;
using Hangerd.Bootstrapper;
using Microsoft.Practices.Unity;
using dTemplate.Infrastructure.EF.Migrations;

namespace dTemplate.Infrastructure.EF.Bootstrapper
{
	public class InitServiceTask : InitServiceBootstrapperTask
	{
		public InitServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<dTemplateUnitOfWork, Configuration>());
		}
	}
}
