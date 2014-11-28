namespace dTemplate.Domain.Specifications
{
	using dTemplate.Domain.Models;
	using Hangerd.Specification;

	public class AccountSpecifications
	{
		public static Specification<Account> LoginNameEquals(string loginName)
		{
			return new DirectSpecification<Account>(a => a.LoginName == loginName);
		}

		public static Specification<Account> NotDeleted()
		{
			return new DirectSpecification<Account>(a => !a.IsDeleted);
		}
	}
}
