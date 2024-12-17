using List.Models;

namespace List.Views
{
    public partial class CategoryPage : ContentPage
    {
        public Category Category { get; private set; }
        private Action SaveCategories;

        public CategoryPage(Category category, Action saveCategories)
        {
            InitializeComponent();
            Category = category;
            SaveCategories = saveCategories;
            BindingContext = this;
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Nowy produkt", "Podaj nazwę produktu:");
            if (string.IsNullOrWhiteSpace(name)) return;

            string unit = await DisplayActionSheet("Wybierz jednostkę: ", " Anuluj", null, "Sztuki", "Kilogramy", "Litry");
            if (unit == null) return;

            Category.Products.Add(new Product { Name = name, Unit = unit, Quantity = 0, IsPurchased = false });
            SaveCategories();
        }

        private void OnIncreaseQuantityClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Product product)
            {
                product.Quantity++;  
                SaveCategories();  
            }
        }

        private void OnDecreaseQuantityClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Product product && product.Quantity > 0)
            {
                product.Quantity--;  
                SaveCategories(); 
            }
        }
        private void OnDeleteProductClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Product product)
            {
                Category.Products.Remove(product);
                SaveCategories();
            }
        }

        private void OnPurchaseToggled(object sender, CheckedChangedEventArgs e)
        {
            SaveCategories();
        }
    }
}