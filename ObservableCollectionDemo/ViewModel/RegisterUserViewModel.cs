using ObservableCollectionDemo.Command;
using ObservableCollectionDemo.Model;
using ObservableCollectionDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ObservableCollectionDemo
{
    public class RegisterUserViewModel : ViewModelBase
    {

        private UserInfo user;
        public UserInfo User
        {
            get { return user; }
            set
            {
                this.user = value;
                OnPropertyChanged("User");
            }
        }

        public RegisterUserViewModel()
        {
            User = new UserInfo() { Name = "Wuke", Age = 29 };
            ClickCommand = new DelegateCommand(new Action<object>(AddAge));
        }

        public void OnPropertyChanged(string name)
        {
            RaisePropertyChanged(name);
        }


        public void AddAge(object text)
        {
            User = new UserInfo { Name = this.user.Name, Age = ++this.user.Age };
        }

        public DelegateCommand ClickCommand
        {
            get;set;
        }

    }
}
