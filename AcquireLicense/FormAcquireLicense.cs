using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Net;
using System.Windows.Forms;

namespace AcquireLicense
{
    public partial class FormAcquire : Form
    {
        object token, licenseToken;
        string realmToken, url, realm, username, password, clientId, role;
        bool debug;

        XElement xdoc = XElement.Load("C:\\Users\\Felipe.Fedozzi\\Source\\Repos\\AcquireLicense\\AcquireLicense\\var.xml");

        public FormAcquire()
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
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            url = xdoc.Element("url").Value;
            realm = xdoc.Element("realm").Value;
            username = xdoc.Element("username").Value;
            password = xdoc.Element("password").Value;
            clientId = xdoc.Element("clientId").Value;
            role = xdoc.Element("role").Value;
            debug = Convert.ToBoolean(xdoc.Element("debug").Value);

            var client = new RestClient(url + realm + "/protocol/openid-connect/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", "grant_type=password&username=" + username + "&password=" + password + "&client_id=" + clientId, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (debug == true) { MessageBox.Show(response.Content, "DEBUG"); }

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
            if (valuesMasterToken is null)
            {
                MessageBox.Show("Failed to acquire license", "ERROR");
                return;
            }

            else
            {
                valuesMasterToken.TryGetValue("access_token", out token);
                realmToken = token.ToString();
                if (debug == true) { MessageBox.Show(realmToken, "DEBUG"); }
            }

            var clientLicense = new RestClient(url + realm + "/license/license");
            var requestLicense = new RestRequest(Method.POST);
            requestLicense.AddHeader("Authorization", "Bearer " + realmToken);
            requestLicense.AddHeader("Content-Type", "application/json");
            requestLicense.AddParameter("undefined", ""+ role + "", ParameterType.RequestBody);

            IRestResponse responseLicense = clientLicense.Execute(requestLicense);
            
            if(debug == true) { MessageBox.Show(responseLicense.Content, "DEBUG"); }
            
            if (responseLicense.Content.Contains("errorMessage") && responseLicense.Content.Contains("license") && responseLicense.Content.Contains("not") && responseLicense.Content.Contains("found"))
            {
                MessageBox.Show("License Type not found", "ERROR");
                return;
            }
            else if (responseLicense.Content.Contains("NO_AVAILABLE_LICENSE"))
            {
                MessageBox.Show("No available licenses", "ERROR");
                return;
            }
            else if (responseLicense.Content.Contains("UNAUTHORIZED"))
            {
                MessageBox.Show("User is not authorized to acquire a license with role " + role, "ERROR");
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("License for " + role.ToUpper() + " acquired for user " + username.ToUpper() + ". Do you want to copy the token?", "License Acquired", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Dictionary<string, object> valuesLicenseToken = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseLicense.Content);
                    valuesLicenseToken.TryGetValue(role, out licenseToken);
                    System.Windows.Forms.MessageBox.Show("License Token acquired and copied to clipboard", "Token copied");
                    Clipboard.SetText(licenseToken.ToString());
                }
                else { return; }
            }
        }

        private void buttonVariables_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            
            FormVariables Form = new FormVariables();
            Form.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
