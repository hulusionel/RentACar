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



            //using (var x = new TransactionManager())
            //{
            //    Transactions trans = new Transactions();
            //    CarManager cm = new CarManager();
            //    Cars car = new Cars();
            //    CustomerManager cmm = new CustomerManager();


            //    var selectedcar = cm.SelectById(2);
            //    var selectedCustomer = cmm.SelectById(1);
            //    x.Rent(trans,selectedcar,selectedCustomer, DateTime.Now, DateTime.Now);
            //}


            using (var x = new CarDetailsManager())
            {
               // CarDetail cust = new CarDetail();
                x.DailyKmControl(1, 4, DateTime.Now, 50);
            }

            using (var x = new CarDetailsManager())
            {

                dataGridView1.DataSource = x.SelectAll();
            }
            
        }
    }
}
