using System;
using System.Collections.Generic;
using Datefa.Core.ViewModels;
using Datefa.Core.Extensions;

namespace Datefa.Core {

    public class DatefaCalendar {

        public DatefaCalendar() {
        }

        #region Fields

        #endregion

        #region Properties

        public PersianMonth CurrentMonth => DateTime.Now.GetPersianMonth();
        public int CurrentYear => DateTime.Now.GetPersianYear();
        public int CurrentDay => DateTime.Now.GetPersianDay();
        public DayOfWeek CurrentDayOfWeek => DateTime.Now.DayOfWeek;
        public string CurrentDayOfWeekName => CurrentDayOfWeek.GetWeekDayName();

        #endregion

        #region Methods

        public MonthViewModel GetMonthView(int year, PersianMonth month) {
            var monthView = new MonthViewModel(year, month);
            int dayNumber = 1;
            int prevMonthStartNumber = monthView.PreviousMonthStartDayNumber;
            monthView.Days = new List<DayViewModel>();

            bool started = false, finished = false;
            for(int j = 0; j < 6; j++) {
                
                for(int i = 6; i >= 0; i--) {
                    if(j == 0) { //means it's first week
                        if(i == 7 - monthView.FirstDayWeekDayNumber) {
                            started = true;
                        }
                        else {
                            if(!started) {
                                var day = DayViewModel.Init(
                                    monthView.PreviousMonth.GetDate(
                                        monthView.PreviousMonthYear, 
                                        prevMonthStartNumber));
                                day.Disabled = true;
                                monthView.Days.Add(day);
                                prevMonthStartNumber++;
                            }
                        }
                    }

                    if(finished) {
                        var day = DayViewModel.Init(
                            monthView.NextMonth.GetDate(monthView.NextMonthYear, dayNumber));
                        day.Disabled = true;
                        monthView.Days.Add(day);
                        dayNumber++;
                    }

                    if(started && !finished) {
                        var day = DayViewModel.Init(
                            month.GetDate(year, dayNumber));
                        monthView.Days.Add(day);
                        if(dayNumber == monthView.LastDayNumber) {
                            finished = true;
                            dayNumber = 0;
                        }
                        dayNumber++;
                    }

                }
            }

            int idx = 0;
            int w = 1;
            int wOrder = 1;
            WeekViewModel week = new WeekViewModel();
            foreach(var day in monthView.Days) {
                if(w == 1) {
                    week = new WeekViewModel {
                        Order = wOrder,
                        StartDate = day.DateValue
                    };
                }
                if(w == 7) {
                    week.FinishDate = day.DateValue;
                    monthView.Weeks.Add(week);
                    w = 0;
                    wOrder++;
                }

                week.Days.Add(day);
                w++;
            }

            return monthView;
        }

        public MonthViewModel GetCurrentMonthView()
            => GetMonthView(CurrentYear, CurrentMonth);

        public IEnumerable<ListItemViewModel> GetPersianMonthsList()
            => new List<ListItemViewModel> {
                new ListItemViewModel(
                    PersianMonth.Farvardin.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Farvardin),

                new ListItemViewModel(
                    PersianMonth.Ordibehesht.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Ordibehesht),

                new ListItemViewModel(
                    PersianMonth.Khordad.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Khordad),

                new ListItemViewModel(
                    PersianMonth.Tir.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Tir),

                new ListItemViewModel(
                    PersianMonth.Mordad.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Mordad),

                new ListItemViewModel(
                    PersianMonth.Shahrivar.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Shahrivar),

                new ListItemViewModel(
                    PersianMonth.Mehr.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Mehr),

                new ListItemViewModel(
                    PersianMonth.Aban.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Aban),

                new ListItemViewModel(
                    PersianMonth.Azar.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Azar),

                new ListItemViewModel(
                    PersianMonth.Day.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Day),

                new ListItemViewModel(
                    PersianMonth.Bahman.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Bahman),

                new ListItemViewModel(
                    PersianMonth.Esfand.GetPersianMonthDisplayName(),
                    (int)PersianMonth.Esfand),
            };

