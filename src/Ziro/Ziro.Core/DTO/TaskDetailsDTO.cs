using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class TaskDetailsDTO
	{
		public Guid Id { get; set; }
		public int Number { get; set; }
		public byte Type { get; set; }
		public byte Status { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public byte Priority { get; set; }
		public double EstimatedTime { get; set; }
		public double SpentTime { get; set; }
		public DateTime CreationDate { get; set; }
		public virtual DateTime LastUpdateDate { get; set; }
		public Guid ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string ShortProjectName { get; set; }
		public Guid AssigneeId { get; set; }
		public string AssigneeName { get; set; }
		public string AssigneeLastName { get; set; }
		public Guid OwnerId { get; set; }
		public string OwnerName { get; set; }
		public string OwnerLastName { get; set; }
		public IList<LogWorkDTO> LogWorks { get; set; }
		public IList<CommentDTO> Comments { get; set; }
		public string FullNumber => string.Format(Consts.TaskNumberTemplate, this.ShortProjectName, this.Number);
	}
}
