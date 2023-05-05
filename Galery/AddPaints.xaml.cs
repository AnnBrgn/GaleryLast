using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для AddPaints.xaml
    /// </summary>
    public partial class AddPaints : Window, INotifyPropertyChanged
    {
        public List<Creator> Creators { get; set; } = new List<Creator>();
        public string Creator { get; set; }
        public Crosscreatorpaint Paint { get; set; } = new Crosscreatorpaint();
        public List<Genre> ListGenre { get; set; }
        public List<Time> ListTime { get; set; }
        public AddPaints()
        {
            InitializeComponent();
            ListGenre = DB.Instance.Genres.ToList();
            ListTime = DB.Instance.Times.ToList();
            Creators = DB.Instance.Creators.ToList();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void AddPaintPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.JPG;*.PNG)|*.JPG;*.PNG";
            if (openFileDialog.ShowDialog() == true)
            {

                string[] pathSplit = openFileDialog.FileName.Split("\\");
                string newPath = Environment.CurrentDirectory + @$"\..\..\..\images\{pathSplit[pathSplit.Length - 1]}";
                if (File.Exists(newPath))
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Файл с таким именем уже существует. Хотите использовать существующее изображение?", "Предупреждение", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.No)
                    {
                        return;
                    }
                    Paint.IdPaintNavigation.PhotoPaint = newPath;
                }
                else
                {
                    Paint.IdPaintNavigation.PhotoPaint = newPath;
                    File.Copy(openFileDialog.FileName, Paint.IdPaintNavigation.PhotoPaint);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paint)));
            }
        }

        private void AddPaint(object sender, RoutedEventArgs e)
        {
            try
            {
                Creator creator = new Creator
                {
                    Name = Creator,
                };
                DB.Instance.Crosscreatorpaints.Add(Paint);                      
                DB.Instance.SaveChanges();
                Paint = new Crosscreatorpaint();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paint)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
