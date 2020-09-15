using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    class DataGridViewImageCellBlank : DataGridViewImageCell
    {
        public DataGridViewImageCellBlank() : base()
        {
        } 

        public DataGridViewImageCellBlank(bool valueIsIcon) : base(valueIsIcon)
        {
        } 

        public override object DefaultNewRowValue
        {
            get
            {
                return null; 
            }
        }
    } 
}
