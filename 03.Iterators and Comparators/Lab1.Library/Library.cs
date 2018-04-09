﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Library : IEnumerable<Book>
{
    private IReadOnlyList<Book> books;  // !!!

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books); // To be intilized without books or with any number of books 
    }

    public IEnumerator<Book> GetEnumerator()
    {
        for (int i = 0; i < books.Count; i++)
        {
            yield return books[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

