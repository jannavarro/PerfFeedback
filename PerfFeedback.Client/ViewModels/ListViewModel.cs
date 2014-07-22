using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PerfFeedback.Client.Interfaces;
using PerfFeedback.Framework;

namespace PerfFeedback.Client.ViewModels{    public abstract class ListViewModel<TViewModel, TModel> : ObservableCollection<TViewModel>, ISubscriber        where TModel : class, new()    {        private ICommand _addCommand;        private ICommand _editCommand;        private TViewModel _selectedItem;
        private TModel _model;

        public event PropertyChangedEventHandler SelectedItemChanged;
        public ICommand AddCommand        {            get            {                if (_addCommand == null)                {                    _addCommand = new DelegateCommand(                        param => OnCanAdd(param),                        param => OnAddItem(param));                }                return _addCommand;            }        }
        public ICommand EditCommand        {            get            {                if (_editCommand == null)                {                    _editCommand = new DelegateCommand(                        param => OnCanEdit(param),                        param => OnEditItem(param));                }                return _editCommand;            }        }

        public TViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnNotifyPropertyChanged(string.Empty);
                if (SelectedItemChanged != null)
                {
                    SelectedItemChanged(this, new PropertyChangedEventArgs("SelectedItem"));
                }
            }
        }

        protected TModel Model
        {
            get
            {
                if (_model == null)
                {
                    _model = new TModel();
                }

                return _model;
            }
        }

        public IOperationView OperationView
        {
            get;
            set;
        }

        public ListViewModel()
        {
            OnInitializeItems();
            OnSubscribe();
        }

        protected virtual void OnAddItem(object param)
        {
            if (OperationView != null)
            {
                OperationView.Add();
            }
        }
                protected virtual void OnEditItem(object param)        {
            if (OperationView != null)
            {
                OperationView.Edit();
            }
        }

        protected virtual bool OnCanAdd(object param)
        {
            return true;
        }
                protected virtual bool OnCanEdit(object param)        {            return SelectedItem != null;        }

        protected virtual void OnNotifyPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected abstract void OnInitializeItems();
        protected abstract void OnSubscribe();
        protected abstract void OnHandleNotification(SubscribeResponse response);

        public void HandleNotification(SubscribeResponse response)
        {
            OnHandleNotification(response);
        }
    }}
