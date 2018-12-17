using System;
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

		public virtual List<UserProject> Projects { get; set; }

		[TableView(Name = "Проекты")]
		public virtual string ProjectsStr => string.Join(Environment.NewLine, Projects?.Select(p => p.Project.Name));

		[InputView(Name = "Проекты")]
		public virtual int[] ProjectsIds => Projects?.Select(p => p.Id).ToArray();
	}
}