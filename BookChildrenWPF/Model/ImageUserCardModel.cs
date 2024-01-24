using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace BookChildrenWPF.Model
{
    public class ImageUserCardModel: INotifyPropertyChanged
    {
        public int idImageUserCard;
        public ImageSource urlImageUserCard;
        public string descriptionImageUserCard;

        public int IdImageUserCard
        {
            get { return idImageUserCard; }
            set
            {
                idImageUserCard = value;
                OnPropertyChanged("IdImageUserCard");
            }
        }

        public ImageSource UrlImageUserCard
        {
            get { return urlImageUserCard; }
            set
            {
                urlImageUserCard = value;
                OnPropertyChanged("UrlImageUserCard");
            }
        }

        public string DescriptionImageUserCard
        {
            get { return descriptionImageUserCard; }
            set
            {
                descriptionImageUserCard = value;
                OnPropertyChanged("DescriptionImageUserCard");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
