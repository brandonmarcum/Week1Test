using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            var word = Console.ReadLine();

            if(isPalindrome(word))
            {
                Console.WriteLine(word + " is a palindrome.");
            }
            else
            {
                Console.WriteLine(word + " is not a palindrome.");
            }

            Console.ReadKey();

        }

        static bool isPalindrome(string word)
        {
            int min = 0;
            int max = word.Length - 1;
            char firstLetter;
            char lastLetter;

            while(min < max)
            {
                firstLetter = word[min];
                lastLetter = word[max];

                if (char.ToLower(firstLetter) != char.ToLower(lastLetter))
                {
                    return false;
                }
                min++;
                max--;
            }
            

            return true;
        }
    }
}
