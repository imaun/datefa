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

        public static DayViewModel GetDayInfo(this DateTime date) {
            var day = new DayViewModel {
                Index = _persianCalendar.GetDayOfMonth(date),
                WeekDay = _persianCalendar.GetDayOfWeek(date),
                Month = (PersianMonth)_persianCalendar.GetMonth(date),
                Year = _persianCalendar.GetYear(date),
                DateValue = date,
                MiladiDayIndex = date.Day,
                MiladiMonth = date.Month,
                HijriDayIndex = _hijriCalendar.GetDayOfMonth(date),
                HijriMonth = _hijriCalendar.GetMonth(date)
            };

            return day;
        }

        public static string GetWeekDayTitle(this DayOfWeek dayOfWeek)
            => _weekDayNames[dayOfWeek];

        public static string GetMonthDisplayName(this PersianMonth month)
            => _monthNames[month];


    }
}
