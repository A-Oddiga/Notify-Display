using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Notifier
{
    public partial class Form1 : Form
    {
        public BackgroundWorker bgWorker = new BackgroundWorker();
        public string mang0 = "https://www.twitch.tv/mang0";
        public string clint = "https://www.twitch.tv/clintstevens";
        public string daph = "https://www.twitch.tv/39daph";
        public string zain = "https://www.twitch.tv/zainssbm";
        public List<string> streamers = new List<string>();
        public bool ClintActive = false;
        public bool Mang0Active = false;
        public bool daphActive = false;
        public bool zainActive = false;
        public bool found = false;

        public Form1()
        {
            InitializeComponent();
            streamers.Add(mang0);
            streamers.Add(clint);
            streamers.Add(daph);
            streamers.Add(zain);
            getWebPage();
            getStatus();
        }
        public void getWebPage()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;           
            foreach (string streamer in streamers)
            {            
             
                webBrowser1.Navigate(streamer);
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
                if(found == true)
                {
                    switch (streamer)
                    {
                        case "https://www.twitch.tv/mang0":
                            Mang0Active = true;
                            break;
                        case "https://www.twitch.tv/clintstevens":
                            ClintActive = true;
                            break;
                        case "https://www.twitch.tv/39daph":
                            daphActive = true;
                            break;
                        case "https://www.twitch.tv/zainssbm":
                            zainActive = true;
                            break;
                    }
                    found = false;
                }            
            }                                          
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Document.Body.InnerText.Contains("zain"))
            {
                found = true;
            }
        }

        public void getStatus()
        {
            mang0Box.BackColor = (Mang0Active ? Color.LightGreen : Color.OrangeRed);
            clintBox.BackColor = (ClintActive ? Color.LightGreen : Color.OrangeRed);
            daphBox.BackColor = (daphActive ? Color.LightGreen : Color.OrangeRed);
            zainBox.BackColor = (zainActive ? Color.LightGreen : Color.OrangeRed);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
