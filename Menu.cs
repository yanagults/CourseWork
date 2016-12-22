using System;
using Manipulation;
using System.Text.RegularExpressions;

namespace Course_Work
{
    class Menu
    {
        private Library logic  = new Library();

        public Menu() {
            //logic = new Library();
        }
       
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("1. Control of library users");
            Console.WriteLine("2. Control of books");
            Console.WriteLine("3. Control of giving books");
            Console.WriteLine("4. Search");
            Console.WriteLine("5. Exit");

            Console.WriteLine("Type number of needed action: ");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("1. Add user");
                    Console.WriteLine("2. Delete user");
                    Console.WriteLine("3. Change data of a user ");
                    Console.WriteLine("4. Show data of a definite user");
                    Console.WriteLine("5. List of all users");
                    Console.WriteLine("6. Back");
                    StudentOp(Console.ReadLine());
                    Run();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("1. Add book");
                    Console.WriteLine("2. Delete book");
                    Console.WriteLine("3. Change data of a book");
                    Console.WriteLine("4. Show data of a definite book");
                    Console.WriteLine("5. List of all books");
                    Console.WriteLine("6. Back");
                    DocumentOp(Console.ReadLine());
                    Run();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("1. Show which books has a definite user");
                    Console.WriteLine("2. Define if book is in the library");
                    Console.WriteLine("3. Give user a book");
                    Console.WriteLine("4. Return book to library");
                    Console.WriteLine("5. Back");
                    ControlOp(Console.ReadLine());
                    Run();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("1. Search student by his surname and name");
                    Console.WriteLine("2. Search students of the definite group");
                    Console.WriteLine("3. Search books by author");
                    Console.WriteLine("4. Search books by title");
                    Console.WriteLine("5. Back");
                    SearchOp(Console.ReadLine());
                    Run();
                    break;
                case "5":
                    logic.SaveToDB();
                    break;
                default:
                    Console.WriteLine($"Unknown operation {operation}");
                    break;
            }
                    
        }

        public void StudentOp(string stOperation)
        {
            switch (stOperation)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    DeleteStudent();
                    break;
                case "3":
                    ChangeData();
                    break;
                case "4":
                    ShowStud();
                    break;
                case "5":
                    ShowAll();
                    break;
                case "6":
                    break;
                default:
                    break;
            }
        }
        
        public void DocumentOp(string docOperation)
        {
            switch (docOperation)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    DeleteBook();
                    break;
                case "3":
                    ChangeBookData();
                    break;
                case "4":
                    ShowBook();
                    break;
                case "5":
                    ShowAllBooks();
                    break;
                case "6":
                    break;
                default:
                    break;
            }
        }

        public void ControlOp(string contrlOperation)
        {
            switch (contrlOperation)
            {
                case "1":
                    ShowStud();
                    break;
                case "2":
                    ReturnBook();
                    break;
                case "3":
                    GiveBook();
                    break;
                case "4":
                    DefineBookFlight();
                    break;
                case "5":
                    break;
                default:
                    break;
            }
        }

        public void SearchOp(string searchOperation)
        {
            switch (searchOperation)
            {
                case "1":
                    SearchStudent();
                    break;
                case "2":
                    SearchGroup();
                    break;
                case "3":
                    SearchAuthor();
                    break;
                case "4":
                    SearchTitle();
                    break;
                case "5":                    
                    break;
                default:
                    break;
            }
        }

        public void AddStudent() {
            try
            {
                Console.WriteLine("Enter data of new student.");
                Console.Write("Enter Surname: ");
                string surname = CheckProfileData(Console.ReadLine());
                Console.Write("Enter Name: ");
                string name = CheckProfileData(Console.ReadLine());
                Console.Write("Enter Goup: ");
                int group = CheckInt();
                logic.AddStudent(name, surname, group);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }    
        public void DeleteStudent() {
            try
            {
                if (logic.IsEmpty())
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("There is nobody to delete.");
                Console.ReadLine();
            }

            Console.WriteLine("Enter student to delete.");
            Console.Write("Enter Surname: ");
            string surnameDEL = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Name: ");
            string nameDEL = CheckProfileData(Console.ReadLine());
            if (logic.DeleteStudent(nameDEL, surnameDEL))
                Console.WriteLine("Student has been deleted.");
        }
        public void ChangeData()
        {
            try
            {
                if (logic.IsEmpty())
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("There is nobody to change.");
                Console.ReadLine();
            }
            Console.WriteLine("Which student do you want to change");
            Console.Write("Enter Surname: ");
            string surname = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Goup: ");
            int group = Convert.ToInt32(Console.ReadLine());
            Student stChange = new Student(name, surname, group);
            if (!logic.ContainsStud(name, surname))
            {
                Console.WriteLine($"There is no such student in group {stChange.Group.ToString()}");
                return;
            }
            Console.WriteLine("Which data do you want to change? (Name, Surname, Group");
            string dataToChange = Console.ReadLine().ToLower();
            switch (dataToChange)
            {
                case "name":
                    Console.Write("Type a NEW name: ");
                    string newName = CheckProfileData(Console.ReadLine());
                    Student newStud = new Student(newName, surname, group);
                    logic.ChangeData(stChange, newStud);
                    break;

                case "surname":
                    Console.Write("Type a NEW surname: ");
                    string newSurname = CheckProfileData(Console.ReadLine());
                    Student newStud2 = new Student(name, newSurname, group);
                    logic.ChangeData(stChange, newStud2);
                    break;

                case "group":
                    Console.Write("Type a NEW group: ");
                    int newgroup = Convert.ToInt32(Console.ReadLine());
                    Student newStud3 = new Student(name, surname, newgroup);
                    logic.ChangeData(stChange, newStud3);
                    break;

                default:
                    Console.WriteLine($"Unknown {dataToChange}");
                    break;
            }
        }        
        public void ShowAll() {
            try
            {
                if (logic.IsEmpty())
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("There is nobody to show.");
                Console.ReadLine();
            }            
            Console.WriteLine("1. By name");
            Console.WriteLine("2. By surname");
            Console.WriteLine("3. By group");
            Console.WriteLine("4. None");

            Console.WriteLine("Which sort do you want to use? :");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine(logic.SortByName());
                    break;
                case "2":
                    Console.WriteLine(logic.SortBySurname());
                    break;
                case "3":
                    Console.WriteLine(logic.SortByGroup());
                    break;
                case "4":
                    Console.WriteLine(logic.StudentsToString());
                    break;
                default:
                    break;
            }
            
        }


        public void AddBook()
        {
            try
            {
                Console.WriteLine("Enter data of new book.");
                Console.Write("Enter Author: ");
                string author = CheckBookData(Console.ReadLine());
                Console.Write("Enter Title: ");
                string title = CheckBookData(Console.ReadLine());
                Console.Write("How many such books do you want to add? :");
                int number = CheckInt();
                logic.AddBook(title, author, number);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteBook()
        {
            try
            {
                if (logic.BookListIsEmpty())
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("There is nothing to delete.");
                Console.ReadLine();
            }

            Console.WriteLine("Enter book to delete.");
            Console.Write("Enter author: ");
            string authorDel = CheckBookData(Console.ReadLine());
            Console.Write("Enter Title: ");
            string titleDel = CheckBookData(Console.ReadLine());
            if (logic.DeleteBook(authorDel, titleDel))
                Console.WriteLine("Book has been deleted.");
        }
        public void ChangeBookData()
        {
            try
            {
                if (logic.BookListIsEmpty())
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("There is no book to change.");
                Console.ReadLine();
            }
            Console.WriteLine("Which book do you want to change");
            Console.Write("Enter author: ");
            string author = CheckBookData(Console.ReadLine());
            Console.Write("Enter title: ");
            string title = CheckBookData(Console.ReadLine());            
            if (!logic.BooksContains(author, title))
            {
                Console.WriteLine("There is no such book");
                return;
            }
            Book bkChange = logic.AssignBookNumber(title, author);
            Console.WriteLine("Which data do you want to change? (Author, Title)");
            string dataToChange = Console.ReadLine().ToLower();
            switch (dataToChange)
            {
                case "author":
                    Console.Write("Type a NEW author: ");
                    string newAuthor = CheckProfileData(Console.ReadLine());
                    Book newbook = logic.AssignBookNumber(title, newAuthor);
                    logic.ChangeBookData(bkChange, newbook);
                    break;

                case "title":
                    Console.Write("Type a NEW title: ");
                    string newTitle = CheckProfileData(Console.ReadLine());
                    Book newbook2 = logic.AssignBookNumber(newTitle, author);
                    logic.ChangeBookData(bkChange, newbook2);
                    break;    
                               
                default:
                    Console.WriteLine($"Unknown {dataToChange}");
                    break;
            }
        }
        public void ShowBook()
        {
            try
            {
                if (logic.IsEmpty())
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("There is nobody to show.");
                Console.ReadLine();
            }
            Console.WriteLine("Which student do you want to see?");
            Console.Write("Enter Surname: ");
            string surname = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Goup: ");
            int group = Convert.ToInt32(Console.ReadLine());
            Student stChange = new Student(name, surname, group);


        }
        public void ShowAllBooks()
        {
            try
            {
                if (logic.IsEmpty())
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("There is no book to show.");
                Console.ReadLine();
            }
            Console.WriteLine("1. By title");
            Console.WriteLine("2. By author");
            Console.WriteLine("3. None");

            Console.WriteLine("Which sort do you want to use? :");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine(logic.SortByTitle());
                    break;
                case "2":
                    Console.WriteLine(logic.SortByAuthor());
                    break;
                case "3":
                    Console.WriteLine(logic.BooksToString());
                    break;
                default:
                    break;
                    Console.WriteLine(logic.BooksToString());
            }
        }


        public void GiveBook()
        {           
            Console.WriteLine("Enter which student needs a book:");
            Console.Write("Enter Surname: ");
            string surname = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Goup: ");
            int group = CheckInt();
            try {
                if (!logic.ChekStudentBooks(name, surname, group) && logic.ContainsStud(name, surname))
                {
                    Console.WriteLine("The operation is unavailable for this student.");
                    return;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Enter data of a needed book:");
            Console.Write("Enter Author: ");
            string author = CheckBookData(Console.ReadLine());
            Console.Write("Enter Title: ");
            string title = CheckBookData(Console.ReadLine());
            try
            {
                if (logic.BooksContains(author, title) && logic.ChekBookAvailability(author, title))
                {
                    logic.GiveStBook(name, surname, group, author, title);
                }
                else
                    Console.Write("There is no such book.");                
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }
        public void ShowStud() {
            try
            {
                if (logic.IsEmpty())
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("There is nobody to show.");
                Console.ReadLine();
            }
            Console.WriteLine("Which student do you want to see?");
            Console.Write("Enter Surname: ");
            string surname = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Goup: ");
            int group = Convert.ToInt32(Console.ReadLine());
            Student st = new Student(name, surname, group);
            Console.WriteLine(st.toString());   
        }
        public void DefineBookFlight()
        {
            Console.WriteLine("Enter data of a needed book:");
            Console.Write("Enter Author: ");
            string author = CheckBookData(Console.ReadLine());
            Console.Write("Enter Title: ");
            string title = CheckBookData(Console.ReadLine());
            Console.Write("Book's owners: ");
            try
            {
                Console.Write(logic.StrOwnerList(author, title));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }        
        public void ReturnBook()
        {
            Console.WriteLine("Enter which student returns a book:");
            Console.Write("Enter Surname: ");
            string surname = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = CheckProfileData(Console.ReadLine());
            Console.Write("Enter Goup: ");
            int group = CheckInt();
            try
            {
                if (!logic.ContainsStud(name, surname))
                {
                    Console.WriteLine("There is no such student");
                    return;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Enter which book is returning:");
            Console.Write("Enter Author: ");
            string author = CheckBookData(Console.ReadLine());
            Console.Write("Enter Title: ");
            string title = CheckBookData(Console.ReadLine());
            try
            {
                if (logic.BooksContains(author, title))
                {
                    logic.ReturnBook(name, surname, group, author, title);
                }
                else
                    Console.Write("There were no such book.");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }


        public void SearchStudent()
        {            
                Console.Write("Enter Surname: ");
                string surname = CheckProfileData(Console.ReadLine());
                Console.Write("Enter Name: ");
                string name = CheckProfileData(Console.ReadLine());
            try
            {
                if (logic.ContainsStud(name, surname))
                    Console.WriteLine(logic.FindStudents(name, surname));
                else throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Such student doesn't exist");
                Console.ReadLine();
            }
        }
        public void SearchGroup()
        {
            Console.Write("Enter Goup: ");
            int group = CheckInt();
            try
            {
                Console.WriteLine(logic.StrGroup(group));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }
        public void SearchAuthor()
        {
            try
            {
                Console.Write("Enter Author: ");
                string author = CheckBookData(Console.ReadLine());
                Console.WriteLine(logic.FindAuthor(author));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }
        public void SearchTitle()
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = CheckBookData(Console.ReadLine());
                Console.WriteLine(logic.FindTitle(title));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }

        

        public string CheckProfileData(string userData)
        {
            string regexp = @"^[A-Z]{1}[a-z]+$";
            string data = "";
            bool flag = true;
            while (flag)
            {
                if (Regex.IsMatch(userData, regexp) != flag)
                {
                    Console.WriteLine("Word should start from Uppercase letter. \nPlease try again: ");
                    userData = Console.ReadLine();
                }
                else
                {
                    data = userData;
                    flag = false;
                }
            }
            return data;
        }
        public string CheckBookData(string userData)
        {
            string regexp = @"^[A-Z]{1}[a-z]";
            string data = "";
            bool flag = true;
            while (flag)
            {
                if (Regex.IsMatch(userData, regexp) != flag)
                {
                    Console.WriteLine("Must begin from uppercase letter. \n Please try again: ");
                    userData = Console.ReadLine();
                }
                else
                {
                    data = userData;
                    flag = false;
                }
            }
            return data;
        }
        public int CheckInt()
        {
            int group = 0;
            bool flag = false;
            do
            {
                try
                {
                    group = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Data is incorrect. Please try again: ");
                }
            } while (flag == false);
            return group;
        }
    }
}
