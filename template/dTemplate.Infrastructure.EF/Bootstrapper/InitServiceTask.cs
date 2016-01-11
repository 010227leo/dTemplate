using System.Data.Entity;
using dTemplate.Infrastructure.EF.Migrations;
using Hangerd.Bootstrapper;
using Microsoft.Practices.Unity;

namespace dTemplate.Infrastructure.EF.Bootstrapper
{
	public class InitServiceTask : InitServiceBootstrapperTask
	{
		public InitServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<dTemplateDbContext, Configuration>());
		}
	}
}
