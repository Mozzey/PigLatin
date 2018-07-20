using System;
using System.Collections.Generic;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            // ======================
            // TREAT Y AS A CONSONANT
            // ======================
            string vowels = "AEIOUaeiou";
            string userWord;
            char yesOrNo;
            bool isRunning = true;
            List<string> pigLatinWords = new List<string>();
            while (isRunning)
            {
                // greet user
                Console.WriteLine("Welcome to the Pig Latin Translator!");
                // prompt the user for a word
                Console.Write("Please enter a word to be translated: ");
                // store user input and convert to lower case
                userWord = Console.ReadLine().ToLower();

                // get and store the first letter of the user word
                string firstLetter = userWord.Substring(0, 1);
                // get and store the rest of the user word
                string restOfTheWord = userWord.Substring(1, userWord.Length - 1);
                // this is testing the vowels string for the matching letter
                // if it does not find the index of the letter it will return -1
                int currentLetterIndex = vowels.IndexOf(firstLetter);
                // there is no IndexOf of currentLetter in the vowels string so it returns -1
                if (currentLetterIndex == -1)
                {
                    // translate and display user input to pig latin
                    pigLatinWords.Add($"{restOfTheWord}{firstLetter}ay");
                    ////Console.W  riteLine($"{restOfTheWord}-{firstLetter}ay");
                }
                else
                {
                    // translate and display user input to pig latin first letter vowel
                    pigLatinWords.Add($"{userWord}-way");
                    ////Console.WriteLine($"{userWord}-way");
                }
                Console.WriteLine(string.Join("", pigLatinWords));
                // ask if the user would like to play again
            
                if (!PlayAgain())
                {
                    Console.WriteLine("Goodbye!");
                    isRunning = false;
                }
            }
            
            


            // convert each word to lower case before translating


            // if input word starts with a vowel just append "way" to the end
            // els  e move all consonants that appear before the first found vowel
            // to the end of the word and then append "ay"

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
