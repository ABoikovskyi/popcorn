using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Enums;
using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.DataLayer.Models
{
	public class FinanceCategory : IDictionaryEntity
	{
		[TableView(Name = "Id")]
		public int Id { get; set; }

		[TableView(Name = "Название")]
		[InputView(Name = "Название")]
		public string Name { get; set; }

		public int? ParentCategoryId { get; set; }

		[InputView(Name = "Родительская категория", Type = InputFieldType.Select)]
		[ForeignKey("ParentCategoryId")]
		public virtual FinanceCategory ParentCategory { get; set; }

		[TableView(Name = "Родительская категория")]
		[NotMapped]
		public string ParentCategoryStr => ParentCategory == null ? "" : ParentCategory.Name;
		
		[InputView(Name = "Описание", Type = InputFieldType.TextArea)]
		public string Description { get; set; }

		public virtual List<FinanceCategory> SubCategories { get; set; }

		public virtual List<ProjectFinance> Finances { get; set; }
	}
}