using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome.Library
{
    public class Word
    {
        public string UserWord { get; set; }

        public bool IsPalindrome()
        {
            int min = 0;
            int max = UserWord.Length - 1;
            char firstLetter;
            char lastLetter;

            if (UserWord.Length < 2)
            {
                return false;
            }

            while (min < max)
            {
                firstLetter = UserWord[min];
                lastLetter = UserWord[max];

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
