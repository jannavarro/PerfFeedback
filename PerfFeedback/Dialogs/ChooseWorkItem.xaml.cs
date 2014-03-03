using System.Windows;
using System.Windows.Input;
using PerfFeedback.Client;
using PerfFeedback.Client.Interfaces;
using PerfFeedback.Client.ViewModels;
using PerfFeedback.Common;

namespace PerfFeedback.Dialogs
{
    /// <summary>
    /// Interaction logic for ChooseWorkItem.xaml
    /// </summary>
    public partial class ChooseWorkItem : Window, IOperationView
    {
        public ChooseWorkItem()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var item = DataContext as CoWorker;
            if (item != null)
            {
                item.WorkItems.OperationView = this;
            //    var command = item.SaveCommand as DelegateCommand;
            //    if (command != null)
            //    {
            //        CommandManager.RequerySuggested += command.GetCanExecuteChanged();
            //    }
                var edit = item.WorkItems.EditCommand as DelegateCommand;
                if (edit != null)
                {
                    CommandManager.RequerySuggested += edit.GetCanExecuteChanged();
                }
            }
        }

        public void Add()
        {
            ModalFeedbackDialog dialog = new ModalFeedbackDialog();
            var clone = DataContext as CoWorker;
            var copy = new CoWorker()
            {
                Id = clone.Id,
                Name = clone.Name,
                WorkItemName = clone.WorkItemName
            };

            dialog.DataContext = copy;
            if (dialog.ShowDialog().IsTrue())
            {

            }
        }

        public void Edit()
        {
            var coWorker = DataContext as CoWorker;
            ModalFeedbackDialog dialog = new ModalFeedbackDialog();
            dialog.DataContext = new CoWorker(coWorker);
            if (dialog.ShowDialog().IsTrue())
            {

            }
        }
    }
}
