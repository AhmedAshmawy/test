using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.Avro;
using Microsoft.Hadoop.Avro.ObjectContainer;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Data;


namespace HadoopSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleData obj = new SampleData();
            using (FileStream xmlStream = new FileStream(@"SampleData.xml", FileMode.Open))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlStream))
                {
                    obj.ReadXml(xmlReader);
                }
            }


            var serializer = new AvroSerializer(typeof(Person));
            StreamWriter schemafs = new StreamWriter(File.Create(@"SampleData.avsc"));
            schemafs.Write(serializer.Schema.ToString());
            schemafs.Close();
            var resultStream = new FileStream(@"SampleData.avro", FileMode.OpenOrCreate);
            var writer = new SequentialWriter<Person>(resultStream, serializer, Codec.Create("null"), 24);
            int i;
            foreach (DataRow item in obj.Tables["Person"].Rows)
            {

                var p = new Person { First_Name = item["Name"].ToString(), Street = item["Street"].ToString(), City = item["City"].ToString(), State = item["State"].ToString() };
                writer.Write(p);
            }
            
            
            writer.Flush();


        }
    }
}
