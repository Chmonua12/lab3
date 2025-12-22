using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IList<T>
{
    private class Node
    {
        public T Data;
        public Node Next;
        public Node Prev;
    }
    
    private Node head;
    private Node tail;
    private int count;
    
    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }
    
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
                
            Node current = GetNode(index);
            return current.Data;
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
                
            Node current = GetNode(index);
            current.Data = value;
        }
    }
    
    public int Count => count;
    public bool IsReadOnly => false;
    
    private Node GetNode(int index)
    {
        if (index < 0 || index >= count)
            return null;
            
        Node current;
        if (index < count / 2)
        {
            current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
        }
        else
        {
            current = tail;
            for (int i = count - 1; i > index; i--)
            {
                current = current.Prev;
            }
        }
        return current;
    }
    
    public void Add(T item)
    {
        Node newNode = new Node { Data = item };
        
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        
        count++;
    }
    
    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }
    
    public bool Contains(T item)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Equals(item))
                return true;
            current = current.Next;
        }
        return false;
    }
    
    public int IndexOf(T item)
    {
        Node current = head;
        int index = 0;
        
        while (current != null)
        {
            if (current.Data.Equals(item))
                return index;
                
            current = current.Next;
            index++;
        }
        
        return -1;
    }
    
    public void Insert(int index, T item)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();
            
        if (index == count)
        {
            Add(item);
            return;
        }
        
        Node newNode = new Node { Data = item };
        
        if (index == 0)
        {
            newNode.Next = head;
            if (head != null)
                head.Prev = newNode;
            head = newNode;
            
            if (tail == null)
                tail = newNode;
        }
        else
        {
            Node current = GetNode(index);
            Node previous = current.Prev;
            
            newNode.Next = current;
            newNode.Prev = previous;
            
            previous.Next = newNode;
            current.Prev = newNode;
        }
        
        count++;
    }
    
    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index != -1)
        {
            RemoveAt(index);
            return true;
        }
        return false;
    }
    
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();
            
        Node current = GetNode(index);
        
        if (current.Prev != null)
            current.Prev.Next = current.Next;
        else
            head = current.Next;
            
        if (current.Next != null)
            current.Next.Prev = current.Prev;
        else
            tail = current.Prev;
            
        count--;
    }
    
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException();
            
        if (arrayIndex < 0)
            throw new IndexOutOfRangeException();
            
        Node current = head;
        int i = arrayIndex;
        
        while (current != null)
        {
            array[i] = current.Data;
            current = current.Next;
            i++;
        }
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
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