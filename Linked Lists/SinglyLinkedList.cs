namespace Linked_Lists;

public class SinglyLinkedList
{
    private Node? _head;
    public bool IsEmpty => _head == null;
    public void AddFirst(int value)
    {
        var toAdd = new Node(_head,value);
        _head = toAdd;
    }
    public void AddLast(int data)
    {
        if (_head == null)
            _head = new Node(null,data);//First element in collection
        else
        {
            var toAdd = new Node(null,data);
            var current = _head;
            while (current.Next != null)//Iteration to last element
            {
                current = current.Next;
            }
            current.Next = toAdd;//Insertion by linking with last element
        }
    }
    public int DeleteByValue(int value)
    {
        if (_head == null)
            return value;
        if (_head.Value == value)
        {
            _head = _head.Next;
            return value;
        }
        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value == value)
            {
                current.Next = current.Next.Next;
                return value;
            }
            current = current.Next;
        }
        return value;
    }
    public int? DeleteTail()
    {
        if (_head == null)
            return null;
        if (_head.Next==null)
        {
            var value = _head.Value;
            _head = null;
            return value;
        }
        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Next == null)
            {
                var value = current.Next.Value;
                current.Next = null;
                return value;
            }
            current = current.Next;
        }
        return null;
    }
    public int? DeleteHead()
    {
        if (_head == null)
            return null;
        var value = _head.Value;
        _head = _head.Next;
        return value;
    }
    public void Print() {
        var current = _head;
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
