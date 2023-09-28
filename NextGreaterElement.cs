using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGreaterElement
{
    class NextGreaterElement
    {
        public class stack
        {
            public int top;
            public int[] items = new int[100];

            public virtual void push(int x)
            {
                if (top == 99)
                {
                    Console.WriteLine("Stack full");
                }
                else
                {
                    items[++top] = x;
                }
            }

            public virtual int pop()
            {
                if (top == -1)
                {
                    Console.WriteLine("Underflow error");
                    return -1;
                }
                else
                {
                    int element = items[top];
                    top--;
                    return element;
                }
            }

            public virtual bool Empty
            {
                get { return (top == -1) ? true : false; }
            }
        }
        public static void GreaterElementNext(int[] arr, int n)
        {
            int i = 0;
            stack s = new stack();
            s.top = -1;
            int element, next;

            s.push(arr[0]);

            for (i = 1; i < n; i++)
            {
                next = arr[i];

                if (s.Empty == false)
                {

                    element = s.pop();

                    while (element < next)
                    {
                        Console.WriteLine(element + " --> "
                                          + next);
                        if (s.Empty == true)
                        {
                            break;
                        }
                        element = s.pop();
                    }

                    if (element > next)
                    {
                        s.push(element);
                    }
                }

                s.push(next);
            }

            while (s.Empty == false)
            {
                element = s.pop();
                next = -1;
                Console.WriteLine(element + " --> " + next);
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 5, 2, 25 };
            int n = arr.Length;
            GreaterElementNext(arr, n);
        }
    }
}
