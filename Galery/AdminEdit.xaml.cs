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
    /// Логика взаимодействия для AdminEdit.xaml
    /// </summary>
    public partial class AdminEdit : Window, INotifyPropertyChanged
    {

        public List<Genre> Genres { get; set; }
        public List<Time> Times { get; set; }
        public List<Creator> Creators { get; set; } = new List<Creator>();
        
        public Crosscreatorpaint Paint { get; set; }

        public AdminEdit(Crosscreatorpaint paint)
        {
            InitializeComponent();
            GalleryContext galleryContext = new GalleryContext();
            Genres = galleryContext.Genres.ToList();
            Times = galleryContext.Times.ToList();
            Creators = galleryContext.Creators.ToList();
            Paint = paint;
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Apply(object sender, RoutedEventArgs e)
        {
            GalleryContext galleryContext = new GalleryContext();
            galleryContext.Paints.Update(Paint.IdPaintNavigation);
            galleryContext.Creators.Update(Paint.IdCreatorNavigation);
            galleryContext.SaveChanges();
            //что-то
        }

        private void AddPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.JPG;*.PNG)|*.JPG;*.PNG";
            if (openFileDialog.ShowDialog() == true)
            {
                
                string[] pathSplit = openFileDialog.FileName.Split("\\");
                string newPath = @$"C:\Users\Student\Desktop\GaleryGallery-master\Galery\images\{pathSplit[pathSplit.Length - 1]}";
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
            }
            //что-то
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paint)));
        }
    }
}
