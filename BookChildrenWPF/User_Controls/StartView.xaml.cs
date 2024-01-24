using BookChildrenWPF.Model;
using GihanSoft.String;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.IO;
using System.Linq;
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
    /// Логика взаимодействия для StartView.xaml
    /// </summary>
    public partial class StartView : UserControl
    {
        
        public StartView()
        {
            InitializeComponent();
            
            DataMetod();
            UserCardListBox1.ItemsSource = exhibitionImageList;
        }
        private void OpenUser(object sender, RoutedEventArgs e)
        {
            //UserChildren UsersContext = new UserChildren();
            //UsersContext.data = Data;
            (Application.Current.MainWindow.FindName("contentControl") as ContentControl).ContentTemplate = (DataTemplate)Application.Current.MainWindow.Resources["userChildren"];
        }

        ObservableCollection<UserCardModel> exhibitionImageList = new ObservableCollection<UserCardModel>();
        public void DataMetod()
        {
           
            List<string> directoryImageName = new List<string>(Directory.EnumerateFileSystemEntries("Exhibitions"));
            for (int i = 0; i < directoryImageName.Count; i++)
            {
                UserCardModel obj= new UserCardModel();
                obj.IdUserCard = i;
                obj.SourseUserCard = Path.GetFullPath(directoryImageName[i] + "/previu/img.jpg");
                obj.DescriptionUserCard = new DirectoryInfo(directoryImageName[i]).Name;
                exhibitionImageList.Add(obj);
            }
        }
        public void AnimationMetod()
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(0.3));
            var animationFrame = new ThicknessAnimation();
            animationFrame.From = new Thickness(-1920, -168, 1920, 0);
            animationFrame.To = new Thickness(0, -168, 0, 0);
            animationFrame.Duration = duration;
            contentExhibition.BeginAnimation(MarginProperty, animationFrame);
        }
        private async void OpenExhibition(object sender, RoutedEventArgs e)
        {
            
            var button = sender as Button;
            switch (button.CommandParameter)
            {
                case 0:
                    contentExhibition.Content = new Exhibition1View();
                    break;
                case 1:
                    contentExhibition.Content = new Exhibition2View();
                    break;
                case 2:
                    contentExhibition.Content = new Exhibition3View();
                    break;
                case 3:
                    contentExhibition.Content = new Exhibition4View();
                    break;

                case 4:
                    contentExhibition.Content = new Exhibition5View();
                    break;
                case 5:
                    contentExhibition.Content = new Exhibition6View();
                    break;
            }
            videoElement.Volume = 0;
            AnimationMetod();

        }

        
    }
}
