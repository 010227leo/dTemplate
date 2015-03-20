using AutoMapper;
using dTemplate.Application.DataObjects;
using dTemplate.Domain.Models;
using Hangerd.Bootstrapper;
using Microsoft.Practices.Unity;

namespace dTemplate.Application.Bootstrapper
{
	public class InitServiceTask : InitServiceBootstrapperTask
	{
		public InitServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			ConfigureAutoMapper();
		}

		private static void ConfigureAutoMapper()
		{
			Mapper.CreateMap<Account, AccountDto>();
		}
	}
}
