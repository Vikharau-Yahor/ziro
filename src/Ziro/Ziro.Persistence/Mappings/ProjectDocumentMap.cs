using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class ProjectDocumentMap : BaseEntityMap<ProjectDocument>
	{
		public ProjectDocumentMap()
		{
			Id(x => x.Id, m => m.Generator(Generators.Guid));
			Property(x => x.FileName, m => { m.Length(100); m.NotNullable(true); });
			Property(x => x.Description, m => { m.Length(4000); m.NotNullable(true); });
			Property(x => x.ContentType, m => { m.Length(100); m.NotNullable(true); });
			Property(x => x.Content, m => { m.NotNullable(true); });
			Property(x => x.UploadDate, m => { m.NotNullable(true); });
			ManyToOne(x => x.Project, c => {
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(Project)));
				c.NotNullable(notnull: true);
			});
		}
	}
}
