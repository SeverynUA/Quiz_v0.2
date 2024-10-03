using ClassLibrary_Quiz_.Models.Team_m;
using ClassLibrary_Quiz_.Models.Template_m.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Quiz_.Models.Game_m
{
    public class Game
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public List<Team> teams { get; set; }
        public int Time { get; set; }

        public FieldGame fieldGame {  get; set; }

        public Game() { }

        public Game(int id, string title, List<Team> teams, int time, FieldGame fieldGame)
        {
            Id = id;
            Title = title;
            this.teams = teams;
            Time = time;
            this.fieldGame = fieldGame;
        }
    }
}
