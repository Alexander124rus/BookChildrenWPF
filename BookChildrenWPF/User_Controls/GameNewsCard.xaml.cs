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
using System.Windows.Shapes;
using BookChildrenWPF.User_Controls;

namespace BookChildrenWPF.User_Controls
{
    /// <summary>
    /// Interaction logic for GameNewsCard.xaml
    /// </summary>
    public partial class GameNewsCard : UserControl
    {
        
        public GameNewsCard()
        {
            InitializeComponent();
            
        }

        //private void Open_razdel(object sender, RoutedEventArgs e)
        //{
        //    //Home home = new Home();
        //    //MainWindow main1 = new MainWindow("ss");

        //    //main1.MyFrame.Content = new Home();
        //}

        //public string ClikMouse
        //{
        //    get { return (Route)GetValue(ClikMouseProperty); }
        //    set { SetValue(ClikMouseProperty, value); }
        //}
        //public static readonly DependencyProperty ClikMouseProperty =
        //    DependencyProperty.Register("ClikMouse", typeof(string), typeof(GameNewsCard));

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(GameNewsCard));



        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(GameNewsCard));


    }
}
