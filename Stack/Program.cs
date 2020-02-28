using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<char> myStack = new MyStack<char>();
            Dictionary<char, char> braces = new Dictionary<char, char> { { '<', '>' }, { '{', '}' }, { '[', ']' }, { '(', ')' }, { '2', '2' }, { '3', '3' }, { '4', '4' } };
            Console.WriteLine("Input a line:");
            string str = Console.ReadLine(); ;
            
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '<' || str[i] == '(' || str[i] == '{' || str[i] == '[')
                    myStack.Push(str[i]);
                else if ((i + 1 < str.Length) && ((str[i] == '2' && str[i + 1] == '3') || (str[i] == '3' && str[i + 1] == '4')))
                {
                    myStack.Push(str[i++]);
                    myStack.Push(str[i]);

                }
                else
                if (str[i] == '>' || str[i] == ')' || str[i] == '}' || str[i] == ']')
                {
                    if (str[i] == braces.GetValueOrDefault(myStack.Peek()) && myStack.StackIsEmpty == false)
                        myStack.Pop();
                    else myStack.Push(str[i]);
                }
                else if ((i + 1 < str.Length) && ((str[i] == '3' && str[i + 1] == '2') || (str[i] == '4' && str[i + 1] == '3')))
                {
                    if (myStack.StackIsEmpty == false)
                    {
                        myStack.Pop();
                        myStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("The line is wrong :(");
                        return;
                    }
                }
            }

            if (myStack.StackIsEmpty == true)
                Console.WriteLine("The line is correct");
            else Console.WriteLine("The line is wrong :(");
        }

        public class MyStack<T>
        {
            private T[] items = new T[100];
            private T Top { get; set; }
            private int size = 1;
     
            public bool StackIsEmpty
            {
                get
                {
                    if (size == 1)
                        return true;
                    else return false;
                }
            }
            public void Push(T item)
            {
                items[size++] = item;
                Top = item;
            }
            public T Peek()
            {
                return Top;
            }
            public T Pop()
            {
                T item = items[--size];
                Top = items[size - 1];
                return item;
            }           
        }
    }
}