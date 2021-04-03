using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Restaurant_Menu_Management_System__Client_.Models
{
    public class Item
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}