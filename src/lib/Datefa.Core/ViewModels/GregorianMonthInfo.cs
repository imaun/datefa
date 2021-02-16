using System;
using System.Collections.Generic;
using System.Text;

namespace Datefa.Core.ViewModels
{
    public class GregorianMonthInfo {
        public int Year { get; set; }
        public GregorianMonth Month { get; set; }
        public DateTime FirstDayDate => new DateTime(Year, (int)Month, 1);
        public DayOfWeek FirstDayWeekDay => FirstDayDate.DayOfWeek;
    }
}
