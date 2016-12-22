using System;
using System.Collections.Generic;

namespace Manipulation
{
    [Serializable]
    public class Book
    {
        private string title;
        private string author;
        private List<Student> owner;//List
        private int number;

        public string Title{get { return title;} }
        public string Author { get { return author; } }
        public List<Student> Owner { get { return owner; } }
        public void SetOwner(Student st) { owner.Add(st); }
        public int Number {
            get { return number; }
            set { number = value; }
        }

        public Book() { }
        public Book(string T, string A, int N)
        {
            title = T;
            author = A;
            owner = new List<Student>();
            number = N;
        }


        public string toString()
        {
            return ($"{title} {author} \n");
        }
    }
}
