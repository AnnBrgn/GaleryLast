﻿using System;
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
    /// Логика взаимодействия для AddCreator.xaml
    /// </summary>
    public partial class AddCreator : Window
    {
        public Creator Creators { get; set; } = new Creator();
        public List<Genre> ListGenre { get; set; }
        public AddCreator()
        {
            InitializeComponent();
            ListGenre = DB.Instance.Genres.ToList();
            DataContext = this;
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            DB.Instance.Add(Creators);
            DB.Instance.SaveChanges();
            Close();
        }
    }
}
