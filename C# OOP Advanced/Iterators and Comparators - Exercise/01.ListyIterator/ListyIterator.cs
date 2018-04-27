using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    int index = 0;
    List<T> collection = new List<T>();

    public ListyIterator(List<T> collection)
    {
        Collection = collection;
    }

    public List<T> Collection
    {
        get => collection;
        set { collection = value; }
    }

    public bool Move()
    {
        if (HasNext())
        {
            index++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HasNext()
    {
        return index + 1 < Collection.Count;
    }

    public void Print()
    {
        if (Collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(collection[index]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int a = 0; a < Collection.Count; a++)
        {
            yield return Collection[a];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
