using Microsoft.VisualBasic;
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
using System.Windows.Navigation;
using System.IO;
using System.Windows.Media.Animation;
using BookChildrenWPF.Model;
using System.Security.Policy;
using BookChildrenWPF.User_Controls;
using BookChildrenWPF.ViewModel;
using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using System.Diagnostics;

namespace BookChildrenWPF.User_Controls
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        List<UserModel> Data = new List<UserModel>
        {
            new UserModel { IdUser=0, NameUser="Е.А. Зыков"},
            new UserModel { IdUser=1, NameUser="Захаров"}
        };
        int idUser = 0;

        public User()
        {
            InitializeComponent();
            
            //DataContext = Data[idUser];
            //AudioPlayer.SourceUrl = Path.GetFullPath("Zikov/Е.А.Зыков.mp3");
            //AudioPlayer.AudioText = Data[idUser].NameUser;

            
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Zikov/zikov.xaml") };
            //userResurses.Source = new Uri("pack://application:,,,/Assets/zikov.xaml", UriKind.Relative);
            //UrlUserResurses = "pack://application:,,,/Assets/zikov.xaml";
        }

        //private int IdUser {
        //    get { return (int)GetValue(IdUserProperty); } 
        //    set { SetValue(IdUserProperty, value); }
        //}
        //public static readonly DependencyProperty IdUserProperty =
        //    DependencyProperty.Register("IdUser", typeof(int), typeof(User), new PropertyMetadata(false));

        public string NameUser {
            get { return (string)GetValue(NameUserProperty); }
            set { SetValue(NameUserProperty, value); }
        }
        public static readonly DependencyProperty NameUserProperty =
            DependencyProperty.Register("NameUser", typeof(string), typeof(User));

        public DependencyObject UrlUserResurses {
            get { return (DependencyObject)GetValue(UrlUserResursesProperty); }
            set { SetValue(UrlUserResursesProperty, value); }
        }
        public static readonly DependencyProperty UrlUserResursesProperty =
            DependencyProperty.Register("UrlUserResurses", typeof(DependencyObject), typeof(User));

        public CategoryModel CategoryUser { get; set; }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            ResIsLoaded = true;
        }

        //private void CloseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

        
        public bool ResIsLoaded
        {
            get { return (bool)GetValue(ResIsLoadedProperty); }
            set { SetValue(ResIsLoadedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResIsLoaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResIsLoadedProperty =
            DependencyProperty.Register("ResIsLoaded", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));



        public bool IsMenuExpanded
        {
            get { return (bool)GetValue(IsMenuExpandedProperty); }
            set { SetValue(IsMenuExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMenuExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMenuExpandedProperty =
            DependencyProperty.Register("IsMenuExpanded", typeof(bool), typeof(MainWindow), new PropertyMetadata(true));

        private void navLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            navLeftBtn.IsEnabled = false;
            navRightBtn.Visibility = Visibility.Visible;

            double offset = (double)scrollViewer.GetValue(CustomScrollViewer.MyOffsetProperty);
            DoubleAnimation goLeft = new DoubleAnimation(
                offset,
                offset - 246 - 20,
                new Duration(TimeSpan.FromSeconds(.5)))
            { AccelerationRatio = .2, DecelerationRatio = .8 };

            goLeft.Completed += GoLeft_Completed; ;
            scrollViewer.BeginAnimation(CustomScrollViewer.MyOffsetProperty, goLeft);
        }

        private void GoLeft_Completed(object sender, EventArgs e)
        {
            navLeftBtn.IsEnabled = true;
            if (Convert.ToInt32(scrollViewer.HorizontalOffset) == 0)
                navLeftBtn.Visibility = Visibility.Collapsed;
        }

        private void navRightBtn_Click(object sender, RoutedEventArgs e)
        {
            navRightBtn.IsEnabled = false;
            IsMenuExpanded = false;
            navLeftBtn.Visibility = Visibility.Visible;

            double offset = (double)scrollViewer.GetValue(CustomScrollViewer.MyOffsetProperty);
            DoubleAnimation goRight = new DoubleAnimation(
                offset,
                offset + 246 + 20,
                new Duration(TimeSpan.FromSeconds(.5)))
            { AccelerationRatio = .2, DecelerationRatio = .8 };

            goRight.Completed += GoRight_Completed;
            scrollViewer.BeginAnimation(CustomScrollViewer.MyOffsetProperty, goRight);
        }

        private void GoRight_Completed(object sender, EventArgs e)
        {
            navRightBtn.IsEnabled = true;
            if (Convert.ToInt32(scrollViewer.HorizontalOffset) == Convert.ToInt32(scrollViewer.ScrollableWidth))
                navRightBtn.Visibility = Visibility.Collapsed;
        }

        //private void nextButton (object sender, RoutedEventArgs e)
        //{
        //    var Id = (int)((Button)sender).CommandParameter;
        //    Id++;
        //    idUser = Id;
        //    this.DataContext = Data[idUser];

        //}
        //private void prevButton(object sender, RoutedEventArgs e)
        //{
        //    var Id = (int)((Button)sender).CommandParameter;
        //    Id--;
        //    idUser = Id;
        //    this.DataContext = Data[idUser];

        //}

    }
}
