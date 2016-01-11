using dTemplate.Domain.Events;
using Hangerd.Event;

namespace dTemplate.Application.EventHandlers
{
	public class SendEmailHandler : IEventHandler<AccountCreatedEvent>
	{
		public void Handle(AccountCreatedEvent @event)
		{
			//send an email
		}
	}
}
