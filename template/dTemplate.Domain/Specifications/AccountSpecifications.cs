using dTemplate.Domain.Models;
using Hangerd.Domain.Specification;

namespace dTemplate.Domain.Specifications
{
	public class AccountSpecifications : EntitySpecifications<Account>
	{
		public static Specification<Account> LoginNameEquals(string loginName)
		{
			return new DirectSpecification<Account>(a => a.LoginName == loginName);
		}
	}
}
