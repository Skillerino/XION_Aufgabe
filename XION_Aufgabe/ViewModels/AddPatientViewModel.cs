using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XION_Aufgabe.Models;

namespace XION_Aufgabe.ViewModels
{
    class AddPatientViewModel : INotifyPropertyChanged, ICloseWindow, IPatientResult
    {
        public DelegateCommand AddPatientButton { get; set; }
        public DelegateCommand CloseButton { get; set; }

        public AddPatientViewModel()
        {
            Title = "Patient hinzufügen";
            FirstnameLabel = "Vorname";
            LastnameLabel = "Nachname";
            CityLabel = "Wohnort";
            AddPatientButtonText = "Patient hinzufügen";
            CloseButtonText = "Schließen";
            this.AddPatientButton = new DelegateCommand(
                (o) => !String.IsNullOrEmpty(FirstnameTextBox) || !String.IsNullOrEmpty(LastnameTextBox) || !String.IsNullOrEmpty(CityTextBox),
                (o) =>
                {
                    Result = new Patient()
                    {
                        Firstname = FirstnameTextBox,
                        Lastname = LastnameTextBox,
                        City = CityTextBox
                    };
                    GetPatient.Invoke(Result);
                    Close.Invoke();
                });
            this.CloseButton = new DelegateCommand(
                (o) =>
                {
                    Close.Invoke();
                });
            AddPatientButton.RaiseCanExecuteChanged();
        }
        public string Title { get; set; }
        public Patient Result { get; set; }
        public string FirstnameLabel { get; set; }
        public string LastnameLabel { get; set; }
        public string CityLabel { get; set; }
        string firstnameTextBox;
        public string FirstnameTextBox
        {
            get => firstnameTextBox; set
            {
                if (firstnameTextBox != value)
                {
                    firstnameTextBox = value;
                    RaisePropertyChanged();
                    AddPatientButton.RaiseCanExecuteChanged();
                }
            }
        }
        string lastnameTextBox;
        public string LastnameTextBox
        {
            get => lastnameTextBox; set
            {
                if (lastnameTextBox != value)
                {
                    lastnameTextBox = value;
                    RaisePropertyChanged();
                    AddPatientButton.RaiseCanExecuteChanged();
                }
            }
        }
        string cityTextBox;
        public string CityTextBox
        {
            get => cityTextBox; set
            {
                if (cityTextBox != value)
                {
                    cityTextBox = value;
                    RaisePropertyChanged();
                    AddPatientButton.RaiseCanExecuteChanged();
                }
            }
        }
        public string AddPatientButtonText { get; set; }
        public string CloseButtonText { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyname = "")
        {
            if (string.IsNullOrEmpty(propertyname))
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public event EventHandler<ResultEventArgs<Patient>> GetResult;
        protected void InvokeGetCompleted(Patient patient)
        {
            EventHandler<ResultEventArgs<Patient>> EventHandler = GetResult;
            EventHandler(this, new ResultEventArgs<Patient>(patient));
        }
        protected void InvokeGetPatient(Patient patient)
        {
            EventHandler<ResultEventArgs<Patient>> EventHandler = GetResult;
            EventHandler(this, new ResultEventArgs<Patient>(patient));
        }
        public Action Close { get; set; }
        public Action<Patient> GetPatient { get; set; }
    }
}
