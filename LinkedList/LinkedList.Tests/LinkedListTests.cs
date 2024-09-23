using System;
using Xunit;

public class LinkedListTests
{
    [Fact]
    public void Insert_SingleElement_ListContainsElement()
    {
        var list = new LinkedList<int>();
        list.Insert(10, 0);
        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(20, 2)); // Out of range
        Assert.Equal("10 -> null", GetListAsString(list));
    }

    [Fact]
    public void Insert_MultipleElements_ListContainsAllElements()
    {
        var list = new LinkedList<int>();
        list.Insert(10, 0);
        list.Insert(20, 1);
        list.Insert(15, 1); // List should be 10 -> 15 -> 20

        Assert.Equal("10 -> 15 -> 20 -> null", GetListAsString(list));
    }

    [Fact]
    public void Delete_HeadElement_HeadIsUpdated()
    {
        var list = new LinkedList<int>();
        list.Insert(10, 0);
        list.Insert(20, 1);
        list.Delete(0); // List should be 20
        Assert.Equal("20 -> null", GetListAsString(list));
    }

    [Fact]
    public void Delete_MiddleElement_ListContainsRemainingElements()
    {
        var list = new LinkedList<int>();
        list.Insert(10, 0);
        list.Insert(20, 1);
        list.Insert(30, 2); // List: 10 -> 20 -> 30
        list.Delete(1); // Delete 20
        Assert.Equal("10 -> 30 -> null", GetListAsString(list));
    }

    [Fact]
    public void Delete_OutOfRange_ThrowsException()
    {
        var list = new LinkedList<int>();
        list.Insert(10, 0);
        Assert.Throws<IndexOutOfRangeException>(() => list.Delete(1)); // Out of range
    }

    private string GetListAsString(LinkedList<int> list)
    {
        // Use reflection or modify your LinkedList class to expose a method for testing
        var output = "";
        var current = list.GetHead(); // Assuming you create a method to expose the head
        while (current != null)
        {
            output += current.Data + " -> ";
            current = current.Next;
        }
        return output + "null";
    }
}