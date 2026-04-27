using System;
using System.Collections.Generic;
using System.Text;

namespace MahirlAlphabets
{
    class UserMainCode
    {
        public static string ProcessString(string input1, string input2)
        {
            string result = "";

            for (int i = 0; i < input1.Length; i++)
            {
                char c1 = input1[i];
                char lower1 = Char.ToLower(c1);

                if (IsVowel(lower1))
                {
                    result = result + c1;
                }
                else
                {
                    bool found = false;

                    for (int j = 0; j < input2.Length; j++)
                    {
                        if (lower1 == Char.ToLower(input2[j]))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        result = result + c1;
                }
            }

            string finalResult = "";

            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0 || Char.ToLower(result[i]) != Char.ToLower(result[i - 1]))
                    finalResult = finalResult + result[i];
            }

            return finalResult;
        }

        static bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
    }
}
