using Quiz_v0._2.Windows.SetUp;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_v0._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            SetUpQuiz setUpQuiz = new SetUpQuiz();
            setUpQuiz.Show();

            // Закриваємо поточне вікно
            this.Close();
        }

        private void themeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (themeComboBox.SelectedIndex == 0) // Якщо обрана світла тема
            {
                ApplyTheme("Themes/LightTheme.xaml");
            }
            else // Якщо обрана темна тема
            {
                ApplyTheme("Themes/DarkTheme.xaml");
            }
        }

        private void ApplyTheme(string themePath)
        {
            // Очищуємо попередні словники ресурсів
            Application.Current.Resources.MergedDictionaries.Clear();

            // Завантажуємо нову тему
            ResourceDictionary newTheme = new ResourceDictionary();
            newTheme.Source = new Uri(themePath, UriKind.Relative);

            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        private void button_continue_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}