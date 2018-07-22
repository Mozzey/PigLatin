using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            // loop flag
            bool isRunning = true;
            while (isRunning)
            {
                // greet the user
                GreetUser();
                // store user input and convert to lower case
                string userInput = Console.ReadLine().ToLower();
                // store piglatin translation
                string pigLatin = TranslateToPigLatin(userInput);
                // display translation
                Console.WriteLine(pigLatin);
               
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
        // seperate method to translate userInput into piglatin
        private static string TranslateToPigLatin(string userInput)
        {
            // an array of vowels to check userInput words against
            char[] VOWELS = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            // an array of acceptable punctuation
            char[] PUNCTUATION = { '!', ',', '.', '?' };
            // string builder to create a string with the translated words
            StringBuilder pigLatinWords = new StringBuilder();
            // user input split into an array from the space character
            string[] userInputArray = userInput.Trim().Split(' ');
            // iterate through each word in the user input
            foreach (var word in userInputArray)
            {
                // WORD SUBSTRINGS
                // first vowel index of each word
                int firstVowelIndex = word.IndexOfAny(VOWELS);
                // word before vowel - ternary operator stating if there is a vowel in the word, beforeFirstVowel returns substring before first vowel
                // else beforeFirstVowel becomes word as to not be ArgumentOutOfBounds
                string beforeFirstVowel = (ContainsVowel(word, VOWELS)) ? word.Substring(0, firstVowelIndex) : word;
                // word from first vowel - t- ternary operator stating if there is a vowel in the word, fromFirstVowel returns substring from the first vowel to the end of the word
                // else beforeFirstVowel becomes word as to not be ArgumentOutOfBounds
                string fromFirstVowel = (ContainsVowel(word, VOWELS)) ? word.Substring(firstVowelIndex, (word.Length - firstVowelIndex)) : word;
                // if character contains punctuation allow it ex: "hey you're over there!" == "ey-hay ou're-yay over-way ere-thay!"
                if (ContainsPunctuation(word, PUNCTUATION))
                {
                    pigLatinWords.Append($"{AllowPunctuation(word, PUNCTUATION)}").Append(" ");
                }
                // if word contains a number
                else if (ContainsNumber(word))
                {
                    pigLatinWords.Append($"{word}").Append(" ");
                }
                // if word has a symbol and first letter is vowel OR word has symbol and first letter isnt vowel
                else if (ContainsSymbol(word) && firstVowelIndex == 0 || ContainsSymbol(word) && firstVowelIndex > 0)
                {
                    pigLatinWords.Append($"{word}").Append(" ");
                }
                // if the first letter is a vowel
                else if (firstVowelIndex == 0 || (firstVowelIndex == 0 && ContainsPunctuation(word, PUNCTUATION)))
                {
                    
                    pigLatinWords.Append($"{word}-way").Append(" ");
                }
                // find the first vowel and do the translation
                else if (firstVowelIndex > 0)
                {
                    pigLatinWords.Append($"{fromFirstVowel}-{beforeFirstVowel}ay").Append(" ");
                }
                // if there are no vowels and not an empty input
                else if (!ContainsVowel(word, VOWELS) && !ContainsNullOrWhiteSpace(word))
                {
                    pigLatinWords.Append($"{word}-ay").Append(" ");
                }
                // has number and doesnt have vowel
                else if ((ContainsNumber(userInput) && !ContainsVowel(word, VOWELS)))
                {
                    pigLatinWords.Append($"{word}").Append(" ");
                }
            }
            // fancy pants success color for translated input
            Console.ForegroundColor = ConsoleColor.Green;
            // join the words in the piglatin string builder at the space character
            return string.Join(' ',pigLatinWords);
        }
        // hey hey hey to the user
        private static void GreetUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            // greet user
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            // prompt the user for a word
            Console.Write("Please enter a word to be translated: ");
        }
        // method to check if the user input contains a vowel
        private static bool ContainsVowel(string userInput, char[] VOWELS)
        {
            if (userInput.IndexOfAny(VOWELS) != -1)
            {
                return true;
            }
            return false;
        }
        // method to check if user input conatins numbers
        private static bool ContainsNumber(string userInput)
        {
            Regex containsNumber = new Regex(@"[0-9]");
            if (containsNumber.IsMatch(userInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // method to check if user input contains sumbols
        private static bool ContainsSymbol(string userInput)
        {
            Regex containsSymbol = new Regex(@"[#$%@^&*)(\[\]{}\\]");
            if (containsSymbol.IsMatch(userInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // method to check if the input contains punctuation
        private static bool ContainsPunctuation(string userInput, char[] PUNCTUATION)
        {
            // Regex containsPunctuation = new Regex(@"[!,.?]");
            if (userInput.IndexOfAny(PUNCTUATION) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // check for null or whitespace
        private static bool ContainsNullOrWhiteSpace(string userInput)
        {
            if (String.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry but you didn't input anything to be translated");
                return true;
            }
            else
            {
                return false;
            }
        }
        // gets the punctuation and moves it to the end of the word
        private static string AllowPunctuation(string userInput, char[] PUNCTUATION)
        {
            int indexOfPunctuation = userInput.IndexOfAny(PUNCTUATION);
            // substring grabbing the punctuation
            string punctuationMark = userInput.Substring(indexOfPunctuation, 1);
            // assign the punctuation to another variable so it can be worked on
            string wordNoPunctuation;

            if (indexOfPunctuation == -1)
            {
                return userInput;
            }
            else
            {
                wordNoPunctuation = userInput.Remove(indexOfPunctuation, 1);
                string pigLatinWithPunctuation = $"{TranslateToPigLatin(wordNoPunctuation).Trim()}{punctuationMark}";
                return pigLatinWithPunctuation;
            }
        }
    }
}
