using System;
using System.Collections;
using System.Collections.Generic;

public class CustomStack<T> : IEnumerable<T>
{
    List<T> collection = new List<T>();

    public List<T> Collection
    {
        get => collection;
        set { collection = value; }
    }

    public void Push(T element)
    {
        Collection.Add(element);
    }

    public T Pop()
    {
        if (Collection.Count == 0)
        {
            throw new ArgumentException("No elements");
        }

        T elementToPop = Collection[Collection.Count - 1];
        Collection.RemoveAt(Collection.Count - 1);

        return elementToPop;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int a = Collection.Count - 1; a >= 0; a--)
        {
            yield return collection[a];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
