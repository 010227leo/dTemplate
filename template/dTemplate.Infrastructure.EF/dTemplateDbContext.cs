using System.Data.Entity;
using dTemplate.Infrastructure.EF.ModelConfigurations;
using Hangerd.EntityFramework;

namespace dTemplate.Infrastructure.EF
{
	public class dTemplateDbContext : HangerdDbContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations
				.Add(new AccountConfig());

			base.OnModelCreating(modelBuilder);
		}
	}
}
