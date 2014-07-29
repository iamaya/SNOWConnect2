using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SNOWConnect2
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string _domainname;
        public string _username;
        public string _password;
        public string _statusMessage;

        public Type PageType { private set; get; }
        public string PageName { private set; get; }

        public ICommand LoginCommand { get; protected set; }
        public ICommand NavigateCommand { get; protected set; }

        private ILoginService loginService = new LoginService();

        public HomeViewModel(Type pageType, Action<Type> navigateTo )
        {
            this.PageType = pageType;
            this.PageName = pageType.Name;

            this.LoginCommand = new Command(() => {
                loginService.AttemptLogin(DomainName, UserName, Password,
                    successs => { //StatusMessage = successs.result.First().short_description;
                        this.NavigateCommand = new Command<Type>(navigateTo);
                        this.NavigateCommand.Execute(pageType);
                    },
                    error => { StatusMessage = "Login Failed. Please check your credentials."; });
                //StatusMessage = "Login Error";
            }); 
        }

        public string DomainName
        {
            get
            {
                return _domainname;
            }
            set
            {
                if (_domainname != value)
                {
                    _domainname = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DomainName"));
                    }
                }
            }
        }

        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
                    }
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                    }
                }
            }
        }

        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("StatusMessage"));
                    }
                }
            }
        }




    }
}
