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
    /// Логика взаимодействия для QueryShowShopAndBase.xaml
    /// </summary>
    public partial class QueryShowShopAndBase : Window
    {
        public QueryShowShopAndBase()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionWithDb = new SqlConnection(@"Server=DESKTOP-8MNL6GQ\SQLEXPRESS;Database=db_Market; Trusted_Connection=True;");
            SqlDataAdapter MyDA = new SqlDataAdapter();
            string sqlSelectAll = $"SELECT dbo.Supply.Number_supply, dbo.Supply.date_supply, dbo.Shop.id_shop, dbo.Base.id_bases, dbo.Department.Name_department, dbo.Base.Wholesale_price, dbo.Shop.Retail_price, dbo.Product.Name_product FROM dbo.Shop INNER JOIN dbo.Department ON dbo.Shop.id_department = dbo.Department.id_department INNER JOIN dbo.Supply ON dbo.Shop.id_shop = dbo.Supply.id_shop AND dbo.Shop.id_department = dbo.Supply.id_department AND dbo.Shop.id_product = dbo.Supply.id_product INNER JOIN dbo.Base INNER JOIN dbo.Product ON dbo.Base.id_product = dbo.Product.id_product ON dbo.Supply.id_bases = dbo.Base.id_bases";
            MyDA.SelectCommand = new SqlCommand(sqlSelectAll, connectionWithDb);
            DataTable table = new DataTable();
            MyDA.Fill(table);
            lox.ItemsSource = table.DefaultView;
        }
    }
}
