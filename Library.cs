using System;
using System.Collections.Generic;
using System.Linq;


namespace Manipulation
{
    [Serializable]
    public class Library
    {
        private string path;
        DB_Interconnection connection;  
        BooksStudents BkSt = new BooksStudents();

        public string Path { get { return path; } set { path = value; } }        

        public Library()
        {           
            path = @"C:\Users\Yana\Documents\Visual Studio 2015\Projects\Course_Work\Books.txt";
            connection = new DB_Interconnection(path);
            BkSt = connection.GetContent();
        }

        public void AddStudent(string n, string s, int gr)
        {
            if (BkSt.Students == null)
                BkSt.Students = new List<Student>();
            Student stAdd = new Student(n, s, gr);
            BkSt.Students.Add(stAdd);
            /*(connection.GetContent()).Students.Add(stAdd);
            connection.SetContent(BkSt);*/
        }
        public bool DeleteStudent(string N, string S)
        {
            bool flag = true;
            //foreach (Student st in BkSt.Students)
            Student st;
            for(int i = 0; i<BkSt.Students.Count; i++)
            {
                st = BkSt.Students[i];
                if (st.Name == N && st.Surname == S)
                {
                    BkSt.Students.Remove(st);
                    flag = true;
                }
            }
             return flag;
        }
        public string StudentsToString()
        {          
                string res = "";
                foreach (Student st in BkSt.Students)
                {
                    res += st.toString();
                }
                return res;            
        }
        public bool ContainsStud(string N, string S)
        {
            bool flag = true;            
            Student st;
            for (int i = 0; i < BkSt.Students.Count; i++)
            {
                st = BkSt.Students[i];
                if (st.Name == N && st.Surname == S)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public bool IsEmpty()
        {
            if (BkSt.Students.Count == 0)
                return true;
            else
                return false;
        }       
        public void ChangeData(Student stChange, Student newSt)
        {
            int index = BkSt.Students.IndexOf(stChange);
            if (index != -1)
                BkSt.Students[index] = newSt;
        }    

        public string SortByName()
        {
            if(BkSt.Students.Count ==0)
                throw new NullReferenceException("Sorry, the list of students is empty. Nothing to sort!");
            List<Student> temp = BkSt.Students.OrderBy(x => x.Name).ToList();
            string res = "";
            foreach (Student st in temp)
            {
                res += st.toString();
            }
            return res;
        }
        public string SortBySurname()
        {
            if (BkSt.Students.Count == 0)
                throw new NullReferenceException("Sorry, the list of students is empty. Nothing to sort!");
            List<Student> temp = BkSt.Students.OrderBy(x => x.Surname).ToList();
            string res = "";
            foreach (Student st in temp)
            {
                res += st.toString();
            }
            return res;
        }    
        public string SortByGroup()
        {
            if (BkSt.Students.Count == 0)
                throw new NullReferenceException("Sorry, the list of students is empty. Nothing to sort!");
            List<Student> temp = BkSt.Students.OrderBy(x => x.Group).ToList();
            string res = "";
            foreach (Student st in temp)
            {
                res += st.toString();
            }
            return res;
        }
        

        public void AddBook(string title, string author, int number)
        {
            if (BkSt.Books == null)
                BkSt.Books = new List<Book>();
            Book new_book = new Book(title, author, number);
            BkSt.Books.Add(new_book);            
        }
        public bool DeleteBook(string A, string T)
        {
            bool flag = true;
            Book bk;
            for (int i = 0; i < BkSt.Books.Count; i++)
            {
                bk = BkSt.Books[i];
                if (bk.Author == A && bk.Title == T)
                {
                    if (bk.Number > 1&& bk.Number<=0)
                        bk.Number = bk.Number - 1;
                    else
                        BkSt.Books.Remove(bk);
                    flag = true;
                }
            }            
            return flag;
        }
        public string BooksToString()
        {
            string res = "";
            foreach (Book bk in BkSt.Books)
            {
                res += bk.toString();
            }
            return res;
        }
        public bool BookListIsEmpty()
        {
            if (BkSt.Books.Count == 0)
                return true;
            else
                return false;
        }
        public bool BooksContains(string A, string T)
        {
            bool flag = true;
            Book bk;
            for (int i = 0; i < BkSt.Books.Count; i++)
            {
                bk = BkSt.Books[i];
                if (bk.Author == A && bk.Title == T)
                {                   
                    flag = true;
                }
            }
            return flag;
        }
        public void ChangeBookData(Book bkChange, Book newBK)
        {
            int index = BkSt.Books.IndexOf(bkChange);
            if (index != -1)
                BkSt.Books[index] = newBK;
        }

        public string SortByTitle()
        {
            if(BkSt.Books.Count ==0)
                throw new NullReferenceException("Sorry, the list of books is empty. Nothing to sort!");
            List<Book> temp = BkSt.Books.OrderBy(x => x.Title).ToList();
            string res = "";
            foreach (Book st in temp)
            {
                res += st.toString();
            }
            return res;
        }
        public string SortByAuthor()
        {
            if (BkSt.Books.Count == 0)
                throw new NullReferenceException("Sorry, the list of books is empty. Nothing to sort!");
            List<Book> temp = BkSt.Books.OrderBy(x => x.Author).ToList();
            string res = "";
            foreach (Book st in temp)
            {
                res += st.toString();
            }
            return res;
        }


        public Book AssignBookNumber(string A, string T)
        {                        
            Book bk = new Book();
            for (int i = 0; i < BkSt.Books.Count; i++)
            {
                bk = BkSt.Books[i];
                if (bk.Author == A && bk.Title == T)
                {
                    return bk;
                }
            }
            return bk;
        }
        public bool ChekStudentBooks(string n, string s, int g)
        {
            Student st = new Student(n, s, g);
            int index = BkSt.Students.IndexOf(st);
            if (index != -1)
               if(BkSt.Students[index].StBooks.Count>=5)          
                return false;
            return true;
        }
        public bool ChekBookAvailability(string a, string t)
        {
            Book bk = AssignBookNumber(t, a);
            int index = BkSt.Books.IndexOf(bk);
            if (index != -1)
                if (BkSt.Books[index].Owner.Count >= BkSt.Books[index].Number)
                    return false;
            return true;
        }
        public void GiveStBook(string name, string surname, int group, string author, string title)
        {
            Student st = new Student(name, surname, group);
            Book bk = AssignBookNumber(author, title);
            st.AddBook(bk);
            int index = BkSt.Books.IndexOf(bk);
            if (index != -1)
                BkSt.Books[index].Number--;
        }

        public List<Student> BookOwners(string a, string t)
        {
            List<Student> OwnerList = new List<Student>();
            Book bk = AssignBookNumber(a, t);
            int index = BkSt.Books.IndexOf(bk);
            if (index != -1)
                if (BkSt.Books[index].Owner == null)
                    return OwnerList;
            return OwnerList;
        }
        public string StrOwnerList(string a, string t)
        {
            string res = "";
            foreach (Student st in BookOwners(a,t))
            {
                res += st.toString();
            }
            return res;
        }

        public void ReturnBook(string name, string surname, int group, string a, string t)
        {
            Student st = new Student(name, surname, group);
            Book bk = AssignBookNumber(a, t);
            st.DeleteBook(bk);
            int index = BkSt.Books.IndexOf(bk);
            if (index != -1)
                BkSt.Books[index].Number++;
        }


        public string FindStudents(string N, string S)
        {
            string res = "";
            Student st;
            for (int i = 0; i < BkSt.Students.Count; i++)
            {
                st = BkSt.Students[i];
                if (st.Name == N && st.Surname == S)
                {
                    res += st.toString();
                }
            }
            return res;
        }
        public string StrGroup(int group)
        {
            string res = $"Group {group}: \n";
            Student st;
            for (int i = 0; i < BkSt.Students.Count; i++)
            {
                st = BkSt.Students[i];
                if (st.Group == group)
                {
                    res += st.toString();
                }
            }
            return res;
        }
        public string FindAuthor(string author)
        {
            string res = "";
            Book bk;
            for (int i = 0; i < BkSt.Books.Count; i++)
            {
                bk = BkSt.Books[i];
                if (bk.Author == author)
                {
                    res += bk.toString();
                }
            }
            return res;
        }
        public string FindTitle(string title)
        {
            string res = "";
            Book bk;
            for (int i = 0; i < BkSt.Books.Count; i++)
            {
                bk = BkSt.Books[i];
                if (bk.Title == title)
                {
                    res += bk.toString();
                }
            }
            return res;
        }


        public void SaveToDB()
        {
            connection.SetContent(BkSt);
        }
    }
}


