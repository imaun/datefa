using System;
using System.Collections.Generic;
using System.Text;
using Datefa.Core.Extensions;

namespace Datefa.Core.ViewModels
{
    public class DayViewModel {

        public static DayViewModel Init(DateTime date)
            => date.GetDayInfo();

        public DayViewModel() { }

        public DayViewModel(DateTime value) {
            var day = value.GetDayInfo();
            Title = day.Title;
            Number = day.Number;
            WeekDay = day.WeekDay;
            Month = day.Month;
            Year = day.Year;
            DateValue = value;
            MiladiDayNumber = day.MiladiDayNumber;
            MiladiMonth = day.MiladiMonth;
            HijriDayNumber = day.HijriDayNumber;
            HijriMonth = day.HijriMonth;
        }

        public string Title { get; set; }
        public int Number { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public string WeekDayTitle => WeekDay.GetWeekDayTitle();
        public PersianMonth Month { get; set; }
        public string MonthDisplayName => Month.GetPersianMonthDisplayName();
        public int? Year { get; set; }
        public DateTime DateValue { get; set; }
        public bool Holiday { get; set; }
        public bool Enabled { get; set; } = true;
        public int MiladiDayNumber { get; set; }
        public int MiladiMonth { get; set; }
        public int HijriDayNumber { get; set; }
        public int HijriMonth { get; set; }
        public string Description { get; set; }
    }
}
