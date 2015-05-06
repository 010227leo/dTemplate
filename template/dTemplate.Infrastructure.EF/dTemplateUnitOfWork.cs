using System.Data.Entity;
using Hangerd.EntityFramework;
using dTemplate.Infrastructure.EF.ModelConfigurations;

namespace dTemplate.Infrastructure.EF
{
	public class dTemplateUnitOfWork : EfRepositoryContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations
				.Add(new AccountConfig());

			base.OnModelCreating(modelBuilder);
		}
	}
}
