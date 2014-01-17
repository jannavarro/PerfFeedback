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
using PerfFeedback.Client;
using PerfFeedback.Common;
using PerfFeedback.Dialogs;

namespace PerfFeedback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ListCoWorker();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var vm = DataContext as ListCoWorker;

            //if (vm != null)
            //{
            //    var item = vm.SelectedItem as CoWorker;
            //    if (item != null)
            //    {
            //        ModalFeedbackDialog dialog = new ModalFeedbackDialog();
            //        dialog.DataContext = item;
            //        if (dialog.ShowDialog().IsTrue())
            //        {
            //        }
            //    }
            //}
            ModalFeedbackDialog dialog = new ModalFeedbackDialog();
            dialog.DataContext = new CoWorkerViewModel();
            if (dialog.ShowDialog().IsTrue())
            {
            }
            
        }

        private void EditCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ListCoWorker;
            if (vm != null)
            {
                var edit = vm.EditCommand as DelegateCommand;
                if (edit != null)
                {
                    CommandManager.RequerySuggested += edit.GetCanExecuteChanged();
                }
            }
        }
    }
}
