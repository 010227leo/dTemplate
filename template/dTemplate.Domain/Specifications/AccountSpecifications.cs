using Hangerd.Specification;
using dTemplate.Domain.Models;

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
