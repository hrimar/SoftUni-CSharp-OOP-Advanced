using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ExtendedDatabase
{
  public  class Person
    {
        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }

        public string Username { get; }

        public long Id { get; }
    }
}
