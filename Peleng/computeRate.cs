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
    public partial class computeRate : Form
    {
        float a, b, c, x, diam;
        int n = 0;
        private Детали det = new Детали();

        ErrorProvider epA = new ErrorProvider();
        ErrorProvider epB = new ErrorProvider();
        ErrorProvider epC = new ErrorProvider();
        ErrorProvider epX = new ErrorProvider();

        public Детали Det
        {
            get
            {
                return det;
            }
        }

        public computeRate()
        {
            InitializeComponent();
            maskedTextBox1.ValidatingType = maskedTextBox2.ValidatingType = maskedTextBox3.ValidatingType = typeof(float);
            maskedTextBox5.ValidatingType = typeof(uint);
            cbProfile.SelectedIndex = 0;
            label1.Text = "Диаметр, мм";
        }

        private void computeRate_Load(object sender, EventArgs e)
        {
            try
            {
                this.маркиМатериалаTableAdapter.Fill(this.pelengDataSet.МаркиМатериала);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            a = float.Parse(maskedTextBox1.Text);
            if (cbProfile.SelectedIndex == 1)
                b = float.Parse(maskedTextBox2.Text);
            c = float.Parse(maskedTextBox3.Text);
            if (maskedTextBox5.TextLength != 0)
                x = uint.Parse(maskedTextBox5.Text);
            n = (int)numericUpDown1.Value;
            listRate(a, b, c, n, x);
        }

        private void mtb_TextChanged(object sender, EventArgs e)
        {
            Validate(true);
            if (maskedTextBox2.Visible == true)
            {
                if ((epA.GetError(maskedTextBox1) == "") & (epB.GetError(maskedTextBox2) == "") &
                    (epC.GetError(maskedTextBox3) == "") & (epX.GetError(maskedTextBox5) == "") &
                    (maskedTextBox1.TextLength != 0) & (maskedTextBox2.TextLength != 0) &
                    (maskedTextBox3.TextLength != 0))
                    btnCompute.Enabled = true;
            }
            else
            {
                if ((epA.GetError(maskedTextBox1) == "") & (epC.GetError(maskedTextBox3) == "") & (epX.GetError(maskedTextBox5) == "") &
                    (maskedTextBox1.TextLength != 0) & (maskedTextBox3.TextLength != 0))
                    btnCompute.Enabled = true;
            }
        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (maskedTextBox1.TextLength > 4)
            {
                epA.SetError(maskedTextBox1, "Слишком длинное значение!");
                btnCompute.Enabled = false;
            }
            else if (!e.IsValidInput)
            {
                epA.SetError(maskedTextBox1, "Invalid Data Value");
                btnCompute.Enabled = false;
            }
            else if ((maskedTextBox1.Text.Contains('-')) | (maskedTextBox1.Text.Contains('+')) | (maskedTextBox1.Text.Equals("0")))
            {
                btnCompute.Enabled = false;
                epA.SetError(maskedTextBox1, "Invalid Data Value");
            }
            else
                epA.Clear();
        }

        private void maskedTextBox2_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (maskedTextBox2.Visible == true)
            {
                if (maskedTextBox2.TextLength > 4)
                {
                    epB.SetError(maskedTextBox2, "Слишком длинное значение!");
                    btnCompute.Enabled = false;
                }
                else if (!e.IsValidInput)
                {
                    epB.SetError(maskedTextBox2, "Invalid Data Value");
                    btnCompute.Enabled = false;
                }
                else if ((maskedTextBox2.Text.Contains('-')) | (maskedTextBox2.Text.Contains('+')) | (maskedTextBox2.Text.Equals("0")))
                {
                    btnCompute.Enabled = false;
                    epB.SetError(maskedTextBox2, "Invalid Data Value");
                }
                else
                    epB.Clear();
            }
        }

        private void maskedTextBox3_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (maskedTextBox3.TextLength > 4)
            {
                epC.SetError(maskedTextBox3, "Слишком длинное значение!");
                btnCompute.Enabled = false;
            }
            else if (!e.IsValidInput)
            {
                epC.SetError(maskedTextBox3, "Invalid Data Value");
                btnCompute.Enabled = false;
            }
            else if ((maskedTextBox3.Text.Contains('-')) | (maskedTextBox3.Text.Contains('+')) | (maskedTextBox3.Text.Equals("0")))
            {
                btnCompute.Enabled = false;
                epC.SetError(maskedTextBox3, "Invalid Data Value");
            }
            else
                epC.Clear();
        }

        private void maskedTextBox5_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (maskedTextBox5.TextLength > 4)
            {
                epX.SetError(maskedTextBox5, "Слишком длинное значение!");
                btnCompute.Enabled = false;
            }
            else if ((!e.IsValidInput) & (maskedTextBox5.TextLength != 0))
            {
                epX.SetError(maskedTextBox5, "Invalid Data Value");
                btnCompute.Enabled = false;
            }
            else if ((maskedTextBox5.Text.Contains('-')) | (maskedTextBox5.Text.Contains('+')))
            {
                btnCompute.Enabled = false;
                epX.SetError(maskedTextBox5, "Invalid Data Value");
            }
            else
                epX.Clear();
        }

        private float computeDiam(float x, float y)
        {
            return (float)Math.Pow(x * x + y * y, (double)1 / 2);
        }

        private void listRate(float a, float b, float c, int n, float x)
        {
            listView1.Items.Clear();
            PelengEntities pe = new PelengEntities();
            var matsDiam = (from m in pe.Материалы
                            where ((m.Профили.ВидПрофиля.Contains("Круг") || m.Профили.ВидПрофиля.Contains("Пруток")) &&
                            m.МаркиМатериала.НаименованиеМарки == cbMark.SelectedValue)
                            orderby m.Габарит
                            select m).ToList<Материалы>();
            var matsList = (from m in pe.Материалы
                            where ((!m.Профили.ВидПрофиля.Contains("Круг") & !m.Профили.ВидПрофиля.Contains("Пруток")) &&
                            m.МаркиМатериала.НаименованиеМарки == cbMark.SelectedValue)
                            orderby m.Габарит
                            select m).ToList<Материалы>();

            if (cbProfile.SelectedIndex == 1)
                diam = computeDiam(a, b);
            else
                diam = a;
            List<Детали> listDet = new List<Детали>();
            foreach (var m in matsDiam)
            {
                if (m.Габарит >= allowanceDiam(diam))
                {
                    listDet.Add(new Детали()
                    {
                        ДлинаЗаготовки = (int)((c + 2 + calcCut(m.Габарит)) * n + x + 0.6F),
                        ВыходДеталей = n,
                        МатериалID = m.МатериалID,
                        НормаРасхода = Math.Round(m.МаркиМатериала.Плотность / 1E6 * Math.PI * m.Габарит * m.Габарит / 4 * ((int)((c + 2 + calcCut(m.Габарит)) * n + x + 0.6F) + calcCutX(m.Габарит)) / n, 4)
                    });
                    break;
                }
            }
            if (cbProfile.SelectedIndex == 1)
            {
                diam = computeDiam(a, c);
                foreach (var m in matsDiam)
                {
                    if (m.Габарит >= allowanceDiam(diam))
                    {
                        listDet.Add(new Детали()
                        {
                            ДлинаЗаготовки = (int)((b + 2 + calcCut(m.Габарит)) * n + x + 0.6F),
                            ВыходДеталей = n,
                            МатериалID = m.МатериалID,
                            НормаРасхода = Math.Round(m.МаркиМатериала.Плотность / 1E6 * Math.PI * m.Габарит * m.Габарит / 4 * ((int)((b + 2 + calcCut(m.Габарит)) * n + x + 0.6F) + calcCutX(m.Габарит)) / n, 4)
                        });
                        break;
                    }
                }
                diam = computeDiam(c, b);
                foreach (var m in matsDiam)
                {
                    if (m.Габарит >= allowanceDiam(diam))
                    {
                        listDet.Add(new Детали()
                        {
                            ДлинаЗаготовки = (int)((a + 2 + calcCut(m.Габарит)) * n + x + 0.6F),
                            ВыходДеталей = n,
                            МатериалID = m.МатериалID,
                            НормаРасхода = Math.Round(m.МаркиМатериала.Плотность / 1E6 * Math.PI * m.Габарит * m.Габарит / 4 * ((int)((a + 2 + calcCut(m.Габарит)) * n + x + 0.6F) + calcCutX(m.Габарит)) / n, 4)
                        });
                        break;
                    }
                }
            }
            foreach (var m in matsList)     //расчёт единичных заготовок из листа
            {
                if (m.Габарит >= allowanceList(a))
                {
                    if (cbProfile.SelectedIndex == 0)
                        b = a;
                    int weight, length;
                    if ((m.Длина > m.Ширина)&(c>b))
                    {
                        weight = (int)((b + calcCutList(m.Габарит)) + 0.6F);
                        length = (int)((c + calcCutList(m.Габарит)) + 0.6F);
                        if ((m.Ширина >= b) & (m.Ширина < weight))
                            weight = m.Ширина.Value;
                        if ((m.Длина >= c) & (m.Длина < length))
                            length = m.Длина.Value;
                    }
                    else
                    {
                        weight = (int)((c + calcCutList(m.Габарит)) + 0.6F);
                        length = (int)((b + calcCutList(m.Габарит)) + 0.6F);
                        if ((m.Ширина >= c) & (m.Ширина < weight))
                            weight = m.Ширина.Value;
                        if ((m.Длина >= b) & (m.Длина < length))
                            length = m.Длина.Value;
                    }

                    if ((m.Ширина >= weight) & (m.Длина >= length))
                        listDet.Add(new Детали()
                        {
                            ДлинаЗаготовки = length,
                            ШиринаЗаготовки = weight,
                            ВыходДеталей = 1,
                            МатериалID = m.МатериалID,
                            НормаРасхода = Math.Round((m.МаркиМатериала.Плотность / 1E6 * m.Габарит * ((int)((b + calcCutList(m.Габарит)) + 0.6F) + calcCutXList(m.Габарит)) * ((int)((c + calcCutList(m.Габарит)) + 0.6F) + calcCutXList(m.Габарит))),4)
                        });
                    break;
                }
            }
            listDet.Sort();
            listView1.BeginUpdate();
            foreach (Детали detal in listDet)
            {
                var mat = (from m in pe.Материалы
                            where m.МатериалID==detal.МатериалID
                            select m).ToList<Материалы>();
                ListViewItem lvi;
                listView1.Items.Add(lvi=new ListViewItem(new string[] {mat.First().Ширина.HasValue?mat.First().Габарит + " x " + detal.ШиринаЗаготовки + " x " + detal.ДлинаЗаготовки:"\u00d8 "+ mat.First().Габарит + " x " + detal.ДлинаЗаготовки,
                                    detal.НормаРасхода.ToString(), detal.ВыходДеталей.ToString(),mat.First().НаименованиеМатериала}));
                lvi.Tag = detal;
            }
            listView1.EndUpdate();
            if (listView1.Items.Count != 0)
            {
                btnSelect.Enabled = true;
                listView1.Focus();
                listView1.Items[0].Selected = true;
            }
            else
                btnSelect.Enabled = false;
        }

        private float calcCut(double d)    //ширина реза детали от заготовки
        {
            if (d <= 10)
                return 2;
            if (d <= 40)
                return 3;
            if (d <= 60)
                return 3.5F;
            if (d <= 100)
                return 4;
            else
                return 5;
        }

        private float calcCutX(double d)    //ширина реза заготовки ленточной пилой
        {
            if (d <= 100)
                return 1.5F;
            if (d <= 200)
                return 2;
            return 3;
        }

        private int calcCutXList(double t)    //ширина реза заготовки из листа газорезкой
        {
            if (t <= 6)
                return 0;
            if (t <= 15)
                return 10;
            return 12;
        }

        private int calcCutList(double t)     //припуск под механическую обработку заготовки из листа
        {
            if (t <= 6)
                return 5;
            if (t <= 10)
                return 10;
            return 16;
        }

        private double allowanceDiam(double t)     //припуск под механическую обработку из круга
        {
            if ((checkBox1.Checked) & (cbProfile.SelectedIndex == 0))
                return t;
            else 
                return t + 1.8;
        }

        private double allowanceList(double t)     //припуск под механическую обработку из листа
        {
            if (checkBox1.Checked)
                return t;
            else
                return t + 3.5;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {            
            foreach (ListViewItem l in listView1.SelectedItems)
            {
                det = (Детали)l.Tag;
            }
        }

        private void cbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProfile.SelectedIndex == 0)
            {
                label1.Text = "Диаметр, мм";
                label2.Visible = false;
                maskedTextBox2.Text = "";
                maskedTextBox2.Visible = false;
                btnCompute.Enabled = false;
            }
            if (cbProfile.SelectedIndex == 1)
            {
                label1.Text = "Толщина, мм";
                label2.Visible = true;
                maskedTextBox2.Visible = true;
                maskedTextBox2.Clear();
                btnCompute.Enabled = false;
            }
            maskedTextBox1.Clear();
            maskedTextBox3.Clear();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                btnSelect.Enabled = false;
            else
                btnSelect.Enabled = true;
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            foreach (ListViewItem l in lv.SelectedItems)
            {
                det = (Детали)l.Tag;
            }
            this.DialogResult = DialogResult.OK;
        }
    }

    public partial class Детали : IComparable
    {
        public int CompareTo(object obj)
        {
            Детали a = (Детали)obj;
            if (this.НормаРасхода == a.НормаРасхода)
                return 0;
            else if (this.НормаРасхода > a.НормаРасхода)
                return 1;
            else return -1;
        }
    }
}
