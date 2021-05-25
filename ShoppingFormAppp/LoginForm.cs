using ShoppingFormAppp.Helpers;
using ShoppingFormAppp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingFormAppp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (Utilities.IsEmpty(new[] { email,password}))
            { 
                ShoppingContext db = new ShoppingContext();
                User selectedUser = db.Users.FirstOrDefault(x => x.Email == email);
                if (selectedUser != null)
                {
                    if (selectedUser.Password == password.HasMe())
                    {
                        var userRolesId = db.UserToRoles.FirstOrDefault(x => x.UserId == selectedUser.Id).RoleId;
                        if (userRolesId == 2)
                        {
                            AdminForm adm = new AdminForm();
                            adm.ShowDialog();
                        }
                        else if (userRolesId == 1)
                        {
                            CustomerForm cdm = new CustomerForm(selectedUser);
                            cdm.ShowDialog();

                        }
                        
                    }
                    else
                    {

                        lblError.Visible = true;
                        lblError.Text = "Password doesn't correct";
                    }
                }

            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Email doesn't correct";
            }
        }

       
    }
}
