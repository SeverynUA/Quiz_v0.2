using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary_Quiz_.Models.Template_m.Field.Question_m
{
    public class Ask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RightAnswer { get; set; }

        // Зовнішній ключ на тему
        public int Topic_Id { get; set; }

        // Навігаційну властивість ігноруємо при серіалізації
        [XmlIgnore]
        public Topic Topic { get; set; }  // Навігаційна властивість
    }

}
