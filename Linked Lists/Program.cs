using Linked_Lists;

var list = new SinglyLinkedList();
list.InsertHead(1);
list.InsertTail(2);
list.InsertTail(2);
list.InsertHead(3);
list.InsertAfter(2, 55);
list.InsertAfter(8, 55);
Console.WriteLine($"List before deletion: ");
list.Print();
list.DeleteHead();
list.DeleteTail();
list.DeleteByValue(2);
Console.WriteLine($"List after deletion: ");
list.Print();
