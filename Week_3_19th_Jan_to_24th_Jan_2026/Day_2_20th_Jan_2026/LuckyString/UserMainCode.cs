using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyString
{
    class UserMainCode
    {
        public static string IsLuckyString(int input1, string input2)
        {
            int n = input1;
            string s = input2;

            if (n > s.Length)
                return "Invalid";

            int half = n / 2;

            for (int i = 0; i <= s.Length - n; i++)
            {
                int p = 0, g = 0, sc = 0;

                for (int j = i; j < i + n; j++)
                {
                    if (s[j] != 'P' && s[j] != 'S' && s[j] != 'G')
                    {
                        p = g = sc = 0;
                        break;
                    }

                    if (s[j] == 'P')
                    {
                        p++;
                        g = sc = 0;
                    }
                    else if (s[j] == 'G')
                    {
                        g++;
                        p = sc = 0;
                    }
                    else
                    {
                        sc++;
                        p = g = 0;
                    }

                    if (p >= half || g >= half || sc >= half)
                        return "Yes";
                }
            }

            return "No";
        }
    }
}
