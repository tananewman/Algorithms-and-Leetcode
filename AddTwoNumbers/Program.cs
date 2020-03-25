using System;

namespace AddTwoNumbers
{
    public class ListNode
    {
        public ListNode(int x)
        {
            val = x;
        }

        public ListNode next { get; set; }
        public int val { get; set; }
    }

    class AddTwoNumbersClass
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode current = null;
            ListNode previous = null;
            var carry = 0;
            var foundHead = false;
            ListNode head = null;

            while (l1 != null || l2 != null || carry != 0)
            {
                if (l1 == null)
                {
                    l1 = new ListNode(0);
                }
                if (l2 == null)
                {
                    l2 = new ListNode(0);
                }

                var result = l1.val + l2.val + carry;
                carry = result / 10;
                var digit = result % 10;

                current = new ListNode(digit);
                if (!foundHead)
                {
                    head = current;
                    foundHead = true;
                }

                if (previous != null)
                {
                    previous.next = current;
                }
                previous = current;

                l1 = l1.next;
                l2 = l2.next;
            }

            return head;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
