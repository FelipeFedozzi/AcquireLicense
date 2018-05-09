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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAcquire));
            this.buttonToken = new System.Windows.Forms.Button();
            this.buttonLicense = new System.Windows.Forms.Button();
            this.buttonVariables = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonToken
            // 
            this.buttonToken.Location = new System.Drawing.Point(55, 70);
            this.buttonToken.Name = "buttonToken";
            this.buttonToken.Size = new System.Drawing.Size(129, 23);
            this.buttonToken.TabIndex = 0;
            this.buttonToken.Text = "Only Acquire Token";
            this.buttonToken.UseVisualStyleBackColor = true;
            this.buttonToken.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonLicense
            // 
            this.buttonLicense.Location = new System.Drawing.Point(55, 116);
            this.buttonLicense.Name = "buttonLicense";
            this.buttonLicense.Size = new System.Drawing.Size(128, 23);
            this.buttonLicense.TabIndex = 1;
            this.buttonLicense.Text = "Acquire License";
            this.buttonLicense.UseVisualStyleBackColor = true;
            this.buttonLicense.Click += new System.EventHandler(this.buttonLicense_Click);
            // 
            // buttonVariables
            // 
            this.buttonVariables.Location = new System.Drawing.Point(128, 226);
            this.buttonVariables.Name = "buttonVariables";
            this.buttonVariables.Size = new System.Drawing.Size(92, 23);
            this.buttonVariables.TabIndex = 3;
            this.buttonVariables.Text = "Variables";
            this.buttonVariables.UseVisualStyleBackColor = true;
            this.buttonVariables.Click += new System.EventHandler(this.buttonVariables_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(12, 226);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(92, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormAcquire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 261);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonVariables);
            this.Controls.Add(this.buttonLicense);
            this.Controls.Add(this.buttonToken);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAcquire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acquire License";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonToken;
        private System.Windows.Forms.Button buttonLicense;
        private System.Windows.Forms.Button buttonVariables;
        private System.Windows.Forms.Button buttonExit;
    }
}

