using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

    
namespace DAL
{    
    public class DataBase 
    {
        public void Write(Object data, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }

        public Object Read(string path)
        {
            Object data = new Object();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                data = (Object)formatter.Deserialize(fs);
            }

            return data;
        }

    }
}
