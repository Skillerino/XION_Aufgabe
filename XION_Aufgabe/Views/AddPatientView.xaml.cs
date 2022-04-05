using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XION_Aufgabe.Views
{
    /// <summary>
    /// Interaktionslogik für AddPatientView.xaml
    /// </summary>
    public partial class AddPatientView : UserControl
    {
        public AddPatientView()
        {
            InitializeComponent();
            Loaded += AddPatientView_Loaded;
        }

        private void AddPatientView_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is ICloseWindow viewModel)
            {
                viewModel.Close += () =>
                {
                    var window = this.Parent as Window;
                    window.Close();
                };

                viewModel.Close += () =>
                {
                    var window = this.Parent as Window;
                    
                    window.Close();
                };
            }
        }
    }
}
