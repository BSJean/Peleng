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
    public partial class reportItemEnter : Form
    {
        private string number;

        public reportItemEnter()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            if (maskedTbNumber.CanFocus)
                maskedTbNumber.Focus(); 
            maskedTbNumber.Select(0, 0);
            maskedTbNumber.Mask = "0000.00.00.000";
            maskedTbNumber.PromptChar = '_';
        }

        public string Number
        {
            get
            {
                return number;
            }
        }

        public int TypeReport
        {
            get
            {
                return comboBox1.SelectedIndex;
            }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            number = maskedTbNumber.Text.Replace(',', '.');
            PelengEntities pe = new PelengEntities();
            if (number.EndsWith("0"))
            {
                var specs = (from m in pe.Сборки
                             where m.НомерСборки == number
                             select m);
                if (specs.Count() == 0)
                {
                    MessageBox.Show("Спецификация с таким номером не существует!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                var specs = (from m in pe.Детали
                             where m.НомерДетали == number
                             select m);
                if (specs.Count() == 0)
                {
                    MessageBox.Show("Спецификация с таким номером не существует!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            }

        }
    }
}
