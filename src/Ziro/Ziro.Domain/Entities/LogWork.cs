using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Domain.Entities
{
	public class LogWork
	{
		public virtual Guid Id { get; set; }
		public virtual string Text { get; set; }
		public virtual double SpentTimeHours { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual User Author { get; set; }
		public virtual Task Task { get; set; }
	}
}
