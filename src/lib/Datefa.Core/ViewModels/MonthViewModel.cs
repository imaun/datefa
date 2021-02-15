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

        public PersianMonth Month { get; set; }
        public int Year { get; set; }
        public string PersianTitle { get; set; }
        public int MiladiMonth1_Index { get; set; }
        public string MiladiMonth1_Title { get; set; }
        public int MiladiMonth2_Index { get; set; }
        public string MiladiMonth2_Title { get; set; }
        public int HijriMonth1_Index { get; set; }
        public string HijriMonth1_Title { get; set; }
        public int HijriMonth2_Index { get; set; }
        public string HijriMonth2_Title { get; set; }
        public ICollection<DayViewModel> Days { get; set; }
    }
}
