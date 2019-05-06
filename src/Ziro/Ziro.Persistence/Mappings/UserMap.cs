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
			Property(x => x.Role, m => m.NotNullable(notnull: true));
			Property(x => x.Name, m =>
			{
				m.Length(250);
				m.NotNullable(notnull: false);
			});
			Property(x => x.LastName, m =>
			{
				m.Length(250);
				m.NotNullable(notnull: false);
			});
			Property(x => x.Skype, m =>
			{
				m.Length(150);
				m.NotNullable(notnull: false);
			});
			Property(x => x.PhoneNumber, m =>
			{
				m.Length(20);
				m.NotNullable(notnull: false);
			});
			Property(x => x.DateOfBirth, m => { m.NotNullable(notnull: false); });
			ManyToOne(x => x.Position, c => {
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(Position)));
				c.NotNullable(notnull: false);
			});
			Set(a => a.Projects,
			c => {
				c.Cascade(Cascade.Persist);
				c.Key(k => k.Column(FKColumnName(nameof(User))));
				c.Table(MToMTableName(nameof(Project), nameof(User)));
			},
			r => r.ManyToMany(m => m.Column(FKColumnName(nameof(Project)))));
		}
	}
}
