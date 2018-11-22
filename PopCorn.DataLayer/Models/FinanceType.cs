using System.Collections.Generic;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Enums;
using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.DataLayer.Models
{
	public class FinanceType : IDictionaryEntity
	{
		[TableView(Name = "Id")]
		public int Id { get; set; }

		[TableView(Name = "Название")]
		[InputView(Name = "Название")]
		public string Name { get; set; }

		public bool Income { get; set; }

		[InputView(Name = "Описание", Type = InputFieldType.TextArea)]
		public string Description { get; set; }

		public virtual List<ProjectFinance> Finances { get; set; }
	}
}