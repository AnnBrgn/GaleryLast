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

namespace Galery
{
    /// <summary>
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class Input : Window
    {
        public string Login { get; set; }
        public Input()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void buttonAuth(object sender, RoutedEventArgs e)
        {
            var user = DB.Instance.Admins.FirstOrDefault(a => a.Password == password.Password && a.Login == Login);
            if (user != null)
            {
                MessageBox.Show("Здравствуйте! "+user.Name);
                MainWindow mv = new MainWindow(true);
                mv.Show();
                Close();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }

        private void buttonSignIn(object sender, RoutedEventArgs e)
        {
            MainWindow mv = new MainWindow(false);
            mv.Show();
            Close();
        }
    }
}
