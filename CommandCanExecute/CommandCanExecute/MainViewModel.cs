using System.Windows;
using CommandCanExecute.MvvmFoundation;
using System.Windows.Input;

namespace CommandCanExecute
{
    class MainViewModel : ViewModelBase
    {
        private RelayCommand dateiSpeichernCommand;
        private bool istSpeichernAktiv = false;

        public ICommand DateiSpeichernCommand
        {
            get
            {
                if (dateiSpeichernCommand == null)
                {
                    dateiSpeichernCommand = new RelayCommand(() => this.Speichern(), () => istSpeichernAktiv == false);
                }

                return dateiSpeichernCommand;
            }
        }

        private void Speichern()
        {
            istSpeichernAktiv = true;
            MessageBox.Show("Speichere jetzt!");
            istSpeichernAktiv = false;
        }
    }
}
