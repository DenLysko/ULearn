namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			var remainder = count % 100;
			if (remainder / 10 == 1)
            {
				return "рублей";
            }
			if (remainder % 10 < 5 && remainder % 10 > 1)
            {
				return "рубля";
            }
			if (remainder % 10 == 1)
            {
				return "рубль";
            }
			else
            {
				return "рублей";
            }
		}
	}
}