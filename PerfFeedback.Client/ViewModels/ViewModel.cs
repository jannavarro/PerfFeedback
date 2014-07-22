using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;



namespace PerfFeedback.Client.ViewModels
{
    [DataContract]
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            OnPropertyChanged(PropertyName(propertyExpression));
        }

        protected string PropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            MemberExpression expression = propertyExpression.Body as MemberExpression;
            if (expression == null)
            {
                throw new ArgumentException("The argument 'propertyExpression' must be of the form '() => SomeProperty'");
            }

            return expression.Member.Name;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            //if (!IsInitializing && !string.IsNullOrEmpty(propertyName))
            //{
            //    IsDirty = true;
            //}
            NotifyPropertyChanged(propertyName);
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                try
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
                catch (NullReferenceException)
                {
                    // sometimes in the .net code, usually when using a datagrid, this handler will throw a null reference exception.
                    // we will ignore it for now.
                }
            }
        }
    }
}
