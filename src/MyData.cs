using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace ftext
{
    [Serializable()]
    public class MyData
    {
        public List<string> finds;
        public int scale;

        [field: NonSerialized()]
        public static string dataFileName;

        protected MyData()
        {
            finds = new List<string>();
            scale = 10;
        }

        public static MyData LoadMyData(string filename)
        {
            dataFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            if (File.Exists(dataFileName)) {
                var formatter = new BinaryFormatter();
                using (Stream stream = File.OpenRead(dataFileName)) {
                    try {
                        MyData myData = (MyData)formatter.Deserialize(stream);
                        if (myData.scale < 1 || myData.scale > 10) myData.scale = 10;
                        return myData;
                    } catch { }
                }
            }

            return new MyData();
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            Stream stream = File.Create(dataFileName);
            formatter.Serialize(stream, this);
            stream.Close();
        }
    }
}
