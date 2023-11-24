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
    public partial class DepUpd : Form
    {
        DepWin frm;
        public DepUpd(DepWin frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        DepManager _depManager = new DepManager();
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxDepName.Text))
                {
                    MessageBox.Show("Please input department name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxDepName.Focus();
                    return;
                }
                Department department = new Department();
                department.DepartmentId = int.Parse(textBoxDepId.Text);
                department.DepartmentName = textBoxDepName.Text;
                department.Location = textBoxLoc.Text;
                department.EmployeeCount = int.Parse(textBoxDepCount.Text);
                if (_depManager.Update(department))
                {
                    MessageBox.Show("Department information has been updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frm.LoadData();
                }
                else
                {
                    MessageBox.Show("Updated department information has not been saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
