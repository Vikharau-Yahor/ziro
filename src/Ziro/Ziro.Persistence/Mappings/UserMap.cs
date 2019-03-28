using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class UserMap : ClassMapping<User>
	{
		public UserMap()
		{
			Id(x => x.Id, m => m.Generator(Generators.Guid));
			Property(x => x.Email, m =>
			{
				m.Length(50);
				m.NotNullable(notnull: true);
			});
			Property(x => x.Password, m =>
			{
				m.Length(50);
				m.NotNullable(notnull: true);
			});
		}
	}
}
