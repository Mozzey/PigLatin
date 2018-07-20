using System;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            // ======================
            // TREAT Y AS A CONSONANT
            // ======================

            string userInput;
            // greet user
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            // prompt the user for a word
            Console.Write("Please enter a word to be translated: ");
            // store user input
            userInput = Console.ReadLine();


            // translate and display user input to pig latin

            // ask if the user would like to play again

            // convert each word to lower case before translating


            // if input word starts with a vowel just append "way" to the end
            // else move all consonants that appear before the first found vowel
            // to the end of the word and then append "ay"

            // =========================================================
            // DONT FORGET ABOUT STRINGBUILDER FOR THE OUTPUT FORMATTING
            // =========================================================
        }

        // method asking wether user would like to play again/ enter another number
        private static bool PlayAgain(char yesOrNo)
        {
            // try catch to handle exception a character must be input
            // in case of blank input
            try
            {
                // ask the user if they would like play again
                Console.WriteLine("Would you like to enter another word to be translated? ( y/n )");
                // parse the input into a char y/n
                yesOrNo = char.Parse(Console.ReadLine());
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
                    return PlayAgain(yesOrNo);
                }

            }
            catch (Exception)
            {
                // // if incorrect input causes a no character exception call PlayAgain recursively
                return PlayAgain(yesOrNo);
            }
        }
    }
}
