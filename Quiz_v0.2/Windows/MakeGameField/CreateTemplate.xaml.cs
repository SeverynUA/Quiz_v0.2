using ClassLibrary_Quiz_.Models.Template_m.Field.Question_m;
using ClassLibrary_Quiz_.Models.Template_m.Field;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Quiz_v0._2.Windows.MakeGameField
{
    /// <summary>
    /// Interaction logic for CreateTemplate.xaml
    /// </summary>
    public partial class CreateTemplate : Window
    {
        private int numberOfTopics;
        private int numberOfQuestions;

        // Динамічне зберігання інформації про теми та питання
        private List<Topic> topics = new List<Topic>();
        private Dictionary<int, List<Button>> topicQuestionButtons = new Dictionary<int, List<Button>>(); // Для зберігання кнопок питань по темах
        private Dictionary<int, Button> topicButtons = new Dictionary<int, Button>(); // Для зберігання кнопок тем

        public CreateTemplate()
        {
            InitializeComponent();
        }

        // Основний конструктор для отримання кількості тем і питань
        public CreateTemplate(int numberOfTopics, int numberOfQuestions) : this()
        {
            this.numberOfTopics = numberOfTopics;
            this.numberOfQuestions = numberOfQuestions;

            // Створюємо макет на основі введеної кількості тем і питань
            CreateLayout();
        }

        // Метод для створення макета
        private void CreateLayout()
        {
            // Створюємо сітку для відображення тем і питань у стовпчиках
            Grid layoutGrid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(10),
                ShowGridLines = false
            };

            // Створюємо спільний розмір для колонок
            layoutGrid.ColumnDefinitions.Clear();
            layoutGrid.RowDefinitions.Clear();

            // Додаємо колонки для кожної теми
            for (int i = 0; i < numberOfTopics; i++)
            {
                // Додаємо колонки, які рівномірно заповнюють простір
                ColumnDefinition column = new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star) // Рівномірний розподіл по колонках
                };
                layoutGrid.ColumnDefinitions.Add(column);

                Topic topic = new Topic { Id = i + 1, Name = $"Topic {i + 1}", Question = new List<Question>() };
                topics.Add(topic);

                // Створюємо список для зберігання кнопок питань для цієї теми
                topicQuestionButtons[i] = new List<Button>();

                // Створюємо кнопку для теми (в першому рядку кожної колонки)
                Button topicButton = new Button
                {
                    Content = $"Topic {i + 1}",
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(5),
                    FontSize = 16,
                    Padding = new Thickness(10),
                    Tag = i, // Зберігаємо індекс теми
                    Background = (Brush)this.FindResource("TopicButtonBackground") // Прив'язка до кольору з теми
                };

                // Додаємо обробник події натискання на кнопку теми
                topicButton.Click += TopicButton_Click;

                // Зберігаємо кнопку для теми
                topicButtons[i] = topicButton;

                // Додаємо кнопку до сітки (перший рядок, колонка для теми)
                Grid.SetRow(topicButton, 0);
                Grid.SetColumn(topicButton, i);
                layoutGrid.Children.Add(topicButton);

                // Додаємо кнопки для кожного питання під відповідною темою
                for (int j = 0; j < numberOfQuestions; j++)
                {
                    // Додаємо новий рядок, якщо його ще немає
                    if (layoutGrid.RowDefinitions.Count <= j + 1)
                    {
                        RowDefinition row = new RowDefinition
                        {
                            Height = new GridLength(1, GridUnitType.Star) // Рівномірний розподіл по рядках
                        };
                        layoutGrid.RowDefinitions.Add(row);
                    }

                    // Створюємо кнопку для кожного питання
                    Button questionButton = new Button
                    {
                        Content = $"Question {j + 1}",
                        Tag = new { TopicIndex = i, QuestionIndex = j },
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(5),
                        FontSize = 14,
                        Padding = new Thickness(10),
                        IsEnabled = false, // Кнопка спочатку заблокована
                        Background = (Brush)this.FindResource("QuestionButtonBackground") // Прив'язка до кольору з теми
                    };

                    // Додаємо обробник події натискання на кнопку
                    questionButton.Click += QuestionButton_Click;

                    // Зберігаємо кнопку для подальшого розблокування і оновлення кольору
                    topicQuestionButtons[i].Add(questionButton);

                    // Додаємо кнопку до сітки
                    Grid.SetRow(questionButton, j + 1);  // Рядок (питання йдуть під темою)
                    Grid.SetColumn(questionButton, i);  // Колонка (кожна тема має свій стовпчик)
                    layoutGrid.Children.Add(questionButton);
                }
            }

            // Додаємо сітку до основного контейнера вікна
            this.Content = layoutGrid;
        }

        // Обробник події натискання на кнопку питання
        private void QuestionButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            var tagInfo = (dynamic)clickedButton.Tag;

            // Відкриваємо вікно InsertQuestion для введення даних питання
            InsertQuestion insertQuestionWindow = new InsertQuestion();
            if (insertQuestionWindow.ShowDialog() == true)
            {
                // Якщо користувач ввів дані і натиснув "Save"
                string questionTitle = insertQuestionWindow.QuestionTitle;
                int questionPoints = insertQuestionWindow.QuestionPoints;
                string rightAnswer = insertQuestionWindow.RightAnswer;
                byte[] photoData = insertQuestionWindow.PhotoData;

                // Оновлюємо текст на кнопці після введення інформації
                clickedButton.Content = $"Q{tagInfo.QuestionIndex + 1}: {questionTitle}";
                clickedButton.Background = Brushes.Green; // Змінюємо фон на зелений

                // Створюємо новий об'єкт Picture, якщо фото є
                Picture questionPicture = null;
                if (photoData != null)
                {
                    questionPicture = new Picture { Data = photoData };
                }

                // Додаємо нове питання до теми з можливим зображенням
                Question newQuestion = new Question(tagInfo.QuestionIndex + 1, questionTitle, questionPoints, new Ask { Title = questionTitle, RightAnswer = rightAnswer }, questionPicture);
                topics[tagInfo.TopicIndex].Question.Add(newQuestion);

                // Перевіряємо, чи всі питання заповнені
                CheckIfAllQuestionsAreFilled();
            }
        }

        // Метод для перевірки, чи всі питання та теми заповнені
        private void CheckIfAllQuestionsAreFilled()
        {
            bool allFilled = true;

            // Перевіряємо кожну тему та її питання
            foreach (var topicButtonList in topicQuestionButtons)
            {
                foreach (var questionButton in topicButtonList.Value)
                {
                    if (questionButton.Background != Brushes.Green) // Якщо хоча б одне питання не заповнено
                    {
                        allFilled = false;
                        break;
                    }
                }

                if (!allFilled)
                {
                    break;
                }
            }

            if (allFilled)
            {
                SaveField();
            }
        }

        // Метод для збереження поля (шаблону)
        private void SaveField()
        {
            // Відкриваємо діалог для введення імені шаблону
            string templateName = Interaction.InputBox("Enter a name for the template:", "Template Name");

            if (string.IsNullOrWhiteSpace(templateName))
            {
                MessageBox.Show("Template name cannot be empty. Please enter a valid name.");
                return;
            }

            FieldGame gameField = new FieldGame
            {
                Id = Guid.NewGuid().ToString(), // Унікальний ідентифікатор шаблону
                Name = templateName // Встановлюємо ім'я шаблону
            };

            // Додаємо всі теми та питання
            foreach (var topic in topics)
            {
                gameField.AddTopic(topic);
                foreach (var question in topic.Question)
                {
                    gameField.AddQuestion(question);
                }
            }

            // Зберігаємо дані в XML форматі
            SaveTemplateAsXml(gameField);

            MessageBox.Show("Template saved successfully!");
        }

        private void SaveTemplateAsXml(FieldGame gameField)
        {
            string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\users\Templates\");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = System.IO.Path.Combine(folderPath, $"{gameField.Name}.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(FieldGame));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, gameField);
            }
            this.Close();
        }



        // Обробник події натискання на кнопку теми
        private void TopicButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            int topicIndex = (int)clickedButton.Tag;

            // Відкриваємо діалог для введення інформації про тему
            string topicName = Interaction.InputBox($"Enter the name for Topic {topicIndex + 1}", "Topic Name", $"Topic {topicIndex + 1}");

            if (!string.IsNullOrWhiteSpace(topicName))
            {
                // Оновлюємо текст на кнопці після введення інформації
                clickedButton.Content = topicName;

                // Оновлюємо фон кнопки на зелений, якщо дані введені
                clickedButton.Background = Brushes.Green;

                // Оновлюємо дані теми
                topics[topicIndex].Name = topicName;

                // Розблоковуємо всі питання для цієї теми
                foreach (var questionButton in topicQuestionButtons[topicIndex])
                {
                    questionButton.IsEnabled = true;

                    // Оновлюємо фон кнопки на червоний, якщо вона не містить даних
                    if (questionButton.Background != Brushes.Green)
                    {
                        questionButton.Background = Brushes.Red;
                    }
                }

                MessageBox.Show($"You selected {clickedButton.Content}. Questions are now unlocked for this topic.");
            }
            else
            {
                MessageBox.Show("Invalid topic name.");
            }
        }

        // Метод для обробки події натискання на кнопку збереження
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Перевіряємо, чи є дані для збереження
            if (topics.Any())
            {
                // Створюємо об'єкт шаблону (FieldGame або Template)
                FieldGame gameField = new FieldGame();

                // Додаємо всі теми та питання в об'єкт
                foreach (var topic in topics)
                {
                    gameField.AddTopic(topic);
                    foreach (var question in topic.Question)
                    {
                        gameField.AddQuestion(question);
                    }
                }

                // Тут можна реалізувати логіку збереження цього об'єкта в базу даних або в файл
                MessageBox.Show("Game field saved successfully!");
            }
            else
            {
                MessageBox.Show("No data to save.");
            }
        }

    }
}
