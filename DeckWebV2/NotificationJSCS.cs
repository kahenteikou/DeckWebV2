using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DeckWebV2
{
    public class ShowNotificationEventArgs:EventArgs
    {
        private string _title;
        private string _optionsj;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Optionj
        {
            get { return _optionsj; }
            set { _optionsj = value; }
        }
        public ShowNotificationEventArgs(string title,string optionsj) : base()
        {
            _title = title;
            _optionsj = optionsj;
        }

    }
    public interface INotificationJSCS
    {
        void showNotification(string title);
        void showNotification(string title,string optionsj);

    }
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class NotificationJSCS : INotificationJSCS
    {
        public event EventHandler<ShowNotificationEventArgs> showNotificationed;

        public void showNotification(string title)
        {
            showNotificationed?.Invoke(this,new ShowNotificationEventArgs(title,""));
        }

        public void showNotification(string title, string optionsj)
        {
            showNotificationed?.Invoke(this, new ShowNotificationEventArgs(title,optionsj));
        }
    }
}
