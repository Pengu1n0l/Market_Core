﻿using System;
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

namespace Market_Core.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Store_Click(object sender, RoutedEventArgs e)
        {
            ShowMarket form = new ShowMarket();
            this.Close();
            form.Show();
        }

        private void MenuItem_Otdel_Click(object sender, RoutedEventArgs e)
        {
            Otdel otdel = new Otdel();
            this.Close();
            otdel.Show();

        }

        private void MenuItem_Product_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            this.Close();
            product.Show();
        }

        private void MenuItem_AddShop_Click(object sender, RoutedEventArgs e)
        {
      
           AddShops add = new AddShops();
            this.Close();
            add.Show();
        }


        private void MenuItem_AddBases_Click(object sender, RoutedEventArgs e)
        {
            AddBase add = new AddBase();
            this.Close();
            add.Show();
        }

        private void MenuItem_Supply_Click(object sender, RoutedEventArgs e)
        {
            AddSupply add = new AddSupply();
            this.Close();
            add.Show();
        }

        private void MenuItem_Query1_Click(object sender, RoutedEventArgs e)
        {
            QueryProductMarket query = new QueryProductMarket();
            Close();
            query.Show();
        }

        private void MenuItem_Querry_Click(object sender, RoutedEventArgs e)
        {
            QueryShowShopAndBase query= new QueryShowShopAndBase();
            Close();
            query.Show();
        }

        private void MenuItem_Querry3_Click(object sender, RoutedEventArgs e)
        {
            QueryPriceProduct query = new QueryPriceProduct();
            Close();
            query.Show();
        }
    }
}
