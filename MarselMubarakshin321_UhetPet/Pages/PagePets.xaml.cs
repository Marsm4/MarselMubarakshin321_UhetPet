using MarselMubarakshin321_UhetPet.Classes;
using System;
using System.Collections.Generic;
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
        public PagePets()
        {
            InitializeComponent();
            LoadPets();
        }

        private void LoadPets()
        {
            // Загрузка всех питомцев из базы данных
            PetsListView.ItemsSource = DatabaseConnectionClass.DatabaseConnection.Pets.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddPetButton_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Пока просто заглушка");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Выход.    Будет реализован когда я создам авторизацию. Пока просто как заглушку решил оставить   
        }
    }
}