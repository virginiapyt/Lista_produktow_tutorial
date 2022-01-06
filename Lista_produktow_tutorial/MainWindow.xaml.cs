using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lista_produktow_tutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> ListOfProduct { get; set; }
        public Product SelectedProduct { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ListOfProduct = new ObservableCollection<Product>();
            ListOfProduct.Add(new Product(1, "Kawa", (decimal)34.23, new DateTime(2022, 12, 4)));
            ListOfProduct.Add(new Product(2, "mleko", (decimal)10.23, new DateTime(2022, 1, 4)));
            ListOfProduct.Add(new Product(3, "herbata", (decimal)2, new DateTime(2022, 10, 22)));
            DataContext = this;

            CollectionView widok =
                (CollectionView)CollectionViewSource.GetDefaultView(ListOfProduct);
            widok.Filter = myFilter;
        }

        private bool myFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtSzukaj.Text))
            {
                return true;
            }
            else
                return ((obj as Product).Name.IndexOf(txtSzukaj.Text,
                    StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtSzukaj_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListOfProduct).Refresh();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            Product product  = new Product(0,"", 0, new DateTime(2022, 1, 1));
            Window window = new ProductWindow(product);
            var result = window.ShowDialog();
            if (result == true)
            {
                ListOfProduct.Add(product);
            }

        }

        private void edytuj_Click(object sender, RoutedEventArgs e)
        {
           
            if (SelectedProduct == null) 
                return;
            var product = (Product)SelectedProduct.Clone();
            Window window = new ProductWindow(product);           
            var result = window.ShowDialog();
            if (result == true)
            {
                ListOfProduct.Remove(SelectedProduct);
                ListOfProduct.Add(product);
            }
           
        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct == null) return;
            var result = MessageBox.Show("Czy chcesz skasować",
                "Potwierdzenie",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                ListOfProduct.Remove(SelectedProduct);
        }
    }
}
