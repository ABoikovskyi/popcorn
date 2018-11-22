using System.Collections.Generic;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Enums;
using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.DataLayer.Models
{
	public class ProjectStatus : IDictionaryEntity
	{
		[TableView(Name = "Id")]
		public int Id { get; set; }

		[TableView(Name = "Название")]
		[InputView(Name = "Название")]
		public string Name { get; set; }

		[InputView(Name = "Описание", Type = InputFieldType.TextArea)]
		public string Description { get; set; }

		public virtual List<Project> Projects { get; set; }
	}
}