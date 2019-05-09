using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class CommentMap : BaseEntityMap<Comment>
	{
		public CommentMap()
		{
			Id(x => x.Id, m => m.Generator(Generators.Guid));
			Property(x => x.Text, m =>
			{
				m.Length(4000);
				m.NotNullable(notnull: false);
			});
			Property(x => x.Date, m => { m.NotNullable(notnull: true); });
			ManyToOne(x => x.Task, c =>
			{
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(Comment.Task)));
				c.NotNullable(notnull: false);
			});
			ManyToOne(x => x.Author, c =>
			{
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(Comment.Author)));
			});
		}
	}
}
