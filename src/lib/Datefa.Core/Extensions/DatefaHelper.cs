using System;
using System.Collections.Generic;
using System.Globalization;
using Datefa.Core.ViewModels;

namespace Datefa.Core.Extensions {

    public static class DatefaHelper {

        private static PersianCalendar _persianCalendar = new PersianCalendar();

        private static HijriCalendar _hijriCalendar = new HijriCalendar();

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

        private static Dictionary<GregorianMonth, string> _gregorianMonthNames
            = new Dictionary<GregorianMonth, string> {
                { GregorianMonth.April, "April" },
                { GregorianMonth.August, "August" },
                { GregorianMonth.December, "December" },
                { GregorianMonth.Feburuary, "Feburuary" },
                { GregorianMonth.January, "January" },
                { GregorianMonth.July, "July" },
                { GregorianMonth.June, "June" },
                { GregorianMonth.March, "March" },
                { GregorianMonth.May, "May" },
                { GregorianMonth.November, "November" },
                { GregorianMonth.October, "October" },
                { GregorianMonth.September, "September" }
            };

        private static Dictionary<HijriMonth, string> _hijriMonthNames
            = new Dictionary<HijriMonth, string> {
                { HijriMonth.Muharram, "محرم‎" },
                { HijriMonth.Safar, "صفر" },
                { HijriMonth.RabialAwal, "ربیع الاول" },
                { HijriMonth.RabialThani, "ربیع الثانی" },
                { HijriMonth.JamadiAwal, "جمادی الاولی" },
                { HijriMonth.JamadiThani, "جمادی الثانیه" },
                { HijriMonth.Rajab, "رجب" },
                { HijriMonth.Shaban, "شعبان" },
                { HijriMonth.Ramadan, "رمضان" },
                { HijriMonth.Shawal, "شوال" },
                { HijriMonth.DualQadah, "ذوالقعده" },
                { HijriMonth.DualHijjah, "ذوالحجه" }
            };

        public static DayViewModel GetDayInfo(this DateTime date) {
            var day = new DayViewModel {
                Number = _persianCalendar.GetDayOfMonth(date),
                WeekDay = _persianCalendar.GetDayOfWeek(date),
                Month = (PersianMonth)_persianCalendar.GetMonth(date),
                Year = _persianCalendar.GetYear(date),
                DateValue = date,
                GregorianDayNumber = date.Day,
                GregorianMonth = date.Month,
                HijriDayNumber = _hijriCalendar.GetDayOfMonth(date),
                HijriMonth = _hijriCalendar.GetMonth(date)
            };

            return day;
        }

        public static int GetWeekDayNumber(this DayOfWeek weekDay)
            => _weekDayNumbers[weekDay];

        public static string GetWeekDayName(this DayOfWeek dayOfWeek)
            => _weekDayNames[dayOfWeek];

        public static string GetPersianMonthDisplayName(this PersianMonth month)
            => _monthNames[month];

        public static string GetGregorianMonthDisplayName(this GregorianMonth month)
            => _gregorianMonthNames[month];

        public static string GetHijriMonthDisplayName(this HijriMonth month)
            => _hijriMonthNames[month];

        public static DateTime GetDate(this PersianMonth month, int year, int day)
            => _persianCalendar.ToDateTime(year, (int)month, day, 0, 0, 0, 0);

        public static int GetHijriYear(this DateTime date)
            => _hijriCalendar.GetYear(date);

        public static PersianMonth GetPersianMonth(this DateTime date)
            => (PersianMonth)_persianCalendar.GetMonth(date);

        public static int GetPersianYear(this DateTime date)
            => _persianCalendar.GetYear(date);

        public static int GetPersianDay(this DateTime date)
            => _persianCalendar.GetDayOfMonth(date);

        public static GregorianMonth GetGregorianMonth(this DateTime date)
            => (GregorianMonth)date.Month;

        public static HijriMonth GetHijriMonth(this DateTime date)
            => (HijriMonth)_hijriCalendar.GetMonth(date);

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

        public static int GetGregorianMonthMaxDayNumber(this GregorianMonth month, int year) {
            switch (month) {
                case GregorianMonth.January:
                    return 31;
                case GregorianMonth.Feburuary:
                    return DateTime.IsLeapYear(year) ? 29 : 28;
                case GregorianMonth.March:
                    return 31;
                case GregorianMonth.April:
                    return 30;
                case GregorianMonth.May:
                    return 31;
                case GregorianMonth.June:
                    return 30;
                case GregorianMonth.July:
                    return 30;
                case GregorianMonth.August:
                    return 31;
                case GregorianMonth.September:
                    return 30;
                case GregorianMonth.October:
                    return 31;
                case GregorianMonth.November:
                    return 30;
                case GregorianMonth.December:
                    return 31;
                default:
                    throw new NotSupportedException("Unknown Month!");
            }
        }

        public static int GetHijriMonthMaxDayNumber(this HijriMonth month, int year) {
            switch(month) {
                case HijriMonth.Muharram:
                case HijriMonth.RabialAwal:
                case HijriMonth.JamadiAwal:
                case HijriMonth.Rajab:
                case HijriMonth.Ramadan:
                case HijriMonth.DualQadah:
                    return 30;
                case HijriMonth.Safar:
                case HijriMonth.RabialThani:
                case HijriMonth.JamadiThani:
                case HijriMonth.Shaban:
                case HijriMonth.Shawal:
                    return 29;
                case HijriMonth.DualHijjah:
                    return _hijriCalendar.IsLeapYear(year)
                        ? 30 : 29;
                default:
                    throw new NotSupportedException("Invalid Month!");
            }
        }

        public static string ToPersianDate(this DateTime date, string format = "YY:MM:DD") {
            var day = _persianCalendar.GetDayOfMonth(date);
            var month = _persianCalendar.GetMonth(date);
            var year = _persianCalendar.GetYear(date);
            var monthName = ((PersianMonth)month).GetPersianMonthDisplayName();
            var dayName = GetWeekDayName(date.DayOfWeek);
            var dayStr = day.ToString();
            if (day < 10)
                dayStr = $"0{day}";

            format = format.ToUpper();
            string result = format
                .Replace("YY", year.ToString())
                .Replace("MM", month.ToString())
                .Replace("MMMM", monthName)
                .Replace("DD", dayStr)
                .Replace("DDDD", dayName);

            return result;
        }

        public static string ToHijriDate(this DateTime date, string format = "YY:MM:DD") {
            var day = _hijriCalendar.GetDayOfMonth(date);
            var month = _hijriCalendar.GetMonth(date);
            var year = _hijriCalendar.GetYear(date);
            var monthName = ((HijriMonth)month).GetHijriMonthDisplayName();
            var dayStr = day.ToString();
            if (day < 10)
                dayStr = $"0{day}";

            format = format.ToUpper();
            string result = format
                .Replace("YY", year.ToString())
                .Replace("MM", month.ToString())
                .Replace("MMMM", monthName)
                .Replace("DD", dayStr);

            return result;
        }

    }
}
