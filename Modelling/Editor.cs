using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Reflection;

namespace Modelling
{
    public partial class Editor : Form
    {
        public int Engprop { get; set; }
        public Uri MyProperty { get; set; }
        public Editor()
        {
           InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;

        }
        Uri temp = new Uri("file:///C:/Users/asus/Desktop/Templates/newtmp.html");
        Uri eng = new Uri("file:///C:/Users/asus/Desktop/Templates/engtemp.html");

        private void Editor_Load(object sender, EventArgs e)
        {
            
            if (Engprop==1)
            {
                
                webBrowser1.Navigate(eng);

            }
            if (MyProperty != temp && Engprop != 1)
            {

                webBrowser1.Navigate(MyProperty);
            }

            if(MyProperty==null && Engprop !=1)
            {
                webBrowser1.Navigate(temp);
            }
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();


            var html = httpClient.GetStringAsync(textBox1.Text); // get isteği gönderir ve onu stringe çevirir

            string b = html.Result;
            File.WriteAllText(@"C:\Users\PC\Desktop\Modelling\website.htm", b);
            File.WriteAllText(@"C:\Users\PC\Desktop\Modelling\website.txt", b);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
        }



    

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
      
            var Edit = new Editingpage();
            Edit.Show();
        }
    }
}
