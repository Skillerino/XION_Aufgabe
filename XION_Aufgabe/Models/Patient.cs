using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XION_Aufgabe.Models
{
    public struct Patient : INotifyPropertyChanged
    {
        private string firstname { get; set; }
        public string Firstname {
            get => firstname; 
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string lastname { get; set; }
        public string Lastname {
            get => lastname;
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string city { get; set; }
        public string City {
            get => city;
            set
            {
                if (city != value)
                {
                    city = value;
                    RaisePropertyChanged();
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (string.IsNullOrEmpty(propertyname))
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
