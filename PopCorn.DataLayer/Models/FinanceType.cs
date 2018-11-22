using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
		
		[InputView(Name = "Доход")]
		public bool Income { get; set; }

		[TableView(Name = "Доход")]
		[NotMapped]
		public string IncomeStr => Income ? "+" : "-";

		[InputView(Name = "Описание", Type = InputFieldType.TextArea)]
		public string Description { get; set; }

		public virtual List<ProjectFinance> Finances { get; set; }
	}
}