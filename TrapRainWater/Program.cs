using System;

namespace TrapRainWater
{
    class Program
    {
        public static int Trap(int[] height)
        {
            var left = new int[height.Length];
            var right = new int[height.Length];
            var leftMax = 0;
            var rightMax = 0;
            var trapped = 0;

            for (int i = 0; i < height.Length; i++)
            {
                left[i] = leftMax;
                leftMax = Math.Max(height[i], leftMax);
            }

            for (int i = height.Length - 1; i >= 0; i--)
            {
                right[i] = rightMax;
                rightMax = Math.Max(height[i], rightMax);
            }

            for (int i = 0; i < height.Length; i++)
            {
                // min of left and right, minus the value there
                var potentional = Math.Min(left[i], right[i]) - height[i];

                trapped += potentional >= 0 ? potentional : 0;
            }

            return trapped;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
