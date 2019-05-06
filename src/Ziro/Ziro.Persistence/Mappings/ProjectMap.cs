using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class ProjectMap : BaseEntityMap<Project>
	{
		public ProjectMap()
		{
			Id(x => x.Id, m => m.Generator(Generators.Guid));

			Property(x => x.Name, m =>
			{
				m.Length(255);
				m.NotNullable(notnull: true);
			});
			Property(x => x.ShortName, m =>
			{
				m.Length(5);
				m.NotNullable(notnull: true);
			});
			Property(x => x.Description, m =>
			{
				m.Length(4000);
				m.NotNullable(notnull: true);
			});

			Set(x => x.Tasks,
				c => {
					c.Key(k => k.Column(FKColumnName(nameof(Project))));
					c.Inverse(true);
				},
				r => r.OneToMany());


			Set(a => a.Users,
				c => {
					c.Cascade(Cascade.Persist);
					c.Key(k => k.Column(FKColumnName(nameof(Project))));
					c.Table(MToMTableName(nameof(Project), nameof(User)));
				},
				r => r.ManyToMany(m => m.Column(FKColumnName(nameof(User)))));
		}
	}
}
