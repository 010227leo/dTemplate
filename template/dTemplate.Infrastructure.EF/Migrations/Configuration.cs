namespace dTemplate.Infrastructure.EF.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<HPVP.Infrastructure.EF.dTemplateUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
