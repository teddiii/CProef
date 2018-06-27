using CproefLib.BL;
using CproefLib.Models;
using CproefLib.Utilities;
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
using System.Windows.Shapes;
using WpfApp2.Extensions;

namespace WpfApp2
{
    /// <summary>
    /// Represents the window for our users to log in
    /// </summary>
    public partial class Loginwindow : Window
    {
        public bool ShowPassword { get; set; }


        public Loginwindow()
        {
            InitializeComponent();

            ShowPassword = false;
            TogglePass();
            txtUsername.Focus();

            //if (BL_Users.Any())
            //{
            //    txtUsername.Focus();
            //}
            //else
            //{
                //var _initial = new InitialUserWindow();
                //_initial.OnUserCreated += InitialUserWindow_OnUserCreated;

                //_initial.Show();
            //}
        }

        /// <summary>
        /// this is to toggle the password between text or dots
        /// </summary>
        private void TogglePass()
        {
            txtPassword.Visibility = btnShowPass.Visibility = !ShowPassword ? Visibility.Visible : Visibility.Collapsed;
            txtPasswordplain.Visibility = btnHidePass.Visibility = ShowPassword ? Visibility.Visible : Visibility.Collapsed;
        }

        private void InitialUserWindow_OnUserCreated(string username, string pass)
        {
            txtUsername.Text = username;
            txtPassword.Password = pass;

            txtPassword.Focus();
            txtPassword.SetCursorOnEnd();
        }

        private void PerformAuthentication()
        {
            lblError.Content = lblPasswordError.Content = lblUsernameError.Content = string.Empty;

            bool _ok = true;
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    lblUsernameError.Content = "is mandatory.";
                }
                if (string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    lblPasswordError.Content = "is mandatory.";
                }
                if (_ok && BL_Users.Authenticate(new Loginmodel() { CredentialName = txtUsername.Text, Password = txtPassword.Password }))
                {
                    new Mainwindow().Show();
                    this.Close();
                }
                else
                {
                    throw new Exception("Authentication failed. Please check your credentials");
                }
            }
            catch (UserNotFoundException ex)
            {
                lblUsernameError.Content = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
            ShowPassword = false;
            TogglePass();

            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            PerformAuthentication();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application?", "Close application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)

            this.Close();
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PerformAuthentication();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PerformAuthentication();
            }
        }

        private void txtPasswordplain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PerformAuthentication();
            }
        }

        private void btnShowPass_Click(object sender, RoutedEventArgs e)
        {
            ShowPassword = true;
            TogglePass();
        }

        private void btnHidePass_Click(object sender, RoutedEventArgs e)
        {
            ShowPassword = false;
            TogglePass();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordplain.Text = txtPassword.Password;
            txtPassword.SetCursorOnEnd();
        }

        private void txtPasswordplain_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPassword.Password = txtPasswordplain.Text;
            txtPassword.Focus();
        }
    }
}
