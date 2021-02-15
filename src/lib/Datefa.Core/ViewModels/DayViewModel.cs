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
            Index = day.Index;
            WeekDay = day.WeekDay;
            Month = day.Month;
            Year = day.Year;
            DateValue = value;
            MiladiDayIndex = day.MiladiDayIndex;
            MiladiMonth = day.MiladiMonth;
            HijriDayIndex = day.HijriDayIndex;
            HijriMonth = day.HijriMonth;
        }

        public string Title { get; set; }
        public int Index { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public string WeekDayTitle => WeekDay.GetWeekDayTitle();
        public PersianMonth Month { get; set; }
        public string MonthDisplayName => Month.GetMonthDisplayName();
        public int? Year { get; set; }
        public DateTime DateValue { get; set; }
        public bool Holiday { get; set; }
        public bool Enabled { get; set; } = true;
        public int MiladiDayIndex { get; set; }
        public int MiladiMonth { get; set; }
        public int HijriDayIndex { get; set; }
        public int HijriMonth { get; set; }
        public string Description { get; set; }
    }
}
