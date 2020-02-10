﻿using ComponentProgramming.Models;
using ComponentProgramming.Views;
using CustomControlls;
using Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.Linq;

namespace ComponentProgramming.Controllers
{
    class AddEmployeeController : Display
    {
        private AddEmployee model;
        private AddEmployeeView view;
        private LINQDataContext db;
        public AddEmployeeController(AddEmployee model, AddEmployeeView view)
        {
            db = new LINQDataContext();
            this.model = model;
            this.view = view;
            model.BtnCreate.Click += (sender, e) => btnCreate_Click(sender, e);
            DisplayDepartment();
        }

        private void DisplayDepartment()
        {
            
            var query = from displayPlace in db.Departments where displayPlace.DepartmentID != 7 select displayPlace;
            model.ComboDepartment.DataSource = query;
            model.ComboDepartment.DisplayMember = "Place";
            model.ComboDepartment.ValueMember = "DepartmentID";
        }
        private void AddAccount()
        {            
                Employee employee = new Employee
                {
                    FullName = model.TxtFirstName.Text + " " + model.TxtSurname.Text,
                    EAddress = model.TxtAddress.Text,
                    Email = model.TxtEmail.Text,
                    Password = model.TxtPassword.Text,
                    Phone = model.TxtPhone.Text,
                    DepartmentID = (int)model.ComboDepartment.SelectedValue,
                    DateJoined = DateTime.Now.ToShortDateString()
                };
                
                db.Employees.InsertOnSubmit(employee);

            try
            {
                db.SubmitChanges();
                MessageBox.Show("Data Inserted");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
                AddAccount();      
        }

        public void DisplayView(Form curForm)
        {
            view.SetUpControlls(model.LblFirstName,
                model.LblSurname,
                model.LblAddress,
                model.LblEmail,
                model.LblPassword,
                model.LblPhone,
                model.LblDepartment,
                model.TxtFirstName,
                model.TxtSurname,
                model.TxtAddress,
                model.TxtEmail,
                model.TxtPassword,
                model.TxtPhone,
                model.ComboDepartment,
                model.BtnCreate, curForm);
        }


    }
}
