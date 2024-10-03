using ClassLibrary_Quiz_.Models.Template_m.Field;
using ClassLibrary_Quiz_.Models.Game_m;
using ClassLibrary_Quiz_.Models.Team_m;
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
using Quiz_v0._2.Windows.MakeGameField;
using Quiz_v0._2.Windows.Games;

namespace Quiz_v0._2.Windows.SetUp
{
    /// <summary>
    /// Interaction logic for SetUpQuiz.xaml
    /// </summary>
    public partial class SetUpQuiz : Window
    {
        private bool isLoaded = false;
        private bool withTimer = false;
        private bool withPoints = false;

        public SetUpQuiz()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;  // Прив'язуємо подію Loaded
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            isLoaded = true;  // Тепер вікно завантажене, і події можуть оброблятися
        }

        private void scrollBar_teamCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isLoaded)
            {
                // Перевіряємо, чи вікно завантажене
                double currentValue = scrollBar_teamCount.Value;

                // Перетворюємо значення в ціле число
                int intValue = (int)Math.Round(currentValue);  // Використовуємо Math.Round для точного округлення

                // Оновлюємо значення Label
                teamCountText.Text = intValue.ToString();

                // Для налагодження: вивести інформацію у консоль
                Console.WriteLine($"Поточне значення ScrollBar: {currentValue}, Округлене значення: {intValue}");
            }
        }

        // Обробник події при відмітці прапорця
        private void checkBox_withTimer_Checked(object sender, RoutedEventArgs e)
        {
            // Розблоковуємо поле для введення часу
            textBox_secondsTimer.IsReadOnly = false;
        }

        // Обробник події при знятті відмітки з прапорця
        private void checkBox_withTimer_Unchecked(object sender, RoutedEventArgs e)
        {
            // Блокуємо поле для введення часу та встановлюємо значення "0"
            textBox_secondsTimer.Text = "0";
            textBox_secondsTimer.IsReadOnly = true;
        }


        private void createTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            // Запитуємо кількість тем
            string inputTopics = Interaction.InputBox("Enter the number of topics:", "Number of Topics", "1");

            if (int.TryParse(inputTopics, out int numberOfTopics) && numberOfTopics > 0)
            {
                // Далі запитуємо кількість питань для кожної теми
                string inputQuestions = Interaction.InputBox("Enter the number of questions per topic:", "Number of Questions", "1");

                if (int.TryParse(inputQuestions, out int numberOfQuestions) && numberOfQuestions > 0)
                {
                    // Логіка створення макета для поля на основі введених тем і питань
                    MessageBox.Show($"Creating template with {numberOfTopics} topics and {numberOfQuestions} questions per topic.");

                    // Створюємо нове вікно CreateTemplate
                    CreateTemplate createTemplate = new CreateTemplate(numberOfTopics, numberOfQuestions);

                    // Відкриваємо його як діалогове вікно
                    bool? result = createTemplate.ShowDialog();

                    // Перевіряємо результат закриття вікна
                    if (result == true)
                    {
                        // Логіка, якщо діалогове вікно закрито через "ОК" або інший позитивний результат
                    }
                    else
                    {
                        // Логіка для негативного результату або закриття через "Cancel"
                    }
                }
                else
                {
                    MessageBox.Show("Invalid number of questions.");
                }
            }
            else
            {
                MessageBox.Show("Invalid number of topics.");
            }
        }

        private void input_button_Click(object sender, RoutedEventArgs e)
        {
            List<FieldGame> templates = LoadTemplates();

            if (templates.Any())
            {
                // Відкриваємо нове вікно для вибору шаблону
                ChooseTemplate chooseTemplateWindow = new ChooseTemplate(templates);

                // Перевіряємо, чи користувач вибрав шаблон
                if (chooseTemplateWindow.ShowDialog() == true)
                {
                    // Отримуємо вибраний шаблон і показуємо його в текстовому полі
                    ActiveTemplateTextBox.Text = chooseTemplateWindow.SelectedTemplate;
                }
            }
            else
            {
                MessageBox.Show("No templates found.", "Templates");
            }
        }

        private List<FieldGame> LoadTemplates()
        {
            string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\users\Templates\");

            List<FieldGame> templates = new List<FieldGame>();

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath, "*.xml"); // Шукаємо всі файли XML

                XmlSerializer serializer = new XmlSerializer(typeof(FieldGame));

                foreach (string file in files)
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        FieldGame template = (FieldGame)serializer.Deserialize(reader);
                        templates.Add(template);
                    }
                }
            }
            return templates;
        }

        private FieldGame LoadTemplateByName(string nameOfFile)
        {
            // Шлях до папки з шаблонами
            string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\users\Templates\");

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Templates directory not found.", "Error");
                return null;
            }

            if (string.IsNullOrWhiteSpace(nameOfFile))
            {
                MessageBox.Show("Template name cannot be empty.", "Error");
                return null;
            }

            // Знаходимо файл з точною назвою або частковою відповідністю
            string[] files = Directory.GetFiles(folderPath, $"{nameOfFile}*.xml");

            if (files.Length == 0)
            {
                MessageBox.Show("No templates found with the given name.", "Templates");
                return null;
            }

            // Десеріалізуємо перший знайдений файл
            XmlSerializer serializer = new XmlSerializer(typeof(FieldGame));
            using (StreamReader reader = new StreamReader(files[0]))  // Використовуємо перший файл у списку
            {
                FieldGame template = (FieldGame)serializer.Deserialize(reader);
                return template;  // Повертаємо об'єкт шаблону
            }
        }


        private void createGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveTemplateTextBox.Text != "No Active Template")
            {
                int teamCount = (int)scrollBar_teamCount.Value;
                List<Team> teams = new List<Team>();

                // Збираємо назви команд через InputBox
                for (int i = 0; i < teamCount; i++)
                {
                    // Запитуємо назву команди
                    string teamName;
                    bool isUnique;
                    do
                    {
                        teamName = Microsoft.VisualBasic.Interaction.InputBox($"Enter the name of team {i + 1}:", "Team Name", "");

                        if (string.IsNullOrWhiteSpace(teamName))
                        {
                            MessageBox.Show("The team name cannot be empty. Please enter a valid name.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                            isUnique = false;
                        }
                        else if (teams.Any(t => t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase)))
                        {
                            MessageBox.Show($"The team name '{teamName}' is already taken. Please enter a unique name.", "Duplicate Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            isUnique = false;
                        }
                        else
                        {
                            isUnique = true;
                        }

                    } while (!isUnique); // Повторюємо, поки не буде введено коректну унікальну назву

                    // Додаємо команду до списку
                    teams.Add(new Team { Name = teamName });
                }


                // Створюємо генератор випадкових чисел
                Random rnd = new Random();

                // Сортуємо команди у випадковому порядку
                teams = teams.OrderBy(team => rnd.Next()).ToList();

                // Запитуємо назву гри
                string nameOfGame;
                do
                {
                    nameOfGame = Microsoft.VisualBasic.Interaction.InputBox("Enter name of the game:", "Game Name", "");

                    if (string.IsNullOrWhiteSpace(nameOfGame))
                    {
                        MessageBox.Show("The game name cannot be empty. Please enter a valid name.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                } while (string.IsNullOrWhiteSpace(nameOfGame)); // Повторюємо, поки не буде введено коректну назву гри

                // Створюємо гру і передаємо зібрані дані
                // Отримуємо значення часу
                int gameTime;
                if (checkBox_withTimer.IsChecked == true)
                {
                    // Якщо таймер активований, беремо значення з текстового поля
                    if (int.TryParse(textBox_secondsTimer.Text, out gameTime) && gameTime > 0)
                    {
                        // Використовуємо введений час
                    }
                    else
                    {
                        // Якщо введене значення некоректне, можна встановити значення за замовчуванням, наприклад, 60 секунд
                        gameTime = 60;
                    }
                }
                else
                {
                    // Якщо таймер не активований, встановлюємо "безкінечний" час
                    gameTime = int.MaxValue;  // Значення для умовної "безкінечності"
                }

                // Створюємо гру і передаємо зібрані дані
                Game newGame = new Game
                {
                    Id = 1, // Можливо, варто генерувати унікальний ідентифікатор
                    Title = nameOfGame,
                    teams = teams,
                    Time = gameTime,  // Встановлюємо час гри
                    fieldGame = LoadTemplateByName(ActiveTemplateTextBox.Text)  // Ініціалізуйте поле гри, якщо є потрібні параметри
                };


                // Логіка для подальшої роботи з новою грою
                MessageBox.Show($"Гра '{newGame.Title}' створена з {teams.Count} командами!");

                // Створюємо нове вікно гри і показуємо його
                GameWindow gameWindow = new GameWindow(newGame);
                gameWindow.Show();  // Використовуємо Show() або ShowDialog() для відображення нового вікна

                // Закриваємо поточне вікно після відкриття нового
                this.Close();
            }
            else
            {
                MessageBox.Show("You have to be make choose template!");
            }
        }
    }
}
