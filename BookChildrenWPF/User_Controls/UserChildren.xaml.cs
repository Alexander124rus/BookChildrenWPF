using BookChildrenWPF.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

using System.Collections.ObjectModel;

using System.IO;
using GihanSoft.String;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookChildrenWPF.User_Controls
{
    /// <summary>
    /// Логика взаимодействия для UserChildren.xaml
    /// </summary>
    /// 
    
    public partial class UserChildren : UserControl
    {
        //public List<UserModel> data;
        //public int iduser;
        //public List<UserModel> Data
        //{
        //    get { return data; }
        //    set
        //    {
        //        data = value;
        //        OnPropertyChanged("Data");
        //    }
        //}
        //public int idUser
        //{
        //    get { return iduser; }
        //    set
        //    {
        //        iduser = value;
        //        OnPropertyChanged("idUser");
        //    }
        //}
        int idUser = 0;
        List<UserModel> Data = new List<UserModel>();

        public void UserData()
        {
            var path = "Heroes";
            List<string> DirectoryList = new List<string>(Directory.EnumerateDirectories("Heroes"));

            for (int i = 0; i < DirectoryList.Count; i++)
            {
                UserModel obj = new UserModel();
                obj.IdUser = i;

                obj.NameUser = new DirectoryInfo(DirectoryList[i]).Name;

                List<string> FilesXAML = new List<string>(Directory.EnumerateFiles(DirectoryList[i], "*.xaml"));
                obj.GlossaryUser = FilesXAML[0];

                List<string> FilesMP3 = new List<string>(Directory.EnumerateFiles(DirectoryList[i], "*.mp3"));
                obj.AudioPathUser = FilesMP3[0];
                obj.AudioNameUser = Path.GetFileNameWithoutExtension(FilesMP3[0]);

                List<string> FilesTXT = new List<string>(Directory.EnumerateFiles(DirectoryList[i], "*.txt"));
                obj.DescriptionUser = File.ReadAllText(FilesTXT[0]);
                obj.QuotationUser = File.ReadAllText(FilesTXT[1]);

                obj.UserCardList = new ObservableCollection<UserCardModel> { };

                //--Прочитать директорию UserScroll, получить полные имена файлов директории и отсортировать их Натуральной сортировкой
                var pathUserScroll = DirectoryList[i] + "/UserScroll";
                List<string> UserScrollImage = new List<string>(Directory.EnumerateFiles(pathUserScroll));
                UserScrollImage.Sort(new NaturalComparer(StringComparison.Ordinal));
                //--Конец

                ObservableCollection<UserCardModel> UserCardList = new ObservableCollection<UserCardModel>();
                for (int j = 0; j < UserScrollImage.Count(); j++)
                {
                    UserCardModel obj2 = new UserCardModel();
                    obj2.IdUserCard = j;
                    obj2.SourseUserCard = System.IO.Path.GetFullPath(UserScrollImage[j]);
                    obj2.TextUserCard = System.IO.Path.GetFileNameWithoutExtension(UserScrollImage[j]);


                    obj2.ImageUserCardList = new ObservableCollection<ImageUserCardModel> { };

                    var path3 = DirectoryList[i] + "/UserCatScroll/" + obj2.TextUserCard;

                    List<string> FilesTXT2 = new List<string>(Directory.EnumerateFiles(path3, "*.txt"));
                    obj2.DescriptionUserCard = File.ReadAllText(FilesTXT2[0]);

                    List<string> UserCatScrollList = new List<string>(Directory.EnumerateFiles(path3, "*.jpg"));
                    for (int t = 0; t < UserCatScrollList.Count; t++)
                    {
                        ImageUserCardModel obj3 = new ImageUserCardModel();
                        obj3.IdImageUserCard = t;
                        obj3.UrlImageUserCard = (ImageSource)new ImageSourceConverter().ConvertFromString(UserCatScrollList[t]);

                        obj2.ImageUserCardList.Add(obj3);
                    }
                    obj.UserCardList.Add((UserCardModel)obj2);

                }
                Data.Add(obj);
            }
        }

        public UserChildren()
        {
            InitializeComponent();
            UserData();
            DataContext = Data[idUser];
            UserModel glossary = Data.Find(x => x.IdUser == idUser);
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/" + glossary.GlossaryUser) };

            DemoItemsListBox.ItemsSource = Data;
            UserCardListBox.ItemsSource = Data[idUser].UserCardList;
        }

        private async void OpenInformation(object sender, RoutedEventArgs e)
        {
            InformationDialog InformationDialogOpenInformation = new InformationDialog();
            var result = await DialogHost.Show(InformationDialogOpenInformation, "RootDialog", null, null, null);
        }

        private void Open_razdel(object sender, RoutedEventArgs e)
        {
            var IdUser = (int)((Button)sender).CommandParameter;
            UserCardView obj = new UserCardView();
            obj.DataContext = Data[idUser].UserCardList[IdUser];
            AudioPlayer.audioElement.Stop();
            UserModel glossary = Data.Find(x => x.IdUser == idUser);
            obj.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/" + glossary.GlossaryUser) };
            MyFrame.Content = obj;

        }

        private void Home(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow.FindName("contentControl") as ContentControl).ContentTemplate = (DataTemplate)Application.Current.MainWindow.Resources["startView"];
            //MainWindow temp = new MainWindow();
            //temp.contentControl.Content = new MainWindow();
            //temp.contentControl.ContentTemplate = (DataTemplate)temp.Resources["startView"];
        }
        private void MovePrev(object sender, RoutedEventArgs e)
        {
            AudioPlayer.audioElement.Stop();
            if (idUser == 0)
            {
                idUser = Data.Count;
            }
            idUser--;

            DataContext = Data[idUser];
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/" + Data[idUser].GlossaryUser) };
            UserCardListBox.ItemsSource = Data[idUser].UserCardList;

            MyFrame.Content = null;
        }
        private void MoveNext(object sender, RoutedEventArgs e)
        {
            AudioPlayer.audioElement.Stop();
            if (idUser == Data.Count - 1)
            {
                idUser = 0;
            }
            else
            {
                idUser++;
            }
            DataContext = Data[idUser];
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/" + Data[idUser].GlossaryUser) };
            UserCardListBox.ItemsSource = Data[idUser].UserCardList;

            MyFrame.Content = null;
        }

        //public string NameUser
        //{
        //    get { return (string)GetValue(NameUserProperty); }
        //    set { SetValue(NameUserProperty, value); }
        //}
        //public static readonly DependencyProperty NameUserProperty =
        //    DependencyProperty.Register("NameUser", typeof(string), typeof(User));

        //public DependencyObject UrlUserResurses
        //{
        //    get { return (DependencyObject)GetValue(UrlUserResursesProperty); }
        //    set { SetValue(UrlUserResursesProperty, value); }
        //}
        //public static readonly DependencyProperty UrlUserResursesProperty =
        //    DependencyProperty.Register("UrlUserResurses", typeof(DependencyObject), typeof(User));

        //private void OpenUser (object sender, RoutedEventArgs e)
        //{

        //    var Id = (int)((Button)sender).CommandParameter;
        //    DataContext= Data[Id];

        //    //UserModel glossary = Data.Find(x => x.IdUser == Id);

        //    this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/" + Data[Id].GlossaryUser) };
        //}

        private void LstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AudioPlayer.audioElement.Stop();

            ListBox Id = sender as ListBox;
            idUser = Id.SelectedIndex;
            DataContext = Data[Id.SelectedIndex];
            UserCardListBox.ItemsSource = Data[Id.SelectedIndex].UserCardList;

            
            MyFrame.Content = null;
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/" + Data[Id.SelectedIndex].GlossaryUser) };
        }

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

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen flag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;

            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        //private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var sampleMessageDialog = new SampleMessageDialog
        //    {
        //        Message = { Text = ((ButtonBase)sender).Content.ToString() }
        //    };

        //    await DialogHost.Show(sampleMessageDialog, "RootDialog");
        //}

        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string stringValue)
            {
                try
                {
                    Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        //private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        //    => DemoItemsSearchBox.Focus();

        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
            => DemoItemsListBox.Focus();
        
        //private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
        //    => ModifyTheme(DarkModeToggleButton.IsChecked == true);

        //private void FlowDirectionButton_Click(object sender, RoutedEventArgs e)
        //    => FlowDirection = FlowDirectionToggleButton.IsChecked.GetValueOrDefault(false)
        //        ? FlowDirection.RightToLeft
        //        : FlowDirection.LeftToRight;

        private static void ModifyTheme(bool isDarkTheme)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(isDarkTheme ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }


        //private void OnSelectedItemChanged(object sender, DependencyPropertyChangedEventArgs e)
        //    => MainScrollViewer.ScrollToHome();

        
    }
}
