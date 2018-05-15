using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Net;
using System.Windows.Forms;

namespace AcquireLicense
{
    public partial class FormAddUsers : Form
    {
        object token, licenseToken;
        string realmToken, url, realm, username, password, clientId, masteruser, masterpass;
        IRestResponse response, responseNewUser, responseRealm;
        bool debug;
        int i, r;

        XElement xdoc = XElement.Load("C:\\Users\\Felipe.Fedozzi\\Source\\Repos\\AcquireLicense\\AcquireLicense\\var.xml");

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();

            FormMain form = new FormMain();
            form.Show();
        }

        private void radioButtonRealmsUsers_CheckedChanged(object sender, EventArgs e)
        {
            realmNameBox.Visible = true;
            buttonCreateRealm.Visible = true;
            numericUpDown1.Visible = true;
            progressBarUser.Visible = true;
            progressBarUser.Value = 0;
            progressBarRealm.Visible = true;
            progressBarRealm.Value = 0;

            if (radioButtonUsers.Checked == true)
            {
                if (userNameBox.Text == "" || numericUpDown.Value == 0) { buttonCreateUser.Enabled = false; }
                else { buttonCreateUser.Enabled = true; }
            }
            else if (radioButtonRealmsUsers.Checked == true)
            {
                if (realmNameBox.Text == "" || numericUpDown.Value == 0 || userNameBox.Text == "" || numericUpDown1.Value == 0)
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = false;
                }
                else
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = true;
                }
            }
        }

        private void radioButtonUsers_CheckedChanged(object sender, EventArgs e)
        {
            realmNameBox.Visible = false;
            buttonCreateRealm.Visible = false;
            numericUpDown1.Visible = false;
            progressBarRealm.Visible = false;

            if (radioButtonUsers.Checked == true)
            {
                if (userNameBox.Text == "" || numericUpDown.Value == 0) { buttonCreateUser.Enabled = false; }
                else { buttonCreateUser.Enabled = true; }
            }
            else if (radioButtonRealmsUsers.Checked == true)
            {
                if (realmNameBox.Text == "" || numericUpDown.Value == 0 || userNameBox.Text == "" || numericUpDown1.Value == 0)
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = false;
                }
                else
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = true;
                }
            }
        }

        private void realmNameBox_TextChanged(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked == true)
            {
                if (userNameBox.Text == "" || numericUpDown.Value == 0) { buttonCreateUser.Enabled = false; }
                else { buttonCreateUser.Enabled = true; }
            }
            else if (radioButtonRealmsUsers.Checked == true)
            {
                if (realmNameBox.Text == "" || numericUpDown.Value == 0 || userNameBox.Text == "" || numericUpDown1.Value == 0)
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = false;
                }
                else
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = true;
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked == true)
            {
                if (userNameBox.Text == "" || numericUpDown.Value == 0) { buttonCreateUser.Enabled = false; }
                else { buttonCreateUser.Enabled = true; }
            }
            else if (radioButtonRealmsUsers.Checked == true)
            {
                if (realmNameBox.Text == "" || numericUpDown.Value == 0 || userNameBox.Text == "" || numericUpDown1.Value == 0)
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = false;
                }
                else
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = true;
                }
            }
        }

        private void buttonCreateRealm_Click(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            url = xdoc.Element("url").Value;
            realm = xdoc.Element("realm").Value;
            username = xdoc.Element("username").Value;
            password = xdoc.Element("password").Value;
            clientId = xdoc.Element("clientId").Value;
            masteruser = xdoc.Element("masteruser").Value;
            masterpass = xdoc.Element("masterpass").Value;
            debug = Convert.ToBoolean(xdoc.Element("debug").Value);

            progressBarUser.Maximum = Convert.ToInt32(numericUpDown.Value);
            progressBarRealm.Maximum = Convert.ToInt32(numericUpDown1.Value);
            
            r = 1;

            do
            {
                var client = new RestClient(url + "/realms/master/protocol/openid-connect/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("undefined", "grant_type=password&username=" + masteruser + "&password=" + masterpass + "&client_id=" + clientId, ParameterType.RequestBody);

                response = client.Execute(request);

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
                }

                var newRealm = new RestClient(url + "/admin/realms/");
                var requestNewRealm = new RestRequest(Method.POST);
                requestNewRealm.AddHeader("Authorization", "Bearer " + realmToken);
                requestNewRealm.AddHeader("Content-Type", "application/json");
                requestNewRealm.AddParameter("undefined", "{\"realm\": \"" + realmNameBox.Text + r + "\"," +
                                                          "\"displayName\": \"" + realmNameBox.Text + r + "\"," +
                                                          "\"enabled\": true}", ParameterType.RequestBody);
                responseRealm = newRealm.Execute(requestNewRealm);

                progressBarRealm.Value = r - 1;

                i = 1;

                do {
                    var clientUser = new RestClient(url + "/admin/realms/" + realmNameBox.Text + r + "/users");
                    var requestUser = new RestRequest(Method.POST);
                    requestUser.AddHeader("Authorization", "Bearer " + realmToken);
                    requestUser.AddHeader("Content-Type", "application/json");
                    requestUser.AddParameter("undefined", "{\"username\":\"" + userNameBox.Text + i + "\"," +
                                                          "\"enabled\":\"true\",\"emailVerified\":\"true\"," +
                                                          "\"credentials\": " +
                                                          "[{\"type\": \"password\"," +
                                                          "\"value\": \"" + userNameBox.Text + i + "\"}]}", ParameterType.RequestBody);
                    responseNewUser = clientUser.Execute(requestUser);
                    
                    progressBarUser.Value = i - 1;

                    i++;

                } while (i <= numericUpDown.Value);

                r++;

            } while (r <= numericUpDown1.Value);

            MessageBox.Show("Done creating " + (r-1) + " realm(s) and " + (i-1) + " user(s).");
            progressBarUser.Value = i - 1;
            progressBarRealm.Value = r - 1;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked == true)
            {
                if (userNameBox.Text == "" || numericUpDown.Value == 0) { buttonCreateUser.Enabled = false; }
                else { buttonCreateUser.Enabled = true; }
            }
            else if (radioButtonRealmsUsers.Checked == true)
            {
                if (realmNameBox.Text == "" || numericUpDown.Value == 0 || userNameBox.Text == "" || numericUpDown1.Value == 0)
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = false;
                }
                else
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = true;
                }
            }
        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked == true)
            {
                if (userNameBox.Text == "" || numericUpDown.Value == 0) { buttonCreateUser.Enabled = false; }
                else { buttonCreateUser.Enabled = true; }
            }
            else if (radioButtonRealmsUsers.Checked == true)
            {
                if (realmNameBox.Text == "" || numericUpDown.Value == 0 || userNameBox.Text == "" || numericUpDown1.Value == 0)
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = false;
                }
                else
                {
                    buttonCreateUser.Enabled = false;
                    buttonCreateRealm.Enabled = true;
                }
            }
        }

        private void FormAddUsers_Load(object sender, EventArgs e)
        {
            radioButtonUsers.Checked = true;

            userNameBox.Text = "";
            numericUpDown.Value = 0;
            buttonCreateUser.Enabled = false;
            realmNameBox.Text = "";
            numericUpDown1.Value = 0;
            buttonCreateRealm.Enabled = false;
        }
        
        public FormAddUsers()
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

            progressBarUser.Maximum = Convert.ToInt32(numericUpDown.Value);

            i = 1;

            do
            {
                var client = new RestClient(url + "/realms/" + realm + "/protocol/openid-connect/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("undefined", "grant_type=password&username=" + username + "&password=" + password + "&client_id=" + clientId, ParameterType.RequestBody);

                response = client.Execute(request);

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
                }

                var clientUser = new RestClient(url + "/admin/realms/" + realm + "/users");
                var requestUser = new RestRequest(Method.POST);
                requestUser.AddHeader("Authorization", "Bearer " + realmToken);
                requestUser.AddHeader("Content-Type", "application/json");
                requestUser.AddParameter("undefined", "{\"username\":\"" + userNameBox.Text + i + "\"," +
                                                      "\"enabled\":\"true\",\"emailVerified\":\"true\"," +
                                                      "\"credentials\": " +
                                                      "[{\"type\": \"password\"," +
                                                      "\"value\": \"" + userNameBox.Text + i + "\"}]}", ParameterType.RequestBody);
                responseNewUser = clientUser.Execute(requestUser);

                progressBarUser.Value = i-1;

                i++;
            } while (i <= numericUpDown.Value);

            MessageBox.Show("Created " + (i-1) + " users.");
            progressBarUser.Value = i - 1;

        }
    }
}
