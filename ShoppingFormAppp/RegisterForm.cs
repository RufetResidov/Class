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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ShoppingContext db = new ShoppingContext();
            string fullname = txtBoxFullname.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPass = txtConfirmPassword.Text;
            string []myArr ={ fullname,email,password,confirmPass};

           if (Utilities.IsEmpty(myArr))
            {
                if (password == confirmPass)
                {
                    User selectedUser = db.Users.FirstOrDefault(x=> x.Email == email);
                    if (selectedUser == null)
                    {
                        lblError.Visible = false;
                        var User = new User
                        {
                            Fullname = fullname,
                            Email = email,
                            Password = Utilities.HasMe(password)
                        };
                        db.Users.Add(User);
                        db.SaveChanges();
                        MessageBox.Show("user added succesfuly", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserToRole ustRole = new UserToRole()
                        {
                            UserId = User.Id,
                            RoleId = 1
                        };
                        db.UserToRoles.Add(ustRole);
                        db.SaveChanges();
                        txtBoxFullname.Text = "";
                        txtConfirmPassword.Text = "";
                        txtEmail.Text = "";
                        txtPassword.Text = "";
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "username already exist";

                    }

                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "password and confirm is not the same ";
                }
               

            }
           else
            {
                lblError.Visible = true;
                lblError.Text="Please all tje fiell";

            }
        }

       
    }
}
