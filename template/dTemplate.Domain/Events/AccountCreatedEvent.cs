using dTemplate.Domain.Models;
using Hangerd.Event;

namespace dTemplate.Domain.Events
{
	public class AccountCreatedEvent : DomainEvent
	{
		public Account Account { get; private set; }

		public AccountCreatedEvent(Account account)
		{
			Account = account;
		}
	}
}
