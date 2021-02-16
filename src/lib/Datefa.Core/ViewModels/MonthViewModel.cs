using System;
using System.Collections.Generic;
using System.Text;
using Datefa.Core.Extensions;

namespace Datefa.Core.ViewModels {

    public class MonthViewModel {

        public MonthViewModel(PersianMonth month) {
            Month = month;
            Days = new List<DayViewModel>();
        }

        public MonthViewModel(int year, PersianMonth month) {
            Year = year;
            Month = month;
            Days = new List<DayViewModel>();
        }

        #region Properties
        public PersianMonth Month { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string DisplayName => Month
            .GetPersianMonthDisplayName();
        public MiladiMonth MiladiMonth1 => FirstDayDate.GetMiladiMonth();
        public string MiladiMonth1Title 
            => MiladiMonth1.GetMiladiMonthDisplayName();
        public int MiladiYear1 => FirstDayDate.Year;
        public MiladiMonth MiladiMonth2 => LastDayDate.GetMiladiMonth();
        public string MiladiMonth2Title
            => MiladiMonth2.GetMiladiMonthDisplayName();
        public int MiladiYear2 => LastDayDate.Year;
        public HijriMonth HijriMonth1 => FirstDayDate.GetHijriMonth();
        public string HijriMonth1Title
            => HijriMonth1.GetHijriMonthDisplayName();
        public int HijriYear1 => FirstDayDate.GetHijriYear();
        public HijriMonth HijriMonth2 => LastDayDate.GetHijriMonth();
        public string HijriMonth2Title
            => HijriMonth2.GetHijriMonthDisplayName();
        public int HijriYear2 => LastDayDate.GetHijriYear();
        public ICollection<DayViewModel> Days { get; set; }
        public DayViewModel FirstDayOfMonth { get; set; }
        public DateTime FirstDayDate => Month.GetFirstDayDateOfPersianMonth(Year);
        public int LastDayNumber => Month.GetLastDayNumberOfPersianMonth(Year);
        public DateTime LastDayDate => Month.GetDate(Year, LastDayNumber);
        #endregion
    }
}
