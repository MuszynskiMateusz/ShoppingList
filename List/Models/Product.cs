using System.ComponentModel;

namespace List.Models
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private string unit;
        private int quantity;
        private bool isPurchased;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Unit
        {
            get => unit;
            set
            {
                unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public bool IsPurchased
        {
            get => isPurchased;
            set
            {
                isPurchased = value;
                OnPropertyChanged(nameof(IsPurchased));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}