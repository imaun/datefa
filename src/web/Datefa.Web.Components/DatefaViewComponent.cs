using Microsoft.AspNetCore.Mvc;
using Datefa.Core;

namespace Datefa.Web.Components
{
    [ViewComponent(Name = "Datefa")]
    public class DatefaViewComponent: ViewComponent {

        public IViewComponentResult Invoke(int? year = null, int? month = null) {
            bool isNow = year == null || month == null;
            var datefa = new DatefaCalendar();
            if (isNow)
                return View(model: datefa.GetCurrentMonthView());

            return View(
                datefa.GetMonthView(
                    year.Value, 
                    (PersianMonth)month.Value)
            );
        }
    }
}
