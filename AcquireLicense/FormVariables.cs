using System;
using System.Xml.Linq;
using System.Windows.Forms;

namespace AcquireLicense
{
    public partial class FormVariables : Form
    {
        public string url, realm, username, password, clientId, role, origin;
        bool debug;
        
        XElement xdoc = XElement.Load("C:\\Users\\Felipe.Fedozzi\\Source\\Repos\\AcquireLicense\\AcquireLicense\\var.xml");

        public FormVariables()
        {
            InitializeComponent();

            url = xdoc.Element("url").Value;
            realm = xdoc.Element("realm").Value;
            username = xdoc.Element("username").Value;
            password = xdoc.Element("password").Value;
            clientId = xdoc.Element("clientId").Value;
            role = xdoc.Element("role").Value;
            debug = Convert.ToBoolean(xdoc.Element("debug").Value);

            textBox1.Text = url;
            textBox2.Text = realm;
            textBox3.Text = username;
            textBox4.Text = password;
            textBox5.Text = clientId;
            textBox6.Text = role;
            checkBox1.Checked = debug;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            xdoc.Element("url").Value = textBox1.Text;
            xdoc.Element("realm").Value = textBox2.Text;
            xdoc.Element("username").Value = textBox3.Text;
            xdoc.Element("password").Value = textBox4.Text;
            xdoc.Element("clientId").Value = textBox5.Text;
            xdoc.Element("role").Value = textBox6.Text;
            xdoc.Element("debug").Value = checkBox1.Checked.ToString();

            xdoc.Save("C:\\Users\\Felipe.Fedozzi\\Source\\Repos\\AcquireLicense\\AcquireLicense\\var.xml");
            
            this.Close();

            if (origin == "Main")
            {
                FormMain form = new FormMain();
                form.Show();
            }
            else if (origin == "License")
            {
                FormAcquire form = new FormAcquire();
                form.origin = "License";
                form.Show();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            if (origin == "Main")
            {
                FormMain form = new FormMain();
                form.Show();
            }
            else if (origin == "License")
            {
                FormAcquire form = new FormAcquire();
                form.origin = "License";
                form.Show();
            }
        }
    }
}
