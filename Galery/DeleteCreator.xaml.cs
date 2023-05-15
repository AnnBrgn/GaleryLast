using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для DeleteCreator.xaml
    /// </summary>
    public partial class DeleteCreator : Window
    {
        public List<Creator> Creators { get; set; } = new List<Creator>();
        public Creator Creator { get; set; }
        public DeleteCreator()
        {
            InitializeComponent();
            DataContext = this;
            Creators = DB.Instance.Creators.Include(s=>s.GenreNavigation).ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (Creator == null)
            {
                MessageBox.Show("Вы не выбрали художника.");
                return;
            }
            else if (Creator.Crosscreatorpaints.Count > 0)
            {
                MessageBox.Show("Художник уже используется.");
                return;
            }
            var result = DB.Instance.Creators.Remove(Creator);
            if(result.State == EntityState.Deleted)
            {
                MessageBox.Show("Успешно");
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
            }
            DB.Instance.SaveChanges();
        }
    }
}
