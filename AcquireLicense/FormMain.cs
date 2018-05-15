using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Net;
using System.Windows.Forms;

namespace AcquireLicense
{
    public partial class FormMain : Form
    {

        string url, realm, username, password, clientId, masteruser, masterpass, role;
        bool debug;

        XElement xdoc = XElement.Load("C:\\Users\\Felipe.Fedozzi\\Source\\Repos\\AcquireLicense\\AcquireLicense\\var.xml");

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo);
            if (exit == DialogResult.Yes)
            {
                this.Close();
                return;
            }
        }

        private void buttonVariables_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            FormVariables form = new FormVariables();
            form.origin = "Main";
            form.Show();

            //this.Close();
        }

        private void buttonRealmsUsers_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormAddUsers formusers = new FormAddUsers();
            formusers.Show();
        }
        
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            url = xdoc.Element("url").Value;
            realm = xdoc.Element("realm").Value;
            username = xdoc.Element("username").Value;
            password = xdoc.Element("password").Value;
            clientId = xdoc.Element("clientId").Value;
            masteruser = xdoc.Element("masteruser").Value;
            masterpass = xdoc.Element("masterpass").Value;
            debug = Convert.ToBoolean(xdoc.Element("debug").Value);
            role = xdoc.Element("role").Value;

            labelRealm.Text = "Realm: " + realm;
            labelRole.Text = "Role: " + role;
            labelUser.Text = "Username: " + username;
            if (debug == true) { labelDebug.Text = "DEBUG MODE"; }
            if (debug == false) { labelDebug.Text = ""; }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            FormLicenses formlicenses = new FormLicenses();
            formlicenses.Show();
        }
    }
}
