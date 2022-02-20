using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeckWebV2
{
    public class ShowNotificationEventArgs:EventArgs
    {
        private string _title;
        private JsonElement _optionsje;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public JsonElement Optionsje
        {
            get { return _optionsje; }
            set { _optionsje = value; }
        }
        public ShowNotificationEventArgs(string title,string optionsj) : base()
        {
            _title = title;
            if (optionsj == "")
            {
                _optionsje = new JsonElement();
            }
            else
            {
                using(JsonDocument doc = JsonDocument.Parse(optionsj))
                {
                    _optionsje = doc.RootElement;
                }
            }
        }
        public ShowNotificationEventArgs(string title,JsonElement optj) : base()
        {
            _title=title;
            _optionsje = optj;
        }

    }
    public interface INotificationJSCS
    {
        void showNotification(string title,string optionsj);

    }
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class NotificationJSCS : INotificationJSCS
    {
        public event EventHandler<ShowNotificationEventArgs> showNotificationed;

        public void showNotification(string title, string optionsj)
        {
            showNotificationed?.Invoke(this, new ShowNotificationEventArgs(title,optionsj));
        }
    }
}
