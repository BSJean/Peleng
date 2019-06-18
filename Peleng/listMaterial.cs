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
    public partial class listMaterial : Form
    {
        private SqlConnection con;
        private SqlCommand command;
        private SqlDataAdapter sda;
        private DataTable dt;
        private string queryMat;
        private Материалы material = new Материалы();

        public listMaterial()
        {
            InitializeComponent();
        }

        public Материалы Material
        {
            get
            {
                return material;
            }
        }

        private void listMaterial_Load(object sender, EventArgs e)
        {            
            this.маркиМатериалаTableAdapter.Fill(this.pelengDataSet.МаркиМатериала);            
            rbFull.Checked = true;
        }

        private void rbFull_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbFull.Checked == true)
                {                    
                    con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Peleng.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    command = new SqlCommand(@"SELECT     НаименованиеМатериала as [Наименование материала], Габарит
                                            FROM   Материалы
                                            ORDER by Габарит");
                    command.Connection = con;
                    sda = new SqlDataAdapter(command);
                    dt = new DataTable();
                    sda.Fill(dt);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    dataGridView1.DataSource = bs;
                }
                else
                {
                    queryMat = cbMaterial.Text;
                    con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Peleng.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    command = new SqlCommand(@"SELECT     НаименованиеМатериала as [Наименование материала], Габарит
                                            FROM   Материалы, МаркиМатериала
                                            WHERE Материалы.МаркаID=МаркиМатериала.МаркаID and МаркиМатериала.НаименованиеМарки=@queryMat
                                            ORDER by Габарит");
                    command.Parameters.Add("@queryMat", SqlDbType.VarChar, 20);
                    command.Parameters["@queryMat"].Value = queryMat;
                    command.Connection = con;
                    sda = new SqlDataAdapter(command);
                    dt = new DataTable();
                    sda.Fill(dt);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    dataGridView1.DataSource = bs;
                    rbMark.Checked = true;
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void cbMaterial_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                rbMark.Checked = true;
                queryMat = cbMaterial.Text;
                con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Peleng.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                command = new SqlCommand(@"SELECT     НаименованиеМатериала as [Наименование материала], Габарит
                                            FROM   Материалы, МаркиМатериала
                                            WHERE Материалы.МаркаID=МаркиМатериала.МаркаID and МаркиМатериала.НаименованиеМарки=@queryMat
                                            ORDER by Габарит");
                command.Parameters.Add("@queryMat", SqlDbType.VarChar, 20);
                command.Parameters["@queryMat"].Value = queryMat;
                command.Connection = con;
                sda = new SqlDataAdapter(command);
                dt = new DataTable();
                sda.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
            }

            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            material.НаименованиеМатериала = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            PelengEntities pe = new PelengEntities();
            var mats = (from m in pe.Материалы
                        where m.НаименованиеМатериала == material.НаименованиеМатериала
                        select m);
            material = mats.Single();
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
                    btnChoose_Click(sender, e);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
