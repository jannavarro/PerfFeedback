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
using System.Windows.Shapes;
using PerfFeedback.Client;

namespace PerfFeedback.Dialogs
{
    /// <summary>
    /// Interaction logic for ModalFeedbackDialog.xaml
    /// </summary>
    public partial class ModalFeedbackDialog : Window
    {
        public ModalFeedbackDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var item = DataContext as CoWorkerViewModel;
            if (item != null)
            {
                var command = item.SaveCloseCommand as DelegateCommand;
                if (command != null)
                {
                    CommandManager.RequerySuggested += command.GetCanExecuteChanged();
                }
            }
        }
    }
}
