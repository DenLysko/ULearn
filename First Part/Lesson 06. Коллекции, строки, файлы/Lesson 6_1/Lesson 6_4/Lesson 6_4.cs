using System;

namespace Lesson_6_4
{
    class Program
    {
        static void Main()
        {
			var contacts = new List<string>() { "Aa: Aaron@A.A", "Ab: Abigheil@B.com" };
			var dict = OptimizeContacts(contacts);
        }

		private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
		{	
			// Полезные знакомства
			var dictionary = new Dictionary<string, List<string>>();
			foreach (var contact in contacts)
			{
				string[] nameAndEmail = contact.Split(':');
				string name = nameAndEmail[0];
				string beginningOfContact;
				if (name.Length > 2)
					beginningOfContact = name.Substring(0, 2);
				else
					beginningOfContact = name;
				if (dictionary.ContainsKey(beginningOfContact))
					dictionary[beginningOfContact].Add(contact);
				else
				{
					var list = new List<string>();
					list.Add(contact);
					dictionary[beginningOfContact] = list;
				}
			}
			return dictionary;
		}
	}
}