using System;
using System.Text.RegularExpressions;
using System.Net.Mail;

public class EmailValidator
{
	public static void Main(string[] args)
	{
		//String elligible characters.
		string regex = @"^([\w.-]+)@([\w-]+)((.(\w){2,})+)$";

		while (true)
		{
			Console.Write("Enter an email address: ");

			string? input = Console.ReadLine();
			bool regexMatch = false;

			regexMatch = Regex.IsMatch(input, regex);

			MailAddress? address;

			if (!MailAddress.TryCreate(input, result: out address))
			{
				Console.WriteLine($"{input} is not a valid email address");
				if (regexMatch)
				{
					Console.WriteLine("But the regex check passed, so it must be garbage");
				}
			}
			else
			{
				Console.WriteLine("Finally");
				return;
			}

			Console.WriteLine("No soup for you! try again");
		}
	}
}