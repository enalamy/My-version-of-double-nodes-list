/*using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    Node<T>? head;
    Node<T>? tail;
    int count;

    public void Add(T Data)
    {
        Node<T> node = new Node<T>(Data);

        if (head == null) 
            head = node;
        else 
            tail!.Next = node;
        tail = node;

        count++;
    }

    public bool Remove(T Data)
    {
        Node<T>? current = head;
        Node<T>? previous = null;

        while(current != null && current.Data != null)
        {
            if (current.Data.Equals(Data))
            {
                if (previous != null)
                {
                    previous.Next = current.Next;
                    if (current.Next == null)
                        tail = previous;
                }
                else
                {
                    head = head?.Next;
                    if (head == null)
                        tail = null; 
                } 
                count--;
                return true;
            }
            previous = current;
            current = current.Next; 
        }
        return false;
    }

    public int Count {  get { return count; } } 
    public bool IsEmpty { get { return count == 0; } }
    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public bool Contains (T Data)
    {
        Node<T>? current = head;
        while (current != null && current.Data != null)
        {
            if (!current.Data.Equals(Data))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void AppendFirst (T Data)
    {
        Node<T> node = new Node<T> (Data);
        node.Next = head;
        head = node;
        if (count == 0)
            tail = head;
        count++;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<string> names = new LinkedList<string>
        {
            "Tom",
            "Alice",
            "Bob",
            "Sam"
        };
        foreach (var item in names)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\n Huy!!!!! \n");
        names.AppendFirst("Huyara");
        foreach (var item in names)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(names.Contains("Bob"));
        Console.WriteLine(names.Contains("pizda"));
        Console.WriteLine(names.IsEmpty);
        names.Clear();
        Console.WriteLine("this is elon musk");
        foreach (var item in names)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(names.IsEmpty);
    }
}
    
*/