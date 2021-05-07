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
using Market_Core.property_classes;
using Microsoft.Data.SqlClient;

namespace Market_Core.View
{
    /// <summary>
    /// Логика взаимодействия для AddSupply.xaml
    /// </summary>
    public partial class AddSupply : Window
    {
        public AddSupply()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var date = (DateTime)DateTimeSupplys.SelectedDate;

            using (AppContext context = new AppContext())
            {
                context.Supply.Add(new Supplys
                {
                    
                    id_bases= Convert.ToInt32(comboboxBase.SelectedItem),
                    id_shop= Convert.ToInt32(comboboxShop.SelectedItem),
                    
                    id_department = Convert.ToInt32(Department_Textbox.Text),
                    id_product= Convert.ToInt32(Name_productTextbox.Text),
                    date_supply = date
                });
                context.SaveChanges();
                ShowDate();
            }
        }

        private void ShowDate()
        {
            using (AppContext context = new AppContext())
            {


                comboboxBase.ItemsSource = context.Base.Select(x => x.id_bases).ToList();
                comboboxShop.ItemsSource = context.Shop.Select(x => x.id_shop).ToList();
                //var listSupplys = context.Supply.ToList();
                //datagridSupply.ItemsSource = listSupplys;

                var listBase = context.Supply.ToList();
                datagridSupply.ItemsSource = listBase;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (AppContext context = new AppContext())
            {
                //var date = (DateTime)DateTimeSupplys.SelectedDate;
                //SqlConnection connectionWithDb = new SqlConnection(@"Server=DESKTOP-8MNL6GQ\SQLEXPRESS;Database=db_Market; Trusted_Connection=True;");
                //SqlDataAdapter MyDA = new SqlDataAdapter();
                //string sqlSelectAll = $"SELECT id_department FROM Supply WHERE id_shop=={comboboxShop.SelectedItem}";
                //MyDA.SelectCommand = new SqlCommand(sqlSelectAll, connectionWithDb);
                //DataTable table = new DataTable();
                //MyDA.Fill(table);

                comboboxBase.ItemsSource = context.Base.Select(x => x.id_bases).ToList();
                comboboxShop.ItemsSource = context.Shop.Select(x => x.id_shop).ToList();
                //var listSupplys = context.Supply.ToList();
                //datagridSupply.ItemsSource = listSupplys;

                var listBase = context.Supply.ToList();
                datagridSupply.ItemsSource = listBase;
            }
        }
        private void ComboboxShopDep()
        {
            //string conect = @"Server=DESKTOP-8MNL6GQ\SQLEXPRESS;Database=db_Market; Trusted_Connection=True;";
            //using (SqlConnection connection = new SqlConnection(conect))
            //{
            //    SqlCommand command = new SqlCommand("SELECT id_department FROM Supply ", connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            ComboboxDepartment.Items.Add(reader.GetString(int id_department)); // index of column you want, because this method takes only int
            //        }

            //    }
            //}
            List<int> numbers = new List<int>() { 1, 2, 3, 45 };

            SqlConnection connectionWithDb = new SqlConnection(@"Server=DESKTOP-8MNL6GQ\SQLEXPRESS;Database=db_Market; Trusted_Connection=True;");
            SqlDataAdapter MyDA = new SqlDataAdapter();
            string sqlSelectAll = $"SELECT id_department FROM Department";
            MyDA.SelectCommand = new SqlCommand(sqlSelectAll, connectionWithDb);
            DataTable table = new DataTable();
            MyDA.Fill(table);
            this.ComboboxDepartment.Items.Add(table.DefaultView.ToString());
        }

        //private void comboboxShop_Selected(object sender, RoutedEventArgs e)
        //{
        //    using (AppContext context = new AppContext())
        //    {
        //        foreach (var item in context.Base.Select(x => x.id_bases))
        //        {
        //            if (Convert.ToInt32(sender) == item)
        //            {
                        
        //            }
        //        }
                
        //    }
             
        //}
    }
}
