﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PerfFeedback.Client.Interfaces;

namespace PerfFeedback.Client.ViewModels
        private TModel _model;

        public event PropertyChangedEventHandler SelectedItemChanged;
        public ICommand AddCommand
        public ICommand EditCommand

        public TViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
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
        }

        protected virtual void OnAddItem(object param)
        {
            if (OperationView != null)
            {
                OperationView.Add();
            }
        }
        
            if (OperationView != null)
            {
                OperationView.Edit();
            }
        }

        protected virtual bool OnCanAdd(object param)
        {
            return true;
        }
        