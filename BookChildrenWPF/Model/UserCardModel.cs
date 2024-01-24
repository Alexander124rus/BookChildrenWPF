using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BookChildrenWPF.Model
{
    public class UserCardModel : INotifyPropertyChanged
    {
        public int idUserCard;
        public string sourseUserCard;
        public string textUserCard;
        public string descriptionUserCard;


        public int IdUserCard
        {
            get { return idUserCard; }
            set
            {
                idUserCard = value;
                OnPropertyChanged("IdUserCard");
            }
        }

        public string SourseUserCard
        {
            get { return sourseUserCard; }
            set
            {
                sourseUserCard = value;
                OnPropertyChanged("SourseUserCard");
            }
        }

        public string TextUserCard
        {
            get { return textUserCard; }
            set
            {
                textUserCard = value;
                OnPropertyChanged("TextUserCard");
            }
        }

        public string DescriptionUserCard
        {
            get { return descriptionUserCard; }
            set
            {
                descriptionUserCard = value;
                OnPropertyChanged("DescriptionUserCard");
            }
        }

        public ObservableCollection<ImageUserCardModel> ImageUserCardList { get; set; }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
