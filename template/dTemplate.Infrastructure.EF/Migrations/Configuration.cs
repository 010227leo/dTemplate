using System.Data.Entity.Migrations;

namespace dTemplate.Infrastructure.EF.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<dTemplateUnitOfWork>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}
	}
}
