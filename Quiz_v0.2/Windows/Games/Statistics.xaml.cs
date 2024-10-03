using ClassLibrary_Quiz_.Models.Game_m;
using ClassLibrary_Quiz_.Models.Team_m;
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

namespace Quiz_v0._2.Windows.Games
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        public Statistics(List<Team> teams, List<HistoryRecord> history)
        {
            InitializeComponent();

            // Відсортуємо команди по балах у спадному порядку
            var sortedTeams = teams.OrderByDescending(t => t.Point).ToList();

            // Заповнюємо ListView відсортованими командами
            TeamsListView.ItemsSource = sortedTeams;

            // Додаємо історію гри до ListView
            HistoryListView.ItemsSource = history;
        }
    }
}
