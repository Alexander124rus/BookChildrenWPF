using BookChildrenWPF.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace BookChildrenWPF.User_Controls
{
    /// <summary>
    /// Логика взаимодействия для Exhibition4View.xaml
    /// </summary>
    public partial class Exhibition4View : UserControl
    {

        public List<string> objList = new List<string>(Directory.EnumerateFileSystemEntries("Exhibitions\\4. Музей заповедник Шушенское", "*.jpg"));
        public ObservableCollection<ImageUserCardModel> imageObj = new ObservableCollection<ImageUserCardModel> { };

        //ObservableCollection <ImageUserCardModel> DataList = ((UserCardModel)this.DataContext).ImageUserCardList;
        //public void ExhibitionData()
        //{
        //    var path = "Exhibitions";
        //    List<string> exhibitionsList = new List<string>(Directory.EnumerateDirectories(path));
        //    List<DirectoryInfo> objList = new List<DirectoryInfo> { new DirectoryInfo(path+ "/ЦБС Ачинск") };
        //}

        void DataList()
        {
            for (int i = 0; i < objList.Count; i++)
            {
                ImageUserCardModel obj = new ImageUserCardModel();
                obj.idImageUserCard = i;

                var image = new BitmapImage(new Uri(Path.GetFullPath(objList[i]), UriKind.Absolute));

                //obj.UrlImageUserCard = (ImageSource)new ImageSourceConverter().ConvertFromString(objList[i]);
                obj.UrlImageUserCard = image;
                //obj.UrlImageUserCard = (ImageSource)new ImageSourceConverter().ConvertFromString(Path.GetFullPath(objList[i])); 
                obj.DescriptionImageUserCard = Path.GetFileNameWithoutExtension(objList[i]);
                imageObj.Add(obj);
            }
        }

        public Exhibition4View()
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
