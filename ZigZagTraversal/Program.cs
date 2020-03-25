using System;
using System.Collections.Generic;

namespace ZigZagTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var node5 = new TreeNode(5);
            var node9 = new TreeNode(9);
            var node20 = new TreeNode(20);
            var node15 = new TreeNode(15);
            var node17 = new TreeNode(17);
            var node1 = new TreeNode(1);

            node5.left = node9;
            node5.right = node20;
            node20.left = node15;
            node20.right = node17;
            node9.left = node1;

            ZigzagLevelOrder(node5);
        }

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root) 
        {
            // the leetcode stuff
            var resultList = new List<List<int>>();
            var levelList = new List<int>();

            if (root == null)
            {
                return new List<List<int>>().ToArray();
            }

            var currentLevel = new Stack<TreeNode>();
            currentLevel.Push(root);

            var nextLevel = new Stack<TreeNode>();

            var isLeftToRight = true;

            while (currentLevel.Count != 0)
            {
                var current = currentLevel.Pop();
                levelList.Add(current.val);

                if (isLeftToRight)
                {
                    if (current.left != null)
                    {
                        nextLevel.Push(current.left);
                    }
                    if (current.right != null)
                    {
                        nextLevel.Push(current.right);
                    }
                }
                else
                {
                    if (current.right != null)
                    {
                        nextLevel.Push(current.right);
                    }
                    if (current.left != null)
                    {
                        nextLevel.Push(current.left);
                    }
                }

                if (currentLevel.Count == 0)
                {
                    resultList.Add(levelList);
                    levelList = new List<int>();

                    currentLevel = nextLevel;
                    nextLevel = new Stack<TreeNode>();
                    isLeftToRight = !isLeftToRight;
                }
            }

            return resultList.ToArray();
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
