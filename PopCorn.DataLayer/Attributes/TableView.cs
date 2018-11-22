using System;

namespace PopCorn.DataLayer.Attributes
{
	public class TableView : Attribute
	{
		public string Name { get; set; }
		public string Type { get; set; }
	}
}