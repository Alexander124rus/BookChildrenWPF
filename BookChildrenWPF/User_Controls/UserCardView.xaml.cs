using BookChildrenWPF.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookChildrenWPF.User_Controls
{
    /// <summary>
    /// Логика взаимодействия для UserCardView.xaml
    /// </summary>
    public partial class UserCardView : UserControl
    {
        public UserCardView()
        {
            InitializeComponent();

            //UserCardView userCard = DataContext;
            //var myValue = this.DataContext.GetType().GetProperty("UserCardList").GetValue(this.DataContext, null);

        }
        private void ButtonPrevClouse_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
        }
        private async void OpenDialog(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            SampleDialog sempleDialog = new SampleDialog();

            ObservableCollection<ImageUserCardModel> DataList = ((UserCardModel)this.DataContext).ImageUserCardList;

            sempleDialog.DataSampleList = DataList;
            sempleDialog.idSampleDialog = (int)button.CommandParameter;
            sempleDialog.DataContext = DataList[(int)button.CommandParameter];
            var result = await DialogHost.Show(sempleDialog, "RootDialog", null, null, null);
        }
    }
}
