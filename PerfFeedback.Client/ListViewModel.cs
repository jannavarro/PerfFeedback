using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfFeedback.Client
{
    public class ListViewModel<TViewModel> : ObservableCollection<TViewModel>
    {
        private ICommand _addCommand;
        private ICommand _editCommand;

        private TViewModel _selectedItem;

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new DelegateCommand(
                        param => OnCanAdd(param),
                        param => OnAddItem(param));
                }

                return _addCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new DelegateCommand(
                        param => OnCanEdit(param),
                        param => OnEditItem(param));
                }

                return _editCommand;
            }
        }

        private object OnEditItem(object param)
        {
            throw new NotImplementedException();
        }

        protected virtual bool OnCanEdit(object param)
        {
            return SelectedItem != null;
        }

        protected virtual void OnAddItem(object param)
        {
            var p = param;
        }

        protected virtual bool OnCanAdd(object param)
        {
            return true;
        }

        public TViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                var editDelegatedCommand = _editCommand as DelegateCommand;
            }
        }
    }
}
