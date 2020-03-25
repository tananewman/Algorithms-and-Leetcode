using System;
using System.Collections.Generic;

namespace LengthOfLongestSubstring
{

    class Program
    {
        public int LengthOfLongestSubstring2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            if (s.Length == 1)
            {
                return 1;
            }

            var seenChars = new Dictionary<char, int>();
            var longestLength = 1;
            var start = 0;

            for (int end = 0; end < s.Length; end++)
            {
                if (!seenChars.ContainsKey(s[end]))
                {
                    seenChars.Add(s[end], end);
                    longestLength = Math.Max(longestLength, end - start + 1);
                }
                else
                {
                    var character = s[end];
                    start = seenChars[character] + 1;
                }
            }


            return longestLength;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
