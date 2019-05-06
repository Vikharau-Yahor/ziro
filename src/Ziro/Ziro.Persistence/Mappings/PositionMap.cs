using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class PositionMap : BaseEntityMap<Position>
	{
		public PositionMap()
		{
			Id(x => x.Id, m => m.Generator(Generators.Guid));

			Property(x => x.Name, m =>
			{
				m.Length(400);
				m.NotNullable(notnull: true);
			});


			Set(x => x.Users,
				c => {
					c.Key(k => k.Column(FKColumnName(nameof(Position))));
					c.Inverse(true);
				},
				r => r.OneToMany());
		}
	}
}
