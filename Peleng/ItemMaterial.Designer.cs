namespace Peleng
{
    partial class ItemMaterial
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mtbRate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.btnMaterialChoose = new System.Windows.Forms.Button();
            this.btnCompute = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbGabarit = new System.Windows.Forms.Label();
            this.toolTipMats = new System.Windows.Forms.ToolTip(this.components);
            this.lbType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // mtbRate
            // 
            this.mtbRate.Location = new System.Drawing.Point(215, 125);
            this.mtbRate.Name = "mtbRate";
            this.mtbRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbRate.Size = new System.Drawing.Size(100, 20);
            this.mtbRate.TabIndex = 26;
            this.mtbRate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mtbRate_TypeValidationCompleted);
            this.mtbRate.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(394, 76);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBox2.Size = new System.Drawing.Size(72, 20);
            this.maskedTextBox2.TabIndex = 25;
            this.maskedTextBox2.Visible = false;
            this.maskedTextBox2.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.maskedTextBox2_TypeValidationCompleted);
            this.maskedTextBox2.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(298, 76);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBox1.Size = new System.Drawing.Size(72, 20);
            this.maskedTextBox1.TabIndex = 24;
            this.maskedTextBox1.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.maskedTextBox1_TypeValidationCompleted);
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            // 
            // btnMaterialChoose
            // 
            this.btnMaterialChoose.Location = new System.Drawing.Point(625, 29);
            this.btnMaterialChoose.Name = "btnMaterialChoose";
            this.btnMaterialChoose.Size = new System.Drawing.Size(27, 23);
            this.btnMaterialChoose.TabIndex = 23;
            this.btnMaterialChoose.Text = "...";
            this.btnMaterialChoose.UseVisualStyleBackColor = true;
            this.btnMaterialChoose.Click += new System.EventHandler(this.btnMaterialChoose_Click);
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(343, 123);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(102, 23);
            this.btnCompute.TabIndex = 22;
            this.btnCompute.Text = "Рассчитать...";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(535, 314);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 31);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(399, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 31);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Записать";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Норма расхода, кг";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Заготовка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Номенклатура материала";
            // 
            // tbMat
            // 
            this.tbMat.Location = new System.Drawing.Point(215, 31);
            this.tbMat.Name = "tbMat";
            this.tbMat.ReadOnly = true;
            this.tbMat.Size = new System.Drawing.Size(404, 20);
            this.tbMat.TabIndex = 15;
            this.tbMat.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Выход деталей";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(215, 172);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "x";
            this.label6.Visible = false;
            // 
            // lbGabarit
            // 
            this.lbGabarit.AutoSize = true;
            this.lbGabarit.Location = new System.Drawing.Point(251, 79);
            this.lbGabarit.Name = "lbGabarit";
            this.lbGabarit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGabarit.Size = new System.Drawing.Size(0, 13);
            this.lbGabarit.TabIndex = 31;
            this.lbGabarit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolTipMats
            // 
            this.toolTipMats.IsBalloon = true;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(236, 79);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(0, 13);
            this.lbType.TabIndex = 32;
            // 
            // ItemMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbGabarit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mtbRate);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.btnMaterialChoose);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMat);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "ItemMaterial";
            this.Size = new System.Drawing.Size(704, 386);
            this.Load += new System.EventHandler(this.ItemMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbRate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button btnMaterialChoose;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbGabarit;
        private System.Windows.Forms.ToolTip toolTipMats;
        private System.Windows.Forms.Label lbType;

    }
}
