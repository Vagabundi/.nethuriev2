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
    public partial class EmpsWin : Form
    {
        public EmpsWin()
        {
            InitializeComponent();
        }
        EmployeeManager _empManager = new EmployeeManager();
        JobManager _jobManager = new JobManager();
        DepManager _depManager = new DepManager();
        private void buttonSave_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Please input surname", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxLastName.Focus();
                    return;
                }
                Employee employee = new Employee();
                employee.EmployeeId = int.Parse(textBoxEmpId.Text);
                employee.FirstName = textBoxName.Text;
                employee.LastName = textBoxLastName.Text;
                employee.JobId = int.Parse(comboBoxJobId.Text);
                employee.DepartmentId = int.Parse(comboBoxDepId.Text);
                employee.Email = $"{employee.FirstName}{employee.LastName}{employee.EmployeeId}@gmail.com";
                employee.Salary = double.Parse(textBoxSalary.Text);
                var depList = _depManager.GetAll();
                Department? selectedDep = depList.FirstOrDefault(obj => obj.DepartmentId == employee.DepartmentId);
                selectedDep.EmployeeCount++;
                _depManager.Update(selectedDep);
                if (_empManager.Add(employee))
                {
                    MessageBox.Show("Employee information has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Employee information has not been saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EmpsWin_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                EmpUpd frm = new EmpUpd(this);
                frm.textBoxEmpId.Text = row.Cells[0].Value.ToString();
                frm.textBoxName.Text = row.Cells[1].Value.ToString();
                frm.textBoxLastName.Text = row.Cells[2].Value.ToString();
                frm.textBoxEmail.Text = row.Cells[3].Value.ToString();
                frm.comboBoxJobId.Text = row.Cells[4].Value.ToString();
                frm.comboBoxDepId.Text = row.Cells[5].Value.ToString();
                frm.textBoxSalary.Text = row.Cells[6].Value.ToString();
                var jobList = _jobManager.GetAll();
                frm.comboBoxJobId.DataSource = jobList;
                frm.comboBoxJobId.DisplayMember = "JobId";
                var depList = _depManager.GetAll();
                frm.comboBoxDepId.DataSource = depList;
                frm.comboBoxDepId.DisplayMember = "DepartmentId";
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                if (MessageBox.Show("Do you want to delete this row?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = (int)row.Cells[0].Value;
                    bool isDelete = _empManager.Delete(id);
                    if (isDelete)
                    {
                        MessageBox.Show("Employee has been removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Rows.Remove(row);
                    }
                    else
                    {
                        MessageBox.Show("Employee removal failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonToDeps_Click(object sender, EventArgs e)
        {
            DepWin depWin = new DepWin();
            Hide();
            depWin.Show();
        }
        private void buttonToJobs_Click(object sender, EventArgs e)
        {
            JobsWin jobsWin = new JobsWin();
            Hide();
            jobsWin.Show();
        }
        public void Reset()
        {
            textBoxEmpId.Clear();
            textBoxLastName.Clear();
            textBoxName.Clear();
            textBoxSalary.Clear();
            LoadData();
        }
        public void LoadData()
        {
            var employees = _empManager.GetAll();
            dataGridView1.Rows.Clear();
            foreach (var employee in employees)
            {
                dataGridView1.Rows.Add(employee.EmployeeId, employee.FirstName, employee.LastName, employee.Email, employee.JobId, employee.DepartmentId, employee.Salary);
            }
            textBoxEmpId.Text = GenerateId().ToString();
            var jobList = _jobManager.GetAll();
            comboBoxJobId.DataSource = jobList;
            comboBoxJobId.DisplayMember = "JobId";
            var depList = _depManager.GetAll();
            comboBoxDepId.DataSource = depList;
            comboBoxDepId.DisplayMember = "DepartmentId";
        }
        public int GenerateId()
        {
            var emps = _empManager.GetAll();
            int lastId = 0;
            if (emps.Count > 0)
            {
                lastId = emps.Max(emp => emp.EmployeeId);
            }
            return lastId + 1;
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxJobId.SelectedItem != null && comboBoxJobId.SelectedItem is Job selectedObject)
            {
                int selectedId = selectedObject.JobId;
                var jobList = _jobManager.GetAll();
                Job? selectedJob = jobList.FirstOrDefault(obj => obj.JobId == selectedId);
                textBoxSalary.Text = $"{selectedJob?.MinSalary}-{selectedJob?.MaxSalary}";
                label7.Text = selectedJob?.JobName;
            }
            else
            {
                label7.Text = "No job selected";
            }
        }

        private void comboBoxDepId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDepId.SelectedItem != null && comboBoxDepId.SelectedItem is Department selectedObject)
            {
                int selectedId = selectedObject.DepartmentId;
                var depList = _depManager.GetAll();
                Department? selectedDep = depList.FirstOrDefault(obj => obj.DepartmentId == selectedId);
                label8.Text = selectedDep?.DepartmentName;
            }
            else
            {
                label8.Text = "No department selected";
            }
        }

        private void textBoxSalary_Enter(object sender, EventArgs e)
        {
            if (textBoxSalary.Text.Contains("-"))
            {
                textBoxSalary.Text = "";
            }
        }
    }
}
