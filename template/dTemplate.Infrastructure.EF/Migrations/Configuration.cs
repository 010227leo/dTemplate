namespace dTemplate.Infrastructure.EF.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<dTemplateUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
