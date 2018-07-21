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
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            string userWord;
            bool isRunning = true;
            //List<string> pigLatinWords = new List<string>();
            while (isRunning)
            {
                // greet user
                Console.WriteLine("Welcome to the Pig Latin Translator!");
                // prompt the user for a word
                Console.Write("Please enter a word to be translated: ");
                // store user input and convert to lower case
                userWord = Console.ReadLine().ToLower();
                string firstLetter = userWord.Substring(0, 1);
                int firstVowelIndex = userWord.IndexOfAny(vowels);
                int userWordLength = userWord.Length;
                string fromFirstVowel = userWord.Substring(firstVowelIndex, userWordLength - 1);
                string beforeFirstVowel = userWord.Substring(0, firstVowelIndex);

                if (userWord.IndexOf(firstLetter) == firstVowelIndex)
                {
                    Console.WriteLine($"{userWord}-way");
                }
                else if(userWord.IndexOfAny(vowels) != -1)
                {
                    Console.WriteLine($"{fromFirstVowel}-{beforeFirstVowel}ay");
                }
                else if (beforeFirstVowel.Length < firstVowelIndex)
                {
                    Console.WriteLine($"{fromFirstVowel}-{beforeFirstVowel}ay");
                }
                // ask if the user would like to play again
            
                if (!PlayAgain())
                {
                    Console.WriteLine("Goodbye!");
                    isRunning = false;
                }
            }
            // =========================================================
            // DONT FORGET ABOUT STRINGBUILDER FOR THE OUTPUT FORMATTING
            // =========================================================
        }

        // method asking wether user would like to play again/ enter another number
        private static bool PlayAgain()
        {
            // try catch to handle exception a character must be input
            // in case of blank input
            try
            {
                // ask the user if they would like play again
                Console.WriteLine("Would you like to enter another word to be translated? ( y/n )");
                // parse the input into a char y/n
                char yesOrNo = char.Parse(Console.ReadLine());
                if (yesOrNo == 'y')
                {
                    return true;
                }
                else if(yesOrNo == 'n')
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
    }
}
