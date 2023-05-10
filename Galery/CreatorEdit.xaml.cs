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
    /// Логика взаимодействия для CreatorAddEdit.xaml
    /// </summary>
    public partial class CreatorAddEdit : Window
    {
        public CreatorAddEdit()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void EditCreator(object sender, RoutedEventArgs e)
        {

        }
    }
}
