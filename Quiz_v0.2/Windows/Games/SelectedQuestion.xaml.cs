using ClassLibrary_Quiz_.Models.Template_m.Field.Question_m;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Quiz_v0._2.Windows.Games
{
    /// <summary>
    /// Interaction logic for SelectedQuestion.xaml
    /// </summary>
    public partial class SelectedQuestion : Window
    {
        private DispatcherTimer _timer;  // Таймер для оновлення часу
        private int _remainingTime;      // Залишковий час
        private QuizMusicPlayer musicPlayer;

        public bool IsCorrect { get; private set; }
        private Question question;

        public SelectedQuestion(Question question, int time , QuizMusicPlayer musicPlayer_)
        {
            InitializeComponent();
            this.question = question;
            _remainingTime = time; // Встановлюємо початковий час

            musicPlayer = musicPlayer_;
            musicPlayer.PlayThinkMusic();

            // Встановлюємо текст питання
            QuestionInfoTextBlock.Text = $"Питання: {question.Title}\nБалів: {question.Points}";

            // Якщо є зображення
            if (question.Picture != null && question.Picture.Data != null)
            {
                QuestionImage.Source = LoadImageFromBytes(question.Picture.Data);
            }
            else
            {
                QuestionImage.Visibility = Visibility.Collapsed;
            }

            // Ініціалізуємо таймер
            InitializeTimer();
        }

        // Ініціалізація таймера
        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        // Оновлення таймера кожну секунду
        // Оновлення таймера кожну секунду
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_remainingTime > 0)
            {
                _remainingTime--;

                // Переводимо секунди в години, хвилини і секунди
                int hours = _remainingTime / 3600;
                int minutes = (_remainingTime % 3600) / 60;
                int seconds = _remainingTime % 60;

                // Оновлюємо текст таймера
                TimerTextBlock.Text = $"Залишилось часу: {hours:D2}:{minutes:D2}:{seconds:D2}"; // Форматування у вигляді годин, хвилин, секунд
            }
            else
            {
                _timer.Stop();
                MessageBox.Show("Час на питання вийшов!", "Таймер питання", MessageBoxButton.OK, MessageBoxImage.Warning);
                LoseMusic();
                IsCorrect = false;
                this.DialogResult = true;
                this.Close();
            }
        }

        // Завантаження зображення з байтів
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumPad1 || e.Key == Key.D1)
            {
                WinMusic();
                IsCorrect = true;
                _timer.Stop();
                this.DialogResult = true;
                this.Close();
            }
            if (e.Key == Key.NumPad0 || e.Key == Key.D0)
            {
                LoseMusic();
                IsCorrect = false;
                _timer.Stop();
                this.DialogResult = true;
                this.Close();
            }
            if(e.Key == Key.A)
            {
                _timer.Stop();
                AnswerMusic();
            }
            if (e.Key == Key.P)
            {
                musicPlayer.StopMusic();
                IsCorrect = false;
                _timer.Stop();
                this.DialogResult = true;
                this.Close();
            }
        }

        private async void WinMusic() { musicPlayer.StopMusic(); await musicPlayer.PlayWinMusic(); musicPlayer.StopMusic(); }
        private async void LoseMusic() { musicPlayer.StopMusic(); await musicPlayer.PlayLoseMusic(); musicPlayer.StopMusic(); }
        private async void AnswerMusic() { musicPlayer.StopMusic(); await musicPlayer.PlayAnswerMusic(); musicPlayer.StopMusic(); }
    }
}
