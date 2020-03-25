using System;
using System.Collections.Generic;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class LRUCache
    {
        private int _capacity;
        private Dictionary<int, int> _internalMap;
        private LinkedList<int> _lastAccessedList;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _internalMap = new Dictionary<int, int>(capacity);
            _lastAccessedList = new LinkedList<int>();
        }

        public int Get(int key)
        {
            if (_internalMap.ContainsKey(key))
            {
                MoveKeyToFront(key); // O(n)

                return _internalMap[key];
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (value < 0)
            {
                return;
            }

            MoveKeyToFront(key);

            if (_internalMap.Count == _capacity && !_internalMap.ContainsKey(key))
            {
                var lruItem = _lastAccessedList.Last.Value;
                _lastAccessedList.RemoveLast();
                _internalMap.Remove(lruItem);
            }

            if (!_internalMap.ContainsKey(key))
            {
                _internalMap.Add(key, value);
            }
            else
            {
                _internalMap[key] = value;
            }
        }

        private void MoveKeyToFront(int key)
        {
            _lastAccessedList.Remove(key);
            _lastAccessedList.AddFirst(key);
        }
    }
}
