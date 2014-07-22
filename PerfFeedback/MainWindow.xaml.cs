using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PerfFeedback.Client;
using PerfFeedback.Client.Interfaces;
using PerfFeedback.Client.ViewModels;
using PerfFeedback.Common;
using PerfFeedback.Dialogs;
namespace PerfFeedback{    /// <summary>    /// Interaction logic for MainWindow.xaml    /// </summary>
    public partial class MainWindow : Window, IOperationView    {        public MainWindow()        {            InitializeComponent();
            DataContext = new ListCoWorker() { OperationView = this };        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)        {            CommandManager.InvalidateRequerySuggested();        }
        private void Window_Loaded(object sender, RoutedEventArgs e)        {            var vm = DataContext as ListCoWorker;            if (vm != null)            {                var edit = vm.EditCommand as DelegateCommand;                if (edit != null)                {                    CommandManager.RequerySuggested += edit.GetCanExecuteChanged();                }            }        }

        public void Add()
        {
            ModalFeedbackDialog dialog = new ModalFeedbackDialog();
            dialog.DataContext = new CoWorker();
            if (dialog.ShowDialog().IsTrue())
            {

            }
        }

        public void Edit()
        {
            ChooseWorkItem dialog = new ChooseWorkItem();
            var item = DataContext as ListCoWorker;
            item.SelectedItem.OperationState = OperationState.Edit;
            dialog.DataContext = new CoWorker(item.SelectedItem);
            dialog.ShowDialog();
            //update item when dialog closes.
            item.SelectedItem = dialog.DataContext as CoWorker;
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var context = DataContext as ListCoWorker;
            try
            {
                context.EditCommand.Execute(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
