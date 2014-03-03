using System;
using System.Runtime.Serialization;
using System.Windows.Input;
using PerfFeedback.Client.Interfaces;
using PerfFeedback.Client.Models;
using PerfFeedback.Framework;

namespace PerfFeedback.Client.ViewModels{
    [DataContract(Namespace = "http://perf.com/perf")]
    public abstract class ItemViewModel : ViewModel, ISubscriber    {
        public ItemViewModel()
        {
            Initialize();
            OnSubscribe();
        }

        public IItemView ItemView { get; set; }
        protected OperationState _operationState;
        private ICommand _saveCommand;        public ICommand SaveCommand        {            get            {                if (_saveCommand == null)                {                    _saveCommand = new DelegateCommand(                                        (param) => OnCanSave(param),                                        (param) => OnSave(param));                }                return _saveCommand;             }        }

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
        protected virtual void OnSave(object param)        {            OnCommit();        }

        public void HandleNotification(SubscribeResponse response)
        {
            OnHandleNotification(response);
        }
    }}
