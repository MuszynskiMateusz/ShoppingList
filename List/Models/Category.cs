using System.Collections.ObjectModel;

namespace List.Models
{
    public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    }
}