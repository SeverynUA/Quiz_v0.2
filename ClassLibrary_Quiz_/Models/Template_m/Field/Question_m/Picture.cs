using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary_Quiz_.Models.Template_m.Field.Question_m
{
    public class Picture
    {
        public int Id { get; set; }

        //[XmlIgnore]  // Якщо не хочемо серіалізувати байти у XML, можна додати цей атрибут
        public byte[] Data { get; set; }
    }

}
