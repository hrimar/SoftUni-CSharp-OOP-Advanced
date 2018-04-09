using System;
using System.Collections.Generic;
using System.Text;

namespace P03.IteratorTestProject
{
   public class ListIterator
    {
        private List<string> data;
        private int currentIndex = 0;

        public ListIterator(List<string> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            this.data = new List<string>(collection);
        }

        public bool Move() => ++this.currentIndex < this.data.Count;

        public bool HasNext() => this.currentIndex < this.data.Count - 1;

        public string Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.data[this.currentIndex];
        }

    }
}
