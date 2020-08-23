namespace WordLadder.Lib.Tests
{
	using System;
	using System.Collections.Generic;
	using WordLadder.Lib.Exceptions;
	using Xunit;

	public class WordLadderSolverTests
	{
		private const string START_WORD = "cat";
		private const string END_WORD = "dog";

		private const string START_WORD_PARAM_NAME = "beginWord";
		private const string END_WORD_PARAM_NAME = "endWord";
		private const string DICTIONARY_PARAM_NAME = "dictionary";

		private readonly List<string> _dictionary = new List<string>()
		{
			"cat",
			"cot",
			"cog",
			"dog"
		};

		[Fact]
		public void TryFindLadder_WhenGivenANullBeginningWord_Throws()
		{
			//arrange

			//act
			var exception = Assert.Throws<ArgumentException>(() => WordLadderSolver.TryFindLadder(
				  null,
				  END_WORD,
				  new List<string>(),
				  out var ladder));

			//assert
			Assert.Equal(START_WORD_PARAM_NAME, exception.ParamName);
		}

		[Fact]
		public void TryFindLadder_WhenGivenAnEmptyStringAsBeginningWord_Throws()
		{
			//arrange

			//act
			var exception = Assert.Throws<ArgumentException>(() => WordLadderSolver.TryFindLadder(
				string.Empty,
				END_WORD,
				new List<string>(),
				out var ladder));

			//assert
			Assert.Equal(START_WORD_PARAM_NAME, exception.ParamName);
		}

		[Fact]
		public void TryFindLadder_WhenGivenANullEndingWord_Throws()
		{
			//arrange

			//act
			var exception = Assert.Throws<ArgumentException>(() => WordLadderSolver.TryFindLadder(
				START_WORD,
				null,
				new List<string>(),
				out var ladder));

			Assert.Equal(END_WORD_PARAM_NAME, exception.ParamName);
		}

		[Fact]
		public void TryFindLadder_WhenGivenAnEmptyStringAsEndingWord_Throws()
		{
			//arrange

			//act
			var exception = Assert.Throws<ArgumentException>(() => WordLadderSolver.TryFindLadder(
				START_WORD,
				string.Empty,
				new List<string>(),
				out var ladder));

			//assert
			Assert.Equal(END_WORD_PARAM_NAME, exception.ParamName);
		}

		[Fact]
		public void TryFindLadder_WhenGivenAnNullDictionary_Throws()
		{
			//arrange

			//act
			var exception = Assert.Throws<ArgumentException>(() => WordLadderSolver.TryFindLadder(
				START_WORD,
				END_WORD,
				null,
				out var ladder));

			//assert
			Assert.Equal(DICTIONARY_PARAM_NAME, exception.ParamName);
		}

		[Fact]
		public void TryFindLadder_WhenGivenAnEmptyDictionary_Throws()
		{
			//arrange

			//act
			var exception = Assert.Throws<ArgumentException>(() => WordLadderSolver.TryFindLadder(
				START_WORD,
				END_WORD,
				new List<string>(),
				out var ladder));

			//assert
			Assert.Equal(DICTIONARY_PARAM_NAME, exception.ParamName);
		}

		[Fact]
		public void TryFindLadder_WhenGivenTwoWordsOfDifferentLength_Throws()
		{
			//arrange

			//act + assert
			var exception = Assert.Throws<WordLengthException>(() => WordLadderSolver.TryFindLadder(
				"test",
				"tests",
				_dictionary,
				out var ladder));
		}

		[Fact]
		public void TryFindLadder_WhenEndWordDoesExistInDictionary_Throws()
		{
			//arrange
			const string nonExistantWord = "asd";

			//act + assert
			var exception = Assert.Throws<WordDoesNotExistException>(() => WordLadderSolver.TryFindLadder(
				START_WORD,
				nonExistantWord,
				_dictionary,
				out var ladder));
		}

		[Theory]
		[InlineData(START_WORD, END_WORD, new string[] { "cat", "cot", "cog", "dog" })]
		[InlineData(END_WORD, START_WORD, new string[] { "dog", "cog", "cot", "cat" })]
		[InlineData(START_WORD, "cot", new string[] { "cat", "cot" })]
		[InlineData("cog", END_WORD, new string[] { "cog", "dog" })]
		[InlineData(END_WORD, "cot", new string[] { "dog", "cog", "cot" })]
		public void TryFindLadder_WhenGivenAValidStartAndEndWord_ReturnsALadder(string startWord, string endWord, string[] expected)
		{
			//arrange

			//act
			var result = WordLadderSolver.TryFindLadder(
				startWord,
				endWord,
				_dictionary,
				out var ladder);

			//assert
			Assert.True(result);
			Assert.Equal(expected, ladder);
		}

		[Fact]
		public void TryFindLadder_WhenGivenAValidStartAndEndWord_AndTheyAreDifferentCases_ReturnsALadder()
		{
			//arrange
			var expected = new List<string>()
			{
				"cat",
				"cot",
				"cog",
				"dog"
			};

			//act
			var result = WordLadderSolver.TryFindLadder(
				START_WORD.ToUpper(),
				END_WORD.ToLower(),
				_dictionary,
				out var ladder);

			//assert
			Assert.True(result);
			Assert.Equal(expected, ladder);
		}

		[Fact]
		public void TryFindLadder_WhenGivenValidInput_AndCannotFindALadder_ReturnsFalse()
		{
			//arrange
			const string startWord = "ham";

			//act
			var result = WordLadderSolver.TryFindLadder(
				startWord,
				END_WORD.ToLower(),
				_dictionary,
				out var ladder);

			//assert
			Assert.False(result);
			Assert.Equal(ladder, new List<string>());
		}
	}
}
