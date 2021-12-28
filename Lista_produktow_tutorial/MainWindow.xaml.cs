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
        public MainWindow()
        {
            InitializeComponent();
            ListOfProduct = new ObservableCollection<Product>();
            ListOfProduct.Add(new Product(1, "Kawa", (decimal)34.23, new DateTime(2022, 12, 4)));
            ListOfProduct.Add(new Product(2, "mleko", (decimal)10.23, new DateTime(2022, 1, 4)));
            ListOfProduct.Add(new Product(3, "herbata", (decimal)2, new DateTime(2022, 10, 22)));
            DataContext = this;
        }
    }
}
