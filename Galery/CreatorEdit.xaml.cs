using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class CreatorAddEdit : Window, INotifyPropertyChanged
    {
        private Creator creator;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Genre> ListGenre { get; set; }
        public Creator Creator
        {
            get => creator;
            set 
            {
                creator = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Creator"));
            } 
        }
        public List<Creator> Creators { get; set; } = new List<Creator>();
        public CreatorAddEdit()
        {
            InitializeComponent();
            Creators = DB.Instance.Creators.Include(s => s.GenreNavigation).ToList();
            ListGenre = DB.Instance.Genres.ToList();
            DataContext = this;
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            DB.Instance.SaveChanges();
            Close();
        }
    }
}
