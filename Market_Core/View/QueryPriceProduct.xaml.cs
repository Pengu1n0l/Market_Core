using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для QueryPriceProduct.xaml
    /// </summary>
    public partial class QueryPriceProduct : Window
    {
        public QueryPriceProduct()
        {
            InitializeComponent();
            ShowProduct();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool Success = false;

            string FullName = ComboboxProduct.Text;

            string connectionString = @"Server=DESKTOP-8MNL6GQ\SQLEXPRESS;Database=db_Market; Trusted_Connection=True;";

            //string sqlExpression = "select Full_Name,Name_Book,Date_Of_Issue from  Book JOIN Extradition ex ON ex.Id_Book = Book.Id_Book JOIN Reader r ON ex.Id_Library_card = r.Id_Library_Card WHERE r.Full_Name = @FullName ";
            string sqlExpression = "SELECT dbo.Product.Name_product, dbo.Shop.Retail_price, dbo.Base.Amount_product, dbo.Supply.id_bases, dbo.Supply.id_shop FROM dbo.Shop INNER JOIN dbo.Department ON dbo.Shop.id_department = dbo.Department.id_department INNER JOIN dbo.Supply ON dbo.Shop.id_shop = dbo.Supply.id_shop AND dbo.Shop.id_department = dbo.Supply.id_department AND dbo.Shop.id_product = dbo.Supply.id_product INNER JOIN dbo.Base INNER JOIN dbo.Product ON dbo.Base.id_product =  dbo.Product.id_product ON dbo.Supply.id_bases = dbo.Base.id_bases WHERE  dbo.Product.Name_product=@FullName";
            using (SqlConnection openConnection = new SqlConnection(connectionString))
            {
                openConnection.Open();

                using (SqlCommand cmdSel = new SqlCommand(sqlExpression, openConnection))
                {
                    cmdSel.Parameters.AddWithValue("@FullName", FullName);
                    using (var dataReader = cmdSel.ExecuteReader())
                    {
                        Success = dataReader.Read();

                    }

                    if (Success)
                    {
                        DataTable dt = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmdSel);

                        dt.Clear();

                        da.Fill(dt);

                        QueryDataGrid.DataContext = dt;
                    }
                    else
                    {
                        MessageBox.Show("Данных на товар не сушествует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                }

                openConnection.Close();
            }
        }

        private void ShowProduct()
        {
            using (AppContext context = new AppContext())
            {
                ComboboxProduct.ItemsSource = context.Product.Select(x => x.Name_product).ToList();
            }
        }
    }
}
