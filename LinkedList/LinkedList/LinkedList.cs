using System;

public class LinkedList<T>
{
    private Node<T> head;
    public int Count { get; private set; } // Keeps track of the number of nodes

    // Make Node<T> public so it can be accessed outside
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public void Insert(T data, int position)
    {
        if (position < 0 || position > Count)
            throw new IndexOutOfRangeException("Position is out of range.");

        var newNode = new Node<T>(data);

        if (position == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            var current = head;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        Count++; // Increment the count
    }

    public void Delete(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            var current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next?.Next;
        }

        Count--; // Decrement the count
    }

    public Node<T> GetHead() // Method to get the head of the list
    {
        return head;
    }

    public void PrintList()
    {
        var current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}