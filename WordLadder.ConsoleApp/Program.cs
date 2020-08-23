namespace WordLadder.ConsoleApp
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using WordLadder.Lib;

	internal static class Program
	{
		private const string DICTIONARY_NAME = "dictionary.txt";

		private static void Main()
		{
			List<string> dictionary = ReadDictionary();

			var (start, end) = GetInput(dictionary);

			Console.WriteLine();
			Console.WriteLine("Please wait...");
			Console.WriteLine();

			dictionary = dictionary.Where(word => word.Length == start.Length).ToList();
			if (!WordLadderSolver.TryFindLadder(start, end, dictionary, out var ladder))
			{
				Console.WriteLine($"Could not find word ladder for the given words {start} to {end}");
				Environment.Exit(1);
			}

			Console.WriteLine("Ladder:");
			foreach (var word in ladder)
			{
				Console.WriteLine(word);
			}
		}

		private static List<string> ReadDictionary()
		{
			var deliminators = new[] { "\r\n", "\r", "\n" };
			var dictionary = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, DICTIONARY_NAME));
			return dictionary.Split(deliminators, StringSplitOptions.RemoveEmptyEntries).ToList();
		}

		private static (string start, string end) GetInput(List<string> dictList)
		{
			var valid = false;
			var start = string.Empty;
			var end = string.Empty;

			while (!valid)
			{
				Console.WriteLine("Start word:");
				start = Console.ReadLine().Trim().ToLower();

				Console.WriteLine("End word:");
				end = Console.ReadLine().Trim().ToLower();

				if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
				{
					Console.WriteLine("Please input a start and end word");
					continue;
				}
				if (start.Length != end.Length)
				{
					Console.WriteLine("Words must be the same length");
					continue;
				}
				if (!dictList.Contains(end))
				{
					Console.WriteLine("End word must be real");
					continue;
				}

				valid = true;
			}
			return (start, end);
		}
	}
}
