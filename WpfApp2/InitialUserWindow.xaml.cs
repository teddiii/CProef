﻿using CproefLib.BL;
using CproefLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for InitialUserWindow.xaml
    /// </summary>
    public partial class InitialUserWindow : Window
    {
        public delegate void UserCreated(string username, string pwd);
        public event UserCreated OnUserCreated;

        public InitialUserWindow()
        {
            InitializeComponent();

            //var _form = new UserForm();
            //_form.Confirming += FormConfirming;

            //mainContent.Content = _form;
        }

        private void FormConfirming(Users user, string pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd))
            {
                MessageBox.Show("The password is mandatory");
            }
            else
            {
                user = BL_Users.ChangePassword(user, pwd);

                BL_Users.Create(user);

                if (OnUserCreated != null)
                    OnUserCreated(user.Username, pwd);

                this.Close();
            }
        }
    }
}
