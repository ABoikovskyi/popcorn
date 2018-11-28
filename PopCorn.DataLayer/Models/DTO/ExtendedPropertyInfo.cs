using System.Collections.Generic;
using System.Reflection;
using PopCorn.DataLayer.Attributes;

namespace PopCorn.DataLayer.Models.DTO
{
	public class ExtendedPropertyInfo
	{
		public PropertyInfo Property { get; set; }
		public TableView TableViewAttribute { get; set; }
		public InputView InputViewAttribute { get; set; }
		public List<SelectValue> SelectValues { get; set; }
	}

    public class SelectValue
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public string GroupName { get; set; }
    }
}