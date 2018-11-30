using System.Collections.Generic;
using PopCorn.DataLayer.Attributes;
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

		public virtual Role Role { get; set; }

		public virtual List<UserProject> Projects { get; set; }
	}
}