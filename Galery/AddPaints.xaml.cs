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
        GalleryContext galleryContext;
        public string Creator { get; set; }
        public Paint Paint { get; set; } = new Paint();
        public List<Genre> ListGenre { get; set; }
        public List<Time> ListTime { get; set; }
        public AddPaints()
        {
            InitializeComponent();
            galleryContext = new GalleryContext();
            ListGenre = galleryContext.Genres.ToList();
            ListTime = galleryContext.Times.ToList();
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
                    Paint.PhotoPaint = newPath;
                }
                else
                {
                    Paint.PhotoPaint = newPath;
                    File.Copy(openFileDialog.FileName, Paint.PhotoPaint);
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
                galleryContext.Crosscreatorpaints.Add(new Crosscreatorpaint
                {
                    IdCreatorNavigation = creator,
                    IdPaintNavigation = Paint
                });                      
                galleryContext.SaveChanges();
                Paint = new Paint();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paint)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
