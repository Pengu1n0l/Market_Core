using Microsoft.Data.SqlClient;
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

namespace Market_Core.View
{
    /// <summary>
    /// Логика взаимодействия для AddShops.xaml
    /// </summary>
    public partial class AddShops : Window
    {
        public AddShops()
        {
            InitializeComponent();
       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (AppContext appContext = new AppContext())
            {


                var shop = new Shops
                {
                    id_shop = Convert.ToInt32(IdShop_Text.Text),
                    id_department = Convert.ToInt32(comboIdDepartment.SelectedItem),
                    Amount_product = Convert.ToInt32(AmountProduct_Text.Text),
                    Retail_price = Convert.ToDecimal(RetailPrice_Text.Text)
                };
                var relationships = new Shop_Bases
                {
                    id_shop = Convert.ToInt32(IdShop_Text.Text),
                    id_bases = Convert.ToInt32(Id_Bases_TextBox.Text)
                };
               
                appContext.Shop.Add(shop);
                appContext.Shop_Base.Add(relationships);
                appContext.SaveChanges();
                ShowShopsList();
            }
        }

        public void ShowShopsList()
        {
            using (AppContext appContext = new AppContext())
            {
                var listDepartament = appContext.Shop.ToList();
                DataGridAddShop.ItemsSource = listDepartament;

            }
        }
       
        private void win_Loaded(object sender, RoutedEventArgs e)
        {

            using (AppContext appContext = new AppContext())
            {
                var listDepartament = appContext.Shop.ToList();
                DataGridAddShop.ItemsSource = listDepartament;

                var Readers = appContext.Department.Select(x => x.id_department);
                comboIdDepartment.ItemsSource = Readers.ToList();
            }
        }
    }
}
