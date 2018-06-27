
using CproefLib.BL;
using CproefLib.Entities;
using Fluent;
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

namespace WpfApp2
{
    /// <summary>
    /// Represents the main window in our application
    /// </summary>
    public partial class Mainwindow : RibbonWindow
    {
        private const string TITLE = "BryanPong";
        private Users currentUser;


        /// <summary>
        /// default constructor
        /// </summary>
        public Mainwindow()
        {
            InitializeComponent();

            currentUser = BL_Users.GetCurrentUser();
            SetTitle();
        }

        private void SetTitle()
        {
            try
            {
                string _title = "";

                //if (!string.IsNullOrWhiteSpace(label))
                {
                    //_title += label + " - ";
                    //_title = _title + label + " - ";
                }

                _title += TITLE + " " + currentUser.Fullname;

                this.Title = _title;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetTitleByButton(object sender)
        {
            try
            {
                SetTitleByButton(((Fluent.Button)sender).Header);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
