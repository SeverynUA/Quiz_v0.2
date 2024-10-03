using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary_Quiz_.Models.Template_m.Field.Question_m
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [XmlElement("Question")]
        public List<Question> Question { get; set; } = new List<Question>();  // Список питань для теми
    }
}
