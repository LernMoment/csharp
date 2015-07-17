using System.Windows;
using CommandCanExecute.MvvmFoundation;
using System.Windows.Input;

namespace CommandCanExecute
{
    class MainViewModel : ViewModelBase
    {
        private SpeichernCommand dateiSpeichernCommand;
        private bool istSpeichernAktiv = false;

        public ICommand DateiSpeichernCommand
        {
            get
            {
                if (dateiSpeichernCommand == null)
                {
                    dateiSpeichernCommand = new SpeichernCommand();
                }

                return dateiSpeichernCommand;
            }
        }
    }
}
