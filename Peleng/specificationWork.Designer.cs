namespace Peleng
{
    partial class specificationWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(specificationWork));
            this.tabSpecification = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbWay = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.lbWay = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tabAssembly = new System.Windows.Forms.TabPage();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnSaveAssembly = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.номерВхСборкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерСборкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.входящиеСборкиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pelengDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pelengDataSet = new Peleng.PelengDataSet();
            this.tabItem = new System.Windows.Forms.TabPage();
            this.tabMaterial = new System.Windows.Forms.TabPage();
            this.входящиеСборкиTableAdapter = new Peleng.PelengDataSetTableAdapters.ВходящиеСборкиTableAdapter();
            this.epWay = new System.Windows.Forms.ErrorProvider(this.components);
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabSpecification.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabAssembly.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.входящиеСборкиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pelengDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pelengDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSpecification
            // 
            this.tabSpecification.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabSpecification.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabSpecification.Controls.Add(this.tabMain);
            this.tabSpecification.Controls.Add(this.tabAssembly);
            this.tabSpecification.Controls.Add(this.tabItem);
            this.tabSpecification.Controls.Add(this.tabMaterial);
            this.tabSpecification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSpecification.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabSpecification.ItemSize = new System.Drawing.Size(35, 110);
            this.tabSpecification.Location = new System.Drawing.Point(0, 0);
            this.tabSpecification.Margin = new System.Windows.Forms.Padding(5);
            this.tabSpecification.Multiline = true;
            this.tabSpecification.Name = "tabSpecification";
            this.tabSpecification.Padding = new System.Drawing.Point(20, 10);
            this.tabSpecification.SelectedIndex = 0;
            this.tabSpecification.Size = new System.Drawing.Size(862, 393);
            this.tabSpecification.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSpecification.TabIndex = 0;
            this.tabSpecification.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabSpecification_DrawItem);
            this.tabSpecification.SelectedIndexChanged += new System.EventHandler(this.tabSpecification_SelectedIndexChanged);
            // 
            // tabMain
            // 
            this.tabMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabMain.Controls.Add(this.btnExit);
            this.tabMain.Controls.Add(this.btnSave);
            this.tabMain.Controls.Add(this.tbWay);
            this.tabMain.Controls.Add(this.tbName);
            this.tabMain.Controls.Add(this.tbNumber);
            this.tabMain.Controls.Add(this.lbWay);
            this.tabMain.Controls.Add(this.lbNumber);
            this.tabMain.Controls.Add(this.lbName);
            this.tabMain.Location = new System.Drawing.Point(153, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(705, 385);
            this.tabMain.TabIndex = 3;
            this.tabMain.Text = "Основная информация";
            this.tabMain.ToolTipText = "Информация о спецификации";
            this.tabMain.UseVisualStyleBackColor = true;
            this.tabMain.Validating += new System.ComponentModel.CancelEventHandler(this.tabMain_Validating);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(546, 314);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 31);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(410, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 31);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Записать";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbWay
            // 
            this.tbWay.Location = new System.Drawing.Point(183, 123);
            this.tbWay.MaxLength = 100;
            this.tbWay.Name = "tbWay";
            this.tbWay.Size = new System.Drawing.Size(495, 20);
            this.tbWay.TabIndex = 5;
            this.tbWay.TextChanged += new System.EventHandler(this.tbWay_TextChanged);
            this.tbWay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWay_KeyPress);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(183, 77);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(495, 20);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(183, 36);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.ReadOnly = true;
            this.tbNumber.Size = new System.Drawing.Size(170, 20);
            this.tbNumber.TabIndex = 3;
            // 
            // lbWay
            // 
            this.lbWay.AutoSize = true;
            this.lbWay.Location = new System.Drawing.Point(42, 123);
            this.lbWay.Name = "lbWay";
            this.lbWay.Size = new System.Drawing.Size(52, 13);
            this.lbWay.TabIndex = 2;
            this.lbWay.Text = "Маршрут";
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(42, 36);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(118, 13);
            this.lbNumber.TabIndex = 1;
            this.lbNumber.Text = "Номер спецификации";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(42, 77);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(57, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Название";
            // 
            // tabAssembly
            // 
            this.tabAssembly.AllowDrop = true;
            this.tabAssembly.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.tabAssembly.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabAssembly.Controls.Add(this.btnExit2);
            this.tabAssembly.Controls.Add(this.btnSaveAssembly);
            this.tabAssembly.Controls.Add(this.toolStrip1);
            this.tabAssembly.Controls.Add(this.dataGridView1);
            this.tabAssembly.Location = new System.Drawing.Point(153, 4);
            this.tabAssembly.Margin = new System.Windows.Forms.Padding(5);
            this.tabAssembly.Name = "tabAssembly";
            this.tabAssembly.Padding = new System.Windows.Forms.Padding(5);
            this.tabAssembly.Size = new System.Drawing.Size(705, 385);
            this.tabAssembly.TabIndex = 0;
            this.tabAssembly.Text = "Сборочные единицы";
            this.tabAssembly.ToolTipText = "Входящие сборки";
            this.tabAssembly.UseVisualStyleBackColor = true;
            // 
            // btnExit2
            // 
            this.btnExit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit2.Location = new System.Drawing.Point(571, 342);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(107, 31);
            this.btnExit2.TabIndex = 9;
            this.btnExit2.Text = "Выйти";
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveAssembly
            // 
            this.btnSaveAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAssembly.Location = new System.Drawing.Point(435, 342);
            this.btnSaveAssembly.Name = "btnSaveAssembly";
            this.btnSaveAssembly.Size = new System.Drawing.Size(107, 31);
            this.btnSaveAssembly.TabIndex = 8;
            this.btnSaveAssembly.Text = "Записать";
            this.btnSaveAssembly.UseVisualStyleBackColor = true;
            this.btnSaveAssembly.Click += new System.EventHandler(this.btnSaveAssembly_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnEdit,
            this.tsBtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(691, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAdd.Image")));
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Size = new System.Drawing.Size(63, 22);
            this.tsBtnAdd.Text = "Добавить";
            this.tsBtnAdd.Click += new System.EventHandler(this.tsBtnAdd_Click);
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEdit.Image")));
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(91, 22);
            this.tsBtnEdit.Text = "Редактировать";
            this.tsBtnEdit.Click += new System.EventHandler(this.tsBtnEdit_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelete.Image")));
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(55, 22);
            this.tsBtnDelete.Text = "Удалить";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерВхСборкиDataGridViewTextBoxColumn,
            this.количествоDataGridViewTextBoxColumn,
            this.номерСборкиDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.входящиеСборкиBindingSource;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(5, 41);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(688, 290);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // номерВхСборкиDataGridViewTextBoxColumn
            // 
            this.номерВхСборкиDataGridViewTextBoxColumn.DataPropertyName = "НомерВхСборки";
            this.номерВхСборкиDataGridViewTextBoxColumn.HeaderText = "Номер сборки";
            this.номерВхСборкиDataGridViewTextBoxColumn.Name = "номерВхСборкиDataGridViewTextBoxColumn";
            // 
            // количествоDataGridViewTextBoxColumn
            // 
            this.количествоDataGridViewTextBoxColumn.DataPropertyName = "Количество";
            this.количествоDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.количествоDataGridViewTextBoxColumn.Name = "количествоDataGridViewTextBoxColumn";
            // 
            // номерСборкиDataGridViewTextBoxColumn
            // 
            this.номерСборкиDataGridViewTextBoxColumn.DataPropertyName = "НомерСборки";
            this.номерСборкиDataGridViewTextBoxColumn.HeaderText = "НомерСборки";
            this.номерСборкиDataGridViewTextBoxColumn.Name = "номерСборкиDataGridViewTextBoxColumn";
            this.номерСборкиDataGridViewTextBoxColumn.Visible = false;
            // 
            // входящиеСборкиBindingSource
            // 
            this.входящиеСборкиBindingSource.DataMember = "ВходящиеСборки";
            this.входящиеСборкиBindingSource.DataSource = this.pelengDataSetBindingSource;
            // 
            // pelengDataSetBindingSource
            // 
            this.pelengDataSetBindingSource.DataSource = this.pelengDataSet;
            this.pelengDataSetBindingSource.Position = 0;
            // 
            // pelengDataSet
            // 
            this.pelengDataSet.DataSetName = "PelengDataSet";
            this.pelengDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabItem
            // 
            this.tabItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabItem.Location = new System.Drawing.Point(153, 4);
            this.tabItem.Name = "tabItem";
            this.tabItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabItem.Size = new System.Drawing.Size(705, 385);
            this.tabItem.TabIndex = 1;
            this.tabItem.Text = "Детали";
            this.tabItem.ToolTipText = "Входящие детали";
            this.tabItem.UseVisualStyleBackColor = true;
            // 
            // tabMaterial
            // 
            this.tabMaterial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabMaterial.Location = new System.Drawing.Point(153, 4);
            this.tabMaterial.Name = "tabMaterial";
            this.tabMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaterial.Size = new System.Drawing.Size(705, 385);
            this.tabMaterial.TabIndex = 2;
            this.tabMaterial.Text = "Материалы";
            this.tabMaterial.ToolTipText = "Входящие материалы";
            this.tabMaterial.UseVisualStyleBackColor = true;
            // 
            // входящиеСборкиTableAdapter
            // 
            this.входящиеСборкиTableAdapter.ClearBeforeFill = true;
            // 
            // epWay
            // 
            this.epWay.ContainerControl = this;
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // specificationWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 393);
            this.Controls.Add(this.tabSpecification);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "specificationWork";
            this.Text = "Просмотр спецификации";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.specificationWork_FormClosing);
            this.Load += new System.EventHandler(this.specificationWork_Load);
            this.tabSpecification.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabAssembly.ResumeLayout(false);
            this.tabAssembly.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.входящиеСборкиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pelengDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pelengDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSpecification;
        private System.Windows.Forms.TabPage tabAssembly;
        private System.Windows.Forms.TabPage tabItem;
        private System.Windows.Forms.TabPage tabMaterial;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbWay;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label lbWay;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnEdit;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.BindingSource pelengDataSetBindingSource;
        private PelengDataSet pelengDataSet;
        private System.Windows.Forms.BindingSource входящиеСборкиBindingSource;
        private PelengDataSetTableAdapters.ВходящиеСборкиTableAdapter входящиеСборкиTableAdapter;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button btnSaveAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерВхСборкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерСборкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.ErrorProvider epWay;
        private System.Windows.Forms.ErrorProvider epName;
    }
}