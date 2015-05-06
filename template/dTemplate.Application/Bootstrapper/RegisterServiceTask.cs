﻿using Hangerd.Bootstrapper;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;
using dTemplate.Application.Services;
using dTemplate.Application.Services.Implementation;

namespace dTemplate.Application.Bootstrapper
{
	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			//application services
			_container.RegisterTypeAsPerResolve<IAccountService, AccountService>();
		}
	}
}
