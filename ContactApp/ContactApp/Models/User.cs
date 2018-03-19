using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ContactApp.Models
{
    class User
    {
        private string _login;
        private string _password;

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

        public event PropertyChangedEventHandler PropertyChanged;

     
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
