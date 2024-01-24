using BookChildrenWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookChildrenWPF.User_Controls
{
    /// <summary>
    /// Логика взаимодействия для SampleDialog.xaml
    /// </summary>
    public partial class SampleDialog : UserControl
    {
        public SampleDialog()
        {

            InitializeComponent();

        }

        public int idSampleDialog = 0;
        //Список объектов
        public ObservableCollection<ImageUserCardModel> DataSampleList { get; set; }
        //Объект
        //public ImageUserCardModel DataSampleContext { get; set; }
        
        

        private void NextButton(object sender, RoutedEventArgs e)
        {
            if (idSampleDialog == DataSampleList.Count - 1)
            {
                idSampleDialog = 0;
            }
            else
            {
                idSampleDialog++;
            }
            
            DataContext = DataSampleList[idSampleDialog];
            //ImageDialog.Source = DataSampleList[id].UrlImageUserCard;
            //if (DataSampleContext.IdImageUserCard == DataSampleList.Count)
            //{
            //    DataSampleContext.IdImageUserCard = 0;
            //}
        }
        private void PrevButton(object sender, RoutedEventArgs e)
        {
            if (idSampleDialog == 0)
            {
                idSampleDialog = DataSampleList.Count;
            }
            idSampleDialog--;

            DataContext = DataSampleList[idSampleDialog];
        }
    }
}
