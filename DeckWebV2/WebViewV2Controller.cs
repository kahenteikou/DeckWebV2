using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;

namespace DeckWebV2
{
    public class WebViewV2Controller
    {
        private Microsoft.Web.WebView2.Wpf.WebView2 webview2=new Microsoft.Web.WebView2.Wpf.WebView2();
        public WebViewV2Controller()
        {
            webview2.CoreWebView2InitializationCompleted += this.CoreWebView2Initialization;
        }
        private void CoreWebView2Initialization(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            //None
        }
        public async void Navigate(string uri)
        {
            if(webview2.CoreWebView2 is null)
            {
                await webview2.EnsureCoreWebView2Async();
            }
            webview2.CoreWebView2.Navigate(uri);
        }
        public Microsoft.Web.WebView2.Wpf.WebView2 getWebView()
        {
            return webview2;
        }

    }
}
