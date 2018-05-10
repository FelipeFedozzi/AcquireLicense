namespace AcquireLicense
{
    partial class FormAcquire
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
            this.radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.radioButtonMultiple = new System.Windows.Forms.RadioButton();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonLicense = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonLicenses = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonSingle
            // 
            this.radioButtonSingle.AutoSize = true;
            this.radioButtonSingle.Location = new System.Drawing.Point(12, 12);
            this.radioButtonSingle.Name = "radioButtonSingle";
            this.radioButtonSingle.Size = new System.Drawing.Size(94, 17);
            this.radioButtonSingle.TabIndex = 0;
            this.radioButtonSingle.TabStop = true;
            this.radioButtonSingle.Text = "Single License";
            this.radioButtonSingle.UseVisualStyleBackColor = true;
            this.radioButtonSingle.CheckedChanged += new System.EventHandler(this.radioButtonSingle_CheckedChanged);
            // 
            // radioButtonMultiple
            // 
            this.radioButtonMultiple.AutoSize = true;
            this.radioButtonMultiple.Location = new System.Drawing.Point(12, 115);
            this.radioButtonMultiple.Name = "radioButtonMultiple";
            this.radioButtonMultiple.Size = new System.Drawing.Size(106, 17);
            this.radioButtonMultiple.TabIndex = 1;
            this.radioButtonMultiple.TabStop = true;
            this.radioButtonMultiple.Text = "Multiple Licenses";
            this.radioButtonMultiple.UseVisualStyleBackColor = true;
            this.radioButtonMultiple.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.radioButtonMultiple.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(81, 226);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonLicense
            // 
            this.buttonLicense.Location = new System.Drawing.Point(51, 46);
            this.buttonLicense.Name = "buttonLicense";
            this.buttonLicense.Size = new System.Drawing.Size(128, 23);
            this.buttonLicense.TabIndex = 4;
            this.buttonLicense.Text = "Acquire License";
            this.buttonLicense.UseVisualStyleBackColor = true;
            this.buttonLicense.Click += new System.EventHandler(this.buttonLicense_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(12, 151);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown.TabIndex = 5;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // buttonLicenses
            // 
            this.buttonLicenses.Location = new System.Drawing.Point(68, 150);
            this.buttonLicenses.Name = "buttonLicenses";
            this.buttonLicenses.Size = new System.Drawing.Size(111, 23);
            this.buttonLicenses.TabIndex = 6;
            this.buttonLicenses.Text = "Acquire Licenses";
            this.buttonLicenses.UseVisualStyleBackColor = true;
            this.buttonLicenses.Click += new System.EventHandler(this.buttonLicenses_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(0, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.TabIndex = 7;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormAcquire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 261);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLicenses);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.buttonLicense);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.radioButtonMultiple);
            this.Controls.Add(this.radioButtonSingle);
            this.Name = "FormAcquire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acquire License";
            this.Activated += new System.EventHandler(this.FormAcquire_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonSingle;
        private System.Windows.Forms.RadioButton radioButtonMultiple;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonLicense;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button buttonLicenses;
        private System.Windows.Forms.Label label1;
    }
}