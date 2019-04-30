using RentACar.Dal.Concretes.Repo;
using RentACar.Bll.Concretes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentACar.Model.EntityModels;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //using (var x = new EmployeeManager())
            //{
            //    Employees cust = new Employees();
            //    cust = x.SelectById(4);

            //}

            //ekle
            //using (var x = new CustomerManager())
            //{
            //    Customers cust = new Customers();
            //    cust.FirstName = "Yasin";
            //    cust.Password = "1234Aydın";
            //    x.Insert(cust);
            //}

            //using (var x = new CustomerManager())
            //{
            //    Customers cust = new Customers();
            //    cust = x.SelectById(1003);
            //    x.Delete(cust);
            //}
            using (var x = new EmployeeManager())
            {

                dataGridView1.DataSource = x.SelectAll();
            }
            
        }
    }
}
