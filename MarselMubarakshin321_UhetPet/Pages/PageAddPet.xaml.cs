using MarselMubarakshin321_UhetPet.Classes;
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
    /// <summary>
    /// Логика взаимодействия для PageAddPet.xaml
    /// </summary>
    public partial class PageAddPet : Page
    {
        private string selectedPhotoPath;

        public PageAddPet()
        {
            InitializeComponent();
            LoadPhotosFromResources();
        }

        private void LoadPhotosFromResources()
        {
            // Путь к папке Resources в корне проекта.
            var resourcesFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

            // Проверка, существует ли папка Resources.
            if (Directory.Exists(resourcesFolderPath))
            {
                // Получение всех файлов изображений в папке Resources.
                var imageFiles = Directory.GetFiles(resourcesFolderPath, "*.jpg")
                                           .Concat(Directory.GetFiles(resourcesFolderPath, "*.png"));

                // Добавление имен файлов в ComboBox.
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
            if (string.IsNullOrEmpty(NameTextBox.Text) || PhotoComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля и выберите фото.");
                return;
            }

            // Получаем выбранное имя файла из ComboBox
            var fileName = PhotoComboBox.SelectedItem.ToString();
            var imagePathInResources = $"/Resources/{fileName}";

            var newPet = new Pets
            {
                Names = NameTextBox.Text,
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
        private void AddNamePlaceholder(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                NameTextBox.Text = "Введите кличку";
                NameTextBox.Foreground = Brushes.Gray;
            }
        }

        private void RemoveNamePlaceholder(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "Введите кличку")
            {
                NameTextBox.Text = string.Empty;
                NameTextBox.Foreground = Brushes.Black;
            }
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