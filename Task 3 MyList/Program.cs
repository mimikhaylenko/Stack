using System;

namespace Task_3_MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> my = new MyList<string>();

            my.Add("the first");
            my.Add("the second");
            my.Add("the third");

            Console.WriteLine(my.GetValue(2));
            Console.WriteLine(my.GetValue(1));
            Console.WriteLine(my.GetValue(0));
            Console.WriteLine("Amount of items: " + my.Count);

            string[] arr = my.GetArray();
            foreach (string item in arr)
                Console.Write($"{item} ");
        }
    }
    public class Node<T>
    {
        T item;
        public T Item { get { return item; } set { item = value; } }
        public Node<T> Next { get; set; }

    }
    static class MyListExtension
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] arr = new T[list.Count];

            for (int i = 0; i < list.Count; i++)
                arr[i] = list.GetValue(i);
            return arr;
        }
    }
    class MyList<T>
    {

        Node<T> head;
        Node<T> tail;
        int count = 0;
        public int Count { get { return count; } }
        public void Add(T value)
        {
            Node<T> node = new Node<T>();
            node.Item = value;
            if (head == null)
                head = node;
            else tail.Next = node;
            tail = node;
            count++;
        }
        public T GetValue(int index)
        {
            T temp = default(T);
            int counter = 0;
            Node<T> current = head;
            temp = current.Item;
            while (current != null)
            {
                if (counter == index)
                    return temp;
                else
                {
                    counter++;
                    current = current.Next;
                    temp = current.Item;
                }
            }
            Console.WriteLine("This index doesn't exist");
            return default(T);
        }

    }
}
