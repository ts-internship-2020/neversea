using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class WebViewForm : Form
    {
        public WebViewForm()
        {
            InitializeComponent();
            webView1.Navigate("https://google.ro");
        }
    }
}
