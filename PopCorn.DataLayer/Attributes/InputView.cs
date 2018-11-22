using System;
using PopCorn.DataLayer.Enums;

namespace PopCorn.DataLayer.Attributes
{
	public class InputView : Attribute
	{
		public InputView()
		{
			Type = InputFieldType.Text;
		}

		public string Name { get; set; }
		public InputFieldType Type { get; set; }
	}
}