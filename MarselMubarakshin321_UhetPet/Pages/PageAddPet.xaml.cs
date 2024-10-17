using MarselMubarakshin321_UhetPet.Classes;
using Microsoft.Win32;
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
    /// Логика взаимодействия для PageAddPet.xaml
    /// </summary>
    public partial class PageAddPet : Page
    {
        private string photoPath;
        public PageAddPet()
        {
            InitializeComponent();
        }
        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
    
        }
        private void SavePetButton_Click(object sender, RoutedEventArgs e)
        {

    }
        private void AddNamePlaceholder(object sender, RoutedEventArgs e)
        {
           
        }

        private void RemoveNamePlaceholder(object sender, RoutedEventArgs e)
        {
         
        }

        private void AddDescriptionPlaceholder(object sender, RoutedEventArgs e)
        {
          
        }

        private void RemoveDescriptionPlaceholder(object sender, RoutedEventArgs e)
        {
          
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на предыдущую страницу
            NavigationService?.GoBack();
        }
    }
}
