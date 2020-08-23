namespace WordLadder.Lib
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using WordLadder.Lib.Exceptions;

	public static class WordLadderSolver
	{
		public static bool TryFindLadder(string beginWord, string endWord, List<string> dictionary, out List<string> ladder)
		{
			if (string.IsNullOrWhiteSpace(beginWord))
			{
				throw new ArgumentException("Please supply a starting word", nameof(beginWord));
			}

			if (string.IsNullOrWhiteSpace(endWord))
			{
				throw new ArgumentException("Please supply an ending word", nameof(endWord));
			}

			if (dictionary == null || dictionary.Count == 0)
			{
				throw new ArgumentException("Please supply a dictionary", nameof(dictionary));
			}

			beginWord = beginWord.Trim();
			endWord = endWord.Trim();

			if (beginWord.Length != endWord.Length)
			{
				throw new WordLengthException("Both words must be equal length");
			}

			beginWord = beginWord.ToLower();
			endWord = endWord.ToLower();
			var dictionaryClone = new List<string>(dictionary.Select(e => e.ToLower()));

			if (!dictionary.Contains(endWord))
			{
				throw new WordDoesNotExistException("Destination word does not exist in dictionary");
			}

			var wordQueue = new Queue<List<string>>();
			wordQueue.Enqueue(new List<string> { beginWord });

			while (wordQueue.Count != 0)
			{
				var visitedList = new HashSet<string>();
				var queueList = new List<List<string>>();
				while (wordQueue.Count != 0)
				{
					var words = wordQueue.Dequeue();
					var word = words.Last();
					foreach (var item in dictionaryClone.Where(x => IsLadderWord(word, x)))
					{
						visitedList.Add(item);

						if (item.Equals(endWord))
						{
							ladder = new List<string>(words)
							{
								item
							};
							return true;
						}
						queueList.Add(new List<string>(words)
						{
							item
						});
					}
				}
				dictionaryClone.RemoveAll(x => visitedList.Contains(x));
				foreach (var item in queueList)
				{
					wordQueue.Enqueue(item);
				}
			}

			ladder = new List<string>();
			return false;
		}

		private static bool IsLadderWord(string wordOne, string wordTwo)
		{
			var diffCount = 0;
			for (var i = 0; i < wordOne.Length; i++)
			{
				if (wordOne[i] != wordTwo[i])
				{
					diffCount++;
				}
				if (diffCount > 1)
				{
					break;
				}
			}
			return diffCount == 1;
		}
	}
}
