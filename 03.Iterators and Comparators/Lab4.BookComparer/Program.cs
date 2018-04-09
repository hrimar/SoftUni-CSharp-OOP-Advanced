using System;


class Program
{
    static void Main()  // 100/100 - !
    {
        // Виж Library - row13 - инициализиране на кол-я с 2-ри парам как да са подредени!!!

        Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
        Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
        Book bookThree = new Book("The Documents in the Case", 1930);

        Library libraryOne = new Library();
        Library libraryTwo = new Library(bookOne, bookTwo, bookThree);


        foreach (var book in libraryTwo)
        {
            Console.WriteLine(book);
        }
    }
}

