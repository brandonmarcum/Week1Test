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
            string userWordNoSpace = UserWord.Replace(" ", String.Empty);

            int min = 0;
            int max = userWordNoSpace.Length - 1;
            char firstLetter;
            char lastLetter;

            if (userWordNoSpace.Length < 2)
            {
                return false;
            }

            while (min < max)
            {
                firstLetter = userWordNoSpace[min];
                lastLetter = userWordNoSpace[max];

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
