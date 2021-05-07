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
    /// Логика взаимодействия для Otdel.xaml
    /// </summary>
    public partial class Otdel : Window
    {
        public Otdel()
        {
            InitializeComponent();
            ShowDepartmentList();
        }

        private void Button_Click_AddNewOtdel(object sender, RoutedEventArgs e)
        {
            using (AppContext appContext = new AppContext())
            {
                var department = new Departments
                {
                    id_department = Convert.ToInt32(Id_Department.Text),
                    Name_department = Text_otdel.Text,
                    Manager = Manager_otdel.Text
                };
                appContext.Department.Add(department);
                appContext.SaveChanges();
                ShowDepartmentList();
            }
        }
        public void ShowDepartmentList()
        {
            using (AppContext appContext = new AppContext())
            {
                var listDepartament = appContext.Department.ToList();
                dataGrid_Departament.ItemsSource = listDepartament;
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();

            this.Close();
            main.Show();
        }
    }
}
