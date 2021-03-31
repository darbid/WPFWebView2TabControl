using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFWebView2TabControl
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public string Title
        {
            get
            {
                return _Title;
            }

            set
            {
                if (value != _Title)
                {
                    _Title = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _Title = @"New Tab";

        public Uri Source
        {
            get
            {
                return _Source;
            }

            set
            {
                if (value != _Source && value != null)
                {
                    _Source = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Uri _Source;


        #region "Notify Property Changed"
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion //"Notify Property Changed"
    }
}
