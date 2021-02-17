using System;
using Datefa.Core.Extensions;

namespace Datefa.Core.ViewModels {

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
        public string NumberDisplay => Number.ToPersianNumbers();
        public DayOfWeek WeekDay { get; set; }
        public string WeekDayTitle => WeekDay.GetWeekDayName();
        public PersianMonth Month { get; set; }
        public string MonthDisplayName => Month.GetPersianMonthDisplayName();
        public int Year { get; set; }
        public DateTime DateValue { get; set; }
        public bool IsToday => DateValue.Date == DateTime.Today;
        /// <summary>
        /// If true, means It's holiday
        /// </summary>
        public bool Holiday { get; set; }

        public bool IsFriday => WeekDay == DayOfWeek.Friday;

        /// <summary>
        /// If set true, means that this day does not belongs to current month
        /// </summary>
        public bool Disabled { get; set; } 
        public int GregorianDayNumber { get; set; }
        public string GregorianDayNumberDisplay => GregorianDayNumber.ToEnglishNumbers();
        public int GregorianMonth { get; set; }
        public int HijriDayNumber { get; set; }
        public string HijriDayNumberDisplay => HijriDayNumber.ToArabicNumbers();
        public int HijriMonth { get; set; }
        public string Description { get; set; }
    }
}
