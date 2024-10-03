using ClassLibrary_Quiz_.Models.Template_m.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Quiz_.Models.Template_m
{
    public class Template
    {
        public int Id { get; set; }  // Унікальний ідентифікатор шаблону
        public string Name { get; set; }  // Назва шаблону
        public FieldGame GameField { get; set; }  // Поле з інформацією про гру (розміри, теми, питання)

        // Конструктор для ініціалізації шаблону
        public Template(int id, string name, FieldGame gameField)
        {
            Id = id;
            Name = name;
            GameField = gameField;
        }
    }

}
