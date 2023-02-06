namespace Linked_Lists;

public class SinglyLinkedList
{
    public Node? head;
    public bool IsEmpty => head == null;
    public void AddFirst(int value)
    {
        var toAdd = new Node(head,value);
        head = toAdd;
    }
    public void AddLast(int data)
    {
        if (head == null)
            head = new Node(null,data);//First element in collection
        else
        {
            var toAdd = new Node(null,data);
            var current = head;
            while (current.Next != null)//Iteration to last element
            {
                current = current.Next;
            }
            current.Next = toAdd;//Insertion by linking with last element
        }
    }
    public int DeleteTail()
    {
        throw new NotImplementedException();
    }
    public int DeleteHead()
    {
        throw new NotImplementedException();
    }
    public void Print() {
        var current = head;
        while (current != null) 
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }
    public class Node
    {
        public Node? Next;
        public int Value;
        public Node(Node? next, int value)
        {
            Next = next;
            Value = value;
        }
    }
}
