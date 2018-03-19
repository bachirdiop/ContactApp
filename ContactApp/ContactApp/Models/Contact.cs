using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ContactApp.Models
{
    public class Contact
    {

        private string _name;
        private string _cellNumber;
        private string _id;
        private ImageSource _imgSource;

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }



        public string CellNumber
        {
            get => _cellNumber;
            set
            {
                if (value == _cellNumber) return;
                _cellNumber = value;
                OnPropertyChanged(nameof(CellNumber));
            }
        }

        public ImageSource ImgSource
        {
            get => _imgSource;
            set
            {
                if (value == _imgSource) return;
                _imgSource = value;
                OnPropertyChanged(nameof(ImgSource));
            }
        }

        public string Id { get => _id; set => _id = value; }

        public Contact(string nm, string cn)
        {
            Id = Guid.NewGuid().ToString();
            Name = nm;
            CellNumber = cn;
            ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png");
        }

        public Contact()
        {
            Random r = new Random();
            Id = Guid.NewGuid().ToString();
            Name = "Contact " + r.Next().ToString();
            CellNumber = r.Next().ToString() + " - " + r.Next().ToString();
            ImgSource = ImageSource.FromResource("Images.profile.png");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
