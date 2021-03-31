using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;

namespace WPFWebView2TabControl
{
    class BrowserTabItemViewModel : BaseViewModel
    {
        private CoreWebView2NewWindowRequestedEventArgs Args;
        private CoreWebView2Deferral Def;

        public delegate void BrowserTabNewWindowRequestedEventHandler(Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e);
        /// <summary>
        /// The IPAS browser is requesting a new tab.
        /// </summary>
        public event BrowserTabNewWindowRequestedEventHandler BrowserTabNewWindowRequestedEvent;

        private string _BaseURL;

        /// <summary>
        /// The base url of the web browser. This is only used for other browser tabs and then only used for
        /// a tooltip.
        /// </summary>
        public string BaseURL
        {
            get
            {
                if (Source != null)
                {
                    _BaseURL = Source.Host;
                }
                else
                {
                    _BaseURL = "";
                }

                return _BaseURL;
            }
            set
            {
                if (value != _BaseURL)
                {
                    _BaseURL = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void AddNewTab(CoreWebView2NewWindowRequestedEventArgs e)
        {
            Args = e;
            Def = e.GetDeferral();
            this.Source = new Uri(e.Uri);
        }

        public void CompleteNewTabInitialize(CoreWebView2 coreWebView)
        {
            if (Def != null)
            {
                Args.NewWindow = coreWebView;
                Args.Handled = true;
                Def.Complete();
                Def = null;
            }
        }

        public void HandleNewWindowRequested(Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            BrowserTabNewWindowRequestedEvent?.Invoke(e);
        }

        public void HandleDocumentTitle(string title)
        {
            this.Title = title;
        }
    }
}

