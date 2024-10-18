using MarselMubarakshin321_UhetPet.Classes;
using MarselMubarakshin321_UhetPet.DataBaseUhet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class PageAddPet : Page
    {
        public PageAddPet()
        {
            InitializeComponent();
            LoadPhotosFromResources();
        }

        private void LoadPhotosFromResources()
        {
            var resourcesFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\mubar\\Source\\Repos\\MarselMubarakshin321_UhetPetdgf\\MarselMubarakshin321_UhetPet\\Resources\\");
            if (Directory.Exists(resourcesFolderPath))
            {
                var imageFiles = Directory.GetFiles(resourcesFolderPath, "*.jpg")
                                           .Concat(Directory.GetFiles(resourcesFolderPath, "*.png"));

                foreach (var imagePath in imageFiles)
                {
                    var fileName = System.IO.Path.GetFileName(imagePath);
                    PhotoComboBox.Items.Add(fileName);
                }
            }
            else
            {
                MessageBox.Show("Папка Resources не найдена. Убедитесь, что папка существует в корне проекта.");
            }
        }

        private void SavePetButton_Click(object sender, RoutedEventArgs e)
        {
            if (PetComboBox.SelectedItem == null || PhotoComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите питомца и фото.");
                return;
            }

            // Получаем выбранное имя питомца из ComboBox
            var selectedPet = (PetComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            var fileName = PhotoComboBox.SelectedItem.ToString();
            var imagePathInResources = $"/Resources/{fileName}";

            var newPet = new Pets
            {
                Names = selectedPet,
                Opisanie = DescriptionTextBox.Text,
                ImagePath = imagePathInResources
            };

            DatabaseConnectionClass.DatabaseConnection.Pets.Add(newPet);
            DatabaseConnectionClass.DatabaseConnection.SaveChanges();

            MessageBox.Show("Питомец добавлен!");
            NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void AddDescriptionPlaceholder(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                DescriptionTextBox.Text = "Введите описание";
                DescriptionTextBox.Foreground = Brushes.Gray;
            }
        }

        private void RemoveDescriptionPlaceholder(object sender, RoutedEventArgs e)
        {
            if (DescriptionTextBox.Text == "Введите описание")
            {
                DescriptionTextBox.Text = string.Empty;
                DescriptionTextBox.Foreground = Brushes.Black;
            }
        }
    }
}