using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleDictionary<TKey, TValue> : IDictionary<TKey, TValue>, 
                                             IReadOnlyDictionary<TKey, TValue>
{
    private class Entry
    {
        public TKey Key;
        public TValue Value;
        public Entry Next;
    }
    
    private Entry[] buckets;
    private int count;
    
    public SimpleDictionary()
    {
        buckets = new Entry[16];
        count = 0;
    }
    
    public TValue this[TKey key]
    {
        get
        {
            if (TryGetValue(key, out TValue value))
                return value;
            throw new KeyNotFoundException();
        }
        set
        {
            int index = GetBucketIndex(key);
            Entry current = buckets[index];
            
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    current.Value = value;
                    return;
                }
                current = current.Next;
            }
            
            Add(key, value);
        }
    }
    
    public ICollection<TKey> Keys
    {
        get
        {
            List<TKey> keys = new List<TKey>();
            foreach (var entry in this)
            {
                keys.Add(entry.Key);
            }
            return keys;
        }
    }
    
    public ICollection<TValue> Values
    {
        get
        {
            List<TValue> values = new List<TValue>();
            foreach (var entry in this)
            {
                values.Add(entry.Value);
            }
            return values;
        }
    }
    
    IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;
    IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;
    
    public int Count => count;
    public bool IsReadOnly => false;
    
    private int GetBucketIndex(TKey key)
    {
        int hashCode = key.GetHashCode() & 0x7FFFFFFF;
        return hashCode % buckets.Length;
    }
    
    public void Add(TKey key, TValue value)
    {
        if (key == null)
            throw new ArgumentNullException();
            
        int index = GetBucketIndex(key);
        Entry current = buckets[index];
        
        while (current != null)
        {
            if (current.Key.Equals(key))
                throw new ArgumentException("Такой ключ уже есть");
            current = current.Next;
        }
        
        Entry newEntry = new Entry
        {
            Key = key,
            Value = value,
            Next = buckets[index]
        };
        
        buckets[index] = newEntry;
        count++;
    }
    
    public void Add(KeyValuePair<TKey, TValue> item)
    {
        Add(item.Key, item.Value);
    }
    
    public bool ContainsKey(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException();
            
        int index = GetBucketIndex(key);
        Entry current = buckets[index];
        
        while (current != null)
        {
            if (current.Key.Equals(key))
                return true;
            current = current.Next;
        }
        
        return false;
    }
    
    public bool Remove(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException();
            
        int index = GetBucketIndex(key);
        Entry current = buckets[index];
        Entry previous = null;
        
        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                if (previous == null)
                    buckets[index] = current.Next;
                else
                    previous.Next = current.Next;
                    
                count--;
                return true;
            }
            
            previous = current;
            current = current.Next;
        }
        
        return false;
    }
    
    public bool TryGetValue(TKey key, out TValue value)
    {
        if (key == null)
            throw new ArgumentNullException();
            
        int index = GetBucketIndex(key);
        Entry current = buckets[index];
        
        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                value = current.Value;
                return true;
            }
            current = current.Next;
        }
        
        value = default(TValue);
        return false;
    }
    
    public void Clear()
    {
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = null;
        }
        count = 0;
    }
    
    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        if (TryGetValue(item.Key, out TValue value))
        {
            return value.Equals(item.Value);
        }
        return false;
    }
    
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException();
            
        if (arrayIndex < 0)
            throw new IndexOutOfRangeException();
            
        int i = arrayIndex;
        foreach (var entry in this)
        {
            array[i] = entry;
            i++;
        }
    }
    
    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        if (Contains(item))
        {
            return Remove(item.Key);
        }
        return false;
    }
    
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < buckets.Length; i++)
        {
            Entry current = buckets[i];
            while (current != null)
            {
                yield return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                current = current.Next;
            }
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}