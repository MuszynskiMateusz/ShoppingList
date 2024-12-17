using List.Views;
using List.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace List.Views
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        private string filePath = Path.Combine(FileSystem.AppDataDirectory, "categories.json");

        public MainPage()
        {
            InitializeComponent();
            LoadCategories();
            BindingContext = this;
        }

        private void LoadCategories()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var categories = JsonSerializer.Deserialize<ObservableCollection<Category>>(json);
                if (categories != null)
                {
                    Categories = categories;
                }
            }
        }

        private void SaveCategories()
        {
            var json = JsonSerializer.Serialize(Categories);
            File.WriteAllText(filePath, json);
        }

        private async void OnAddCategoryClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Nowa kategoria", "Podaj nazwę kategorii:");
            if (!string.IsNullOrWhiteSpace(result))
            {
                Categories.Add(new Category { Name = result });
                SaveCategories();
            }
        }

        private async void OnCategorySelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Category selectedCategory)
            {

                ((CollectionView)sender).SelectedItem = null;


                await Navigation.PushAsync(new CategoryPage(selectedCategory, SaveCategories));
            }
        }
    }
}

