using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class ProjectInfoViewMap : BaseEntityMap<ProjectInfoView>
	{
		public ProjectInfoViewMap()
		{
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

			Property(x => x.NonClosedTasksCount, m =>
			{
				m.NotNullable(notnull: false);
			});

			Property(x => x.TotalUsersCount, m =>
			{
				m.NotNullable(notnull: false);
			});
		}
	}
}
