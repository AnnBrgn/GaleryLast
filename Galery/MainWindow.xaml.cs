using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Galery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool sortDate;
        public Crosscreatorpaint SelectedPaint { get; set; }
        public List<Crosscreatorpaint> ourPictures { get; set; }
        public List<Crosscreatorpaint> Paints { get; set; }
        public Time SelectedTime
        {
            get => selectedTime;
            set
            {
                selectedTime = value;
                Sort();
            }
        }
        private Time selectedTime;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Time> Time { get; set; }
        public string SearchText { get; set; }

        public bool IsAdmin { get; set; }
        public Visibility Admin { get { return IsAdmin ? Visibility.Visible : Visibility.Hidden; } }
        public MainWindow(bool v = false)
        {
            InitializeComponent();
            IsAdmin = v;
            DataContext = this;
            Time = DB.Instance.Times.ToList();
            Time.RemoveAt(Time.Count - 1);
            Time.Add(new Galery.Time { Time1 = "Все эпохи" });
            SelectedTime = Time.First();
        }
        public void Sort()
        {
            Paints = DB.Instance.Crosscreatorpaints.
                Include(s => s.IdCreatorNavigation).
                Include(s => s.IdPaintNavigation.TimeNavigation).
                Include(s => s.IdPaintNavigation.GenreNavigation).
                Include(s => s.IdPaintNavigation).
                Where(s => selectedTime.Id == 0 || s.IdPaintNavigation.Time == selectedTime.Id).ToList();
            if (sortDate)
            {
                Paints.Sort((x,y)=>y.IdPaintNavigation.Date.Value.CompareTo(x.IdPaintNavigation.Date.Value));
                sortDate = false;
            }
            /*var r = DB.Instance.Paints.ToList();
            Paints = new();
            for (int i = 0; i < r.Count; i++)
            {
                Paints.Add(new PaintOutPut
                {
                    Creator = DB.Instance.Creators.Include(s=>s.GenreNavigation.Paints).Where(a =>
                    a.Id == DB.Instance.Crosscreatorpaints.Where(a =>
                    a.IdPaint == r[i].Id).Select(a=>
                    a.IdCreator).FirstOrDefault()).FirstOrDefault().Name,
                    Time = r[i].TimeNavigation.Time1,
                    DateOfCreate = r[i].DateOfCreate,
                    Genre = r[i].GenreNavigation.Genre1,
                    Location = r[i].Location,
                    Material = r[i].Material,
                    PhotoPaint = r[i].PhotoPaint,
                    Title = r[i].Title,
                    TimeId = r[i].Time
                });
            }
            if (SelectedTime != Time.Count - 1)
            {
                var times = DB.Instance.Times.ToArray();
                int id = times[selectedTime].Id;
                Paints = Paints.Where(a => a.TimeId == id).ToList();
            }*/
            OnPropertyChanged(nameof(Paints));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            new Input().Show();
            base.OnClosing(e);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void OurTime(object sender, RoutedEventArgs e)
        {
            selectedTime = new Time { Id = 5 };
            Sort();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if(IsAdmin)
                new AddPaints().Show();
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (SelectedPaint == null)
                return;
            new AdminEdit(
                SelectedPaint
            ).ShowDialog();
            Sort();
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            DB.Instance.Crosscreatorpaints.Remove(SelectedPaint);
            DB.Instance.Paints.Remove(SelectedPaint.IdPaintNavigation);
            DB.Instance.SaveChanges();
            Sort();
        }

        private void SortDate(object sender, RoutedEventArgs e)
        {
            sortDate = true;
            Sort();
        }

        private void EditCreators(object sender, RoutedEventArgs e)
        {

        }
    }
}