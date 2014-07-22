using System.Windows;
using System.Windows.Input;
using PerfFeedback.Client;
using PerfFeedback.Client.Interfaces;
using PerfFeedback.Client.ViewModels;
namespace PerfFeedback.Dialogs{    /// <summary>    /// Interaction logic for ModalFeedbackDialog.xaml    /// </summary>    public partial class ModalFeedbackDialog : Window, IItemView    {        public ModalFeedbackDialog()        {            InitializeComponent();        }
        private void Window_Loaded(object sender, RoutedEventArgs e)        {            var context = DataContext as CoWorker;
            if (context != null)
            {
                context.ItemView = this;
                var command = context.SaveCommand as DelegateCommand;
                if (command != null)
                {
                    CommandManager.RequerySuggested += command.GetCanExecuteChanged();
                }
            }
            //During Add the DataContext is a CoWorker but during edit it is only the WorkItem we are editing.
            //else
            //{
            //    var context2 = DataContext as WorkItem;
            //    if (context2 != null)
            //    {
            //        context2.ItemView = this;
            //        var command = context2.SaveCommand as DelegateCommand;
            //        if (command != null)
            //        {
            //            CommandManager.RequerySuggested += command.GetCanExecuteChanged();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(string.Format("Wrong DataContext type: {0}.", DataContext.GetType()));
            //    }
            //}        }

        public void FailedCommit(string error)
        {
            MessageBox.Show(error);
        }

        public void SuccessCommit(object response)
        {
            DialogResult = true;
            Close();
        }
    }}
