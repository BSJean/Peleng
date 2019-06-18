using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Peleng
{
    public partial class specificationEnterNumber : Form
    {
        public specificationEnterNumber()
        {
            InitializeComponent();
            
            if (maskedTbNumber.CanFocus)
            maskedTbNumber.Focus();
            maskedTbNumber.Select(0, 0);
            maskedTbNumber.Mask = "0000.00.00.000";
            maskedTbNumber.PromptChar = '_';
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            specificationWork specWork = new specificationWork(maskedTbNumber.Text.Replace(',','.'));
            specWork.MdiParent = this.Owner;
            specWork.Show();
        }

        private void maskedTbNumber_TextChanged(object sender, EventArgs e)
        {
            if (maskedTbNumber.MaskFull)
            {      
                btnOK.Enabled = true;
            }
            else
                btnOK.Enabled = false;
        }
    }
}
