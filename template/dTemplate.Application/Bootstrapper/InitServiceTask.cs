using AutoMapper;
using dTemplate.Application.Dtos;
using Hangerd.Bootstrapper;
using Microsoft.Practices.Unity;
using dTemplate.Domain.Models;
using Hangerd.Components;
using Hangerd.Event.Bus;

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

			RegisterEventHandlers();
		}

		private static void ConfigureAutoMapper()
		{
			Mapper.CreateMap<Account, AccountDto>();
		}

		private static void RegisterEventHandlers()
		{
			var dispatcher = LocalServiceLocator.GetService<IEventDispatcher>();

			dispatcher.AutoRegister();
		}
	}
}
