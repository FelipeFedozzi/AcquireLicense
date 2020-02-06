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
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.labelUsers = new System.Windows.Forms.Label();
            this.labelRealms = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(32, 50);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(77, 20);
            this.userNameBox.TabIndex = 3;
            this.userNameBox.TextChanged += new System.EventHandler(this.userNameBox_TextChanged);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(155, 50);
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown.TabIndex = 4;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.buttonClose.Location = new System.Drawing.Point(77, 288);
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
            this.buttonCreateRealm.Location = new System.Drawing.Point(32, 195);
            this.buttonCreateRealm.Name = "buttonCreateRealm";
            this.buttonCreateRealm.Size = new System.Drawing.Size(164, 23);
            this.buttonCreateRealm.TabIndex = 8;
            this.buttonCreateRealm.Text = "Create Realms and Users";
            this.buttonCreateRealm.UseVisualStyleBackColor = true;
            this.buttonCreateRealm.Click += new System.EventHandler(this.buttonCreateRealm_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(155, 169);
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
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // realmNameBox
            // 
            this.realmNameBox.Location = new System.Drawing.Point(32, 169);
            this.realmNameBox.Name = "realmNameBox";
            this.realmNameBox.Size = new System.Drawing.Size(77, 20);
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
            this.progressBarRealm.Location = new System.Drawing.Point(32, 225);
            this.progressBarRealm.Name = "progressBarRealm";
            this.progressBarRealm.Size = new System.Drawing.Size(164, 23);
            this.progressBarRealm.TabIndex = 10;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(111, 169);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown2.TabIndex = 11;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // labelUsers
            // 
            this.labelUsers.Location = new System.Drawing.Point(32, 132);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(164, 34);
            this.labelUsers.TabIndex = 12;
            this.labelUsers.Text = "label1";
            this.labelUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRealms
            // 
            this.labelRealms.Location = new System.Drawing.Point(35, 251);
            this.labelRealms.Name = "labelRealms";
            this.labelRealms.Size = new System.Drawing.Size(161, 34);
            this.labelRealms.TabIndex = 13;
            this.labelRealms.Text = "label1";
            this.labelRealms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(111, 50);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown3.TabIndex = 14;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormAddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 316);
            this.ControlBox = false;
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.labelRealms);
            this.Controls.Add(this.labelUsers);
            this.Controls.Add(this.numericUpDown2);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.Label labelRealms;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
    }
}