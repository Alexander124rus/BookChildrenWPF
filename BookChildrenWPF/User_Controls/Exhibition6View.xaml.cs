using BookChildrenWPF.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;


namespace BookChildrenWPF.User_Controls
{
    /// <summary>
    /// Логика взаимодействия для Exhibition6View.xaml
    /// </summary>
    public partial class Exhibition6View : UserControl
    {
        public List<string> objList = new List<string>(Directory.EnumerateFileSystemEntries("Exhibitions\\6. Красноярск библиотека музеев России", "*.jpg"));
        public ObservableCollection<ImageUserCardModel> imageObj = new ObservableCollection<ImageUserCardModel> { };

        void DataList()
        {
            for (int i = 0; i < objList.Count; i++)
            {
                ImageUserCardModel obj = new ImageUserCardModel();
                obj.idImageUserCard = i;
                var image = new BitmapImage(new Uri(Path.GetFullPath(objList[i]), UriKind.Absolute));
                obj.UrlImageUserCard = image;
                obj.DescriptionImageUserCard = Path.GetFileNameWithoutExtension(objList[i]);
                imageObj.Add(obj);
            }
        }
        public Exhibition6View()
        {
            InitializeComponent();
            DataList();
            UmageExhibition.ItemsSource = imageObj;
        }
        private void Clouse(object sender, RoutedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(0.3));
            var animationFrame = new ThicknessAnimation();
            animationFrame.From = new Thickness(0, -168, 0, 0);
            animationFrame.To = new Thickness(-1920, -168, 1920, 0);
            animationFrame.Duration = duration;

            this.BeginAnimation(MarginProperty, animationFrame);
            //this.Content = null;
        }
        private async void OpenDialog(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SampleDialog sempleDialog = new SampleDialog();
            sempleDialog.DataSampleList = imageObj;
            sempleDialog.idSampleDialog = (int)button.CommandParameter;
            sempleDialog.DataContext = imageObj[(int)button.CommandParameter];
            var result = await DialogHost.Show(sempleDialog, "RootDialog", null, null, null);
        }
    }
}
