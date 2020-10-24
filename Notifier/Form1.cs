using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;

namespace Notifier
{
    public partial class Form1 : Form
    {
        public string mang0 = "https://www.twitch.tv/mang0";
        public string clint = "https://www.twitch.tv/clintstevens";
        public string zain = "https://www.twitch.tv/zainssbm";
        public string soil = "https://www.twitch.tv/soilmk";
        public List<string> streamers = new List<string>();
        public bool ClintActive = false;
        public bool Mang0Active = false;
        public bool zainActive = false;
        public bool soilActive = false;
        public bool found = false;

        public Form1()
        {
            InitializeComponent();          
            streamers.Add(mang0);
            streamers.Add(clint);
            streamers.Add(zain);
            streamers.Add(soil);
            getWebPage();          
        }
        public void getWebPage()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Position = new Point(-2000, 0);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Debug.WriteLine("Checking Status...");            
            foreach (string streamer in streamers)
            {               
                driver.Url = $"{streamer}";
                driver.Navigate();
                Thread.Sleep(1000);
                CheckIfLive(streamer);

                if (found == true)
                {
                    switch (streamer)
                    {
                        case "https://www.twitch.tv/mang0":
                            Mang0Active = true;
                            break;
                        case "https://www.twitch.tv/clintstevens":
                            ClintActive = true;
                            break;
                        case "https://www.twitch.tv/zainssbm":
                            zainActive = true;
                            break;
                        case "https://www.twitch.tv/soilmk":
                            soilActive = true;
                            break;
                    }
                    found = false;
                }            
            }
            void CheckIfLive(string streamer)
            {
                try
                {
                    if (driver.FindElementByClassName("live-time").Displayed)
                        found = true;
                }
                catch { };
            }
            void getStatus()
            {
                mang0Box.BackColor = (Mang0Active ? Color.LightGreen : Color.OrangeRed);
                clintBox.BackColor = (ClintActive ? Color.LightGreen : Color.OrangeRed);
                zainBox.BackColor = (zainActive ? Color.LightGreen : Color.OrangeRed);
                soilmkBox.BackColor = (soilActive ? Color.LightGreen : Color.OrangeRed);
                driver.Close();
            }
            getStatus();
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            getWebPage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
