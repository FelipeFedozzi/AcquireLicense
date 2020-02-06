using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Net;
using System.Windows.Forms;
using System.Linq;
using System.Web.Script.Serialization;

namespace AcquireLicense
{
    public partial class FormAcquire : Form
    {

        object token, licenseToken;
        public string realmToken, url, realm, username, password, clientId, role, origin;
        int i;
        IRestResponse responseLicense;
        bool debug;

        private void FormAcquire_Activated(object sender, EventArgs e)
        {
            if (origin == "Main")
            { radioButtonSingle.Checked = true; }
            else if (origin == "License")
            { radioButtonMultiple.Checked = true; }

            numericUpDown.Value = 0;

            //progressBar.Visible = false;
        }

        XElement xdoc = XElement.Load("C:\\Users\\Felipe.Fedozzi\\Source\\Repos\\AcquireLicense\\AcquireLicense\\var.xml");

        private void FormAcquire_Load(object sender, EventArgs e)
        {

        }

        public FormAcquire()
        {
            InitializeComponent();
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

            var client = new RestClient(url + "/realms/" + realm + "/protocol/openid-connect/token");
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
                Clipboard.SetText(realmToken);
                if (debug == true) { MessageBox.Show(realmToken, "DEBUG"); }
            }

            var clientLicense = new RestClient(url + "/realms/" + realm + "/license/license");
            var requestLicense = new RestRequest(Method.POST);
            requestLicense.AddHeader("Authorization", "Bearer " + realmToken);
            requestLicense.AddHeader("Content-Type", "application/json");
            requestLicense.AddParameter("undefined", "" + role + "", ParameterType.RequestBody);

            IRestResponse responseLicense = clientLicense.Execute(requestLicense);

            if (debug == true) { MessageBox.Show(responseLicense.Content, "DEBUG"); Clipboard.SetText(responseLicense.Content); }

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
                    var valuesLicenseToken = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseLicense.Content);
                    valuesLicenseToken.TryGetValue(role, out licenseToken);
                    Clipboard.SetText(responseLicense.Content.ToString());
                    MessageBox.Show("License Token acquired and copied to clipboard", "Token copied");
                }
                else { return; }
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            DialogResult dialogResult = MessageBox.Show("Please be advised, to use multiple licenses the user need to have set multiple users and they need to be in numbered sequence (eg. USER1, USER2) for both username AND password. Please modify the username and password and remove the number at the end. Do you want to make the changes now?", "NOTICE", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Visible = false;

                FormVariables Form = new FormVariables();
                Form.origin = "License";
                Form.Show();
            }
            else if (dialogResult == DialogResult.No) { radioButtonMultiple.Checked = true; }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();

            FormLicenses form = new FormLicenses();
            form.Show();
        }

        private void radioButtonSingle_CheckedChanged(object sender, EventArgs e)
        {
            buttonLicense.Enabled = true;
            buttonLicenses.Enabled = false;
            numericUpDown.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            buttonLicense.Enabled = false;
            buttonLicenses.Enabled = false;
            numericUpDown.Enabled = true;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown.Value == 0) { buttonLicenses.Enabled = false; }
            else if (numericUpDown.Value > 0) { buttonLicenses.Enabled = true; }
        }

        private void buttonLicenses_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            progressBar.Maximum = Convert.ToInt32(numericUpDown.Value);

            i = 1;

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            url = xdoc.Element("url").Value;
            realm = xdoc.Element("realm").Value;
            username = xdoc.Element("username").Value;
            password = xdoc.Element("password").Value;
            clientId = xdoc.Element("clientId").Value;
            role = xdoc.Element("role").Value;
            debug = Convert.ToBoolean(xdoc.Element("debug").Value);

            do
            {
                var client = new RestClient(url + "/realms/" + realm + "/protocol/openid-connect/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("undefined", "grant_type=password&username=" + username + i + "&password=" + password + i + "&client_id=" + clientId, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                if (debug == true) { MessageBox.Show(response.Content, "DEBUG"); }

                string masterTokenArray = response.Content;

                if (masterTokenArray.Contains("invalid"))
                {
                    MessageBox.Show("Invalid user credentials", "ERROR");
                    progressBar.Value = 0;
                    return;
                }

                if (masterTokenArray.Contains("unauthorized_client"))
                {
                    MessageBox.Show("Invalid client", "ERROR");
                    progressBar.Value = 0;
                    return;
                }

                Dictionary<string, object> valuesMasterToken = JsonConvert.DeserializeObject<Dictionary<string, object>>(masterTokenArray);

                //Deserialize Token value
                if (valuesMasterToken is null)
                {
                    MessageBox.Show("Failed to acquire license", "ERROR");
                    progressBar.Value = 0;
                    return;
                }

                else
                {
                    valuesMasterToken.TryGetValue("access_token", out token);
                    realmToken = token.ToString();
                    if (debug == true) { MessageBox.Show(realmToken, "DEBUG"); }
                }

                var clientLicense = new RestClient(url + "/realms/" + realm + "/license/license");
                var requestLicense = new RestRequest(Method.POST);
                requestLicense.AddHeader("Authorization", "Bearer " + realmToken);
                requestLicense.AddHeader("Content-Type", "application/json");
                requestLicense.AddParameter("undefined", "" + role + "", ParameterType.RequestBody);

                responseLicense = clientLicense.Execute(requestLicense);

                response = clientLicense.Execute(requestLicense);

                if (debug == true) { MessageBox.Show(responseLicense.Content, "DEBUG"); }

                if (responseLicense.Content.Contains("errorMessage") && responseLicense.Content.Contains("license") && responseLicense.Content.Contains("not") && responseLicense.Content.Contains("found"))
                {
                    MessageBox.Show("License Type not found", "ERROR");
                    progressBar.Value = 0;
                    return;
                }
                else if (responseLicense.Content.Contains("NO_AVAILABLE_LICENSE"))
                {
                    MessageBox.Show("Only " + (i-1) + " available licenses for " + numericUpDown.Value + " users.\n\nThe "+ (i-1) + " licenses were aquired.\n"+(numericUpDown.Value - (i-1)) +" user(s) couldn't acquire a license.", "Warning");
                    progressBar.Value = 0;
                    return;
                }
                else if (responseLicense.Content.Contains("UNAUTHORIZED"))
                {
                    MessageBox.Show("User is not authorized to acquire a license with role " + role, "ERROR");
                    progressBar.Value = 0;
                    return;
                }
                
                i++;

                progressBar.Value = i-1;
            } while (i <= numericUpDown.Value);

            if ((i-1) == 1)
            {
                DialogResult dialogResult = MessageBox.Show("1 License for " + role.ToUpper() + " acquired for user " + username.ToUpper() + i + ". Do you want to copy the token?", "License Acquired", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    object test;
                    Dictionary<string, object> valuesLicenseToken = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseLicense.Content);
                    valuesLicenseToken.TryGetValue(role, out test);
                    MessageBox.Show("License Token acquired and copied to clipboard", "Token copied");
                    Clipboard.SetText(test.ToString());
                    //progressBar.Visible = false;
                }
                else { return; }
            }
            else if ((i-1) > 1)
            {
                MessageBox.Show((i-1) + " licenses were acquired successfully.", "Success");
                progressBar.Value = i - 1;
            }

        }
    }
}
