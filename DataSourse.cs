using System;

namespace DAL
{
    public class DataSource
    {
        string path;
        DataBase dAccess;
        public Object storedData;

        public DataSource(string p)
        {
            path = p;
            dAccess =  new DataBase();
        }

        public DataBase DAccess
        {
            get { return dAccess; }
            set { dAccess = value; }
        }
        public string Path
        {
            get { return path; }
        }

        public Object ReadData(Object t)
        {
            if (dAccess != null)
            {
                if (storedData != null)
                    return storedData;
                else
                {
                    try
                    {
                        storedData = dAccess.Read(path);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Data Base is empty.");
                    }
                    return storedData;
                }
            }
            else
                throw new InvalidOperationException("Invalid operation. Accessor is not defined.");
        }

        public void WriteData(Object data)
        {
            if (dAccess != null)
                dAccess.Write(data, path);
            else
                throw new InvalidOperationException("Invalid operation. Accessor is not defined.");
        }

    }
}
