using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Peleng
{
    public partial class ItemMaterial : UserControl
    {
        private Материалы material;
        private double gabarit, length, rate, weight;
        private int n;
        ErrorProvider epA = new ErrorProvider();
        ErrorProvider epB = new ErrorProvider();
        ErrorProvider epX = new ErrorProvider();

        public ItemMaterial()
        {
            InitializeComponent();
            maskedTextBox1.ValidatingType = maskedTextBox2.ValidatingType = typeof(uint);
            mtbRate.ValidatingType = typeof(float);
        }

        public int N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
            }
        }

        public Материалы Material
        {
            get
            {
                return material;
            }

            set
            {
                material = value;
            }
        }

        public double Gabarit
        {
            get
            {
                return gabarit;
            }
            set
            {
                gabarit = value;
            }
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            computeRate rateForm = new computeRate();
            Детали det = new Детали();
            PelengEntities pe = new PelengEntities();
            var mat = (from m in pe.Материалы
                       where (m.МатериалID == det.МатериалID)
                       select m);
            if (rateForm.ShowDialog(this) == DialogResult.OK)
            {
                det = rateForm.Det;
                mtbRate.Text = det.НормаРасхода.ToString();
                epA.Clear();
                epB.Clear();
                epX.Clear();
                if (det.ШиринаЗаготовки.HasValue)
                {
                    maskedTextBox1.Text = det.ШиринаЗаготовки.ToString();
                    maskedTextBox2.Text = det.ДлинаЗаготовки.ToString();
                    maskedTextBox2.Visible = true;
                    label6.Visible = true;
                    lbType.Visible = false;
                }
                else
                {
                    maskedTextBox1.Text = det.ДлинаЗаготовки.ToString();
                    maskedTextBox2.Visible = false;
                    label6.Visible = false;
                    lbType.Visible = true;
                    lbType.Text = "\u00d8";
                }
                numericUpDown1.Value = det.ВыходДеталей;
                lbGabarit.Text = mat.First().Габарит.ToString();
                tbMat.Text = mat.First().НаименованиеМатериала;
                tbMat.Tag = mat.First();
                label5.Visible = true;
                maskedTextBox1.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PelengEntities pe = new PelengEntities();
            var det = (from m in pe.Детали
                       where (m.НомерДетали == this.ParentForm.Text)
                       select m);
            var mat = (from m in pe.Материалы
                       where (m.НаименованиеМатериала == tbMat.Text)
                       select m);
            if (det.Count() != 0)
            {
                det.First().ВыходДеталей = (int)numericUpDown1.Value;
                det.First().НормаРасхода = double.Parse(mtbRate.Text);
                det.First().МатериалID = mat.First().МатериалID;
                if (maskedTextBox2.Visible)
                {
                    det.First().ДлинаЗаготовки = double.Parse(maskedTextBox2.Text);
                    det.First().ШиринаЗаготовки = double.Parse(maskedTextBox1.Text);
                }
                else
                {
                    det.First().ДлинаЗаготовки = double.Parse(maskedTextBox1.Text);
                    det.First().ШиринаЗаготовки = null;
                }
                pe.SaveChanges();
            }
            else
            {
                if (((specificationWork)ParentForm).WayID != 0 & ((specificationWork)ParentForm).ItemName != "")
                {
                    Детали d = new Детали();
                    d.Наименование = ((specificationWork)ParentForm).ItemName;
                    d.НомерДетали = this.ParentForm.Text;
                    d.МаршрутID = ((specificationWork)ParentForm).WayID;
                    d.МатериалID = ((Материалы)tbMat.Tag).МатериалID;
                    d.ВыходДеталей = (int)numericUpDown1.Value;
                    d.НормаРасхода = double.Parse(mtbRate.Text);
                    if (maskedTextBox2.Visible)
                    {
                        d.ДлинаЗаготовки = double.Parse(maskedTextBox2.Text);
                        d.ШиринаЗаготовки = double.Parse(maskedTextBox1.Text);
                    }
                    else
                    {
                        d.ДлинаЗаготовки = double.Parse(maskedTextBox1.Text);
                        d.ШиринаЗаготовки = null;
                    }
                    pe.AddToДетали(d);
                    pe.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Необходимо правильно заполнить все поля в разделе с основной информацией", "Внимание!",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void ItemMaterial_Load(object sender, EventArgs e)
        {
            toolTipMats.SetToolTip(btnMaterialChoose, "Выбор материала из номенклатуры");
            lbType.Text = "\u00d8";
            if ((length != 0) & (rate != 0) & (gabarit != 0))
            {
                if (weight != 0)
                {
                    maskedTextBox1.Text = weight.ToString();
                    maskedTextBox2.Text = length.ToString();
                    maskedTextBox2.Visible = true;
                    label6.Visible = true;
                    lbType.Visible = false;
                }
                else
                {
                    maskedTextBox1.Text = length.ToString();
                    maskedTextBox2.Visible = false;
                    label6.Visible = false;
                    lbType.Visible = true;
                }
                mtbRate.Text = rate.ToString();
                lbGabarit.Text = gabarit.ToString();
                tbMat.Text = material.НаименованиеМатериала;
                tbMat.Tag = material;
                numericUpDown1.Value = n;                
            }
            else
            {
                maskedTextBox2.Visible = false;
                label6.Visible = false;
                lbType.Visible = false;
                maskedTextBox1.Visible = false;
                label5.Visible = false;
                btnSave.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnMaterialChoose_Click(object sender, EventArgs e)
        {
            listMaterial listMats = new listMaterial();
            if (listMats.ShowDialog(this) == DialogResult.OK)
            {
                Материалы m = new Материалы();
                m = listMats.Material;
                tbMat.Text = m.НаименованиеМатериала;
                lbGabarit.Text = m.Габарит.ToString();
                if (m.Ширина.HasValue)
                {
                    lbType.Visible = false;
                    maskedTextBox2.Visible = true;
                    label6.Visible = true;
                }
                else
                {
                    lbType.Visible = true;
                    maskedTextBox2.Visible = false;
                    label6.Visible = false;
                    maskedTextBox2.Clear();
                }
                tbMat.Tag = m;                
                maskedTextBox1.Visible = true;
                label5.Visible = true;
            }
        }

        private void Textbox_TextChanged(object sender, EventArgs e)
        {
            Validate(true);
            if ((epA.GetError(maskedTextBox1) == "") & (maskedTextBox2.Visible == true ? epB.GetError(maskedTextBox2) == "" : true) &
                (epX.GetError(mtbRate) == "") & (tbMat.TextLength != 0) & (maskedTextBox1.TextLength != 0) &
                (maskedTextBox2.Visible == true ? maskedTextBox2.TextLength != 0 : true) & (mtbRate.TextLength != 0))
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            TypeValidation(sender, e, epA);
            if (tbMat.Tag != null)
            {                
                Материалы m = (Материалы)tbMat.Tag;
                int weight1, length1, a, b;
                if ((epA.GetError(maskedTextBox1) == "") & (m.Ширина.HasValue) & (m.Длина.HasValue))
                {
                    if (m.Длина > m.Ширина)
                    {
                        length1 = m.Длина.Value;
                        weight1 = m.Ширина.Value;
                    }
                    else
                    {
                        weight1 = m.Длина.Value;
                        length1 = m.Ширина.Value;
                    }
                    a = Int32.Parse(maskedTextBox1.Text);
                    if (((epB.GetError(maskedTextBox2) == "") | (epB.GetError(maskedTextBox2) == "Превышен габаритный размер!")) & (maskedTextBox2.TextLength != 0))
                    {
                        if (a > (b = Int32.Parse(maskedTextBox2.Text)))
                        {
                            if (a > length1)
                                epA.SetError(maskedTextBox1, "Превышен габаритный размер!");
                            else
                                epA.Clear();
                            if (b > weight1)
                                epB.SetError(maskedTextBox2, "Превышен габаритный размер!");
                            else
                                epB.Clear();
                        }
                        else if ((epB.GetError(maskedTextBox2) == "") & (a < b))
                        {
                            if (b > length1)
                                epB.SetError(maskedTextBox2, "Превышен габаритный размер!");
                            else
                                epB.Clear();
                            if (a > weight1)
                                epA.SetError(maskedTextBox1, "Превышен габаритный размер!");
                            else
                                epA.Clear();
                        }
                    }
                    else if (a > length1)
                        epA.SetError(maskedTextBox1, "Превышен габаритный размер!");
                }
            }
        }

        private void TypeValidation(object obj, TypeValidationEventArgs e, ErrorProvider ep)
        {
            MaskedTextBox mtb = (MaskedTextBox)obj;
            if (!e.IsValidInput)
            {
                ep.SetError(mtb, "Invalid Data Value");
                btnSave.Enabled = false;
            }
            else if ((mtb.Text.Contains('-')) | (mtb.Text.Contains('+')) | (mtb.Text.Equals("0")))
            {
                btnSave.Enabled = false;
                ep.SetError(mtb, "Invalid Data Value");
            }
            else if (mtb.TextLength > 7)
            {
                btnSave.Enabled = false;
                ep.SetError(mtb, "Слишком длинное значение!");
            }
            else
                ep.Clear();
        }

        private void maskedTextBox2_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            TypeValidation(sender, e, epB);
            if (tbMat.Tag != null)
            {                
                Материалы m = (Материалы)tbMat.Tag;
                int weight1, length1, a, b;
                if ((epB.GetError(maskedTextBox2) == "") & (m.Ширина.HasValue) & (m.Длина.HasValue))
                {
                    if (m.Длина > m.Ширина)
                    {
                        length1 = m.Длина.Value;
                        weight1 = m.Ширина.Value;
                    }
                    else
                    {
                        weight1 = m.Длина.Value;
                        length1 = m.Ширина.Value;
                    }
                    b = Int32.Parse(maskedTextBox2.Text);
                    if (((epA.GetError(maskedTextBox1) == "") | (epA.GetError(maskedTextBox1) == "Превышен габаритный размер!")) & (maskedTextBox1.TextLength != 0))
                    {
                        if ((a = Int32.Parse(maskedTextBox1.Text)) > b)
                        {
                            if (a > length1)
                                epA.SetError(maskedTextBox1, "Превышен габаритный размер!");
                            else
                                epA.Clear();
                            if (b > weight1)
                                epB.SetError(maskedTextBox2, "Превышен габаритный размер!");
                            else
                                epB.Clear();
                        }
                        else if ((epA.GetError(maskedTextBox1) == "") & (a < b))
                        {
                            if (b > length1)
                                epB.SetError(maskedTextBox2, "Превышен габаритный размер!");
                            else
                                epB.Clear();
                            if (a > weight1)
                                epA.SetError(maskedTextBox1, "Превышен габаритный размер!");
                            else
                                epA.Clear();
                        }
                    }
                    else if (b > length1)
                        epB.SetError(maskedTextBox2, "Превышен габаритный размер!");
                }
            }
        }

        private void mtbRate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            TypeValidation(sender, e, epX);
        }
    }
}
