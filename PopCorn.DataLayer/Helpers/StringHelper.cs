namespace PopCorn.DataLayer.Helpers
{
	public static class StringHelper
	{
		public static string ToLowerFirstChar(this string input)
		{
			var newString = input;
			if (!string.IsNullOrEmpty(newString) && char.IsUpper(newString[0]))
				newString = char.ToLower(newString[0]) + newString.Substring(1);
			return newString;
		}
	}
}