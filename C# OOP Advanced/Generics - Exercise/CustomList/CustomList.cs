using System;
using System.Collections;
using System.Collections.Generic;

public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    int length;
    int capacity;
    T[] array;

    public CustomList()
    {
        length = 0;
        capacity = 4;
        array = new T[Capacity];
    }

    public T this[int index]
    {
        get => array[index];
        set
        {
            array[index] = value;
        }
    }

    public int Length
    {
        get => length;
        private set { length = value; }
    }

    public int Capacity
    {
        get => capacity;
        set { capacity = value; }
    }

    public void Add(T element)
    {
        array[Length] = element;
        Length++;

        if (Length == Capacity)
        {
            Capacity *= 2;
            Array.Resize<T>(ref array, Capacity);
        }
    }

    public void Remove(int index)
    {
        for (int a = index; a < Length - 1; a++)
        {
            array[a] = array[a + 1];
        }

        Length--;

        if (Capacity / 2 > Length)
        {
            Capacity /= 2;
            T[] newArr = new T[Capacity];
            Array.Copy(array, newArr, Capacity);
            array = newArr;
        }

        array[Length] = default(T);
    }

    public bool Contains(T element)
    {
        bool isContains = false;

        for (int a = 0; a < Length; a++)
        {
            if (array[a].Equals(element))
            {
                isContains = true;
                break;
            }
        }

        return isContains;
    }

    public void Swap(int index1, int index2)
    {
        T element1 = array[index1];
        array[index1] = array[index2];
        array[index2] = element1;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;

        for (int a = 0; a < Length; a++)
        {
            if (array[a].CompareTo(element) == 1)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        T maxElement = array[0];

        for (int a = 1; a < Length; a++)
        {
            if (array[a].CompareTo(maxElement) == 1)
            {
                maxElement = array[a];
            }
        }

        return maxElement;
    }

    public T Min()
    {
        T minElement = array[0];

        for (int a = 1; a < Length; a++)
        {
            if (array[a].CompareTo(minElement) == -1)
            {
                minElement = array[a];
            }
        }

        return minElement;
    }

    public void Sort()
    {
        Array.Sort(array, 0, Length);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int a = 0; a < Length; a++)
        {
            yield return array[a];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}