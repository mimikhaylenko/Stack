using System;
using System.Collections;

namespace Task_2_Limited_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            LimitedStack<string> limStack = new LimitedStack<string>();

            limStack.Push("a");
            limStack.Push("b");
            limStack.Push("c");
            limStack.Push("d");
            limStack.Push("e");
            limStack.Push("f");
            limStack.Push("g");
            limStack.Push("h");
            limStack.Push("o");
            limStack.Push("10");
            limStack.Push("11");

            while (limStack.Size > 0)
                Console.Write(limStack.Pop() + " ");
        }
        class LimitedStack<T>
        {
            public int Size { get; set; } = 0;
            static int maxSize;
            T[] items;
            public LimitedStack()
            {
                maxSize = 7;
                items = new T[maxSize];
            }
            public void Push(T value)
            {
                if (Size == maxSize)
                    FirstOut();
                items[Size++] = value;
            }
            public T Pop()
            {
                return items[--Size];
            }
            public void FirstOut()
            {
                Size--;
                for (int i = 0; i < Size; i++)
                    items[i] = items[i + 1];
            }
        }
    }
}