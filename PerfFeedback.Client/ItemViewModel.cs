using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfFeedback.Client
{
    public class ItemViewModel : ViewModel
    {
        private ICommand _saveCloseCommand;

        public ICommand SaveCloseCommand
        {
            get
            {
                if (_saveCloseCommand == null)
                {
                    _saveCloseCommand = new DelegateCommand(
                                        (param) => OnCanSave(param),
                                        (param) => OnSaveClose(param));
                }

                return _saveCloseCommand; 
            }
        }

        public ICommand SaveRemainOpenCommand
        {
            get
            {
                if (_saveCloseCommand == null)
                {
                    _saveCloseCommand = new DelegateCommand(
                                        (param) => OnCanSave(param),
                                        (param) => OnSaveClose(param));
                }

                return _saveCloseCommand; 
            }
        }

        protected virtual bool OnCanSave(object param)
        {
            return true;
        }

        protected virtual void OnSaveClose(object param)
        {
            OnCommit();
        }

        protected virtual void OnCommit()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnSaveRemainOpen(object param)
        {
            throw new NotImplementedException();

        }
    }
}
