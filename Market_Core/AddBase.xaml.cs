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
    /// Логика взаимодействия для AddBase.xaml
    /// </summary>
    public partial class AddBase : Window
    {
        public AddBase()
        {
            InitializeComponent();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var contex = new AppContext())
            {
                
                contex.Base.Add(new Bases
                {
                    id_bases=Convert.ToInt32(id_bases_textbox.Text),
                    id_product= Convert.ToInt32(id_products_combobox.SelectedItem),
                    Wholesale_price = Convert.ToDecimal(wholisale_textbox.Text) ,
                    Amount_product= Convert.ToInt32(amount_textbox.Text)
                });
                contex.SaveChanges();
            }
            ShowBase();
        }
        public void ShowBase()
        {
            using (var contex = new AppContext())
            {
                var listBase = contex.Base.ToList();
                datagridShowBases.ItemsSource = listBase;
            }
        }

        private void win_Loaded(object sender, RoutedEventArgs e)
        {
            using (var contex = new AppContext())
            {
                var listProduct = contex.Product.Select(x => x.id_product);
                id_products_combobox.ItemsSource = listProduct.ToList();

                var listBase = contex.Base.ToList();
                datagridShowBases.ItemsSource = listBase;
            }
        }
    }
}
