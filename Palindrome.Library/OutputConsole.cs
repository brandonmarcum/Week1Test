using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome.Library
{
    public class OutputConsole
    {
        public string WelcomePrompt { get; }
        public string ExitPrompt { get; }
        public string CorrectPrompt { get; }
        public string IncorrectPrompt { get; }
        public string ErrorPrompt { get; }

        public OutputConsole()
        {
            WelcomePrompt = "Enter a word you think is a palindrome!";
            ExitPrompt = "Press ANY KEY to exit";
            CorrectPrompt = " is a palindrome.";
            IncorrectPrompt = " is not a palindrome.";
            ErrorPrompt = "An error has occurred";
        }
    }
}
