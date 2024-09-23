using System;

class Program
{
    static void Main(string[] args)
    {
        var linkedList = new LinkedList<int>();
        linkedList.Insert(10, 0); // List: 10
        linkedList.Insert(20, 1); // List: 10 -> 20
        linkedList.Insert(15, 1); // List: 10 -> 15 -> 20
        linkedList.PrintList();    // Output: 10 -> 15 -> 20 -> null

        linkedList.Delete(1);      // Deletes 15
        linkedList.PrintList();    // Output: 10 -> 20 -> null

        linkedList.Insert(5, 0);   // List: 5 -> 10 -> 20
        linkedList.PrintList();    // Output: 5 -> 10 -> 20 -> null
    }
}