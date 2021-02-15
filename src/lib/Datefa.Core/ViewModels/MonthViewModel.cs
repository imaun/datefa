using System;
using System.Collections.Generic;
using System.Text;

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
        public string PersianTitle { get; set; }
        public int MiladiMonth1 { get; set; }
        public string MiladiMonth1Title { get; set; }
        public int MiladiMonth2 { get; set; }
        public string MiladiMonth2Title { get; set; }
        public int HijriMonth1 { get; set; }
        public string HijriMonth1Title { get; set; }
        public int HijriMonth2 { get; set; }
        public string HijriMonth2Title { get; set; }
        public ICollection<DayViewModel> Days { get; set; }
        public DayViewModel FirstDayOfMonth { get; set; }
        public int LastDayNumber { get; set; }
        #endregion
    }
}
