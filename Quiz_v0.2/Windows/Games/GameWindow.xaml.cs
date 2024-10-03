using ClassLibrary_Quiz_.Models;
using ClassLibrary_Quiz_.Models.Game_m;
using ClassLibrary_Quiz_.Models.Team_m;
using ClassLibrary_Quiz_.Models.Template_m.Field.Question_m;
using Quiz_v0._2.Models;
using Quiz_v0._2.Models.Quiz_v0._2.Models.Quiz_v0._2.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz_v0._2.Windows.Games
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Game _game;
        private int activeTeamIndex = 0;
        private List<HistoryRecord> _gameHistory = new List<HistoryRecord>();
        private List<Button> _questionButtons = new List<Button>(); // Список для зберігання всіх кнопок з питаннями
        private QuizMusicPlayer musicPlayer;

        public GameWindow(Game game)
        {
            InitializeComponent();
            _game = game;
            ShowGameInfo();

            // Створюємо і запускаємо музику для меню
            musicPlayer = new QuizMusicPlayer();
            musicPlayer.SetMusicGroup("Who_wants_to_become_a_millionaire");
            musicPlayer.PlayMenuMusic(); // Відтворення меню без очікування

            // Відображаємо поле гри з питаннями
            CreateLayout();
        }

        // Метод для динамічного відображення поля гри
        private void CreateLayout()
        {
            int numberOfTopics = _game.fieldGame.TopicList.Count;

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
                ColumnDefinition column = new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star) // Рівномірний розподіл по колонках
                };
                layoutGrid.ColumnDefinitions.Add(column);

                // Створюємо кнопку для теми (в першому рядку кожної колонки)
                Button topicButton = new Button
                {
                    Content = _game.fieldGame.TopicList[i].Name, // Встановлюємо назву теми
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(5),
                    FontSize = 16,
                    Padding = new Thickness(10),
                    Background = (Brush)this.FindResource("TopicButtonBackground") // Прив'язка до кольору теми
                };

                Grid.SetRow(topicButton, 0);
                Grid.SetColumn(topicButton, i);
                layoutGrid.Children.Add(topicButton);

                // Додаємо кнопки для кожного питання під відповідною темою
                int numberOfQuestions = _game.fieldGame.TopicList[i].Question.Count;
                for (int j = 0; j < numberOfQuestions; j++)
                {
                    // Додаємо новий рядок, якщо його ще немає
                    if (layoutGrid.RowDefinitions.Count <= j + 1)
                    {
                        RowDefinition row = new RowDefinition
                        {
                            Height = new GridLength(1, GridUnitType.Star)
                        };
                        layoutGrid.RowDefinitions.Add(row);
                    }

                    // Отримуємо кількість балів для питання
                    int questionPoints = _game.fieldGame.TopicList[i].Question[j].Points;

                    // Створюємо кнопку для кожного питання
                    Button questionButton = new Button
                    {
                        Content = $"Question {j + 1} \n ({questionPoints} points)", // Відображаємо назву питання та кількість балів
                        Tag = _game.fieldGame.TopicList[i].Question[j], // Зберігаємо питання в Tag
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(5),
                        FontSize = 14,
                        Padding = new Thickness(10),
                        Background = (Brush)this.FindResource("QuestionButtonBackground") // Прив'язка до кольору теми
                    };

                    questionButton.Click += QuestionButton_Click;

                    // Додаємо кнопку до списку для перевірки стану гри
                    _questionButtons.Add(questionButton);

                    // Додаємо кнопку до сітки
                    Grid.SetRow(questionButton, j + 1);
                    Grid.SetColumn(questionButton, i);
                    layoutGrid.Children.Add(questionButton);
                }
            }

            this.Content = layoutGrid;
        }

        private async void QuestionButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Question selectedQuestion = clickedButton.Tag as Question;

            // Зупиняємо музику меню
            musicPlayer.StopMusic();

            // Відтворюємо музику для вибору питання і запускаємо анімацію синхронізовану з тривалістю треку
            var taskPlayMusic = musicPlayer.PlayLetsMusic();
            await AnimateButton(clickedButton); // Анімація кнопки синхронізується з тривалістю треку

            await taskPlayMusic;

            if (selectedQuestion != null)
            {
                bool correctAnswerGiven = false; // Перемінна для відстеження правильної відповіді
                int initialTeamIndex = activeTeamIndex; // Запам'ятовуємо індекс активної команди на початку
                var choosingTeam = _game.teams[initialTeamIndex]; // Фіксуємо команду, яка вибрала питання

                // Обходимо команди, поки не отримаємо правильну відповідь або не обійдемо всі команди
                do
                {
                    var activeTeam = _game.teams[activeTeamIndex];

                    // Відкриваємо нове вікно для відображення інформації про питання і очікуємо на відповідь
                    SelectedQuestion selectedQuestionWindow = new SelectedQuestion(selectedQuestion, _game.Time , musicPlayer);

                    // Якщо користувач відповів
                    if (selectedQuestionWindow.ShowDialog() == true)
                    {
                        // Використовуємо результат IsCorrect для оновлення балів
                        bool isCorrect = selectedQuestionWindow.IsCorrect;

                        if (isCorrect)
                        {
                            // Оновлюємо бали активної команди
                            UpdateTeamPoints(isCorrect, selectedQuestion.Points, activeTeam);

                            // Закриваємо питання
                            clickedButton.IsEnabled = false;
                            clickedButton.Background = Brushes.Gray;
                            clickedButton.Content = "Closed";

                            correctAnswerGiven = true;
                        }
                        else
                        {
                            // Якщо відповідь неправильна
                            if (activeTeam == choosingTeam)
                            {
                                // Знімаємо бали тільки у тієї команди, яка вибрала питання
                                UpdateTeamPoints(false, selectedQuestion.Points, choosingTeam);
                            }

                            // Переходимо до наступної команди, але не знімаємо бали у нової команди
                            NextTeam();
                        }
                    }
                } while (!correctAnswerGiven && activeTeamIndex != initialTeamIndex);

                musicPlayer.PlayMenuMusic();

                // Перевіряємо, чи всі питання закриті
                CheckIfGameEnded();
            }

            // Повертаємо фокус до головного вікна
            this.Focus();
        }

        // Метод для запуску анімації миготіння
        private async Task AnimateButton(Button button)
        {
            // Отримуємо початковий колір з прив'язаного ресурсу теми
            var originalBrush = (SolidColorBrush)button.FindResource("QuestionButtonBackground");

            var colorAnimation = new ColorAnimation
            {
                From = Colors.LightGray,
                To = Colors.Green,
                Duration = new Duration(TimeSpan.FromSeconds(0.1)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever // Постійна анімація
            };

            var brush = new SolidColorBrush(Colors.LightGray);
            button.Background = brush;

            // Запускаємо анімацію фону кнопки
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            // Синхронізація із завершенням музики
            double trackDuration = musicPlayer.GetTrackDuration();
            if (trackDuration > 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(trackDuration)); // Очікуємо поки закінчиться музика
            }

            // Зупинка анімації
            brush.BeginAnimation(SolidColorBrush.ColorProperty, null); // Зупиняємо анімацію
            button.Background = new SolidColorBrush(originalBrush.Color); // Повертаємо початковий колір
        }


        // Метод для перевірки, чи всі питання закриті
        private void CheckIfGameEnded()
        {
            if (_questionButtons.All(button => !button.IsEnabled))
            {
                musicPlayer.StopMusic();
                // Всі питання закриті - показуємо статистику і завершуємо гру
                MessageBox.Show("Гра завершена! Всі питання закриті.", "Гра завершена", MessageBoxButton.OK, MessageBoxImage.Information);

                // Відкриваємо статистику
                Statistics statisticsWindow = new Statistics(_game.teams, _gameHistory);
                statisticsWindow.ShowDialog();

                // Закриваємо вікно гри
                this.Close();
            }
        }

        private bool CheckAnswer(string userAnswer, string correctAnswer)
        {
            return string.Equals(userAnswer, correctAnswer, StringComparison.OrdinalIgnoreCase);
        }

        private void NextTeam()
        {
            // Переходимо до наступної команди по кругу
            activeTeamIndex = (activeTeamIndex + 1) % _game.teams.Count;
            MessageBox.Show($"Тепер відповідає команда: {_game.teams[activeTeamIndex].Name}");
        }

        // Оновлюйте історію гри при зміні балів
        private void UpdateTeamPoints(bool isCorrect, int points, Team team)
        {
            int pointChange = isCorrect ? points : -points;
            team.Point += pointChange;

            // Додаємо запис в історію
            _gameHistory.Add(new HistoryRecord
            {
                Time = DateTime.Now.ToString("HH:mm:ss"),
                TeamName = team.Name,
                PointsChange = pointChange
            });

            MessageBox.Show($"Команда {team.Name} отримала {pointChange} балів! Тепер у неї {team.Point} балів.");
        }

        // Метод для завантаження зображення з байтів
        private BitmapImage LoadImageFromBytes(byte[] imageData)
        {
            BitmapImage image = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
            }
            return image;
        }

        // Метод для виведення всієї інформації перед початком гри
        private void ShowGameInfo()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"Назва гри: {_game.Title}");
            info.AppendLine($"Кількість команд: {_game.teams.Count}");

            // Перевірка, чи є теми в грі
            if (_game.fieldGame.TopicList == null || !_game.fieldGame.TopicList.Any())
            {
                info.AppendLine("Тем не знайдено.");
            }
            else
            {
                // Виводимо інформацію про кожну тему і питання
                foreach (var topic in _game.fieldGame.TopicList)
                {
                    info.AppendLine($"\nТема: {topic.Name}");

                    if (topic.Question == null || !topic.Question.Any())
                    {
                        info.AppendLine("  - Питань не знайдено.");
                    }
                    else
                    {
                        foreach (var question in topic.Question)
                        {
                            info.AppendLine($" - Питання: {question.Title}, Балів: {question.Points}, Відповідь: {question.Ask.RightAnswer}");
                        }
                    }
                }
            }

            // Виводимо всю інформацію у вікні повідомлення
            MessageBox.Show(info.ToString(), "Інформація про гру", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Перевіряємо, чи була натиснута клавіша Enter
            if (e.Key == Key.RightCtrl)
            {
                // Створюємо і відкриваємо нове вікно
                Statistics statistics = new Statistics(_game.teams, _gameHistory);
                statistics.Show(); // Використовуємо Show для відкриття нового вікна
            }
            // Якщо натиснуто клавішу Space
            if (e.Key == Key.Space)
            {
                // Отримуємо команду, яка вибирає питання (в даний момент activeTeamIndex вказує на цю команду)
                var choosingTeam = _game.teams[activeTeamIndex];

                // Виводимо повідомлення з інформацією про команду
                MessageBox.Show($"Зараз питання вибирає команда: {choosingTeam.Name}", "Інформація про команду", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}