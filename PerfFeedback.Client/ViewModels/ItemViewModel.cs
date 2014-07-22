using System;
using System.Runtime.Serialization;
using System.Windows.Input;
using PerfFeedback.Client.Interfaces;
using PerfFeedback.Client.Models;
using PerfFeedback.Framework;

namespace PerfFeedback.Client.ViewModels{
    [DataContract(Namespace = "http://perf.com/perf")]
    public abstract class ItemViewModel<TModel> : ViewModel, ISubscriber        where TModel : class, new()    {
        private bool _saveAndClose = true;
        public ItemViewModel()
        {
            OperationState = ViewModels.OperationState.Add;
            Initialize();
            OnSubscribe();
        }

        public IItemView ItemView { get; set; }
        protected OperationState _operationState;
        private ICommand _saveCommand;
        private ICommand _saveAndAddAnotherCommand;
        private TModel _model;

        public TModel Model
        {
            get
            {
                if (_model == null)
                {
                    _model = new TModel();
                }
                return _model;
            }
            set { _model = value; }
        }        public ICommand SaveCommand        {            get            {                if (_saveCommand == null)                {                    _saveCommand = new DelegateCommand(                                        (param) => OnCanSave(param),                                        (param) => OnSave(param));                }                return _saveCommand;             }        }

        public ICommand SaveCommandAndAddAnotherCommand
        {
            get
            {
                if (_saveAndAddAnotherCommand == null)
                {
                    _saveAndAddAnotherCommand = new DelegateCommand(
                                        (param) => OnCanSave(param),
                                        (param) => OnSave(param));
                }
                return _saveCommand;
            }
        }

        public OperationState OperationState
        {
            get { return _operationState; }
            set { _operationState = value; }
        }

        public bool IsAdd
        {
            get { return _operationState == ViewModels.OperationState.Add; }
        }

        public void Initialize()
        {
            OnInitialize();
        }

        public void Initialize(long id)
        {
            OnInitialize(id);
        }

        protected abstract void OnHandleNotification(SubscribeResponse response);
        protected abstract void OnSubscribe();
        protected abstract void OnInitialize();
        protected abstract void OnInitialize(long id);
        protected abstract void OnCommit();
        protected virtual bool OnCanSave(object param)        {            return true;        }
        protected virtual void OnSave(object param)        {
            _saveAndClose = true;            OnCommit();        }

        public void HandleNotification(SubscribeResponse response)
        {
            OnHandleNotification(response);
        }
    }}
