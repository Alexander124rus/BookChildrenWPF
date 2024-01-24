using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookChildrenWPF.Model
{
    public class UserModel:INotifyPropertyChanged
    {
        public int idUser;
        public string nameUser;
        public string glossaryUser;
        public string audioPathUser;
        public string audioNameUser;
        public string descriptionUser;
        public string quotationUser;

            public int IdUser
            {
                get { return idUser; }
                set
                {
                    idUser = value;
                    OnPropertyChanged("IdUser");
                }
            }

        public string NameUser
        {
            get { return nameUser; }
            set
            {
                nameUser = value;
                OnPropertyChanged("NameUser");
            }
        }

        public string GlossaryUser
        {
            get { return glossaryUser; }
            set
            {
                glossaryUser = value;
                OnPropertyChanged("GlossaryUser");
            }
        }

        public string AudioPathUser
        {
            get { return audioPathUser; }
            set
            {
                audioPathUser = value;
                OnPropertyChanged("AudioPathUser");
            }
        }

        public string AudioNameUser
        {
            get { return audioNameUser; }
            set
            {
                audioNameUser = value;
                OnPropertyChanged("AudioNameUser");
            }
        }

        public string DescriptionUser
        {
            get { return descriptionUser; }
            set
            {
                descriptionUser = value;
                OnPropertyChanged("DescriptionUser");
            }
        }
        public string QuotationUser
        {
            get { return quotationUser; }
            set
            {
                quotationUser = value;
                OnPropertyChanged("QuotationUser");
            }
        }
        

        public ObservableCollection<UserCardModel> UserCardList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
