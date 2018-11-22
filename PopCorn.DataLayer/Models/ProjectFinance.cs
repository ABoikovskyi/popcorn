using System;
using System.ComponentModel.DataAnnotations.Schema;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Enums;
using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.DataLayer.Models
{
	[Table("ProjectFinance")]
	public class ProjectFinance : IEntity
	{
		public ProjectFinance()
		{
			FinanceTypeId = 1;
			OperationDate = DateTime.Now;
		}

		[TableView(Name = "Id")]
		public int Id { get; set; }

		public int? FinanceTypeId { get; set; }

		[InputView(Name = "Тип", Type = InputFieldType.Select)]
		[ForeignKey("FinanceTypeId")]
		public FinanceType FinanceType { get; set; }

		[TableView(Name = "Тип")]
		[NotMapped]
		public string FinanceTypeStr => FinanceType?.Name;
			
		public int? FinanceCategoryId { get; set; }

		[InputView(Name = "Категория", Type = InputFieldType.Select)]
		[ForeignKey("FinanceCategoryId")]
		public FinanceCategory FinanceCategory { get; set; }

		[TableView(Name = "Категория")]
		[NotMapped]
		public string FinanceCategoryStr =>
			$"{(FinanceCategory?.ParentCategory == null ? "" : $"{FinanceCategory?.ParentCategory?.Name}->")}{FinanceCategory?.Name}";

		public int ProjectId { get; set; }

		[InputView(Name = "Проект", Type = InputFieldType.Select)]
		[ForeignKey("ProjectId")]
		public Project Project { get; set; }

		[TableView(Name = "Проект")]
		[NotMapped]
		public string ProjectStr => Project?.Name;

		[TableView(Name = "Дата")]
		[InputView(Name = "Дата", Type = InputFieldType.Calendar)]
		public DateTime OperationDate { get; set; }

		[TableView(Name = "Сумма")]
		[InputView(Name = "Сумма",Type = InputFieldType.Numeric)]
		public double Amount { get; set; }

		[TableView(Name = "Заметки")]
		[InputView(Name = "Заметки", Type = InputFieldType.TextArea)]
		public string Note { get; set; }
	}
}