# Word Ladder

## Project Structure

-   WordLadder.ConsoleApp
    -   A console application to run the word ladder
-   WordLadder.Lib
    -   A library containing the Word Ladder logic
-   WordLadder.Lib.Tests
    -   Test suite for the Word Ladder library

## Running The Console Application

-   Navigate to WordLadder.ConsoleApp
-   Type `dotnet run` in your console
-   Provide a starting and ending word
    -   These must be the same length
    -   Case and whitespace does not matter
-   If able to generate a ladder, the program will print it out and exit
-   If unable to generate a ladder, the program will print an error and exit with code 1

## Running Tests

-   Navigate to WordLadder.Lib.Tests
-   Type `dotnet test` in your console
