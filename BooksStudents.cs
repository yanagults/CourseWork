using System;
using System.Collections.Generic;

namespace Manipulation
{
    [Serializable]
    public class BooksStudents
    {
        List<Student> students = new List<Student>();
        List<Book> books = new List<Book>();
        public BooksStudents()
        {
            students = new List<Student>();
            books = new List<Book>();
        }
        
        public List<Student> Students { get; set; }
        public List<Book> Books { get; set; }

    }
}
