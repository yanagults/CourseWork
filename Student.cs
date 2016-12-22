using System;
using System.Collections.Generic;

namespace Manipulation
{
    [Serializable]
    public class Student
    {
        private string name;
        private string surname;
        private int group;
        private List<Book> books;

        public string Name { get { return name; } }
        public string Surname { get { return surname; } }
        public int Group { get { return group; } }
        public List<Book> StBooks { get { return books; } }
        public void AddBook(Book bk) { books.Add(bk); }
        public void DeleteBook(Book bk) { books.Remove(bk); }


        public Student(string N, string S, int G)
        {
            name = N;
            surname = S;
            group = G;
            books = new List<Book>();
        }

        public string toString()
        {
            string books = "";
            foreach(Book b in StBooks)
            {
                books += b.toString();
            }
            return ($"{name} {surname} group: {group} \nBooks: {books} \n");
        }


    }
}
