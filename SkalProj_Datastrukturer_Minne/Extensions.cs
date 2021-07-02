using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public static class Extensions
    {
        
        public static bool CheckForParanthesis(this string str)
        {
            Dictionary<char, char> mapBrackets = new Dictionary<char, char>() { { '}', '{' },
                                                                         { ']', '[' },
                                                                         { ')', '(' } };

            Stack<char> bracetStack = new Stack<char>();
            foreach (char c in str)
            {
                if (c == '{' || c == '[' || c == '(')
                    bracetStack.Push(c);
                else if (c == '}' || c == ']' || c == ')')
                {
                    if (bracetStack.Count == 0)
                        return false;
                   
                    char mappedBracketValue = mapBrackets[c];
                   
                    if (bracetStack.Peek() == mappedBracketValue)
                    {
                        bracetStack.Pop();
                    }
                    else
                        return false;
                }
            }
            if (bracetStack.Count > 0)
                return false;

            return true;
        }


        public static int RecursiveEven(this int num)
        {
            if (num == 0)
            {
                return 0;
            }
            return RecursiveEven(num - 1) + 2;
        } 


        public static int IterationEven(this int num)
        {
            if (num == 0)
            {
                return 0;
            }
            int result = 0;
           for(int i = 0; i<num;i++)
            {
                result += 2;
            }
            return result;
        }


        public static int FibonacciSequence(this int num)
        {
            if (num == 0||num==1)
            {
                return 1;
            }

            return FibonacciSequence(num - 1)+FibonacciSequence(num-2);
        }

        public static int IterateFibonacciSequence(this int num)
        {
            int pnum = 0, ppnum= 0;
            int res=1;
           
            for (int i = 0; i <  num; i++)
            {
                pnum = ppnum;
                  
                ppnum = res;

                res = pnum+ppnum;
            }
            return res;
        }
    }
}
//Rekursion är slower än iteration på grund av overhead för att underhålla stacken. Rekursion använder mer minne än iteration men Rekursion gör koden mindre.