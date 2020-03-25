using System;
using System.Collections.Generic;

namespace TwoSum
{
    class Program
    {
        public int[] TwoSumN(int[] nums, int target)
        {
            var seenNumberMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (seenNumberMap.ContainsKey(complement))
                {
                    return new[] { i, seenNumberMap[complement] };
                }

                if (!seenNumberMap.ContainsKey(nums[i]))
                {
                    seenNumberMap.Add(nums[i], i);
                }
            }

            return null;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
