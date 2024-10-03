using Microsoft.Win32;
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
using System.IO;
namespace Quiz_v0._2.Windows.MakeGameField
{
    /// <summary>
    /// Interaction logic for InsertQuestion.xaml
    /// </summary>
    public partial class InsertQuestion : Window
    {
        public string QuestionTitle { get; private set; }
        public int QuestionPoints { get; private set; }
        public string RightAnswer { get; private set; }
        public byte[] PhotoData { get; private set; } // Для зберігання фото у вигляді байтів

        // Відносний шлях до папки з фото
        private string defaultPhotoFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sourse", "default", "Images");

        public InsertQuestion()
        {
            InitializeComponent();
        }

        // Обробник для кнопки вибору фото
        private void AttachPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                // Завантажуємо обране зображення
                string selectedFileName = openFileDialog.FileName;
                PhotoPreview.Source = new BitmapImage(new Uri(selectedFileName));

                // Читаємо зображення в масив байтів
                PhotoData = File.ReadAllBytes(selectedFileName);
            }
        }

        // Обробник для кнопки збереження
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Валідація введених даних
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show("Please enter a valid question title.");
                return;
            }

            if (!int.TryParse(PointsTextBox.Text, out int points) || points <= 0)
            {
                MessageBox.Show("Please enter a valid number of points.");
                return;
            }

            if (string.IsNullOrWhiteSpace(RightAnswerTextBox.Text))
            {
                MessageBox.Show("Please enter the right answer.");
                return;
            }

            // Якщо користувач не додав фото, відкриваємо вікно вибору фото з папки
            if (PhotoData == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = defaultPhotoFolder;
                openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
                openFileDialog.Title = "Select a photo from default folder";
                if (openFileDialog.ShowDialog() == true)
                {
                    // Завантажуємо обране зображення з папки
                    string selectedFileName = openFileDialog.FileName;
                    PhotoPreview.Source = new BitmapImage(new Uri(selectedFileName));

                    // Читаємо зображення в масив байтів
                    PhotoData = File.ReadAllBytes(selectedFileName);
                }
            }

            // Зберігаємо дані питання
            QuestionTitle = TitleTextBox.Text;
            QuestionPoints = points;
            RightAnswer = RightAnswerTextBox.Text;

            // Закриваємо вікно і передаємо дані
            this.DialogResult = true;
            this.Close();
        }
    }
}

