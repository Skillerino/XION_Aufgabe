using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XION_Aufgabe.Views;

namespace XION_Aufgabe
{
    public interface IDialogService
    {
        void showDialog<ViewModel>(Action<string> callback);
    }
    public class DialogService : IDialogService
    {
        public void showDialog<TView>(Action<string> callback)
        {
            var dialog = new DialogWindow();

            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult.ToString());
                dialog.Closed -= closeEventHandler;
            };
            dialog.Closed += closeEventHandler;

            var type = Type.GetType(typeof(TView).ToString());
            var Content = Activator.CreateInstance(type);

            dialog.Content = Content;

            dialog.ShowDialog();
        }
    }
}
