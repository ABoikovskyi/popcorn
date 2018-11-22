using System.ComponentModel.DataAnnotations;
using PopCorn.DataLayer.Attributes;

namespace PopCorn.DataLayer.Helpers
{
    public static class AttributeHelper
	{
		public static string GetDisplayName<T>(this T source)
		{
			return GetEnumAttribute<T, DisplayAttribute>(source)?.Name;
		}

		public static string GetTableDisplayName<T>(this T source)
        {
            return GetEnumAttribute<T, TableView>(source)?.Name;
        }

	    public static string GetInputDisplayName<T>(this T source)
	    {
		    return GetEnumAttribute<T, InputView>(source)?.Name;
	    }

		public static string GetDescriptionName<T>(this T source)
        {
            return GetEnumAttribute<T, DisplayAttribute>(source)?.Description;
        }
		
        private static TAttribute GetEnumAttribute<T, TAttribute>(this T source)
            where TAttribute : class
        {
            var field = source.GetType().GetField(source.ToString());
            var attributes = (TAttribute[])field.GetCustomAttributes(typeof(TAttribute), false);

            return attributes.Length > 0 ? attributes[0] : null;
        }
    }
}