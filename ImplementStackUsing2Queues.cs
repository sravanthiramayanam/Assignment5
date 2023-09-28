using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementStackUsing2Queues
{
    class ImplementStackUsing2Queues
    {

        // Two inbuilt queues
        public Queue q1 = new Queue();
        public Queue q2 = new Queue();

        public void push(int x)
        {
            // Push x first in empty q2
            q2.Enqueue(x);

            // Push all the remaining
            // elements in q1 to q2.
            while (q1.Count > 0)
            {
                q2.Enqueue(q1.Peek());
                q1.Dequeue();
            }

            // swap the names of two queues
            Queue q = q1;
            q1 = q2;
            q2 = q;
        }

        public int pop()
        {

            // if no elements are there in q1
            if (q1.Count == 0)
                return -1;
            return (int) q1.Dequeue();
        }


        public static void Main(String[] args)
        {
            ImplementStackUsing2Queues s = new ImplementStackUsing2Queues();
            s.push(1);
            s.push(2);
            s.push(3);

            Console.WriteLine(s.pop());
            Console.WriteLine(s.pop());
            Console.WriteLine(s.pop());

        }

    }
}
