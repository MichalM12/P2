using System;
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
using System.Windows.Shapes;

//
using System.Data;
using System.Data.SqlClient;
using WpfApp1.Classes;
using System.Configuration;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Connect_to_database.xaml
    /// </summary>
    public partial class Connect_to_database : Window
    {
        public Connect_to_database()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DbClass.openConnection();

            DbClass.sql = "SELECT [id],[Nickname] FROM Players;";
            DbClass.cmd.CommandType = CommandType.Text;
            DbClass.cmd.CommandText = DbClass.sql;

            DbClass.da = new SqlDataAdapter(DbClass.cmd);
            DbClass.dt = new DataTable();
            DbClass.da.Fill(DbClass.dt);

            Players_datagrid.ItemsSource = DbClass.dt.DefaultView;

            DbClass.closeconnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into [Players](Nickname)values(@nm)";
            cmd.Parameters.AddWithValue("@nm", text.Text);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if (a==1)
            {
                MessageBox.Show("Data Added");
                
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from [Players] where Nickname = @nm";
            cmd.Parameters.AddWithValue("@nm", text1.Text);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if (a == 1)
            {
                MessageBox.Show("Data Deleted");

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update [Players] SET Nickname = @nm where Nickname = @nmm";
            cmd.Parameters.AddWithValue("@nm", text2.Text);
            cmd.Parameters.AddWithValue("@nmm", text3.Text);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if (a == 2)
            {
                MessageBox.Show("Data Updated");

            }
        }
    }
}
