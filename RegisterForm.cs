using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login.Register
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("server=localhost;" +
                                                           "Trusted_Connection=yes;" +
                                                           "database=LoginAppDB; " +
                                                           "connection timeout=30");
            if (this.textBoxUsername.Text == "" || this.textBoxPassword.Text == "")
            {
                MessageBox.Show("Please provide username and password");
                
            }
            else
            {
                try
                {
                    var uname = this.textBoxUsername.Text;
                    var pswd = this.textBoxPassword.Text;

                    SqlCommand myCommand =
                        new SqlCommand($"insert into loginDB.tblUsers(username, password) values('{uname}','{pswd}')",
                            myConnection);

                    myConnection.Open();
                    var result = myCommand.ExecuteScalar();

                    myConnection.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}