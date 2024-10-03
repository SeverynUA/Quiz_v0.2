using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Quiz_.Models.Game_m
{
    public class HistoryRecord
    {
        public string Time { get; set; }           // Час зміни
        public string TeamName { get; set; }       // Назва команди
        public int PointsChange { get; set; }      // Зміна балів
    }
}
