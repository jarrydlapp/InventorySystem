//*******************************************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			
//
//			File:				Login.cs
//
//			Student:			Jarryd
//
//			Course Name:		COSC 4260
//
//			Date:				March 25th 2017
//
//
//			Description: 
//			This program is a cargo tracking software to be used during military training
//          exercises to track and report cargo within the training area.
//
//			Other Files included: 
//			Users.cs
//          users.csv 
//
//*******************************************************************************************************
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RIDS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private readonly RidsDriver _rdsDriver = new RidsDriver();
      
        ////////////////////////////////////////////////////////////
        // Calls the UserLogin Fucntion to validate Login
        private void btnlogin_Click(object sender, EventArgs e)
        {
            var valid = _rdsDriver.UserLogin(txtUserName.Text, txtPassword.Text);
            if (valid)
            {
                Hide();
                Main rids = new Main();
                rids.Show();
            }
            if (valid) return;
            txtUserName.Clear();
            txtPassword.Clear();
            MessageBox.Show(@"Login Credentials are Invalid");
        }
        ////////////////////////////////////////////////////////////
        // Close the applicaion
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
