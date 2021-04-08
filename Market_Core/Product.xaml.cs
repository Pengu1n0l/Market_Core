using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Market_Core
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        public Product()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (AppContext appContext = new AppContext())
            {
                var prod = new Products
                {
                    id_product = Convert.ToInt32(ID_Product.Text),
                    Name_product = Name_product1.Text,
                    Sort= Sort1.Text
                };
                appContext.Product.Add(prod);
                appContext.SaveChanges();
                ShowDataProduct();
            }
        }
        public void ShowDataProduct()
        {
            using (AppContext appContext = new AppContext())
            {
                var table = appContext.Product.ToList();
                Data_product.ItemsSource = table;
               
            }
        }
    }
}
