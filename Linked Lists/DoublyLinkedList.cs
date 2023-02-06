using System.Text;

namespace Linked_Lists;

public class DoublyLinkedList
{
    private Node? _root = null;
    private Node? _last = null;
    public void Print()
    {
        var sb = new StringBuilder();
        var node = _root;
        while (node != null)
        {
            sb.Append("[ " + node.Value + " ]");
            node = node.Next;
        }
        Console.WriteLine(sb.ToString());
    }
    public int this[int index]//Accessing by index of element 0 to len-1
    {
        get
        {
            var node = GetAt(index);
            if(node == null)
                throw new ArgumentOutOfRangeException();
            return node.Value;
        }
        set
        {
            var node = GetAt(index);
            if (node == null)
                throw new ArgumentOutOfRangeException();
            node.Value = value;
        }
    }
    private Node? GetAt(int index)
    {
        var current = _root;
        for(int i=0;i<index;i++)
        {
            if (current == null)
                return null;
            current = current.Next;
        }
        return current;
    }
    public void Add(int value)
    {
        if (_root == null)
        {
            _root = new Node(value);
            _last = _root;
        }
        else
        {
            _last.Next = new Node(value)
            {
                Previous = _last
            };
            _last = _last.Next;
        }
    }
    private Node? Find(int value)
    {
        if (_root == null)
        {
            return null;
        }
        var current = _root;
        while (current!=null)
        {
            if (current.Value == value)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }
    void Delete(int value)
    {
        if (_root == null)
            return;
        var nodeDelete = Find(value);
        if (nodeDelete == null)
            return;
        if (_root.Value == value)
            _root = _root.Next;

        if (nodeDelete.Next != null)
            nodeDelete.Next.Previous = nodeDelete.Previous;
        else
            _last = nodeDelete.Previous;

        if (nodeDelete.Previous != null)
            nodeDelete.Previous.Next = nodeDelete.Next;
    }
    public class Node
    {
        public int Value {get;set;}
        public Node(int value)
        {
            Value = value;
        }
        public Node? Next { get; set; }
        public Node? Previous { get; set; }
    }
}
