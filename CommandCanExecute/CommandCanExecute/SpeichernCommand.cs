using System;
using System.Windows;
using System.Windows.Input;

namespace CommandCanExecute
{
    class SpeichernCommand : ICommand
    {
        private bool istSpeichernAktiv = false;

        public bool CanExecute(object parameter)
        {
            // Das Kommando kann ausgeführt werden, wenn gerade nicht gespeichert wird.
            return istSpeichernAktiv == false;
        }

        public void Execute(object parameter)
        {
            istSpeichernAktiv = true;
            MessageBox.Show("Speichere jetzt!");
            istSpeichernAktiv = false;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
