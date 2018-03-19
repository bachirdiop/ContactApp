using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ContactApp.Models
{
    public class Contact
    {
        private string _cellNumber;
        private ImageSource _imgSource;

        private string _name;

        public Contact(string nm, string cn)
        {
            Id = Guid.NewGuid().ToString();
            Name = nm;
            CellNumber = cn;
            ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png");
        }

        public Contact()
        {
            var r = new Random();
            Id = Guid.NewGuid().ToString();
            Name = "Contact " + r.Next();
            CellNumber = r.Next() + " - " + r.Next();
            ImgSource = ImageSource.FromResource("Images.profile.png");
        }

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

        public string Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}