using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class ProjectViewMap : BaseEntityMap<ProjectView>
	{
		public ProjectViewMap()
		{
			Property(x => x.UserId);
			Property(x => x.ProjectId);

			Property(x => x.ProjectName, m =>
			{
				m.Length(255);
				m.NotNullable(notnull: true);
			});
			Property(x => x.ProjectShortName, m =>
			{
				m.Length(5);
				m.NotNullable(notnull: true);
			});
			Property(x => x.ProjectDescription, m =>
			{
				m.Length(4000);
				m.NotNullable(notnull: true);
			});

			Property(x => x.TotalTasksCount, m =>
			{
				m.NotNullable(notnull: false);
			});

			Property(x => x.OpenTasksCount, m =>
			{
				m.NotNullable(notnull: false);
			});

			Property(x => x.TasksInProgressCount, m =>
			{
				m.NotNullable(notnull: false);
			});
		}
	}
}
