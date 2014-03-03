using System.Windows;
using System.Windows.Input;
using PerfFeedback.Client;
using PerfFeedback.Client.Interfaces;
using PerfFeedback.Client.ViewModels;
namespace PerfFeedback.Dialogs{    /// <summary>    /// Interaction logic for ModalFeedbackDialog.xaml    /// </summary>    public partial class ModalFeedbackDialog : Window, IItemView    {        public ModalFeedbackDialog()        {            InitializeComponent();        }
        private void Window_Loaded(object sender, RoutedEventArgs e)        {            var item = DataContext as CoWorker;            if (item != null)            {
                item.ItemView = this;                var command = item.SaveCommand as DelegateCommand;                if (command != null)                {                    CommandManager.RequerySuggested += command.GetCanExecuteChanged();                }            }        }

        public void FailedCommit(string error)
        {
            MessageBox.Show(error);
        }

        public void SuccessCommit(object response)
        {
            Close();
        }
    }}
