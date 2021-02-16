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


        #endregion

        #region Methods

        public MonthViewModel GetMonthViewData(int year, PersianMonth month) {
            var monthView = new MonthViewModel(year, month);
            int dayNumber = 1;
            var firstDayWeekDay = month.GetFirstWeekDayOfPersianMonth(year);
            var firstDayPlace = firstDayWeekDay.GetWeekDayNumber();
            var prevPersianMonth = month.GetPreviousPersianMonth();
            var nextPersianMonth = month.GetNextPersianMonth();
            var prevMonthLastNumber = prevPersianMonth.GetLastDayNumberOfPersianMonth(year);
            var prevMonthStartNumber = (prevMonthLastNumber - firstDayPlace) + 2;
            int prevPersianMonthYear = month.GetPreviousPersianMonthYear(year);
            int nextPersianMonthYear = month.GetNextPersianMonthYear(year);
            
            monthView.Days = new List<DayViewModel>();

            bool started = false, finished = false;
            for(int j = 0; j < 6; j++) {
                int w = 0;
                for(int i = 6; i >= 0; i--) {
                    if(j == 0) { //means it's first week
                        if(i == 7 - firstDayPlace) {
                            started = true;
                        }
                        else {
                            if(!started) {
                                var day = DayViewModel.Init(
                                    prevPersianMonth.GetDate(prevPersianMonthYear, prevMonthStartNumber));
                                day.Disabled = true;
                                monthView.Days.Add(day);
                                prevMonthStartNumber++;
                            }
                        }
                    }

                    if(finished) {
                        var day = DayViewModel.Init(
                            nextPersianMonth.GetDate(nextPersianMonthYear, dayNumber));
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
                        w++;
                    }

                }
            }

            return monthView;
        }

        #endregion
    }
}
