using System.Data.Entity.Migrations;

namespace dTemplate.Infrastructure.EF.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<dTemplateDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}
	}
}
