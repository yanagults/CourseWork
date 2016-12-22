using System;
using DAL;
using System.IO;


namespace Manipulation
{
    public class DB_Interconnection
    {
        private DataSource dataSource;
        public DB_Interconnection(string path)
        {
            dataSource = new DataSource(path);
            if (!File.Exists(path))
            {
                BooksStudents obj = new BooksStudents();
                SetContent(obj);
            }
        }
        public BooksStudents GetContent()
        {
            return (BooksStudents)dataSource.ReadData(typeof(BooksStudents));

        }
        public void SetContent(BooksStudents data)
        {
            dataSource.WriteData(data);
        }
    }
}
