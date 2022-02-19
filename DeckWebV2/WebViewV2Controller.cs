using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using System.Text.RegularExpressions;

namespace DeckWebV2
{
    public class WebViewV2Controller
    {
        private Regex tw_ptkun = new Regex(@"^https:\/\/(.+\.)?twitter\.com\/.*", RegexOptions.Compiled);
        private Microsoft.Web.WebView2.Wpf.WebView2 webview2=new Microsoft.Web.WebView2.Wpf.WebView2();
        public WebViewV2Controller()
        {
            webview2.CoreWebView2InitializationCompleted += this.CoreWebView2Initialization;
        }
        private void CoreWebView2Initialization(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            //None
            if (e.IsSuccess)
            {
                webview2.CoreWebView2.NavigationStarting += this.CoreWebView2_NavigationStarting;
            }
        }
        private async void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            var uri = new Uri(e.Uri);
            Debug.WriteLine(uri);
            if (tw_ptkun.IsMatch(e.Uri))
            {
                
            }
            else
            {
                await webview2.CoreWebView2.ExecuteScriptAsync($"open(\"{e.Uri}\");");
                e.Cancel = true;
            }
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
