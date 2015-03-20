using dTemplate.Domain.Models;
using Hangerd.Specification;

namespace dTemplate.Domain.Specifications
{
	public class AccountSpecifications : SpecificationsBase<Account>
	{
		public static Specification<Account> LoginNameEquals(string loginName)
		{
			return new DirectSpecification<Account>(a => a.LoginName == loginName);
		}
	}
}
