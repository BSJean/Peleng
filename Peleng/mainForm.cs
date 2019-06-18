using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Peleng
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = this.Text;
        }

        private void specificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form o in MdiChildren)
            {
                if (o.Text == "Спецификации номенклатуры")
                {
                    o.Activate();
                    return;
                }
            }
            specificationForm specForm = new specificationForm();
            specForm.MdiParent = this;
            specForm.WindowState = FormWindowState.Maximized;
            specForm.Show();
        }

        private void mainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                toolStripStatusLabel1.Text = ActiveMdiChild.Text;
            else
                toolStripStatusLabel1.Text = this.Text;
        }

        private void расположитьПодрядToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void расположитьГоризонтальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void расположитьВертикальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void ведомостьВходимостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportItemEnter report = new reportItemEnter();

            if (report.ShowDialog(this) == DialogResult.OK)
            {
                PelengEntities pe = new PelengEntities();
                string name;
                List<Dictionary<string, int>> fullList = new List<Dictionary<string, int>>();
                List<string> needRead = new List<string>();

                if (report.Number.EndsWith("0"))
                {
                    var specs = (from m in pe.Сборки
                                 where m.НомерСборки == report.Number
                                 select m).First();
                    name = specs.Наименование;
                    var inAssembly = (from m in pe.ВходящиеСборки
                                      where m.НомерВхСборки == report.Number
                                      select m).ToList();
                    foreach (ВходящиеСборки vs in inAssembly)
                    {
                        Dictionary<string, int> dt = new Dictionary<string, int>();
                        dt.Add(vs.НомерСборки, vs.Количество);
                        fullList.Add(dt);
                        needRead.Add(vs.НомерСборки);
                    }
                }
                else
                {
                    var specs = (from m in pe.Детали
                                 where m.НомерДетали == report.Number
                                 select m).First();
                    name = specs.Наименование;
                    var inAssembly = (from m in pe.СборкиДетали
                                      where m.НомерДетали == report.Number
                                      select m).ToList();
                    foreach (СборкиДетали d in inAssembly)
                    {
                        Dictionary<string, int> dt = new Dictionary<string, int>();
                        dt.Add(d.НомерСборки, d.Количество);
                        fullList.Add(dt);
                        needRead.Add(d.НомерСборки);
                    }
                }

                while (needRead.Count != 0)
                {
                    string s = needRead[0];
                    for (int i = 0; i < fullList.Count; i++)
                    {
                        if (fullList[i].Last().Key == s)
                        {
                            var newAssembly = (from m in pe.ВходящиеСборки
                                               where m.НомерВхСборки == s
                                               select m).ToList();
                            int c = 0;
                            IDictionary<string, int> dt = new Dictionary<string, int>();
                            foreach (string key in fullList[i].Keys)
                            {
                                dt.Add(key, fullList[i][key]);
                            }
                            foreach (ВходящиеСборки vs in newAssembly)
                            {
                                c++;
                                if (c > 1)
                                {
                                    dt.Add(vs.НомерСборки, vs.Количество);
                                    fullList.Add(new Dictionary<string,int>(dt));
                                    dt.Remove(vs.НомерСборки);
                                }
                                else
                                {
                                    fullList[i].Add(vs.НомерСборки, vs.Количество);
                                }
                                needRead.Add(vs.НомерСборки);
                            }
                        }
                    }
                    needRead.Remove(s);
                }
                
                Dictionary<string, int> dtTypeNull = new Dictionary<string, int>();
                Dictionary<string, Dictionary<string, int>> listDtOne = new Dictionary<string, Dictionary<string, int>>();

                foreach (Dictionary<string, int> dt in fullList)
                {
                    string str = report.Number;
                    int n = 1;
                    foreach (string s in dt.Keys)
                    {
                        str += " (" + dt[s] + ") --> " + s;
                        n *= dt[s];
                    }
                    if (report.TypeReport == 0)
                    {
                        if (!dtTypeNull.ContainsKey(dt.First().Key))
                            dtTypeNull.Add(dt.First().Key, dt.First().Value);
                    }
                    else
                    {
                        if (!listDtOne.ContainsKey(dt.Last().Key))
                        {
                            Dictionary<string, int> lastDt = new Dictionary<string, int>();
                            lastDt.Add(str, n);
                            listDtOne.Add(dt.Last().Key, lastDt);
                        }
                        else
                        {
                            listDtOne[dt.Last().Key].Add(str, n);
                        }
                    }
                    n = 1;
                }


                Excel.Application application = new Excel.Application();
                Object missing = Type.Missing;
                //добавили книгу
                application.Workbooks.Add(missing);
                Excel.Worksheet sheet = (Excel.Worksheet)application.ActiveSheet;
                if (report.TypeReport == 0)
                {
                    if (dtTypeNull.Count != 0)
                        typeNull(sheet, dtTypeNull);
                    else
                    {
                        addExcelCell(sheet, 3, 1, "Первичная входимость", "Times New Roman", 16, true);
                        if (report.Number.EndsWith("0"))
                            addExcelCell(sheet, 6, 1, "Данная сборка не входит ни в одно изделие!", "Times New Roman", 14, true);
                        else
                            addExcelCell(sheet, 6, 1, "Данная деталь не входит ни в одно изделие!", "Times New Roman", 14, true);
                    }
                }
                else if (report.TypeReport == 1)
                {
                    if (listDtOne.Count != 0)
                        typeOne(sheet, listDtOne);
                    else
                    {
                        addExcelCell(sheet, 3, 1, "Полная входимость без цепочки", "Times New Roman", 16, true);
                        if (report.Number.EndsWith("0"))
                            addExcelCell(sheet, 6, 1, "Данная сборка не входит ни в одно изделие!", "Times New Roman", 14, true);
                        else
                            addExcelCell(sheet, 6, 1, "Данная деталь не входит ни в одно изделие!", "Times New Roman", 14, true);
                    }
                }
                else
                {
                    if (listDtOne.Count != 0)
                        typeTwo(sheet, listDtOne);
                    else
                    {
                        addExcelCell(sheet, 3, 1, "Полная входимость с цепочкой", "Times New Roman", 16, true);
                        if (report.Number.EndsWith("0"))
                            addExcelCell(sheet, 6, 1, "Данная сборка не входит ни в одно изделие!", "Times New Roman", 14, true);
                        else
                            addExcelCell(sheet, 6, 1, "Данная деталь не входит ни в одно изделие!", "Times New Roman", 14, true);
                    }
                }
                addExcelCell(sheet, 1, 1, System.DateTime.Now.ToString(), "Times New Roman", 12, true);                
                addExcelCell(sheet, 4, 1, report.Number + " " + name, "Times New Roman", 16, true);                
                (sheet.get_Range("A3", "D3") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;                
                application.Visible = true;
            }
        }

        private void addExcelCell(Excel.Worksheet sheet, int Column, int Cell, string Text, string Font, int FontSize, bool FontBold)
        {
            //вписываем текст
            sheet.Cells[Column, Cell] = Text;
            //жирность
            (sheet.Cells[Column, Cell] as Excel.Range).Font.Bold = FontBold;
            (sheet.Cells[Column, Cell] as Excel.Range).Font.Name = Font;
            (sheet.Cells[Column, Cell] as Excel.Range).Font.Size = FontSize;
            //(sheet.Cells[Column, Cell] as Excel.Range).NumberFormat = "@";
        }

        private void typeNull(Excel.Worksheet sheet, Dictionary<string, int> dt)
        {
            PelengEntities pe = new PelengEntities();
            int c = 1, row = 7;
            addExcelCell(sheet, 3, 1, "Первичная входимость", "Times New Roman", 16, true);
            addExcelCell(sheet, 6, 1, "№", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 2, "ДСЕ", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 3, "Наименование", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 4, "Кол-во", "Times New Roman", 14, true);            
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDouble;

            foreach (string s in dt.Keys)
            {
                var assembly = (from m in pe.Сборки
                                where m.НомерСборки == s
                                select m);
                addExcelCell(sheet, row, 1, c++.ToString(), "Times New Roman", 14, true);
                addExcelCell(sheet, row, 2, assembly.First().НомерСборки, "Times New Roman", 14, true);
                addExcelCell(sheet, row, 3, assembly.First().Наименование, "Times New Roman", 14, true);
                addExcelCell(sheet, row, 4, dt[s].ToString(), "Times New Roman", 14, true);
                for (int i = 1; i <= 4; i++)
                {
                    (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                    (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
                    (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                    (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDouble;
                }
                sheet.Columns.AutoFit();
                ((Excel.Range)sheet.Columns["A"]).ColumnWidth = 5;
                row++;
            }
        }

        private void typeTwo(Excel.Worksheet sheet, Dictionary<string, Dictionary<string, int>> dt)
        {
            PelengEntities pe = new PelengEntities();
            int c = 1, row = 7;
            addExcelCell(sheet, 3, 1, "Полная входимость с цепочкой", "Times New Roman", 16, true);
            addExcelCell(sheet, 6, 1, "№", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 2, "Входимость", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 5, "Номер изделия", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 3, "Кол-во", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 4, "Общее кол-во", "Times New Roman", 14, true);
            (sheet.get_Range("A6", "E6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "E6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "E6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "E6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "E6") as Excel.Range).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDouble;

            foreach (string s in dt.Keys)
            {
                var assembly = (from m in pe.Сборки
                                where m.НомерСборки == s
                                select m);
                int firstRow = row;
                int fullN = 0;
                foreach (string way in dt[s].Keys)
                {
                    addExcelCell(sheet, row, 1, c++.ToString(), "Times New Roman", 14, true);
                    addExcelCell(sheet, row, 2, way, "Times New Roman", 14, true);
                    addExcelCell(sheet, row, 3, dt[s][way].ToString(), "Times New Roman", 14, true);
                    fullN += dt[s][way];
                    for (int i = 1; i <= 5; i++)
                    {
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDouble;
                    }
                    Excel.Range cellOne, cellTwo;
                    cellOne = sheet.Cells[firstRow, 5];
                    cellTwo = sheet.Cells[row, 5];
                    sheet.get_Range(cellOne, cellTwo).Merge();
                    (sheet.Cells[row, 5] as Excel.Range).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    (sheet.Cells[row, 5] as Excel.Range).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    cellOne = sheet.Cells[firstRow, 4];
                    cellTwo = sheet.Cells[row, 4];
                    sheet.get_Range(cellOne, cellTwo).Merge();
                    (sheet.Cells[row, 4] as Excel.Range).VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    (sheet.Cells[row, 4] as Excel.Range).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    addExcelCell(sheet, row, 5, s, "Times New Roman", 14, true);                    
                    row++;
                }
                addExcelCell(sheet, firstRow, 4, fullN.ToString(), "Times New Roman", 14, true);
                sheet.Columns.AutoFit();
                ((Excel.Range)sheet.Columns["A"]).ColumnWidth = 5;
            }
        }

        private void typeOne(Excel.Worksheet sheet, Dictionary<string, Dictionary<string, int>> dt)
        {
            PelengEntities pe = new PelengEntities();
            int c = 1, row = 7;
            addExcelCell(sheet, 3, 1, "Полная входимость без цепочки", "Times New Roman", 16, true);
            addExcelCell(sheet, 6, 1, "№", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 2, "Номер изделия", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 3, "Наименование", "Times New Roman", 14, true);
            addExcelCell(sheet, 6, 4, "Кол-во", "Times New Roman", 14, true);            
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
            (sheet.get_Range("A6", "D6") as Excel.Range).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDouble;

            foreach (string s in dt.Keys)
            {
                var assembly = (from m in pe.Сборки
                                where m.НомерСборки == s
                                select m);
                int fullN = 0;
                foreach (string way in dt[s].Keys)
                {
                    fullN += dt[s][way];
                    for (int i = 1; i <= 4; i++)
                    {
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                        (sheet.Cells[row, i] as Excel.Range).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDouble;
                    }
                }
                addExcelCell(sheet, row, 1, c++.ToString(), "Times New Roman", 14, true);
                addExcelCell(sheet, row, 2, s, "Times New Roman", 14, true);
                addExcelCell(sheet, row, 3, assembly.First().Наименование, "Times New Roman", 14, true);
                addExcelCell(sheet, row, 4, fullN.ToString(), "Times New Roman", 14, true);
                row++;
                sheet.Columns.AutoFit();
                ((Excel.Range)sheet.Columns["A"]).ColumnWidth = 5;
            }
        }
    }
}
