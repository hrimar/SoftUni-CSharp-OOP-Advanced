using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LinkedList<T> : IEnumerable<T>
{

    public LinkedList()
    {
        this.Count = 0;
        this.HeadNode = null;
    }

    public int Count { get; set; }

    private Node HeadNode { get; set; }


    private class Node
    {
        public Node(T inputValue)
        {
            this.Value = inputValue;
            this.Next = null;
        }

        public T Value { get; }

        public Node Next { get; set; } //

        public void AddToEnd(T inputValue)
        {
            if (this.Next == null)
            {
                this.Next = new Node(inputValue);
            }
            else
            {
                this.Next.AddToEnd(inputValue);
            }
        }
    }

    public void AddToEnd(T data)
    {
        if (this.HeadNode == null)
        {
            this.HeadNode = new Node(data);
        }
        else
        {
            this.HeadNode.AddToEnd(data);
        }

        this.Count++;
    }

    public bool Remove(int item)
    {        
        if (this.HeadNode == null)
        {
            return false;
        }

        Node currentNode = this.HeadNode;
        Node previousNode = null;

        while (currentNode != null)
        {
            if (currentNode.Value.Equals(item))
            {
                // When the current node is not the first one in the list:
                if (previousNode != null)
                {
                    previousNode.Next = currentNode.Next;
                }
                else
                {
                    // When the current node is the first one in the list
                    this.HeadNode = this.HeadNode.Next;
                }

                this.Count--;
                return true;
            }

            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currentNode = this.HeadNode;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    
}

