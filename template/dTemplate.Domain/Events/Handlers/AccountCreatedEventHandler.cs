﻿using Hangerd.Event;

namespace dTemplate.Domain.Events.Handlers
{
	public class AccountCreatedEventHandler : IDomainEventHandler<AccountCreatedEvent>
	{
		public void Handle(AccountCreatedEvent @event)
		{
			//do something in domain
		}
	}
}
