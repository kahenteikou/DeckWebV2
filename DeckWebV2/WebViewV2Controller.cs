using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using System.Text.RegularExpressions;
using System.IO;

namespace DeckWebV2
{
    public class WebViewV2Controller
    {
        private Regex tw_ptkun = new Regex(@"^https:\/\/(.+\.)?twitter\.com\/.*", RegexOptions.Compiled);
        private Microsoft.Web.WebView2.Wpf.WebView2 webview2=new Microsoft.Web.WebView2.Wpf.WebView2();
        public event EventHandler<string> PageTitleChanged;
        public event EventHandler<CoreWebView2PermissionRequestedEventArgs> PermissionRequested;
        public event EventHandler<ShowNotificationEventArgs> showNotificationed;
        private NotificationJSCS notificationJSCSkun=new NotificationJSCS();
        private string scriptGetSrc;
        public WebViewV2Controller()
        {
            scriptGetSrc = File.ReadAllText(".\\injection.js");
            webview2.CoreWebView2InitializationCompleted += this.CoreWebView2Initialization;
            notificationJSCSkun.showNotificationed += (sender, e) => this.showNotificationed?.Invoke(sender, e);
            webview2.DefaultBackgroundColor = System.Drawing.ColorTranslator.FromHtml("#1DA1F2"); 
        }
        private void CoreWebView2PermissionRequested(object sender, CoreWebView2PermissionRequestedEventArgs e)
        {
            PermissionRequested?.Invoke(this, e);
        }
        private async void CoreWebView2Initialization(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            //None
            if (e.IsSuccess)
            {
                webview2.CoreWebView2.NavigationStarting += this.CoreWebView2_NavigationStarting;
                webview2.CoreWebView2.NavigationCompleted += this.CoreWebView2_NavigationCompleted;
                webview2.CoreWebView2.DocumentTitleChanged += this.CoreWebView2_DocumentTitleChanged;
                webview2.CoreWebView2.PermissionRequested += this.PermissionRequested;
                webview2.CoreWebView2.AddHostObjectToScript("NotificationCustom", notificationJSCSkun);

            }
        }
        public void Reload()
        {
            webview2.Reload();
        }
        private async void CoreWebView2_NavigationCompleted(object sender,CoreWebView2NavigationCompletedEventArgs e)
        {

            
            string src = await webview2.CoreWebView2.ExecuteScriptAsync(scriptGetSrc);
            Debug.Print(src);
        }
        private async void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
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
        private void CoreWebView2_DocumentTitleChanged(object sender,object e22)
        {
            this.PageTitleChanged?.Invoke(this,this.webview2.CoreWebView2.DocumentTitle);
        }
        public Microsoft.Web.WebView2.Wpf.WebView2 getWebView()
        {
            return webview2;
        }
        public void OpenTaskManagerWindow()
        {
            this.webview2.CoreWebView2.OpenTaskManagerWindow();
        }
        public void OpenDevToolsWindow()
        {
            webview2.CoreWebView2.OpenDevToolsWindow();
        }
    }
}
