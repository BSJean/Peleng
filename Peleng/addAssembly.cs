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
    public partial class addAssembly : Form
    {
        private ВходящиеСборки add = new ВходящиеСборки();

        public addAssembly(string number)
        {
            InitializeComponent();
            if (maskedTbNumber.CanFocus)
                maskedTbNumber.Focus();
            maskedTbNumber.Select(0, 0);
            maskedTbNumber.Mask = "0000.00.00.000";
            maskedTbNumber.PromptChar = '_';
            add.НомерСборки = number;
        }

        public addAssembly(string number, string current, int k)
            : this(number)
        {
            this.Text = "Редактирование записи";
            maskedTbNumber.Text = current;
            numericUpDown1.Value = k;
        }

        public ВходящиеСборки AddAssembly
        {
            get
            {
                return add;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string addNumber = maskedTbNumber.Text.Replace(',', '.');
            add.Количество = (int)numericUpDown1.Value;
            PelengEntities pe = new PelengEntities();
            var assemblies = (from m in pe.Сборки
                              where m.НомерСборки == addNumber
                              select m);
            List<string> inAssemblies = new List<string>();
            listAssembly(add.НомерСборки, inAssemblies);
            if (assemblies.Count() != 0)
                if (addNumber == add.НомерСборки)
                {
                    string message = "Сборка " + addNumber + " не может входить сама в себя!";
                    MessageBox.Show(message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
                else if (!inAssemblies.Contains(addNumber))
                {
                    add.НомерВхСборки = addNumber;
                }
                else
                {
                    string message = "Сборка " + addNumber + " не может входить в сборку " + add.НомерСборки + " !";
                    MessageBox.Show(message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            else
            {
                if (MessageBox.Show("Спецификация с таким номером не существует.\nСоздать данную спецификацию?", "Внимание!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    specificationWork specWork = new specificationWork(addNumber);
                    if (specWork.ShowDialog(this.ParentForm) == DialogResult.OK)
                    {
                        add.НомерВхСборки = addNumber;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        this.DialogResult = DialogResult.Cancel;
                }
                else
                    this.DialogResult = DialogResult.None;
            }
        }

        private void maskedTbNumber_TextChanged(object sender, EventArgs e)
        {
            if (maskedTbNumber.MaskFull)
            {
                if (maskedTbNumber.Text[13] != '0')
                {
                    maskedTbNumber.Text = maskedTbNumber.Text.Remove(13);
                    maskedTbNumber.Text += "0";
                }

                btnOK.Enabled = true;
            }
            else
                btnOK.Enabled = false;
        }

        private void listAssembly(string number, List<string> assemblies)
        {
            PelengEntities pe = new PelengEntities();
            List<string> newAssemblies = new List<string>();
            var listAssemblies = (from m in pe.ВходящиеСборки
                                  where m.НомерВхСборки == number
                                  select m);
            foreach (var l in listAssemblies)
            {
                if (!assemblies.Contains(l.НомерСборки))
                {
                    newAssemblies.Add(l.НомерСборки);
                }
            }
            assemblies.AddRange(newAssemblies);
            if (newAssemblies.Count != 0)
            {
                foreach (string s in newAssemblies)
                {
                    listAssembly(s, assemblies);
                }
            }
        }
    }
}
