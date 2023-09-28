using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    class LRUCache
    {


        private int _capacity;
        private Dictionary<int, Node> _map;
        private Node head;
        private Node tail;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _map = new Dictionary<int, Node>();

            head = new Node(0, 0);
            tail = new Node(0, 0);

            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            if (_map.ContainsKey(key))
            {
                // Remove the node from the LinkedList 
                RemoveFromLinkedList(_map[key]);
                // Insert it right before the tail so we know It is the Most Recently Used
                InsertIntoLinkedList(_map[key]);
                // Now just return the val
                return _map[key]._val;
            }

            return -1;
        }

        public void Set(int key, int value)
        {

            if (_map.ContainsKey(key))
            {
                //Remove if exist because we need to make it the MRU
                RemoveFromLinkedList(_map[key]);
            }

            //Create a new Node and put it in the HashMap
            _map[key] = new Node(key, value);
            //Insert it in the list 
            InsertIntoLinkedList(_map[key]);
            if (_map.Count > _capacity)
            {
                //Remove the LRU from the LinkedList and Delete it from HashMap
                //Get the LRU
                var lruNode = head.next;
                RemoveFromLinkedList(lruNode);
                _map.Remove(lruNode._key);
            }


        }

        private void RemoveFromLinkedList(Node node)
        {
            var nextNode = node.next;
            var prevNode = node.prev;

            // Update the prev and next nodes to point to eachother and ignore our input node, this is how we remove it from the list
            nextNode.prev = prevNode;
            prevNode.next = nextNode;
        }


        private void InsertIntoLinkedList(Node node)
        {
            // Since we decided earlier that the tail dummy node will point to the Most Recently Used.
            var nodeBeforeTail = tail.prev;

            tail.prev = node;
            nodeBeforeTail.next = node;

            node.prev = nodeBeforeTail;
            node.next = tail;
        }

        //public static void Main(String[] args)
        //{

        //    LRUCache cache = new LRUCache(5);


        //    cache.Set(1, 100);
        //    cache.Set(2, 200);
        //    cache.Set(3, 300);
        //    cache.Set(4, 300);
        //    cache.Set(5, 500);
        //    Console.WriteLine(cache.Get(1));
        //    cache.Set(6, 600);
        //    Console.WriteLine(cache.Get(2));


        //}


    }



    public class Node
    {
        public int _key;
        public int _val;
        public Node next;
        public Node prev;

        public Node(int key, int val)
        {
            _val = val;
            _key = key;
            next = null;
            prev = null;
        }
    }

    

}

