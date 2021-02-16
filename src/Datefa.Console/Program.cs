using System;
using Datefa.Core;
using Datefa.Core.ViewModels;

namespace Datefa.Console
{
    class Program
    {
        static DatefaCalendar _calendar;

        static void Main(string[] args) {
            _calendar = new DatefaCalendar();
            var thisMonth = _calendar.GetMonthView(1399, PersianMonth.Bahman);
            System.Console.Read();
        }
    }
}
