namespace Datefa.Core.ViewModels {

    public class ListItemViewModel {
        public ListItemViewModel() { }

        public ListItemViewModel(string name, object value) {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public object Value { get; set; }
    }
}
