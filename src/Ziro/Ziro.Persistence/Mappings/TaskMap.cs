using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class TaskMap : BaseEntityMap<Task>
	{
		public TaskMap()
		{
			Id(x => x.Id, m => m.Generator(Generators.Guid));
			Property(x => x.Title, m =>
			{
				m.Length(400);
				m.NotNullable(notnull: true);
			});

			ManyToOne(x => x.Project,c=> {
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(Project)));
			});
		}
	}
}
