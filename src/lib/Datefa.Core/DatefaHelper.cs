using System;
using System.Collections.Generic;
using System.Globalization;
using Datefa.Core.ViewModels;

namespace Datefa.Core.Extensions {

    public static class DatefaHelper {

        private static PersianCalendar _persianCalendar
            = new PersianCalendar();

        private static HijriCalendar _hijriCalendar
            = new HijriCalendar();

        private static Dictionary<DayOfWeek, int> _weekDayNumbers 
            = new Dictionary<DayOfWeek, int>() {
                {DayOfWeek.Saturday, 1},
                {DayOfWeek.Sunday, 2},
                {DayOfWeek.Monday, 3},
                {DayOfWeek.Tuesday, 4},
                {DayOfWeek.Wednesday, 5},
                {DayOfWeek.Thursday, 6},
                {DayOfWeek.Friday, 7}
            };

        private static Dictionary<DayOfWeek, string> _weekDayNames 
            = new Dictionary<DayOfWeek, string>() {
                {DayOfWeek.Friday, "جمعه"},
                {DayOfWeek.Monday, "دوشنبه"},
                {DayOfWeek.Saturday, "شنبه"},
                {DayOfWeek.Sunday, "یکشنبه"},
                {DayOfWeek.Thursday, "پنجشنبه"},
                {DayOfWeek.Tuesday, "سه شنبه"},
                {DayOfWeek.Wednesday, "چهارشنبه"}
            };

        private static Dictionary<PersianMonth, string> _monthNames 
            = new Dictionary<PersianMonth, string>() {
                { PersianMonth.Aban, "آبان"},
                { PersianMonth.Azar, "آذر"},
                { PersianMonth.Bahman, "بهمن"},
                { PersianMonth.Day, "دی"},
                { PersianMonth.Esfand, "اسفند"},
                { PersianMonth.Farvardin, "فروردین"},
                { PersianMonth.Khordad, "خرداد" },
                { PersianMonth.Mehr, "مهر"},
                { PersianMonth.Mordad, "مرداد"},
                { PersianMonth.Ordibehesht, "اردیبهشت"},
                { PersianMonth.Shahrivar, "شهریور"},
                { PersianMonth.Tir, "تیر"}
            };

        private static Dictionary<MiladiMonth, string> _miladiMonthNames
            = new Dictionary<MiladiMonth, string> {
                { MiladiMonth.April, "April" },
                { MiladiMonth.August, "August" },
                { MiladiMonth.December, "December" },
                { MiladiMonth.Feburuary, "Feburuary" },
                { MiladiMonth.January, "January" },
                { MiladiMonth.July, "July" },
                { MiladiMonth.June, "June" },
                { MiladiMonth.March, "March" },
                { MiladiMonth.May, "May" },
                { MiladiMonth.November, "November" },
                { MiladiMonth.October, "October" },
                { MiladiMonth.September, "September" }
            };

        
        //private static Dictionary<PersianMonth, MiladiMonth> _1stMonths
        //    = new Dictionary<PersianMonth, MiladiMonth>() {
        //        { PersianMonth.Farvardin, MiladiMonth.}
        //    };

        public static DayViewModel GetDayInfo(this DateTime date) {
            var day = new DayViewModel {
                Number = _persianCalendar.GetDayOfMonth(date),
                WeekDay = _persianCalendar.GetDayOfWeek(date),
                Month = (PersianMonth)_persianCalendar.GetMonth(date),
                Year = _persianCalendar.GetYear(date),
                DateValue = date,
                MiladiDayNumber = date.Day,
                MiladiMonth = date.Month,
                HijriDayNumber = _hijriCalendar.GetDayOfMonth(date),
                HijriMonth = _hijriCalendar.GetMonth(date)
            };

            return day;
        }

        public static int GetWeekDayNumber(this DayOfWeek weekDay)
            => _weekDayNumbers[weekDay];

        public static string GetWeekDayTitle(this DayOfWeek dayOfWeek)
            => _weekDayNames[dayOfWeek];

        public static string GetPersianMonthDisplayName(this PersianMonth month)
            => _monthNames[month];

        public static string GetMiladiMonthDisplayName(this MiladiMonth month)
            => _miladiMonthNames[month];

        //public static int Get1stMiladiMonth(int year, PersianMonth month) 
        //    => 

        //public static MiladiMonthInfo GetMiladiMonthInfo(this DateTime date) {
        //    var result = new MiladiMonthInfo();
        //    result.FirstDayDate = new DateTime(date.Year, date.Month, 1);
            
        //    return result;
        //}

        public static DateTime GetFirstDayDateOfPersianMonth(
            this PersianMonth month, int year) 
                => _persianCalendar.ToDateTime(year, (int)month, 1, 0,0,0,0);

        public static DayOfWeek GetFirstWeekDayOfPersianMonth(
            this PersianMonth month, int year)
                => GetFirstDayDateOfPersianMonth(month, year).DayOfWeek;

        public static bool IsLeapYear(this int year)
            => _persianCalendar.IsLeapYear(year);

        public static int GetLastDayNumberOfPersianMonth(
            this PersianMonth month, 
            int year) {
            
            var monthLastNumber = 30;
            if ((int)month < 7)
                return 31;

            if (month == PersianMonth.Esfand)
                return IsLeapYear(year) 
                    ? 30 
                    : 29;

            return monthLastNumber;
        }

        public static PersianMonth GetPreviousPersianMonth(this PersianMonth month)
            => month == PersianMonth.Farvardin
                ? PersianMonth.Esfand
                : (PersianMonth)((int)month - 1);

        public static PersianMonth GetNextPersianMonth(this PersianMonth month)
            => month == PersianMonth.Esfand
                ? PersianMonth.Farvardin
                : (PersianMonth)((int)month + 1);

        public static int GetPreviousPersianMonthYear(
            this PersianMonth month, 
            int currentYear)
                => month == PersianMonth.Farvardin
                    ? currentYear - 1
                    : currentYear;

        public static int GetNextPersianMonthYear(
            this PersianMonth month,
            int currentYear)
                => month == PersianMonth.Esfand
                    ? currentYear + 1
                    : currentYear;

    }
}
