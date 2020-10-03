using System;
using System.Linq;

namespace TrendyolCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = frameGenerator(8);

            //int[] array = { 3, 2, 3, 1, 1 };
            //var x = concatSwaps("descognail", array);

            //var y = constructorNames("abbzccc", "babzzcz");
            Console.ReadKey();
        }

        public static string[] frameGenerator(int n)
        {
            string[] array = new string[n];
            string val = "";
            for (int i = 0; i < n; i++)
            {
                val = "";
                if (i == 0 || i == n - 1)
                {
                    for (int l = 0; l < n; l++)
                    {
                        val = val + "*";
                    }
                }
                else
                {
                    val = val + "*";
                    for (int l = 0; l < n - 2; l++)
                    {
                        val = val + " ";
                    }
                    val = val + "*";
                }
                array[i] = val;
            }

            return array;
        }

        public static string concatSwaps(string s, int[] sizes)
        {
            string[] character = new string[sizes.Length];
            if (sizes.Length == 1)
            {
                return s;
            }

            for (int i = 0; i < sizes.Length; i++)
            {
                int first = 0;
                if (i != 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        first = first + sizes[j];
                    }
                }
                character[i] = s.Substring(first, sizes[i]);
            }

            string bardak = "";
            for (int i = 1; i < character.Length; i = i + 2)
            {
                bardak = character[i];
                character[i] = character[i - 1];
                character[i - 1] = bardak;
            }


            return string.Join("", character);
        }

        static bool constructorNames(string className, string methodName)
        {
            string newClassName = className.Substring(1, 1) + className.Substring(0, 1) + className.Substring(2);
            string theNewest = "";
            for (int i = 0; i < newClassName.Length; i++)
            {
                char character = newClassName[i];
                if (character == 'z')
                {
                    character = 'c';
                }
                else if (character == 'c')
                {
                    character = 'z';
                }
                theNewest = theNewest + character;
            }
            newClassName = theNewest;

            string newMethodName = methodName;
            if (methodName.Length > 3 && methodName.Length > 5)
            {
                newMethodName = newMethodName.Substring(0, 3) + newMethodName.Substring(5, 1) + newMethodName.Substring(4, 1) + newMethodName.Substring(3, 1) + newMethodName.Substring(6);

            }

            bool response = false;
            for (int i = 0; i < newClassName.Length; i++)
            {
                response = newMethodName.Contains(newClassName[i]);
                if (!response)
                    break;
            }

            return response;
        }

    }
}
