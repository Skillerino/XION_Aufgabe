using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XION_Aufgabe.Models;
using XION_Aufgabe.Views;

namespace XION_Aufgabe.ViewModels
{
    class StartUpViewModel : INotifyPropertyChanged, IPatientResult
    {
        IDialogService dialogService = new DialogService();
        
        public string Title { get; set; }
        ObservableCollection<Patient> patientsList { get; set; } = new ObservableCollection<Patient>();
        public ObservableCollection<Patient> PatientsList
        {
            get => patientsList; set
            {
                if (patientsList != value)
                {
                    patientsList = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DelegateCommand ShowPatientAddCommand { get; set; }
        public string ShowPatientAddText { get; set; }
        public Action<Patient> GetPatient { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ResultEventArgs<Patient>> GetResult;

        public StartUpViewModel()
        {
            this.Title = "Patient List";
            this.ShowPatientAddText = "Patient hinzufügen";

            PatientsList.Add(new Patient { Firstname = "Max", Lastname = "Mustermann", City = "München" });
            this.ShowPatientAddCommand = new DelegateCommand(
                (o) => {
                    GetResult += OnGetResult;
                    GetPatient += result =>
                    {
                        PatientsList.Add(result);
                        Console.WriteLine("Test");
                    };
                    dialogService.showDialog<AddPatientView>(result =>
                    {

                    });
                });
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (string.IsNullOrEmpty(propertyname))
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public void OnGetResult(object sender, ResultEventArgs<Patient> EventArgs)
        {
            PatientsList.Add(EventArgs.Result);
            Console.WriteLine("Test");
            GetResult -= OnGetResult;
        }
    }
}
