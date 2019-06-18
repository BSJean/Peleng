using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Peleng
{
    public partial class specificationWork : Form
    {
        private string number;
        private string currentWay;
        private string currentName;

        public specificationWork()
        {
            InitializeComponent();
        }

        public specificationWork(string number)
            : this()
        {
            this.number = this.Text = tbNumber.Text = number;
            PelengEntities pe = new PelengEntities();
            var det = (from m in pe.Детали
                       where (m.НомерДетали == number)
                       select m);
            var sb = (from m in pe.Сборки
                      where (m.НомерСборки == number)
                      select m);
            int way = 0;
            if (det.Count() != 0)
            {
                tbName.Text = currentName = det.First().Наименование;
                way = det.First().МаршрутID;
                btnSave.Enabled = true;
                this.DialogResult = DialogResult.OK;
            }
            else if (sb.Count() != 0)
            {
                tbName.Text = currentName = sb.First().Наименование;
                way = sb.First().МаршрутID;
                btnSave.Enabled = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                btnSave.Enabled = false;
                this.DialogResult = DialogResult.OK;
            }
            if (way != 0)
            {
                var ways = (from m in pe.Маршруты
                            where (m.МаршрутID == way)
                            select m).ToList();
                foreach (var w in ways)
                {
                    tbWay.Text += w.НомерПодразделения + "-";
                }
                tbWay.Text = currentWay = tbWay.Text.Remove(tbWay.Text.Length - 1);
            }
            var grouped = from p in pe.Маршруты
                          orderby p.МаршрутID
                          group p by p.МаршрутID into grp
                          select new { ID = grp.Key, objWay = grp };
            Dictionary<int, string> waysDiction = new Dictionary<int, string>();
            foreach (var w in grouped.ToList())
            {
                string s = "";
                foreach (var r in w.objWay)
                {
                    s += r.НомерПодразделения + "-";
                }
                s = s.Remove(s.Length - 1);
                waysDiction.Add(w.ID, s);
            }
            tbWay.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbWay.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbWay.AutoCompleteCustomSource.AddRange(waysDiction.Values.ToArray());
        }

        public string ItemName
        {
            get
            {
                if (epName.GetError(tbName) == "")
                    return tbName.Text;
                else
                    return "";
            }
        }

        public int WayID
        {
            get
            {
                if ((epWay.GetError(tbWay) == "") & (tbWay.TextLength > 4))
                {
                    if (tbWay.Text.StartsWith("-"))
                        tbWay.Text = tbWay.Text.Remove(0, 1);
                    if (tbWay.Text.EndsWith("-"))
                        tbWay.Text = tbWay.Text.Remove(tbWay.TextLength - 1);
                    PelengEntities pe = new PelengEntities();
                    var det = (from m in pe.Детали
                               where (m.НомерДетали == number)
                               select m);
                    var sb = (from m in pe.Сборки
                              where (m.НомерСборки == number)
                              select m);
                    Dictionary<int, string> waysDiction = new Dictionary<int, string>();
                    var grouped = from p in pe.Маршруты
                                  orderby p.МаршрутID
                                  group p by p.МаршрутID into grp
                                  select new { ID = grp.Key, objWay = grp };

                    foreach (var w in grouped.ToList())
                    {
                        string s = "";
                        foreach (var r in w.objWay)
                        {
                            s += r.НомерПодразделения + "-";
                        }
                        s = s.Remove(s.Length - 1);
                        waysDiction.Add(w.ID, s);
                    }
                    int numberWay = 0;
                    foreach (int n in waysDiction.Keys)
                    {
                        if (tbWay.Text == waysDiction[n])
                        {
                            numberWay = n;
                            break;
                        }
                    }
                    string[] subWays = tbWay.Text.Split('-');
                    if (numberWay == 0)
                    {
                        int z = 1;
                        foreach (string s in subWays)
                            pe.Маршруты.AddObject(new Маршруты { МаршрутID = waysDiction.Count + 1, ПорядковыйНомер = z++, НомерПодразделения = s });
                        pe.SaveChanges();
                        waysDiction.Add(numberWay = waysDiction.Count + 1, tbWay.Text);
                    }
                    return numberWay;
                }
                else return 0;
            }
        }

        private void tabSpecification_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabSpecification.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabSpecification.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Coral);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)14.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void tabSpecification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSpecification.SelectedTab == tabAssembly)
            {
                    if (number.EndsWith("0"))
                        входящиеСборкиTableAdapter.Fill(pelengDataSet.ВходящиеСборки, number);
                    else
                    {
                        tsBtnAdd.Enabled = false;
                        tsBtnDelete.Enabled = false;
                        tsBtnEdit.Enabled = false;
                        btnSaveAssembly.Enabled = false;
                    }
            }

            if (tabSpecification.SelectedTab == tabMain)
            {
                tbNumber.Text = number;
                tbName_TextChanged(sender, e);
                tbWay_TextChanged(sender, e);
            }

            if (tabSpecification.SelectedTab == tabMaterial)
            {
                if (!number.EndsWith("0"))
                {
                    ItemMaterial im = new ItemMaterial();
                    im.Dock = System.Windows.Forms.DockStyle.Fill;
                    PelengEntities pe = new PelengEntities();
                    var det = (from m in pe.Детали
                               where (m.НомерДетали == number)
                               select m);
                    if (det.Count() != 0)
                    {
                        foreach (Детали d in det)
                        {
                            im.Length = d.ДлинаЗаготовки;
                            im.Rate = d.НормаРасхода;
                            im.Material = d.Материалы;
                            im.Gabarit = d.Материалы.Габарит;
                            im.N = d.ВыходДеталей;
                            if (d.ШиринаЗаготовки.HasValue)
                                im.Weight = d.ШиринаЗаготовки.Value;
                        }
                    }
                    else
                    {
                        Детали d = new Детали();
                        d.НомерДетали = number;
                        d.Наименование = tbName.Text;
                        d.Материалы = im.Material;
                        d.ДлинаЗаготовки = im.Length;
                    }
                    tabMaterial.Controls.Add(im);
                }
            }
        }

        private void specificationWork_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbWay.Text.StartsWith("-"))
                tbWay.Text = tbWay.Text.Remove(0,1);
            if (tbWay.Text.EndsWith("-"))
                tbWay.Text = tbWay.Text.Remove(tbWay.TextLength - 1);
            PelengEntities pe = new PelengEntities();
            var det = (from m in pe.Детали
                       where (m.НомерДетали == number)
                       select m);
            var sb = (from m in pe.Сборки
                      where (m.НомерСборки == number)
                      select m);
            Dictionary<int,string> waysDiction = new Dictionary<int,string>();            
            var grouped = from p in pe.Маршруты
                          orderby p.МаршрутID
                          group p by p.МаршрутID into grp
                          select new { ID = grp.Key, objWay = grp };

            foreach (var w in grouped.ToList())
            {
                string s="";
                foreach (var r in w.objWay)
                {
                    s += r.НомерПодразделения + "-";
                }
                s = s.Remove(s.Length - 1);
                waysDiction.Add(w.ID, s);
            }
            int numberWay=0;
            foreach (int n in waysDiction.Keys)
            {
                if (tbWay.Text == waysDiction[n])
                {
                    numberWay = n;
                    break;
                }
            }
            string[] subWays = tbWay.Text.Split('-');
            if (numberWay == 0)
            {
                int z=1;
                foreach (string s in subWays)
                    pe.Маршруты.AddObject(new Маршруты { МаршрутID = waysDiction.Count+1, ПорядковыйНомер = z++, НомерПодразделения = s });
                pe.SaveChanges();
                waysDiction.Add(numberWay=waysDiction.Count + 1, tbWay.Text);
            }            
            tbWay.AutoCompleteCustomSource.AddRange(waysDiction.Values.ToArray());
            if (det.Count() != 0)
            {
                det.First().Наименование = tbName.Text;
                det.First().МаршрутID = numberWay;
                pe.SaveChanges();
            }
            else if (sb.Count() != 0)
            {
                sb.First().Наименование = tbName.Text;
                sb.First().МаршрутID = numberWay;
                pe.SaveChanges();
            }
            else if (number.EndsWith("0"))
            {
                Сборки assembly = new Сборки();
                assembly.Наименование = tbName.Text;
                assembly.МаршрутID = numberWay;
                assembly.НомерСборки = number;
                pe.Сборки.AddObject(assembly);
                pe.SaveChanges();
            }
            else
            {
                tabSpecification.SelectedTab = tabMaterial;
            }
            currentName = tbName.Text;
            currentWay = tbWay.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            PelengEntities pe = new PelengEntities();
            var currentAssembly = (from m in pe.Сборки
                                   where m.НомерСборки == number
                                   select m);
            if (currentAssembly.Count() == 0)
            {
                if (MessageBox.Show("Текущая спецификация не внесена в базу.\nСохранить данную спецификацию?", "Внимание!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                else
                {
                    if (btnSave.Enabled)
                        btnSave_Click(sender, e);
                    else
                    {
                        MessageBox.Show("Необходимо правильно заполнить все поля", "Внимание!",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        tabSpecification.SelectedTab = tabMain;
                        return;
                    }

                }
            }
            addAssembly add = new addAssembly(number);

            if (add.ShowDialog(this) == DialogResult.OK)
            {
                bool exist = false;
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == add.AddAssembly.НомерВхСборки)
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                    pelengDataSet.ВходящиеСборки.Rows.Add(add.AddAssembly.НомерВхСборки, add.AddAssembly.Количество, number);
                }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                }
                else
                {
                    tsBtnEdit_Click(sender, e);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void btnSaveAssembly_Click(object sender, EventArgs e)
        {
            входящиеСборкиTableAdapter.Update(pelengDataSet);
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                string current = dataGridView1.Rows[index].Cells[0].Value.ToString();
                int k = (int)dataGridView1.Rows[index].Cells[1].Value;
                addAssembly add = new addAssembly(number, current, k);
                PelengEntities pe = new PelengEntities();
                if (add.ShowDialog(this) == DialogResult.OK)
                {
                    if (add.AddAssembly.НомерВхСборки == current && add.AddAssembly.Количество == k)
                        return;
                    if (add.AddAssembly.НомерВхСборки == current)
                    {
                        dataGridView1.Rows[index].Cells[1].Value = add.AddAssembly.Количество;
                    }
                    else
                    {
                        bool exist = false;
                        int newIndex = 0;
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            if (dr.Cells[0].Value.ToString() == add.AddAssembly.НомерВхСборки)
                            {
                                exist = true;
                                newIndex = dr.Index;
                            }
                        }
                        if (!exist)
                        {
                            dataGridView1.Rows.RemoveAt(index);
                            pelengDataSet.ВходящиеСборки.Rows.Add(add.AddAssembly.НомерВхСборки, add.AddAssembly.Количество, number);
                        }
                        else
                        {
                            dataGridView1.Rows[newIndex].Cells[1].Value = add.AddAssembly.Количество;
                            dataGridView1.Rows.RemoveAt(index);
                        }
                    }
                }
            }
        }

        private void specificationWork_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                epName.SetError(tbName, "Не задано наименование!");
            }
            else if (tbName.TextLength > 80)
            {
                epName.SetError(tbName, "Слишком длинное наименование!");
            }
            else
                epName.Clear();
            Validate();
        }

        private void tbWay_TextChanged(object sender, EventArgs e)
        {
            if (tbWay.TextLength > 84)
            {
                epWay.SetError(tbWay, "Слишком длинный маршрут!");
                Validate();
                return;
            }
            string [] subWays = tbWay.Text.Split('-');
            bool rightWay=false;            
            PelengEntities pe = new PelengEntities();
            List<string> listWays = (from m in pe.Подразделения
                                     select m.НомерПодразделения).ToList();
            foreach (string s in subWays)
            {
                if (s.Length == 0)
                    continue;
                if (listWays.Contains(s))
                    rightWay = true;
                else
                {
                    rightWay = false;
                    break;
                }
            }
            if (rightWay)
            {
                epWay.Clear();
            }
            else
            {
                epWay.SetError(tbWay, "Ошибка в кодировке подразделения!");
            }
            Validate();
        }

        private void tbWay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 'К') | (e.KeyChar == 'к'))
            {
                e.KeyChar = 'К';
                return;
            }
            if ((tbWay.TextLength > 0) & (tbWay.SelectionStart>0))
                if (tbWay.Text.ElementAt(tbWay.SelectionStart - 1) == '-' & (e.KeyChar == '-'))
                {
                    e.Handled = true;
                }
            if ((tbWay.TextLength > 0) & (tbWay.SelectionStart < tbWay.TextLength))
                if (tbWay.Text.ElementAt(tbWay.SelectionStart) == '-' & (e.KeyChar == '-'))
                {
                    e.Handled = true;
                    return;
                }
            if (!Char.IsNumber(e.KeyChar) & (e.KeyChar != '-') & (e.KeyChar != 8))
                e.Handled = true;
        }

        private void tabMain_Validating(object sender, CancelEventArgs e)
        {
            if (epName.GetError(tbName) == "" & epWay.GetError(tbWay) == "")
                btnSave.Enabled = true;
            else 
                btnSave.Enabled = false;
            if (tbWay.TextLength < 1 || tbName.TextLength < 1)
                btnSave.Enabled = false;
        }

    }    
}
