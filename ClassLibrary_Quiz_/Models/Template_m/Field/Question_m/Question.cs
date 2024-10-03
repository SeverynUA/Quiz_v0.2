using ClassLibrary_Quiz_.Models.Template_m.Field.Question_m;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Quiz_.Models.Template_m.Field.Question_m
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Points { get; set; }

        public Ask Ask { get; set; }  // Відповідь на питання

        public int? PictureId { get; set; }
        public Picture Picture { get; set; }  // Навігаційна властивість для картинки

        public Question() { }  // Обов'язковий конструктор без параметрів для серіалізації

        public Question(int id, string title, int points, Ask ask, Picture picture = null)
        {
            Id = id;
            Title = title;
            Points = points;
            Ask = ask;
            Picture = picture;
            PictureId = picture?.Id; // Якщо передано зображення, присвоюємо його Id
        }
    }
}
