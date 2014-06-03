using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Data;

namespace HadoopSerialization
{
    class Schema
    {
    }

    [DataContract(Name = "Person", Namespace = "com.linkedin.haivvreo")]
    class Person
    {

        [DataMember(Name = "Fist_Name")]
        public string First_Name { get; set; }

        [DataMember(Name = "Street")]
        public string Street { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }

    }

    

}
