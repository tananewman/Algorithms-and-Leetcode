using System;

namespace KthGrammar
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = KthGrammarRecursive(4, 5);
        }

        public static int KthGrammar(int N, int K) 
        {
            return KthGrammarRecursive(N, K);
        }

        public static int KthGrammarRecursive(int N, int K)
        {        
            // base case
                // if row == 1, return 0
            // recurrence relation
                // return opposite of the (n - 1, k / 2)            
            if (N == 1)
            {
                return 0;
            }

            if (N == 2)
            {
                if (K == 1)
                {
                    return 0;
                }
                return 1;
            }
            
            var result = KthGrammar(N - 1, K / 2);
            return result == 0 ? 1 : 0;

            // row 1: 0
            // row 2: 01
            // row 3: 0110
            // row 4: 011010 0 1
            // row 5: 011010011001 0 110
            // row 6: 01101001100101101001011001101001 12: 1
        }        
    }        
}

