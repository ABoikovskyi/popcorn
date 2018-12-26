using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Enums;
using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.DataLayer.Models
{
	public class User : IEntity
	{
		[TableView(Name = "Id")]
		public int Id { get; set; }

		[TableView(Name = "Email")]
		[InputView(Name = "Email")]
		public string Email { get; set; }

		[InputView(Name = "Пароль")]
		public string Password { get; set; }

		public int RoleId { get; set; }

		[InputView(Name = "Роль", Type = InputFieldType.Select)]
		public virtual Role Role { get; set; }

		[TableView(Name = "Роль")]
		[NotMapped]
		public string RoleStr => Role?.Name;

		public virtual List<UserProject> UserProjects { get; set; }

		[InputView(Name = "Проекты", Type = InputFieldType.MultiSelect)]
		[NotMapped]
		public virtual List<Project> Projects { get; set; }

		[TableView(Name = "Проекты")]
		[NotMapped]
		public virtual string ProjectsStr =>
			UserProjects == null ? null : string.Join(", ", UserProjects.Select(p => p.Project?.Name));

		[NotMapped] private int[] _projectsIds;

		[NotMapped]
		public virtual int[] ProjectsIds
		{
			get => _projectsIds ?? UserProjects?.Select(p => p.ProjectId).ToArray();
			set => _projectsIds = value;
		}
	}
}