using AutoMapper;
using dTemplate.Application.Dtos;
using dTemplate.Domain.Models;
using Hangerd.Bootstrapper;
using Hangerd.Components;
using Hangerd.Event.Bus;
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
