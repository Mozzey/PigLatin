using System;
using System.Collections.Generic;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            // if input word starts with a vowel just append "way" to the end
            // else move all consonants that appear before the first found vowel
            // to the end of the word and then append "ay"
            // ======================
            // TREAT Y AS A CONSONANT
            // ======================
            // string vowels = "AEIOUaeiou";
            char[] VOWELS = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            // user input
            string userWord;
            // loop flag
            bool isRunning = true;
            //List<string> pigLatinWords = new List<string>();
            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.White;
                // greet user
                Console.WriteLine("Welcome to the Pig Latin Translator!");
                // prompt the user for a word
                Console.Write("Please enter a word to be translated: ");
                // store user input and convert to lower case
                userWord = Console.ReadLine();
                try
                {
                    // length of the userWord
                    int userWordLength = userWord.Length;
                    // get the first letter of the userWord
                    string firstLetter = userWord.Substring(0, 1).Trim();
                    // get the index of the first vowel
                    int firstVowelIndex = userWord.IndexOfAny(VOWELS);
                    // ============================================================
                    // a substring of userWord starting at index 0 and ending before the first vowel
                    string beforeFirstVowel = userWord.Substring(0, firstVowelIndex);
                    // the length of the substring before the first vowel
                    int beforeFirstVowelLength = beforeFirstVowel.Length;
                    // =============================================================
                    // a substring of userWord starting at the first vowel and ending at the userWord last index
                    string fromFirstVowel = userWord.Substring(firstVowelIndex, (userWordLength - firstVowelIndex));
                    // length of the userWord substring fromFirstVowel
                    int fromFirstVowelLength = fromFirstVowel.Length;
                    // =============================================================
                    Console.ForegroundColor = ConsoleColor.Green;
                    // if the first letter starts with a vowel add "way" to the end
                    DisplayStartsWithVowel(firstVowelIndex, userWord);
                    // find the first vowel, cut the word before the vowel, append what you cut to the end and add "ay"
                    DisplayFromFirstVowel(VOWELS, userWord, fromFirstVowel, beforeFirstVowel, firstVowelIndex);
                }
                // if there is no vowel in the word inform the user
                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sorry but there is no vowel in the word: {userWord}");
                }
                
                // ask if the user would like to play again
                if (!PlayAgain())
                {
                    Console.WriteLine("Goodbye!");
                    isRunning = false;
                }
            }
        }

        // method asking wether user would like to play again/ enter another number
        private static bool PlayAgain()
        {
            // try catch to handle exception a character must be input
            // in case of blank input
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                // ask the user if they would like play again
                Console.WriteLine("Would you like to enter another word to be translated? ( y/n )");
                // parse the input into a char y/n
                string yesOrNo = Console.ReadLine().ToLower();
                if (yesOrNo.StartsWith('y'))
                {
                    return true;
                }
                else if(yesOrNo.StartsWith('n'))
                {
                    return false;
                }
                else
                {
                    // if incorrect input call PlayAgain recursively
                    return PlayAgain();
                }

            }
            catch (Exception)
            {
                // // if incorrect input causes a no character exception call PlayAgain recursively
                return PlayAgain();
            }
        }
        // if the first letter starts with a vowel add "way" to the end
        private static void DisplayStartsWithVowel(int firstVowelIndex, string userWord)
        {
            if (firstVowelIndex <= 0)
            {
                Console.WriteLine($"{userWord}-way ");
            }
        }
        // find the first vowel, cut the word before the vowel, append what you cut to the end and add "ay"
        private static void DisplayFromFirstVowel(char[] VOWELS, string userWord, string fromFirstVowel, string beforeFirstVowel, int firstVowelIndex)
        {
            if (userWord.IndexOfAny(VOWELS) != -1 && firstVowelIndex > 0)
            {
                
                Console.WriteLine($"{fromFirstVowel}-{beforeFirstVowel}ay");
            }
        }
    }
}
