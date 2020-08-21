using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainForm : Form
    {
        private readonly IGetDemoRepository _getDemoRepository;

        public MainForm(IGetDemoRepository getDemoRepository)
        {
            _getDemoRepository = getDemoRepository;

            InitializeComponent();
            
        }

    }
}
