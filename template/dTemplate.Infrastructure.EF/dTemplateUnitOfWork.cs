﻿namespace dTemplate.Infrastructure.EF
{
	using dTemplate.Infrastructure.EF.ModelConfigurations;
	using Hangerd.EntityFramework;
	using System.Data.Entity;

	public class dTemplateUnitOfWork : EfRepositoryContext
	{
		public dTemplateUnitOfWork() { }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations
				.Add(new AccountConfig());

			base.OnModelCreating(modelBuilder);
		}
	}
}
