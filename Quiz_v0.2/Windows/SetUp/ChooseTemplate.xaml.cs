using ClassLibrary_Quiz_.Models.Template_m.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz_v0._2.Windows.SetUp
{
    /// <summary>
    /// Interaction logic for ChooseTemplate.xaml
    /// </summary>
    public partial class ChooseTemplate : Window
    {
        public string SelectedTemplate { get; private set; }  // Зберігає вибраний шаблон

        public ChooseTemplate(List<FieldGame> templates)
        {
            InitializeComponent();
            // Додаємо імена шаблонів у список
            foreach (var template in templates)
            {
                TemplatesListBox.Items.Add(template.Name);
            }
        }

        // Обробник для вибору шаблону
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (TemplatesListBox.SelectedItem != null)
            {
                SelectedTemplate = TemplatesListBox.SelectedItem.ToString();
                this.DialogResult = true;
                this.Close();  // Закриваємо вікно після вибору
            }
            else
            {
                MessageBox.Show("Please select a template.");
            }
        }

        // Обробник для скасування вибору
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TemplatesListBox.SelectedItem != null)
            {
                string selectedTemplateName = TemplatesListBox.SelectedItem.ToString();

                // Тут реалізуємо логіку для редагування шаблону
                EditTemplate(selectedTemplateName);
            }
            else
            {
                MessageBox.Show("Please select a template to edit.");
            }
        }

        // Метод для редагування вибраного шаблону
        private void EditTemplate(string templateName)
        {
            // Наприклад, відкриваємо вікно для редагування шаблону
            MessageBox.Show($"Editing template: {templateName}");

            // Тут можна викликати нове вікно для редагування або змінити дані прямо у цьому вікні
        }

    }
}
