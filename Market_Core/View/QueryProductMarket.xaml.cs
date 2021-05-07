using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
    /// Логика взаимодействия для Query.xaml
    /// </summary>
    public partial class QueryProductMarket : Window
    {
        public QueryProductMarket()
        {
            InitializeComponent(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (AppContext context = new AppContext())
            {
                dataGride_Show.ItemsSource= context.Shop.Where(x => x.Retail_price > 200).ToList();
            }
        }
    }
}
