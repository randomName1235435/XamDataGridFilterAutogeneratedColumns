using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamDataGridFilterAutogeneratedColumns
{
    public class MainWindowsViewModel : INotifyPropertyChanged
    {
        private List<Customer> items;
        private ObservableCollection<string> invalidColumns;
        private ObservableCollection<string> validColumns;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowsViewModel()
        {
            ValidColumns = new ObservableCollection<string>() { "LastName", "FirstName" };
            InvalidColumns = new ObservableCollection<string>() { "Age", "Sex" };
            items = CreateSampleData();
        }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private List<Customer> CreateSampleData()
        {
            return new List<Customer>() {
                new Customer("Bar", "Foo",1,"m"),
                new Customer("Foo", "Bar",2,"m"),
                new Customer("BarBar", "FooFoo",3,"w"),
                new Customer("FooFoo", "BarBar",4,"w"),
            };
        }

        public List<Customer> Items
        {
            get => items;
            set => SetField(ref items, value);
        }

        public ObservableCollection<string> ValidColumns
        {
            get => validColumns;
            set => SetField(ref validColumns, value);
        }
        public ObservableCollection<string> InvalidColumns
        {
            get => invalidColumns;
            set => SetField(ref invalidColumns, value);
        }

    }
}
