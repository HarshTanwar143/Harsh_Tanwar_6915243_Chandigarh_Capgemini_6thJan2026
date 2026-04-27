using System;
using System.Collections.Generic;
using System.Text;


namespace MahirlAndMath
{
    class UserMainCode
    {
        public static int MinOperations(int input1)
        {
            Queue<int> q = new Queue<int>();
            Dictionary<int, int> dist = new Dictionary<int, int>();

            q.Enqueue(10);
            dist[10] = 0;

            while (q.Count > 0)
            {
                int curr = q.Dequeue();

                if (curr == input1)
                    return dist[curr];

                int[] next = { curr + 2, curr - 1, curr * 3 };

                foreach (int n in next)
                {
                    if (n >= 0 && n <= input1 * 3 && !dist.ContainsKey(n))
                    {
                        dist[n] = dist[curr] + 1;
                        q.Enqueue(n);
                    }
                }
            }

            return -1;
        }
    }
}