        public IEnumerable<ListItemViewModel> GetHijriMonthsList()
            => new List<ListItemViewModel> {
                new ListItemViewModel(
                    HijriMonth.Muharram.GetHijriMonthDisplayName(),
                    (int)HijriMonth.Muharram),

                new ListItemViewModel(
                    HijriMonth.Safar.GetHijriMonthDisplayName(),
                    (int)HijriMonth.Safar),

                new ListItemViewModel(
                    HijriMonth.RabialAwal.GetHijriMonthDisplayName(),
                    (int)HijriMonth.RabialAwal),

                new ListItemViewModel(
                    HijriMonth.RabialThani.GetHijriMonthDisplayName(),
                    (int)HijriMonth.RabialThani),

                new ListItemViewModel(
                    HijriMonth.JamadiAwal.GetHijriMonthDisplayName(),
                    (int)HijriMonth.JamadiAwal),

                new ListItemViewModel(
                    HijriMonth.JamadiThani.GetHijriMonthDisplayName(),
                    (int)HijriMonth.JamadiThani),

                new ListItemViewModel(
                    HijriMonth.Rajab.GetHijriMonthDisplayName(),
                    (int)HijriMonth.Rajab),

                new ListItemViewModel(
                    HijriMonth.Shaban.GetHijriMonthDisplayName(),
                    (int)HijriMonth.Shaban),

                new ListItemViewModel(
                    HijriMonth.Ramadan.GetHijriMonthDisplayName(),
                    (int)HijriMonth.Ramadan),

                new ListItemViewModel(
                    HijriMonth.Shawal.GetHijriMonthDisplayName(),
                    (int)HijriMonth.Shawal),

                new ListItemViewModel(
                    HijriMonth.DualQadah.GetHijriMonthDisplayName(),
                    (int)HijriMonth.DualQadah),

                new ListItemViewModel(
                    HijriMonth.DualHijjah.GetHijriMonthDisplayName(),
                    (int)HijriMonth.DualHijjah),
            };

        public IEnumerable<ListItemViewModel> GetGregorianMonthList()
            => new List<ListItemViewModel> {
                new ListItemViewModel(
                    GregorianMonth.January.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.January),

                new ListItemViewModel(
                    GregorianMonth.Feburuary.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.Feburuary),

                new ListItemViewModel(
                    GregorianMonth.March.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.March),

                new ListItemViewModel(
                    GregorianMonth.April.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.April),

                new ListItemViewModel(
                    GregorianMonth.May.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.May),

                new ListItemViewModel(
                    GregorianMonth.June.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.June),

                new ListItemViewModel(
                    GregorianMonth.July.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.July),

                new ListItemViewModel(
                    GregorianMonth.August.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.August),

                new ListItemViewModel(
                    GregorianMonth.September.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.September),

                new ListItemViewModel(
                    GregorianMonth.October.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.October),

                new ListItemViewModel(
                    GregorianMonth.November.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.November),

                new ListItemViewModel(
                    GregorianMonth.December.GetGregorianMonthDisplayName(),
                    (int)GregorianMonth.December)
            };

        private IEnumerable<ListItemViewModel> getDaysList(
            int year, int maxDayNum) {
            var resutl = new List<ListItemViewModel>();
            for (int i = 1; i <= maxDayNum; i++) {
                resutl.Add(new ListItemViewModel(i.ToString(), i));
                i++;
            }

            return resutl;
        }

        public IEnumerable<ListItemViewModel> GetPersianDaysList(
            int year, PersianMonth month)
                => getDaysList(year, month.GetLastDayNumberOfPersianMonth(year));

        public IEnumerable<ListItemViewModel> GetGregorianDaysList(
            int year, GregorianMonth month)
                => getDaysList(year, month.GetGregorianMonthMaxDayNumber(year));

        public IEnumerable<ListItemViewModel> GetHijriDaysList(
            int year, HijriMonth month)
                => getDaysList(year, month.GetHijriMonthMaxDayNumber(year));
        
        #endregion
    }
}
