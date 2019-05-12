using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Mappings
{
	public class AvatarMap : BaseEntityMap<Avatar>
	{
		public AvatarMap()
		{
			Id(x => x.Id, m => m.Generator(Generators.Guid));
			Property(x => x.ContentType, m => { m.Length(100); m.NotNullable(true); });
			Property(x => x.ImageData, m => { m.NotNullable(true); });
			ManyToOne(x => x.User, c => {
				c.Cascade(Cascade.None);
				c.Column(FKColumnName(nameof(User)));
				c.NotNullable(notnull: true);
			});
		}
	}
}
