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
using PerfFeedback.Client.Interfaces;
using PerfFeedback.Client.ViewModels;

namespace PerfFeedback.Dialogs
{
    /// <summary>
    /// Interaction logic for ModalWorkItem.xaml
    /// </summary>
    public partial class ModalWorkItemDialog : Window, IItemView
    {
        private bool _saveAndClose = true;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var item = DataContext as WorkItem;
            if (item != null)
            {
                item.ItemView = this;
            }
        }

        public ModalWorkItemDialog()
        {
            InitializeComponent();
        }

        public void FailedCommit(string error)
        {
            throw new NotImplementedException();
        }

        public void SuccessCommit(object response)
        {
            if (_saveAndClose)
            {
                DialogResult = true;
                Close();
            }
            else
            {

            }
        }
    }
}
