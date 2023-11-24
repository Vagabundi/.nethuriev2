using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hrDep.Models;
using hrDep.Manager;

namespace hrDep
{
    public partial class EmpUpd : Form
    {
        EmpsWin frm;
        public EmpUpd(EmpsWin frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        EmployeeManager _empManager = new EmployeeManager();
        JobManager _jobManager = new JobManager();
        DepManager _depManager = new DepManager();

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxName.Text))
                {
                    MessageBox.Show("Please input name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBoxLastName.Text))
                {
                    MessageBox.Show("Please input last name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxLastName.Focus();
                    return;
                }
                Employee employee = new Employee();
                employee.EmployeeId = int.Parse(textBoxEmpId.Text);
                employee.FirstName = textBoxName.Text;
                employee.LastName = textBoxLastName.Text;
                employee.Email = textBoxEmail.Text;
                employee.JobId = int.Parse(comboBoxJobId.Text);
                employee.DepartmentId = int.Parse(comboBoxDepId.Text);
                employee.Salary = double.Parse(textBoxSalary.Text);
                if (_empManager.Update(employee))
                {
                    MessageBox.Show("Employee information has been updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frm.LoadData();
                }
                else
                {
                    MessageBox.Show("Updated employee information has not been saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxJobId.SelectedItem != null && comboBoxJobId.SelectedItem is Job selectedObject)
            {
                int selectedId = selectedObject.JobId;
                var jobList = _jobManager.GetAll();
                Job? selectedJob = jobList.FirstOrDefault(obj => obj.JobId == selectedId);
                label11.Text = $"{selectedJob?.MinSalary}-{selectedJob?.MaxSalary}";
                label9.Text = selectedJob?.JobName;
            }
            else
            {
                label9.Text = "No job selected";
            }
        }
        private void textBoxSalary_Enter(object sender, EventArgs e)
        {
            if (textBoxSalary.Text.Contains("-"))
            {
                textBoxSalary.Text = "";
            }
        }

        private void comboBoxDepId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDepId.SelectedItem != null && comboBoxDepId.SelectedItem is Department selectedObject)
            {
                int selectedId = selectedObject.DepartmentId;
                var depList = _depManager.GetAll();
                Department? selectedDep = depList.FirstOrDefault(obj => obj.DepartmentId == selectedId);
                label10.Text = selectedDep?.DepartmentName;
            }
            else
            {
                label10.Text = "No department selected";
            }
        }
    }
}

