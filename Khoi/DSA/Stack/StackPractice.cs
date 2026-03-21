using System.Collections.Generic;

namespace DSA.Stack
{
    public class StackPractice
    {
        // https://leetcode.com/problems/min-stack/submissions/1954970222/?envType=problem-list-v2&envId=stack

        public class MinStack
        {
            Stack<int> stack = new();
            Stack<int> minStack = new();

            public MinStack() { }

            public void Push(int val)
            {
                stack.Push(val);

                if (minStack.Count == 0 || val < minStack.Peek())
                {
                    minStack.Push(val);
                }
                else
                {
                    minStack.Push(minStack.Peek());
                }
            }

            public void Pop()
            {
                if (stack.Count == 0)
                {
                    return;
                }

                stack.Pop();
                minStack.Pop();
            }

            public int Top()
            {
                if (stack.Count == 0)
                {
                    return -1;
                }

                return stack.Peek();
            }

            public int GetMin()
            {
                if (minStack.Count == 0)
                {
                    return -1;
                }
                return minStack.Peek();
            }
        }

        ///////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/evaluate-reverse-polish-notation/submissions/1954938227/?envType=problem-list-v2&envId=stack

        public int EvalRPN(string[] tokens)
        {
            if (tokens.Length == 1)
            {
                return int.Parse(tokens[0]);
            }

            Stack<string> stack = new();

            int res = 0;

            foreach (string el in tokens)
            {
                if (el == "+" || el == "-" || el == "*" || el == "/")
                {
                    int firstNum = int.Parse(stack.Pop());
                    int secondNum = int.Parse(stack.Pop());

                    if (el == "+")
                    {
                        res = firstNum + secondNum;
                    }

                    if (el == "-")
                    {
                        res = secondNum - firstNum;
                    }

                    if (el == "/")
                    {
                        res = secondNum / firstNum;
                    }

                    if (el == "*")
                    {
                        res = secondNum * firstNum;
                    }

                    stack.Push(res.ToString());
                }
                else
                {
                    stack.Push(el);
                }
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/simplify-path/submissions/1954895126/?envType=problem-list-v2&envId=stack

        public string SimplifyPathClean(string path)
        {
            Stack<string> stack = new();

            var parts = path.Split('/');

            foreach (var part in parts)
            {
                if (part == "" || part == ".")
                {
                    continue;
                }
                else if (part == "..")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                {
                    stack.Push(part);
                }
            }

            return "/" + string.Join("/", stack.Reverse());
        }

        // fucking dirty version!!!!
        public string SimplifyPath(string path)
        {
            Stack<string> stack = new();

            char[] chars = path.ToCharArray();

            string curStr = "";
            foreach (char el in chars)
            {
                if (el == '/')
                {
                    if (curStr == ".")
                    {
                        curStr = "";
                        continue;
                    }
                    else if (curStr == "..")
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        curStr = "";
                        continue;
                    }
                    else if (curStr != "")
                    {
                        stack.Push(curStr);
                        curStr = "";
                        continue;
                    }

                    continue;
                }

                curStr += el;
            }

            if (curStr == ".." && stack.Count > 0)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else if (curStr == ".." && stack.Count == 0)
            {
                return "/";
            }
            else if (curStr != "" && curStr != ".")
            {
                stack.Push(curStr);
            }
            string res = "";

            while (stack.Count > 0)
            {
                string el = stack.Pop();

                if (el == "")
                {
                    continue;
                }

                res = "/" + el + res;
            }

            if (res == "")
            {
                return "/";
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/valid-parentheses/submissions/1954860399/?envType=problem-list-v2&envId=stack

        public bool IsValid(string s)
        {
            char[] chars = s.ToCharArray();

            Stack<char> stack = new();

            foreach (char el in chars)
            {
                if (el == '(' || el == '[' || el == '{')
                {
                    stack.Push(el);
                }
                else if (el == ')' || el == ']' || el == '}')
                {
                    if (stack.Count <= 0)
                    {
                        return false;
                    }

                    char curEl = stack.Pop();

                    if ((curEl == '(' && el == ']') || (curEl == '(' && el == '}'))
                    {
                        return false;
                    }

                    if ((curEl == '[' && el == ')') || (curEl == '[' && el == '}'))
                    {
                        return false;
                    }

                    if ((curEl == '{' && el == ']') || (curEl == '{' && el == ')'))
                    {
                        return false;
                    }
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
