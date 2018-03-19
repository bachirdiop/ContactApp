using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactApp.Models
{
    internal class User
    {
        private string _login;
        private string _password;


        public User(string nm, string cn)
        {
            Login = nm;
            Password = cn;
        }

        public User()
        {
            Login = "admin";
            Password = "admin";
        }

        public string Login
        {
            get => _login;
            set
            {
                if (value == _login) return;
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }


        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}