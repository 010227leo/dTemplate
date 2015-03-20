using Hangerd.Entity;
using Hangerd.Specification;

namespace dTemplate.Domain.Specifications
{
	public class SpecificationsBase<TEntity>
		where TEntity : EntityBase
	{
		public static Specification<TEntity> IdEquals(string id)
		{
			return new DirectSpecification<TEntity>(e => e.Id == id);
		}
	}
}
