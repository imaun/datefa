using System;
using System.Collections.Generic;

namespace Datefa.Core.ViewModels {

    public class WeekViewModel {

        public WeekViewModel() {
            Days = new List<DayViewModel>();
        }

        public int Order { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ICollection<DayViewModel> Days { get; set; }
    }
}
