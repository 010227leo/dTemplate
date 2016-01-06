using Hangerd.Domain.Entity;
using Hangerd.Domain.Specification;

namespace dTemplate.Domain.Specifications
{
	public static class DeletableSpecifications<TEntity>
		where TEntity : EntityBase, IDeletable
	{
		public static Specification<TEntity> NotDeleted()
		{
			return new DirectSpecification<TEntity>(e => !e.IsDeleted);
		}
	}
}
