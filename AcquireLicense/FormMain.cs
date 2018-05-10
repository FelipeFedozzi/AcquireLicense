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
        object token, licenseToken;
        string realmToken, url, realm, username, password, clientId, role;
        bool debug;

        XElement xdoc = XElement.Load("C:\\Users\\Felipe.Fedozzi\\Source\\Repos\\AcquireLicense\\AcquireLicense\\var.xml");

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            url = xdoc.Element("url").Value;
            realm = xdoc.Element("realm").Value;
            username = xdoc.Element("username").Value;
            password = xdoc.Element("password").Value;
            clientId = xdoc.Element("clientId").Value;
            debug = Convert.ToBoolean(xdoc.Element("debug").Value);

            var client = new RestClient(url + realm + "/protocol/openid-connect/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", "grant_type=password&username="+ username + "&password="+ password + "&client_id="+ clientId, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (debug == true) { MessageBox.Show(response.Content); }

            string masterTokenArray = response.Content;

            if (masterTokenArray.Contains("invalid"))
            {
                MessageBox.Show("Invalid user credentials", "ERROR");
                return;
            }

            if (masterTokenArray.Contains("unauthorized_client"))
            {
                MessageBox.Show("Invalid client", "ERROR");
                return;
            }

            Dictionary<string, object> valuesMasterToken = JsonConvert.DeserializeObject<Dictionary<string, object>>(masterTokenArray);

            //Deserialize Token value
            if (valuesMasterToken is null) { MessageBox.Show("No token was created", "ERROR"); }

            else
            {
                valuesMasterToken.TryGetValue("access_token", out token);
                realmToken = token.ToString();
                if (debug == true) { MessageBox.Show(realmToken); }
                MessageBox.Show("Token acquired and copied to clipboard", "Success");
                Clipboard.SetText(realmToken);
            }
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            FormAcquire form = new FormAcquire();
            form.origin = "Main";
            form.Show();
        }

        private void buttonVariables_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            
            FormVariables form = new FormVariables();
            form.origin = "Main";
            form.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
