using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleList : IList, ICollection, IEnumerable
{
    private object[] items;
    private int count;
    
    public SimpleList()
    {
        items = new object[10];
        count = 0;
    }
    
    public int Count
    {
        get { return count; }
    }
    
    public bool IsReadOnly
    {
        get { return false; }
    }
    
    public bool IsFixedSize
    {
        get { return false; }
    }
    
    public bool IsSynchronized
    {
        get { return false; }
    }
    
    public object SyncRoot
    {
        get { return this; }
    }
    
    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            return items[index];
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            items[index] = value;
        }
    }
    
    public int Add(object value)
    {
        if (count == items.Length)
        {
            ResizeArray();
        }
        
        items[count] = value;
        count++;
        return count - 1;
    }
    
    public bool Contains(object value)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i] == value)
                return true;
        }
        return false;
    }
    
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            items[i] = null;
        }
        count = 0;
    }
    
    public int IndexOf(object value)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i] == value)
                return i;
        }
        return -1;
    }
    
    public void Insert(int index, object value)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();
            
        if (count == items.Length)
        {
            ResizeArray();
        }
        
        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }
        
        items[index] = value;
        count++;
    }
    
    public void Remove(object value)
    {
        int index = IndexOf(value);
        if (index != -1)
        {
            RemoveAt(index);
        }
    }
    
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();
            
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        
        items[count - 1] = null;
        count--;
    }
    
    public void CopyTo(Array array, int index)
    {
        if (array == null)
            throw new ArgumentNullException();
            
        if (index < 0)
            throw new IndexOutOfRangeException();
            
        for (int i = 0; i < count; i++)
        {
            array.SetValue(items[i], index + i);
        }
    }
    
    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return items[i];
        }
    }
    
    private void ResizeArray()
    {
        object[] newArray = new object[items.Length * 2];
        for (int i = 0; i < count; i++)
        {
            newArray[i] = items[i];
        }
        items = newArray;
    }
}