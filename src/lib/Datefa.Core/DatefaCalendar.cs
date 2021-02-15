using Datefa.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using Datefa.Core.Extensions;

namespace Datefa.Core
{
    public class DatefaCalendar
    {
        public DatefaCalendar() {
            _persianCalendar = new PersianCalendar();
            _hijriCalendar = new HijriCalendar();
        }

        #region Fields
        private PersianCalendar _persianCalendar;
        private HijriCalendar _hijriCalendar;

        

        #endregion

        #region Properties


        #endregion

        #region Methods

        public DateTime GetDateValue(int year, int month, int day)
            => _persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        

        public MonthViewModel GetMonthViewData(int year, PersianMonth month) {
            var monthView = new MonthViewModel(year, month);
            var firstDayWeekDay = month.GetFirstWeekDayOfPersianMonth(year);
            var firstDayPlace = firstDayWeekDay.GetWeekDayNumber();
            monthView.LastDayNumber = month.GetLastDayNumberOfPersianMonth(year);
            var prevPersianMonth = month.GetPreviousPersianMonth();
            var nextPersianMonth = month.GetNextPersianMonth();
            int prevPersianMonthYear = month.GetPreviousPersianMonthYear(year);
            int nextPersianMonthYear = month.GetNextPersianMonthYear(year);
            
        }

        #endregion
    }
}
