using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ExtendedDatabase
{
    public abstract class ExtendedDb<T>
    {
        protected const int MaxCapacity = 16;

        private int currentIndex;
        private T[] elements;

        private ExtendedDb()
        {
            this.Elements = new T[MaxCapacity];
        }
        public ExtendedDb(params T[] values)
            : this()
        {
            this.CurrentIndex = 0;
            this.InitializeValues(values);
        }

        public int CurrentIndex { get => currentIndex; protected set => currentIndex = value; }
        public T[] Elements { get => elements; protected set => elements = value; }

        private void InitializeValues(T[] inputValues)
        {
            try
            {
                Array.Copy(inputValues, this.Elements, inputValues.Length);
                this.CurrentIndex = inputValues.Length;
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException("The database is full!");
            }

            //foreach (var item in inputValues)
            //{
            //    this.Add(item);
            //}
        }

        public T this[int i]
        {
            get { return this.Elements[i]; }
        }

        public virtual void Add(T element)
        {
            if (this.CurrentIndex >= MaxCapacity)
            {
                throw new InvalidOperationException("The database is full!");
            }

            this.Elements[this.CurrentIndex] = element;
            this.CurrentIndex++;
        }

        public void Remove()
        {
            if (this.CurrentIndex == 0)
            {
                throw new InvalidOperationException("The database is empty!");
            }

            this.CurrentIndex--;
            this.Elements[this.CurrentIndex] = default(T); // 0        
        }

        public int[] Fetch()
        {
            int[] newArray = new int[CurrentIndex];
            Array.Copy(this.Elements, newArray, CurrentIndex);

            return newArray;
        }
    }
}
