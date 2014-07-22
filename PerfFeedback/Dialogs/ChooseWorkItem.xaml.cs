using System;
using System.Linq;
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
    public partial class ChooseWorkItem : Window, IOperationView, IItemView
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
            ModalWorkItemDialog dialog = new ModalWorkItemDialog();
            var coWorker = DataContext as CoWorker;
            var workItem = new WorkItem()
                                    {
                                        CoWorkerId = coWorker.CoWorkerId
                                    };

            dialog.DataContext = workItem;
            dialog.ShowDialog();
        }

        public void Edit()
        {
            var coWorker = DataContext as CoWorker;
            ModalWorkItemDialog dialog = new ModalWorkItemDialog();
            var workItem = new WorkItem(coWorker.WorkItems.SelectedItem);
            workItem.OperationState = OperationState.Edit;
            dialog.DataContext = workItem;
            //Get index so we know what to update later.
            int indexOf = coWorker.WorkItems.IndexOf(coWorker.WorkItems.SelectedItem);
            
            if (dialog.ShowDialog().IsTrue())
            {
                coWorker.WorkItems[indexOf] = dialog.DataContext as WorkItem;
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var context = DataContext as CoWorker;
            try
            {
                context.WorkItems.EditCommand.Execute(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void FailedCommit(string error)
        {
            MessageBox.Show(error);
        }

        public void SuccessCommit(object response)
        {
            DialogResult = true;
            Close();
        }
    }
}
