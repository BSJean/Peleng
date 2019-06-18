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
    public partial class specificationForm : Form
    {
        private SqlConnection con;
        private SqlCommand command;
        private SqlDataAdapter sda;
        private DataTable dt;
        
        public specificationForm()
        {
            InitializeComponent();
            connectDB();
        }

        public void connectDB()
        {
            try
            {
                con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Peleng.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                command = new SqlCommand(@"SELECT     Сборки.НомерСборки AS Спецификации, Наименование
                                        FROM         Сборки
                                        union all
                                        SELECT     Детали.НомерДетали AS Спецификации, Наименование
                                        FROM         Детали
                                        order by Спецификации");
                command.Connection = con;
                sda = new SqlDataAdapter(command);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void specificationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
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

                    foreach (Form o in this.MdiParent.MdiChildren)
                    {
                        if (o.Text == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())
                        {
                            o.Activate();
                            return;
                        }
                    }
                    specificationWork specWork = new specificationWork(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    specWork.MdiParent = this.ParentForm;
                    specWork.WindowState = FormWindowState.Maximized;
                    specWork.Show();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void tsCreate_Click(object sender, EventArgs e)
        {
            specificationEnterNumber specNumber = new specificationEnterNumber();
            specNumber.ShowDialog(this.ParentForm);
        }

        private void specificationForm_Activated(object sender, EventArgs e)
        {
            connectDB();
        }
                
    }
}
