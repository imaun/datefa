using System;
using System.Collections.Generic;
using System.Globalization;

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
        


        #endregion
    }
}
