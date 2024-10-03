using ClassLibrary_Quiz_.Models.Template_m.Field.Question_m;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary_Quiz_.Models.Template_m.Field
{
    public class FieldGame
    {
        public string Id { get; set; }  // Ідентифікатор поля
        public string Name { get; set; }  // Назва шаблону

        [XmlElement("TopicList")]
        public List<Topic> TopicList { get; set; }  // Список тем

        [XmlElement("QuestionList")]
        public List<Question> Questions { get; set; }  // Список питань

        // Конструктор для ініціалізації списків
        public FieldGame()
        {
            TopicList = new List<Topic>();
            Questions = new List<Question>();
        }

        // Метод для додавання теми
        public void AddTopic(Topic topic)
        {
            TopicList.Add(topic);
        }

        // Метод для додавання питання
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
    }
}
