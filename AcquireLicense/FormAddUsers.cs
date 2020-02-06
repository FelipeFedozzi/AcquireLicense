using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Net;
using System.Windows.Forms;

using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AcquireLicense
{
    public partial class FormAddUsers : Form
    {
        object token, newToken;
        string realmToken, url, realm, username, password, clientId, masteruser, masterpass, userIdArray, roleIdArray, realmIdArray, userId, roleId, realmId, role, realmNewToken;
        IRestResponse response, responseNewUser, responseRealm, getIdRoleResponse, getIdRealmResponse, getIdUserResponse, responseRole, responseNewToken;

        public void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > numericUpDown2.Value) { buttonCreateRealm.Enabled = true; }
            else { buttonCreateRealm.Enabled = false; }
        }

        bool debug;
        int i, r, a, numUsers;

        XElement xdoc = XElement.Load("C:\\Users\\Felipe.Fedozzi\\Source\\Repos\\AcquireLicense\\AcquireLicense\\var.xml");

        public void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();

            FormMain form = new FormMain();
            form.Show();
        }

        public void radioButtonRealmsUsers_CheckedChanged(object sender, EventArgs e)
        {
            realmNameBox.Visible = true;
            buttonCreateRealm.Visible = true;
            numericUpDown1.Visible = true;
            numericUpDown2.Visible = true;
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
                if (realmNameBox.Text == "" || numericUpDown.Value == 1 || userNameBox.Text == "" || numericUpDown1.Value == 1 || numericUpDown2.Value == 1)
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

            if (numericUpDown1.Value > numericUpDown2.Value) { buttonCreateRealm.Enabled = true; }
            else { buttonCreateRealm.Enabled = false; }
        }

        public void radioButtonUsers_CheckedChanged(object sender, EventArgs e)
        {
            realmNameBox.Visible = false;
            buttonCreateRealm.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
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

        public void realmNameBox_TextChanged(object sender, EventArgs e)
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

            if (numericUpDown1.Value > numericUpDown2.Value) { buttonCreateRealm.Enabled = true; }
            else { buttonCreateRealm.Enabled = false; }
        }

        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
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

            if (numericUpDown1.Value > numericUpDown2.Value) { buttonCreateRealm.Enabled = true; }
            else { buttonCreateRealm.Enabled = false; }
        }

        public void buttonCreateRealm_Click(object sender, EventArgs e)
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
            role = xdoc.Element("role").Value;

            progressBarUser.Maximum = Convert.ToInt32(numericUpDown.Value);
            progressBarRealm.Maximum = Convert.ToInt32(numericUpDown1.Value);
            
            r = Convert.ToInt32(numericUpDown2.Value);

            do
            {
                labelRealms.Text = "Creating " + realmNameBox.Text + r + ".\nPlease wait...";

                var client = new RestClient(url + "/realms/master/protocol/openid-connect/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("undefined", "grant_type=password&username=" + masteruser + "" +
                                                  "&password=" + masterpass + "" +
                                                  "&client_id=" + clientId, ParameterType.RequestBody);

                response = client.Execute(request);

                //if (debug == true) { MessageBox.Show(response.Content); }

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
                    if (debug == true) { MessageBox.Show("Master token = " + realmToken); }
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

                i = Convert.ToInt32(numericUpDown3.Value);

                do {
                    labelUsers.Text = "Creating " + userNameBox.Text + i + ".\nPlease wait...";

                    //Acquire a new token
                    var clientNewToken = new RestClient(url + "/realms/master/protocol/openid-connect/token");
                    var requestNewToken = new RestRequest(Method.POST);
                    requestNewToken.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    requestNewToken.AddParameter("undefined", "grant_type=password&username=" + masteruser + "" +
                                                      "&password=" + masterpass + "" +
                                                      "&client_id=" + clientId, ParameterType.RequestBody);

                    responseNewToken = clientNewToken.Execute(requestNewToken);

                    //if (debug == true) { MessageBox.Show(response.Content); }

                    string newTokenArray = responseNewToken.Content;

                    if (newTokenArray.Contains("invalid"))
                    {
                        MessageBox.Show("Invalid user credentials", "ERROR");
                        return;
                    }

                    if (newTokenArray.Contains("unauthorized_client"))
                    {
                        MessageBox.Show("Invalid client", "ERROR");
                        return;
                    }

                    Dictionary<string, object> valuesNewToken = JsonConvert.DeserializeObject<Dictionary<string, object>>(newTokenArray);

                    //Deserialize Token value
                    if (valuesNewToken is null) { MessageBox.Show("No token was created", "ERROR"); }

                    else
                    {
                        valuesNewToken.TryGetValue("access_token", out newToken);
                        realmNewToken = newToken.ToString();
                        if (debug == true) { MessageBox.Show("Master token = " + realmNewToken); }
                    }

                    //Create new user
                    var clientUser = new RestClient(url + "/admin/realms/" + realmNameBox.Text + r + "/users");
                    var requestUser = new RestRequest(Method.POST);
                    requestUser.AddHeader("Authorization", "Bearer " + realmNewToken);
                    requestUser.AddHeader("Content-Type", "application/json");
                    requestUser.AddParameter("undefined", "{\"username\":\"" + userNameBox.Text + i + "\"," +
                                                          "\"enabled\":\"true\",\"emailVerified\":\"true\"," +
                                                          "\"credentials\": " +
                                                          "[{\"type\": \"password\"," +
                                                          "\"value\": \"" + userNameBox.Text + i + "\"}]}", ParameterType.RequestBody);
                    responseNewUser = clientUser.Execute(requestUser);
            
                    //Get user id
                    var getIdUser = new RestClient(url + "/admin/realms/" + realmNameBox.Text + r + "/users/?username=" + userNameBox.Text + i);
                    var requestIdUser = new RestRequest(Method.GET);
                    requestIdUser.AddHeader("Authorization", "Bearer " + realmNewToken);
                    requestIdUser.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    getIdUserResponse = getIdUser.Execute(requestIdUser);

                    userIdArray = getIdUserResponse.Content;

                    char[] myString1 = userIdArray.ToCharArray();

                    string[] strings1 = new string[200];
                    for (a = 8; a < 44; a++)
                        strings1[a] = myString1[a].ToString();
                    userId = string.Join("", strings1);
                    if (debug == true) { MessageBox.Show("User ID = " + userId); }

                    //Get role id
                    var getIdRole = new RestClient(url + "/admin/realms/" + realmNameBox.Text + r + "/roles/" + role);
                    var requestIdRole = new RestRequest(Method.GET);
                    requestIdRole.AddHeader("Authorization", "Bearer " + realmNewToken);
                    requestIdRole.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    getIdRoleResponse = getIdRole.Execute(requestIdRole);
                    roleIdArray = getIdRoleResponse.Content;
                    
                    char[] myString2 = roleIdArray.ToCharArray();

                    string[] strings2 = new string[200];
                    for (a = 7; a < 43; a++)
                        strings2[a] = myString2[a].ToString();
                    roleId = string.Join("", strings2);
                    
                    if (debug == true) { MessageBox.Show("Role ID = " + roleId); }

                    //Get realm id
                    var getIdRealm = new RestClient(url + "/admin/realms/" + realmNameBox.Text + r);
                    var requestIdRealm = new RestRequest(Method.GET);
                    requestIdRealm.AddHeader("Authorization", "Bearer " + realmNewToken);
                    requestIdRealm.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    getIdRealmResponse = getIdRealm.Execute(requestIdRealm);
                    realmIdArray = getIdRealmResponse.Content;

                    char[] myString3 = realmIdArray.ToCharArray();

                    string[] strings3 = new string[200];
                    for (a = 7; a < 43; a++)
                        strings3[a] = myString3[a].ToString();
                    realmId = string.Join("", strings3);

                    if (debug == true) { MessageBox.Show("Realm ID = " + realmId); }
                    
                    //Assign role
                    var clientRole = new RestClient(url + "/admin/realms/" + realmNameBox.Text + r + "/users/" + userId + "/role-mappings/realm");
                    var requestRole = new RestRequest(Method.POST);
                    requestRole.AddHeader("Authorization", "Bearer " + realmNewToken);
                    requestRole.AddHeader("Content-Type", "application/json");
                    requestRole.AddParameter("undefined", "[{\"clientRole\":\"false\"," +
                                                        "\"composite\":\"false\"," +
                                                        "\"containerId\":\"" + realmId + "\"," +
                                                        "\"id\":\"" + roleId + "\"," +
                                                        "\"name\":\"" + role + "\"," +
                                                        "\"scopeParamRequired\":\"false\"}]", ParameterType.RequestBody);
                    responseRole = clientRole.Execute(requestRole);
                    
                    progressBarUser.Value = i - 1;

                    i++;

                    labelUsers.Update();
                    labelRealms.Update();

                } while (i <= numericUpDown.Value);

                r++;

            } while (r <= numericUpDown1.Value);

            MessageBox.Show("Done creating " + ((numericUpDown1.Value - numericUpDown2.Value) + 1) + " realm(s) and " + ((numericUpDown.Value - numericUpDown3.Value) + 1) + " user(s).\nAll users have the role " + role, "Success");
            progressBarUser.Value = i - 1;
            progressBarRealm.Value = r - 1;
        }

        public void numericUpDown_ValueChanged(object sender, EventArgs e)
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

            numUsers = Convert.ToInt32(numericUpDown.Value);
        }

        public void userNameBox_TextChanged(object sender, EventArgs e)
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

        public FormAddUsers()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)  //Add Users
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            url = xdoc.Element("url").Value;
            realm = xdoc.Element("realm").Value;
            username = xdoc.Element("username").Value;
            password = xdoc.Element("password").Value;
            clientId = xdoc.Element("clientId").Value;
            debug = Convert.ToBoolean(xdoc.Element("debug").Value);
            role = xdoc.Element("role").Value;

            progressBarUser.Maximum = Convert.ToInt32(numericUpDown.Value) + 1;

            i = Convert.ToInt32(numericUpDown3.Value);

            do
            {
                labelUsers.Text = "Creating " + userNameBox.Text + i + ".\nPlease wait...";

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
            
                //Get user id
                var getIdUser = new RestClient(url + "/admin/realms/" + realm + "/users/?username=" + userNameBox.Text + i);
                var requestIdUser = new RestRequest(Method.GET);
                requestIdUser.AddHeader("Authorization", "Bearer " + realmToken);
                requestIdUser.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                getIdUserResponse = getIdUser.Execute(requestIdUser);

                userIdArray = getIdUserResponse.Content;
                
                char[] myString1 = userIdArray.ToCharArray();

                string[] strings1 = new string[200];
                for (a = 8; a < 44; a++)
                    strings1[a] = myString1[a].ToString();
                userId = string.Join("", strings1);

                if (debug == true) { MessageBox.Show(userId); }

                //Get role id
                var getIdRole = new RestClient(url + "/admin/realms/" + realm + "/roles/" + role);
                var requestIdRole = new RestRequest(Method.GET);
                requestIdRole.AddHeader("Authorization", "Bearer " + realmToken);
                requestIdRole.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                getIdRoleResponse = getIdRole.Execute(requestIdRole);

                roleIdArray = getIdRoleResponse.Content;
                
                char[] myString2 = roleIdArray.ToCharArray();

                string[] strings2 = new string[200];
                for (a = 7; a < 43; a++)
                    strings2[a] = myString2[a].ToString();
                roleId = string.Join("", strings2);
                
                if (debug == true) { MessageBox.Show(roleId); }

                //Assign role
                var clientRole = new RestClient(url + "/admin/realms/" + realm + "/users/" + userId + "/role-mappings/realm");
                var requestRole = new RestRequest(Method.POST);
                requestRole.AddHeader("Authorization", "Bearer " + realmToken);
                requestRole.AddHeader("Content-Type", "application/json");
                requestRole.AddParameter("undefined", "[{\"clientRole\":\"false\"," +
                                                    "\"composite\":\"false\"," +
                                                    "\"containerId\":\"" + realm + "\"," +
                                                    "\"id\":\"" + roleId + "\"," +
                                                    "\"name\":\"" + role + "\"," +
                                                    "\"scopeParamRequired\":\"false\"}]", ParameterType.RequestBody);
                responseRole = clientRole.Execute(requestRole);

                if (i - 1 <= progressBarUser.Minimum) { progressBarUser.Value = i - 1; }
                else
                {
                    progressBarUser.Maximum = i + 1;
                    progressBarUser.Value = i;
                }

                i++;

                labelUsers.Update();

            } while (i <= numericUpDown.Value);

            MessageBox.Show("Created " + ((numericUpDown.Value - numericUpDown3.Value) + 1) + " users.");
            progressBarUser.Value = i;

        }

        public void FormAddUsers_Load(object sender, EventArgs e)
        {
            radioButtonUsers.Checked = true;

            userNameBox.Text = "";
            numericUpDown.Value = 1;
            buttonCreateUser.Enabled = false;
            realmNameBox.Text = "";
            numericUpDown1.Value = 1;
            buttonCreateRealm.Enabled = false;
            numericUpDown2.Value = 1;

            labelRealms.Text = "";
            labelUsers.Text = "";
        }
    }
}
