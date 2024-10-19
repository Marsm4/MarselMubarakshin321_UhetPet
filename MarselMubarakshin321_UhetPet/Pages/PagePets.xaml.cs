using MarselMubarakshin321_UhetPet.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarselMubarakshin321_UhetPet.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePets.xaml
    /// </summary>
    public partial class PagePets : Page
    {

        private string _currentUser;
        public PagePets(string currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            LoadPets();
        }

        private void LoadPets()
        {
          
            PetsListView.ItemsSource = DatabaseConnectionClass.DatabaseConnection.Pets.ToList();
            var pets = DatabaseConnectionClass.DatabaseConnection.Pets.ToList();

         
            if (_currentUser == "Андрей пирокинезис")
            {
                pets = pets.Where(p => p.Names == "Ра").ToList();
            }
            else if (_currentUser == "Деля")
            {
                pets = pets.Where(p => p.Names == "Нуби").ToList();
            }
            

            PetsListView.ItemsSource = pets;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)//поиск
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredPets = DatabaseConnectionClass.DatabaseConnection.Pets
                .Where(p => p.Names.ToLower().Contains(searchText))
                .ToList();
            // Фильтрация данных в зависимости от текущего пользователя
            if (_currentUser == "Андрей пирокинезис")
            {
                filteredPets = filteredPets.Where(p => p.Names == "Ра").ToList();
            }
            else if (_currentUser == "Деля")
            {
                filteredPets = filteredPets.Where(p => p.Names == "Нуби").ToList();
            }


            PetsListView.ItemsSource = filteredPets;
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSort = SortComboBox.SelectedItem as ComboBoxItem;

            if (selectedSort != null)
            {
                var pets = DatabaseConnectionClass.DatabaseConnection.Pets.AsQueryable();

                switch (selectedSort.Content.ToString())
                {
                    case "Имя (А-Я)":
                        pets = pets.OrderBy(p => p.Names);
                        break;
                    case "Имя (Я-А)":
                        pets = pets.OrderByDescending(p => p.Names);
                        break;
                    case "Описание (А-Я)":
                        pets = pets.OrderBy(p => p.Opisanie);
                        break;
                    case "Описание (Я-А)":
                        pets = pets.OrderByDescending(p => p.Opisanie);
                        break;
                }
                if (_currentUser == "Андрей пирокинезис")
                {
                    pets = pets.Where(p => p.Names == "Ра");
                }
                else if (_currentUser == "Деля")
                {
                    pets = pets.Where(p => p.Names == "Нуби");
                }

                PetsListView.ItemsSource = pets.ToList();
            }
        }

        private void AddPetButton_Click(object sender, RoutedEventArgs e)
        {

            PageAddPet pageAddPet = new PageAddPet();

            // Переход на новую страницу
            NavigationService?.Navigate(pageAddPet);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}