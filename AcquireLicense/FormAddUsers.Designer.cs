namespace AcquireLicense
{
    partial class FormAddUsers
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
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.radioButtonUsers = new System.Windows.Forms.RadioButton();
            this.radioButtonRealmsUsers = new System.Windows.Forms.RadioButton();
            this.buttonCreateRealm = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.realmNameBox = new System.Windows.Forms.TextBox();
            this.progressBarUser = new System.Windows.Forms.ProgressBar();
            this.progressBarRealm = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(32, 50);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(100, 20);
            this.userNameBox.TabIndex = 3;
            this.userNameBox.TextChanged += new System.EventHandler(this.userNameBox_TextChanged);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(138, 50);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown.TabIndex = 4;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Location = new System.Drawing.Point(32, 76);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(164, 23);
            this.buttonCreateUser.TabIndex = 5;
            this.buttonCreateUser.Text = "Create Users";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(79, 226);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Back";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // radioButtonUsers
            // 
            this.radioButtonUsers.AutoSize = true;
            this.radioButtonUsers.Location = new System.Drawing.Point(7, 13);
            this.radioButtonUsers.Name = "radioButtonUsers";
            this.radioButtonUsers.Size = new System.Drawing.Size(74, 17);
            this.radioButtonUsers.TabIndex = 1;
            this.radioButtonUsers.TabStop = true;
            this.radioButtonUsers.Text = "Add Users";
            this.radioButtonUsers.UseVisualStyleBackColor = true;
            this.radioButtonUsers.CheckedChanged += new System.EventHandler(this.radioButtonUsers_CheckedChanged);
            // 
            // radioButtonRealmsUsers
            // 
            this.radioButtonRealmsUsers.AutoSize = true;
            this.radioButtonRealmsUsers.Location = new System.Drawing.Point(92, 13);
            this.radioButtonRealmsUsers.Name = "radioButtonRealmsUsers";
            this.radioButtonRealmsUsers.Size = new System.Drawing.Size(133, 17);
            this.radioButtonRealmsUsers.TabIndex = 2;
            this.radioButtonRealmsUsers.TabStop = true;
            this.radioButtonRealmsUsers.Text = "Add Realms and Users";
            this.radioButtonRealmsUsers.UseVisualStyleBackColor = true;
            this.radioButtonRealmsUsers.CheckedChanged += new System.EventHandler(this.radioButtonRealmsUsers_CheckedChanged);
            // 
            // buttonCreateRealm
            // 
            this.buttonCreateRealm.Location = new System.Drawing.Point(32, 161);
            this.buttonCreateRealm.Name = "buttonCreateRealm";
            this.buttonCreateRealm.Size = new System.Drawing.Size(164, 23);
            this.buttonCreateRealm.TabIndex = 8;
            this.buttonCreateRealm.Text = "Create Realms and Users";
            this.buttonCreateRealm.UseVisualStyleBackColor = true;
            this.buttonCreateRealm.Click += new System.EventHandler(this.buttonCreateRealm_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(138, 135);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // realmNameBox
            // 
            this.realmNameBox.Location = new System.Drawing.Point(32, 135);
            this.realmNameBox.Name = "realmNameBox";
            this.realmNameBox.Size = new System.Drawing.Size(100, 20);
            this.realmNameBox.TabIndex = 6;
            this.realmNameBox.TextChanged += new System.EventHandler(this.realmNameBox_TextChanged);
            // 
            // progressBarUser
            // 
            this.progressBarUser.Location = new System.Drawing.Point(32, 106);
            this.progressBarUser.Name = "progressBarUser";
            this.progressBarUser.Size = new System.Drawing.Size(164, 23);
            this.progressBarUser.TabIndex = 9;
            // 
            // progressBarRealm
            // 
            this.progressBarRealm.Location = new System.Drawing.Point(32, 191);
            this.progressBarRealm.Name = "progressBarRealm";
            this.progressBarRealm.Size = new System.Drawing.Size(164, 23);
            this.progressBarRealm.TabIndex = 10;
            // 
            // FormAddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 261);
            this.ControlBox = false;
            this.Controls.Add(this.progressBarRealm);
            this.Controls.Add(this.progressBarUser);
            this.Controls.Add(this.buttonCreateRealm);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.realmNameBox);
            this.Controls.Add(this.radioButtonRealmsUsers);
            this.Controls.Add(this.radioButtonUsers);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCreateUser);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.userNameBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAddUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add User";
            this.Load += new System.EventHandler(this.FormAddUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RadioButton radioButtonUsers;
        private System.Windows.Forms.RadioButton radioButtonRealmsUsers;
        private System.Windows.Forms.Button buttonCreateRealm;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox realmNameBox;
        private System.Windows.Forms.ProgressBar progressBarUser;
        private System.Windows.Forms.ProgressBar progressBarRealm;
    }
}