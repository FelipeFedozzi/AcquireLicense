namespace AcquireLicense
{
    partial class FormMain
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
            this.buttonRealmsUsers = new System.Windows.Forms.Button();
            this.buttonLicenses = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDebug = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelRealm = new System.Windows.Forms.Label();
            this.buttonVariables = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRealmsUsers
            // 
            this.buttonRealmsUsers.Location = new System.Drawing.Point(52, 24);
            this.buttonRealmsUsers.Name = "buttonRealmsUsers";
            this.buttonRealmsUsers.Size = new System.Drawing.Size(129, 23);
            this.buttonRealmsUsers.TabIndex = 0;
            this.buttonRealmsUsers.Text = "Realms and Users";
            this.buttonRealmsUsers.UseVisualStyleBackColor = true;
            this.buttonRealmsUsers.Click += new System.EventHandler(this.buttonRealmsUsers_Click);
            // 
            // buttonLicenses
            // 
            this.buttonLicenses.Location = new System.Drawing.Point(52, 60);
            this.buttonLicenses.Name = "buttonLicenses";
            this.buttonLicenses.Size = new System.Drawing.Size(129, 23);
            this.buttonLicenses.TabIndex = 1;
            this.buttonLicenses.Text = "Token and Licenses";
            this.buttonLicenses.UseVisualStyleBackColor = true;
            this.buttonLicenses.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(52, 226);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(129, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Exit";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelDebug);
            this.groupBox1.Controls.Add(this.labelRole);
            this.groupBox1.Controls.Add(this.labelUser);
            this.groupBox1.Controls.Add(this.labelRealm);
            this.groupBox1.Controls.Add(this.buttonVariables);
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 131);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Variables";
            // 
            // labelDebug
            // 
            this.labelDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDebug.ForeColor = System.Drawing.Color.Red;
            this.labelDebug.Location = new System.Drawing.Point(6, 78);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(196, 19);
            this.labelDebug.TabIndex = 9;
            this.labelDebug.Text = "label4";
            this.labelDebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRole
            // 
            this.labelRole.Location = new System.Drawing.Point(6, 59);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(196, 19);
            this.labelRole.TabIndex = 8;
            this.labelRole.Text = "label3";
            this.labelRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUser
            // 
            this.labelUser.Location = new System.Drawing.Point(6, 40);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(196, 19);
            this.labelUser.TabIndex = 7;
            this.labelUser.Text = "label2";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRealm
            // 
            this.labelRealm.Location = new System.Drawing.Point(6, 21);
            this.labelRealm.Name = "labelRealm";
            this.labelRealm.Size = new System.Drawing.Size(196, 19);
            this.labelRealm.TabIndex = 6;
            this.labelRealm.Text = "label1";
            this.labelRealm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonVariables
            // 
            this.buttonVariables.Location = new System.Drawing.Point(40, 102);
            this.buttonVariables.Name = "buttonVariables";
            this.buttonVariables.Size = new System.Drawing.Size(129, 23);
            this.buttonVariables.TabIndex = 5;
            this.buttonVariables.Text = "Change Variables";
            this.buttonVariables.UseVisualStyleBackColor = true;
            this.buttonVariables.Click += new System.EventHandler(this.buttonVariables_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 261);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonLicenses);
            this.Controls.Add(this.buttonRealmsUsers);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Platform";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRealmsUsers;
        private System.Windows.Forms.Button buttonLicenses;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelRealm;
        private System.Windows.Forms.Button buttonVariables;
        private System.Windows.Forms.Label labelDebug;
    }
}