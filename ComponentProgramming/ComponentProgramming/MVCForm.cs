﻿using ComponentProgramming.Controllers;
using ComponentProgramming.Models;
using ComponentProgramming.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentProgramming
{
    public partial class MVCForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int LeftRect,
            int TopRect,
            int RightRect,
            int BottomRect,
            int WidthEllipse,
            int HeightEllipse
        );

        public MVCForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            /*Login loginModel = new Login();
            LoginView loginView = new LoginView();
            LoginController loginController = new LoginController(loginModel, loginView);
            loginController.DisplayView(this);*/

            /*EditEmployee editEmployee = new EditEmployee();
            EditEmployeeView editEmployeeView = new EditEmployeeView();
            EditEmployeeController editEmployeeController = new EditEmployeeController(editEmployee, editEmployeeView);
            editEmployeeController.DisplayView(this);*/

            /*AddEmployee addEmployee = new AddEmployee();
            AddEmployeeView addEmployeeView = new AddEmployeeView();
            AddEmployeeController addEmployeeController = new AddEmployeeController(addEmployee, addEmployeeView);
            addEmployeeController.DisplayView(this);*/

            /*DeleteEmployee deleteEmployee = new DeleteEmployee();
            DeleteEmployeeView deleteEmployeeView = new DeleteEmployeeView();
            DeleteEmployeeController deleteEmployeeController = new DeleteEmployeeController(deleteEmployee, deleteEmployeeView);
            deleteEmployeeController.DisplayView(this);*/

            AdminDashboard adminDashboard = new AdminDashboard();
            AdminDashboardView adminDashboardView = new AdminDashboardView();
            AdminDashboardController adminDashboardController = new AdminDashboardController(adminDashboard, adminDashboardView);
            adminDashboardController.DisplayView(this);
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, Color.FromArgb(233, 233, 241), Color.FromArgb(122, 175, 228), 50);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, ClientRectangle);
            base.OnPaint(e);
        }
    }
}
