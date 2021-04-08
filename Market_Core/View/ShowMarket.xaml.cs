using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для ShowMarketxaml.xaml
    /// </summary>
    public partial class ShowMarket : Window
    {
        public ShowMarket()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();

            this.Close();
            main.Show();
        }

        private void Button_Click_Show_Store(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionWithDb = new SqlConnection("Data Source=106-2;Initial Catalog=db_taa_Market;Integrated Security=True");
            SqlDataAdapter MyDA = new SqlDataAdapter();
            string sqlSelectAll = "SELECT * from Market";
            MyDA.SelectCommand = new SqlCommand(sqlSelectAll, connectionWithDb);

            DataTable table = new DataTable();
            MyDA.Fill(table);
            //ListView listView1 = new ListView();
            //listView1.ItemsSource = table.DefaultView;
            dataGrid1.ItemsSource = table.DefaultView;
            connectionWithDb.Close();
        }
    }
}
