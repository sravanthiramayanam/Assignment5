using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetminelementO_1_
{
    class Getminelement
    {
       Stack<Node> s;

       public class Node
       {
         public int val;
         public int min;

         public Node(int val, int min)
         {
             this.val = val;
             this.min = min;
         }
       }

            /** initialize your data structure here. */
       public Getminelement() 
       { 
            this.s = new Stack<Node>(); 
       }

       public void push(int x)
       {
         if (s.Count == 0)
         {
             this.s.Push(new Node(x, x));
         }
         else
         {
             int min = Math.Min(this.s.Peek().min, x);
             this.s.Push(new Node(x, min));
         }
       }

       public int pop() 
       { 
            return this.s.Pop().val;
       }

       //public int top() 
       //{ 
       //     return this.s.Peek().val; 
       //}

       public int getMin()
       { 
            return this.s.Peek().min;
       }
    }

        // Driver code
        public class GFG
        {

            //public static void Main(String[] args)
            //{
            //    Getminelement s = new Getminelement();

            //    // Function call
            //    s.push(-1);
            //    s.push(10);
            //    s.push(-4);
            //    s.push(0);
            //    Console.WriteLine(s.getMin());
            //    Console.WriteLine(s.pop());
            //    Console.WriteLine(s.pop());
            //    Console.WriteLine(s.getMin());
            //}
        }
    
}
