using System;
using System.Collections.Generic;
using System.Linq;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Context;
using PopCorn.DataLayer.Enums;
using PopCorn.DataLayer.Helpers;
using PopCorn.DataLayer.Models.DTO;
using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.BusinessLayer.Services
{
	public class TypeService
	{
		private readonly PopCornDbContext _context;

		public TypeService(PopCornDbContext context)
		{
			_context = context;
		}

		public List<ExtendedPropertyInfo> GetTypeStructure(Type type, Type attributeType)
		{
			var dbProperties = typeof(PopCornDbContext).GetProperties();
			var propertiesInfo = type.GetProperties();
			var data = new List<ExtendedPropertyInfo>();

			foreach (var property in propertiesInfo)
			{
				var attributes = property.GetCustomAttributes(attributeType, false)
					.Select(a => Convert.ChangeType(a, attributeType)).ToArray();
				if (attributes.Length <= 0)
				{
					continue;
				}

				var isTableAttr = attributes[0] is TableView;
				var isInputAttr = attributes[0] is InputView;

				List<SelectValue> selectValues = null;
				InputView inputAttribues = null;
				if (isInputAttr)
				{
					inputAttribues = (InputView)attributes[0];
					if (inputAttribues.Type == InputFieldType.Select)
					{
						selectValues = new List<SelectValue>();
						if (property.PropertyType.IsEnum)
						{
							foreach (var value in Enum.GetValues(property.PropertyType))
							{
								selectValues.Add(new SelectValue
								{
									Key = (int)Convert.ChangeType(value, property.PropertyType),
									Value = value.GetDisplayName()
								});
							}
						}
						else if (typeof(IDictionaryEntity).IsAssignableFrom(property.PropertyType))
						{
							var dbProperty = dbProperties
								.First(p => p.PropertyType.IsGenericType &&
								            p.PropertyType.GetGenericArguments()[0] == property.PropertyType);
							var isFinanceCategoryProp = property.PropertyType.Name == "FinanceCategory";
							selectValues.Add(new SelectValue
							{
								Key = -1,
								Value = ""
							});
							var dynamicData = (IEnumerable<dynamic>)dbProperty.GetValue(_context, null);
							var selectData = dynamicData.Where(d =>
								type.Name != "FinanceCategory" || d.ParentCategoryId == null);
							foreach (var dictionaryData in selectData.Where(d =>
								!isFinanceCategoryProp || d.ParentCategoryId != null))
							{
								selectValues.Add(new SelectValue
								{
									Key = dictionaryData.Id,
									Value = dictionaryData.Name,
									GroupName = isFinanceCategoryProp ? dictionaryData.ParentCategoryStr : ""
								});
							}
						}
					}
				}

				data.Add(new ExtendedPropertyInfo
				{
					Property = property,
					TableViewAttribute = isTableAttr ? (TableView)attributes[0] : null,
					InputViewAttribute = inputAttribues,
					SelectValues = selectValues
				});
			}

			return data;
		}
	}
}