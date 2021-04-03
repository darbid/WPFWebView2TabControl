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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFWebView2TabControl
{
    /// <summary>
    /// Interaction logic for BrowserTabItemUC.xaml
    /// </summary>
    public partial class BrowserTabItemUC : UserControl
    {
        BrowserTabItemViewModel btivm;
        public BrowserTabItemUC()
        {
            InitializeComponent();
            this.DataContextChanged += BrowserTabItemUC_DataContextChanged;
        }

        private void BrowserTabItemUC_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                this.WebView.DataContext = null;
            }
            btivm = (BrowserTabItemViewModel)this.DataContext;
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            btivm.CompleteNewTabInitialize(this.WebView.CoreWebView2);
            this.WebView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            this.WebView.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
        }

        private void CoreWebView2_DocumentTitleChanged(object sender, object e)
        {
            btivm.HandleDocumentTitle(this.WebView.CoreWebView2.DocumentTitle);
        }

        private void CoreWebView2_NewWindowRequested(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            btivm.HandleNewWindowRequested(e);
        }
    }
}
