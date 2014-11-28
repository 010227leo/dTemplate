namespace dTemplate.Application.Bootstrapper
{
	using AutoMapper;
	using dTemplate.Application.DataObjects;
	using dTemplate.Domain.Models;
	using Hangerd.Bootstrapper;
	using Microsoft.Practices.Unity;

	public class InitServiceTask : InitServiceBootstrapperTask
	{
		public InitServiceTask(IUnityContainer container) : base(container) { }

		public override void Execute()
		{
			this.ConfigureAutoMapper();
		}

		private void ConfigureAutoMapper()
		{
			Mapper.CreateMap<Account, AccountDto>();
		}
	}
}
