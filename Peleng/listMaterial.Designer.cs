namespace Peleng
{
    partial class listMaterial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.маркиМатериалаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pelengDataSet = new Peleng.PelengDataSet();
            this.маркиМатериалаTableAdapter = new Peleng.PelengDataSetTableAdapters.МаркиМатериалаTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rbMark = new System.Windows.Forms.RadioButton();
            this.rbFull = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.маркиМатериалаBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pelengDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMaterial
            // 
            this.cbMaterial.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.маркиМатериалаBindingSource, "НаименованиеМарки", true));
            this.cbMaterial.DataSource = this.маркиМатериалаBindingSource;
            this.cbMaterial.DisplayMember = "НаименованиеМарки";
            this.cbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(36, 84);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(121, 21);
            this.cbMaterial.TabIndex = 1;
            this.cbMaterial.ValueMember = "НаименованиеМарки";
            this.cbMaterial.SelectedValueChanged += new System.EventHandler(this.cbMaterial_SelectedValueChanged);
            // 
            // маркиМатериалаBindingSource
            // 
            this.маркиМатериалаBindingSource.DataMember = "МаркиМатериала";
            this.маркиМатериалаBindingSource.DataSource = this.pelengDataSet;
            // 
            // pelengDataSet
            // 
            this.pelengDataSet.DataSetName = "PelengDataSet";
            this.pelengDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // маркиМатериалаTableAdapter
            // 
            this.маркиМатериалаTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(538, 335);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // rbMark
            // 
            this.rbMark.AutoSize = true;
            this.rbMark.Location = new System.Drawing.Point(19, 61);
            this.rbMark.Name = "rbMark";
            this.rbMark.Size = new System.Drawing.Size(151, 17);
            this.rbMark.TabIndex = 3;
            this.rbMark.TabStop = true;
            this.rbMark.Text = "Выбор марки материала";
            this.rbMark.UseVisualStyleBackColor = true;
            // 
            // rbFull
            // 
            this.rbFull.AutoSize = true;
            this.rbFull.Checked = true;
            this.rbFull.Location = new System.Drawing.Point(19, 19);
            this.rbFull.Name = "rbFull";
            this.rbFull.Size = new System.Drawing.Size(119, 17);
            this.rbFull.TabIndex = 4;
            this.rbFull.TabStop = true;
            this.rbFull.Text = "Вся номенклатура";
            this.rbFull.UseVisualStyleBackColor = true;
            this.rbFull.CheckedChanged += new System.EventHandler(this.rbFull_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.rbFull);
            this.groupBox1.Controls.Add(this.cbMaterial);
            this.groupBox1.Controls.Add(this.rbMark);
            this.groupBox1.Location = new System.Drawing.Point(556, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 156);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 123);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "сохранить выбор";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChoose.Location = new System.Drawing.Point(575, 199);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(151, 32);
            this.btnChoose.TabIndex = 6;
            this.btnChoose.Text = "Выбрать";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(575, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // listMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 359);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "listMaterial";
            this.Text = "Номенклатура материалов";
            this.Load += new System.EventHandler(this.listMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.маркиМатериалаBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pelengDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMaterial;
        private PelengDataSet pelengDataSet;
        private System.Windows.Forms.BindingSource маркиМатериалаBindingSource;
        private PelengDataSetTableAdapters.МаркиМатериалаTableAdapter маркиМатериалаTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rbMark;
        private System.Windows.Forms.RadioButton rbFull;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnCancel;
    }
}