using System.Collections.Generic;

namespace Datefa.Data.Models {

    public class Calendar {
        
        public Calendar() {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
