using System;
using System.Collections.Generic;
using System.Text;
using Datefa.Core.Extensions;

namespace Datefa.Core.ViewModels {

    public class MonthViewModel {

        public MonthViewModel(PersianMonth month) {
            Month = month;
            Days = new List<DayViewModel>();
            Weeks = new List<WeekViewModel>();
        }

        public MonthViewModel(int year, PersianMonth month) {
            Year = year;
            Month = month;
            Days = new List<DayViewModel>();
            Weeks = new List<WeekViewModel>();
        }

        #region Properties
        public PersianMonth Month { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string DisplayName => Month
            .GetPersianMonthDisplayName();
        public GregorianMonth GregorianMonth1 => FirstDayDate.GetGregorianMonth();

        public string GetGregorianMonth1Title() {
            return GregorianMonth1.GetGregorianMonthDisplayName();
        }

        public int GregorianYear1 => FirstDayDate.Year;
        public GregorianMonth GregorianMonth2 => LastDayDate.GetGregorianMonth();
        public string GregorianMonth2Title
            => GregorianMonth2.GetGregorianMonthDisplayName();
        public int GregorianYear2 => LastDayDate.Year;
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
        public DayOfWeek FirstDayWeekDay => Month.GetFirstWeekDayOfPersianMonth(Year);
        public int FirstDayWeekDayNumber => FirstDayWeekDay.GetWeekDayNumber();
        public PersianMonth PreviousMonth => Month.GetPreviousPersianMonth();
        public PersianMonth NextMonth => Month.GetNextPersianMonth();
        public int PreviousMonthLastDayNumber => PreviousMonth.GetLastDayNumberOfPersianMonth(Year);
        public int PreviousMonthStartDayNumber => (PreviousMonthLastDayNumber - FirstDayWeekDayNumber) + 2;
        public int PreviousMonthYear => Month.GetPreviousPersianMonthYear(Year);
        public int NextMonthYear => Month.GetNextPersianMonthYear(Year);
        public ICollection<WeekViewModel> Weeks { get; set; }

        #endregion
    }
}
