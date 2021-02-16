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
            GregorianDayNumber = day.GregorianDayNumber;
            GregorianMonth = day.GregorianMonth;
            HijriDayNumber = day.HijriDayNumber;
            HijriMonth = day.HijriMonth;
        }

        public string Title { get; set; }
        public int Number { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public string WeekDayTitle => WeekDay.GetWeekDayName();
        public PersianMonth Month { get; set; }
        public string MonthDisplayName => Month.GetPersianMonthDisplayName();
        public int Year { get; set; }
        public DateTime DateValue { get; set; }
        /// <summary>
        /// If true, means It's holiday
        /// </summary>
        public bool Holiday { get; set; }
        /// <summary>
        /// If set true, means that this day does not belongs to current month
        /// </summary>
        public bool Disabled { get; set; } 
        public int GregorianDayNumber { get; set; }
        public int GregorianMonth { get; set; }
        public int HijriDayNumber { get; set; }
        public int HijriMonth { get; set; }
        public string Description { get; set; }
    }
}
