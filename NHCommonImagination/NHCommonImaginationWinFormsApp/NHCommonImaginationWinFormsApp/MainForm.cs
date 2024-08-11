using NHCommonImaginationWinFormsApp.Models;
using NHibernate;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NHCommonImaginationWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddTwoEmployees_Click(object sender, EventArgs e)
        {
            var fio = txtFIO.Text.Trim();
            var phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(fio) && string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Введите ФИО и Номер телефона", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }           

            using (var session = Program.sessionFactory.OpenSession())
            {
                var employee = new Employee()
                {
                    Name = fio,
                    PhoneNumber = phone
                };
                session.Save(employee);
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            using (var session = Program.sessionFactory.OpenSession())
            {
                var employees = session.CreateCriteria<Employee>().List<Employee>();
                dataGridView1.DataSource = employees.ToList();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
