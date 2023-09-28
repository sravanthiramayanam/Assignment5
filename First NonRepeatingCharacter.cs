using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class First_NonRepeatingCharacter
    {
        public static void FirstNonRepeating(char[] A)
        {

            // map to find uniqueness of an element
            Dictionary<char, int> mp
              = new Dictionary<char, int>();
            Queue<char> q = new Queue<char>();

            // queue to keep non-repeating element at the starting.
            for (int i = 0; i < A.Length; i++)
            {


                if (!mp.ContainsKey(A[i]))
                {
                    q.Enqueue(A[i]);
                }
                if (mp.ContainsKey(A[i]))
                    mp[A[i]] += 1;
                else
                    mp[A[i]] = 1;

                while (q.Count > 0 && mp[q.Peek()] > 1)
                {
                    q.Dequeue();
                }


                if (q.Count > 0)
                {
                     Console.WriteLine(q.Peek());
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }

           
          
        }

        //static public void Main()
        //{

        //    char[] A = new char[] { 'a', 'a', 'b', 'c' };
        //    FirstNonRepeating(A);
           
        //}
    }
}
