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
			Property(x => x.Number, m => m.NotNullable(notnull: true));
			Property(x => x.Type, m => m.NotNullable(notnull: true));
			Property(x => x.Title, m =>
			{
				m.Length(400);
				m.NotNullable(notnull: true);
			});
			Property(x => x.Description, m =>
			{
				m.Length(20000);
				m.NotNullable(notnull: false);
			});
			Property(x => x.Priority, m => m.NotNullable(notnull: true));
			Property(x => x.EstimatedTime, m => m.NotNullable(notnull: false));
			Property(x => x.SpentTime, m => m.NotNullable(notnull: false));
			Property(x => x.CreationDate, m => m.NotNullable(notnull: true));
			Property(x => x.LastUpdateDate, m => m.NotNullable(notnull: true));
			ManyToOne(x => x.Project, c=> {
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(Project)));
			});
			ManyToOne(x => x.Assignee, c => {
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(Task.Assignee)));
				c.NotNullable(notnull: false);
			});
			ManyToOne(x => x.Owner, c => {
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(Task.Owner)));
			});
		}
	}
}
