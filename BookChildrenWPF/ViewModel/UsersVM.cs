using BookChildrenWPF.Model;
using BookChildrenWPF.User_Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookChildrenWPF.ViewModel
{
    public class UsersVM: INotifyPropertyChanged
    {
        public ObservableCollection<UserModel> Users { get; set; }

        public UsersVM()
        {
            //Users = new UserModel {
            //    IdUser = 0,
            //    NameUser = "Zikov",
            //};

            Users = new ObservableCollection<UserModel>
            {
                new UserModel { IdUser=0, NameUser="Zikov"},
                new UserModel { IdUser=1, NameUser="Zaharov"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public static implicit operator ObservableCollection<object>(UsersVM v)
        {
            throw new NotImplementedException();
        }
    }
}
