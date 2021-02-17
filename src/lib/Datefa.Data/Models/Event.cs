using System;
using System.Collections.Generic;
using System.Text;
using Datefa.Data;

namespace Datefa.Data.Models {

    public class Event {

        public Event() { }

        public int Id { get; set; }
        public CalendarType CalendarType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int IconIndex { get; set; }
        public int DayNumber { get; set; }
        public int? MonthNumber { get; set; }
        public int? Year { get; set; }
        public int Lenght { get; set; }
        public bool IsHoliday { get; set; }
        public string MoreInfoUrl { get; set; }
        public int CalendarId { get; set; }
        public Calendar Calendar { get; set; }
    }
}
