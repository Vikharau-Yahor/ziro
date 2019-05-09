using System;
using System.Collections.Generic;

namespace Ziro.Web.Models.api.Task
{
	public class TaskDetailsResponse
	{
		public TaskDetailsResponse()
		{
			Comments = new List<TaskDetailsComment>();
			LogWorks = new List<TaskDetailsLogWork>();
		}

		public Guid Id { get; set; }
		public string Number { get; set; }
		public byte TypeNum { get; set; }
		public string Type { get; set; }
		public byte StatusNum { get; set; }
		public string Status { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public byte PriorityNum { get; set; }
		public string Priority { get; set; }
		public double EstimatedTime { get; set; }
		public double SpentTime { get; set; }
		public string CreationDate { get; set; }
		public string LastUpdateDate { get; set; }
		public TaskProject Project { get; set; }
		public TaskUser Assignee { get; set; }
		public TaskUser Owner { get; set; }
		public IList<TaskDetailsComment> Comments { get; set; }
		public IList<TaskDetailsLogWork> LogWorks { get; set; }
	}

	public class TaskDetailsComment
	{
		public Guid Id { get; set; }
		public TaskUser Author { get; set; }
		public string Text { get; set; }
		public string LeavingDate { get; set; }
	}

	public class TaskDetailsLogWork
	{
		public Guid Id { get; set; }
		public TaskUser Author { get; set; }
		public string Text { get; set; }
		public string LeavingDate { get; set; }
		public double SpentTimeHours { get; set; }
	}

	public class TaskUser
	{
		public TaskUser(Guid id, string name, string lastName)
		{
			Id = id;
			FullName = $"{lastName} {name}";
		}

		public Guid Id { get; set; }
		public string FullName { get; set; }
	}

	public class TaskProject
	{
		public TaskProject(Guid id, string name, string shortName)
		{
			Id = id;
			Name = name;
			ShortName = shortName;
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
	}
}
