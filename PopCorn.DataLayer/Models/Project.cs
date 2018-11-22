using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Enums;
using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.DataLayer.Models
{
	public class Project : IDictionaryEntity
	{
		public Project()
		{
			CreateDate = DateTime.Now;
			StatusId = 1;
		}

		[TableView(Name = "Id")]
		public int Id { get; set; }

		[TableView(Name = "Название")]
		[InputView(Name = "Название")]
		public string Name { get; set; }

		[InputView(Name = "Описание", Type = InputFieldType.TextArea)]
		public string Description { get; set; }

		public int StatusId { get; set; }

		[InputView(Name = "Статус", Type = InputFieldType.Select)]
		[ForeignKey("StatusId")]
		public virtual ProjectStatus Status { get; set; }

		[TableView(Name = "Статус")]
		[NotMapped]
		public string StatusStr => Status?.Name;

		[InputView(Name = "Дата создания", Type = InputFieldType.Calendar)]
		public DateTime CreateDate { get; set; }

		[InputView(Name = "Дата старта", Type = InputFieldType.Calendar)]
		public DateTime? StartedDate { get; set; }

		[InputView(Name = "Дата закрытия", Type = InputFieldType.Calendar)]
		public DateTime? ClosedDate { get; set; }

		[InputView(Name = "Дата отмены", Type = InputFieldType.Calendar)]
		public DateTime? CanceledDate { get; set; }

		[TableView(Name = "Дата создания")]
		[NotMapped]
		public string CreateDateStr => CreateDate.ToString("yyyy-MM-dd");

		[TableView(Name = "Дата старта")]
		[NotMapped]
		public string StartedDateStr => StartedDate?.ToString("yyyy-MM-dd");

		[TableView(Name = "Дата закрытия")]
		[NotMapped]
		public string ClosedDateStr => ClosedDate?.ToString("yyyy-MM-dd");

		[TableView(Name = "Дата отмены")]
		[NotMapped]
		public string CanceledDateStr => CanceledDate?.ToString("yyyy-MM-dd");

		[TableView(Name = "Ожидаемая сумма")]
		[InputView(Name = "Ожидаемая сумма", Type = InputFieldType.Numeric)]
		public double EstimatedPrice { get; set; }

		public virtual List<ProjectFinance> Finance { get; set; }
	}
}