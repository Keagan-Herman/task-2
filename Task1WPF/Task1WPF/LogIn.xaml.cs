using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Task1WPF
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.conn))
                {
                    connection.Open();
                    String sql = "SELECT * FROM LOG_IN where USERNAME = '" + txtUsername.Text + "' " +
                        "AND PASSWORD ='" + txtPassword.Text + "' ;";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Log in successful");
                        MainWindow m = new MainWindow(txtUsername.Text);
                        txtPassword.Text = "";
                        txtUsername.Text = "";
                        this.Hide();
                        m.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Log in unsuccessful");
                    }
                    reader.Close();
                    command.Dispose();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }

        
    }
}

