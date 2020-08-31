using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }
}
