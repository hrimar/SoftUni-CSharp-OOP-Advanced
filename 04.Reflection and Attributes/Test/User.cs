using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
   public class User
    {
        public readonly string city = "Sofia";
        public int id = 0;

        public int Id { get; set; }
        public string  Name { get; set; }
        public int Age { get; set; }


        public User()
        {
            this.Id = 0;
            this.Name = "no name";            
        }
        public User(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        protected int CalcIdPlusAge()
        {
            return this.Id + this.Age;
        }
    }
}
