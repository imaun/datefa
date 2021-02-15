using System;
using System.Collections.Generic;
using System.Text;

namespace Datefa.Core.ViewModels
{
    public class MiladiMonthInfo {
        public int Year { get; set; }
        public MiladiMonth Month { get; set; }
        public DateTime FirstDayDate => new DateTime(Year, (int)Month, 1);
        public DayOfWeek FirstDayWeekDay => FirstDayDate.DayOfWeek;
    }
}
