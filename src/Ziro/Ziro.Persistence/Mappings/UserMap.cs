using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class UserMap : BaseEntityMap<User>
	{
		public UserMap()
		{
			Id(x => x.Id, m => m.Generator(Generators.Guid));

			Property(x => x.Email, m =>
			{
				m.Length(50);
				m.NotNullable(notnull: true);
			});

			Property(x => x.PasswordHash, m =>
			{
				m.Length(255);
				m.NotNullable(notnull: true);
			});

			Set(a => a.Projects,
			c => {
				c.Cascade(Cascade.Persist);
				c.Key(k => k.Column(FKColumnName(nameof(User))));
				c.Table(MToMTableName(nameof(Project), nameof(User)));
			},
			r => r.ManyToMany(m => m.Column(FKColumnName(nameof(Project)))));

			Property(x => x.Role, m => m.NotNullable(notnull: true));
		}
	}
}
