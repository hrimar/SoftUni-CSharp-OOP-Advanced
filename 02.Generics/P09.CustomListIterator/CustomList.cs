using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private T[] data;
    private bool isFixed;

    public CustomList()
    {
        this.data = new T[0];
    }
    public CustomList(int initialSize)
    {
        this.data = new T[initialSize];
        this.isFixed = true;
    }

    public bool IsEmpty => this.Count == 0;

    public int InnerArraySize => this.data.Length;

    public int Count { get; private set; } = 0;

    public T this[int index] // за да можем да взимаме по индекс в Print
    {
        get
        {
            return this.data[index];
        }
        set
        {
            this.data[index] = value;
        }
    }


    public void Add(T element)
    {
        int newDataSize = this.IsEmpty ? 4 : this.InnerArraySize * 2;

        this.Count++;

        if (this.Count > this.InnerArraySize)
        {     
            T[] newData = new T[this.InnerArraySize * 2];
            Array.Copy(this.data, newData, this.InnerArraySize);
            this.data = newData;

            this.isFixed = false;
        }

        this.data[this.Count - 1] = element;
    }

    public T Remove(int index)
    {
        this.ValidateIndex(index);

        T element = this.data[index];

        this.Count--;

        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.data[this.Count] = default(T);

        if (this.Count < this.InnerArraySize / 3 && !isFixed)
        {
            T[] newData = new T[this.InnerArraySize / 2];
            Array.Copy(this.data, newData, this.Count);
            this.data = newData;
        }

        return element;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        this.ValidateIndex(firstIndex);
        this.ValidateIndex(secondIndex);

        T temp = this.data[firstIndex];

        this.data[firstIndex] = this.data[secondIndex];
        this.data[secondIndex] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        for (int i = 0; i < this.Count; i++)
        {
            T currentEl = this.data[i];

            if (currentEl.CompareTo(element) > 0)
            {
                count++;
            }
        }
        return count;
    }

    public T Min()
    {
        this.CheckIfEmpty();

        T minElement = this.data[0];

        for (int i = 1; i < this.Count; i++)
        {
            T currentEl = this.data[i];
            if (currentEl.CompareTo(minElement) < 0)
            {
                minElement = currentEl;
            }
        }
        return minElement;
    }

    private void CheckIfEmpty()
    {
       if(this.IsEmpty)
        {
            throw new InvalidOperationException();
        }
    }

    public T Max()
    {
        this.CheckIfEmpty();

        T maxElement = this.data[0];

        for (int i = 1; i < this.Count; i++)
        {
            T currentEl = this.data[i];
            if (currentEl.CompareTo(maxElement) > 0)
            {
                maxElement = currentEl;
            }
        }
        return maxElement;
    }

    public void Sort(IComparer<T> comparer = null) // по желание може да се подава и компарер
    {
        Array.Sort(this.data, 0, this.Count, comparer);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.data[i]; // т.е. докато има елем ж масижа връща ст-сти
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void ValidateIndex(int index)
    {
        if(index<0 || index> this.Count-1)
        {
            throw new IndexOutOfRangeException();
        }
    }
}