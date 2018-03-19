using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palindrome.Library;

namespace Palindrome.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object declaration
            Word word = new Word();
            OutputConsole OC = new OutputConsole();

            //Asks for user input
            Console.WriteLine(OC.WelcomePrompt);
            word.UserWord = Console.ReadLine();

            //Processes word and outputs results
            try
            {
                if (word.IsPalindrome())
                {
                    Console.WriteLine(word.UserWord + OC.CorrectPrompt);
                }
                else
                {
                    Console.WriteLine(word.UserWord + OC.IncorrectPrompt);
                }
            }
            catch
            {
                Console.WriteLine(OC.ErrorPrompt);
            }
            
            //Prompts the user to press a button to exit the application
            Console.WriteLine(OC.ExitPrompt);
            Console.ReadKey();
        }

        
    }
}
