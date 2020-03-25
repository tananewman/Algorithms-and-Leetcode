using System;
using System.Collections.Generic;

namespace PascalsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MyPow(234.234, int.MaxValue);
            Console.ReadLine();
        }

        public static double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n == 1)
            {
                return x;
            }

            var absN = Math.Abs(n);
            var dp = new double[absN + 1];
            
            // base case
            dp[0]  = 1;
            dp[1] = x; 

            for (long i = 2; i <= absN; i++)
            {
                dp[i] = x * dp[i - 1];
            }

            return n > 0 ? dp[absN] : 1 / dp[absN];
        }

        public static double MyPowRecursive(double x, int n)
        {
            var absoluteN = Math.Abs(n);
            
            // base case
            if (absoluteN == 0)
            {
                return 1;
            }

            if (absoluteN == 1)
            {
                return n > 0 ? x : 1 / x;
            }
            
            var result = x * MyPow(x, absoluteN - 1);
            return n > 0 ? result : 1 / result;
            // 3 and 3 should be 27
            
            // recurence relation
                // I think it's the number x * MyPower(x, n - 1)
        } 

        public static int ClimbStairs(int n) 
        {
            if (n <= 2)
            {
                return n;
            }
            var memo = CreateMemo(n);
            return ClimbStairs(n, memo);
        }
        
        public static int ClimbStairs(int n, int[] memo)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }
            
            var numberOfWays = ClimbStairs(n - 1, memo) + ClimbStairs(n - 2, memo);
            memo[n] = numberOfWays;
            return numberOfWays;
        }
        
        private static int[] CreateMemo(int n)
        {
            var memo = new int[n + 1];
            memo[0] = 1;
            memo[1] = 1;
            memo[2] = 2;
            
            return memo;
        }

        // public static IList<int> GetRow(int rowIndex) 
        // {        
        //     var row = new int[rowIndex + 1];
        //     var memo = CreateMemo(rowIndex);
            
        //     for (int column = 0; column <= rowIndex; column++)
        //     {
        //         row[column] = GetValueRecursive(rowIndex, column, memo);
        //     }
            
        //     return row;
        // }   
    
        // public static int[][] CreateMemo(int rowCount)
        // {
        //     var memo = new int[rowCount + 1][];
            
        //     for (int i = 0; i <= rowCount; i++)
        //     {
        //         memo[i] = new int[i + 1];
        //     }
            
        //     return memo;
        // }
        
        // public static int GetValueRecursive(int row, int column, int[][] memo)
        // {   // 3, 1        
        //     if (memo[row][column] != 0)
        //     {
        //         return memo[row][column];
        //     }
            
        //     if (column == 0 || row == column)
        //     {
        //         memo[row][column] = 1;
        //         return 1;
        //     }
            
        //     var result = GetValueRecursive(row - 1, column - 1, memo) + GetValueRecursive(row - 1, column, memo);
        //     memo[row][column] = result;
            
        //     return result;
        // }
    }
}
