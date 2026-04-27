using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionPaper
{
    internal class CheckValid
    {
        public static void check(int x, int y, int n1, int n2, int M)
        {
            int maxType1Marks = n1 * x;

            for (int t1 = n1; t1 >= 0; t1--)
            {
                int marksFromType1 = t1 * x;
                int remaining = M - marksFromType1;

                if (remaining < 0) continue;

                if (remaining % y == 0)
                {
                    int t2 = remaining / y;

                    if (t2 >= 0 && t2 <= n2)
                    {
                        Console.WriteLine("\n\nValid");
                        Console.WriteLine(t1);
                        Console.WriteLine(t2);
                        return;
                    }
                }
            }

            Console.WriteLine("\n\nInvalid");
        }
    }
}
