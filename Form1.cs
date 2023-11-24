using hrDep.Models;
using hrDep.Manager;


namespace hrDep
{
    public partial class DepWin : Form
    {
        public DepWin()
        {
            InitializeComponent();
        }
        DepManager _depManager = new DepManager();
        private void buttonSave_Click(object sender, EventArgs e)
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
                if(_depManager.Add(department))
                {
                    MessageBox.Show("Department information has been saved.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Department information has not been saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DepWin_Load(object sender, EventArgs e)
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
                DepUpd frm = new DepUpd(this);
                frm.textBoxDepId.Text = row.Cells[0].Value.ToString();
                frm.textBoxDepName.Text = row.Cells[1].Value.ToString();
                frm.textBoxLoc.Text = row.Cells[2].Value.ToString();
                frm.textBoxDepCount.Text = row.Cells[3].Value.ToString();
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
                    bool isDelete = _depManager.Delete(id);
                    if (isDelete)
                    {
                        MessageBox.Show("Department has been removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Rows.Remove(row);
                    }
                    else
                    {
                        MessageBox.Show("Department removal failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonToEmps_Click(object sender, EventArgs e)
        {
            EmpsWin empWin = new EmpsWin();
            Hide();
            empWin.Show();
        }
        private void buttonToJobs_Click(object sender, EventArgs e)
        {
            JobsWin jobsWin = new JobsWin();
            Hide();
            jobsWin.Show();
        }
        public void Reset()
        {
            textBoxDepId.Clear();
            textBoxLoc.Clear();
            textBoxDepCount.Clear();
            textBoxDepName.Clear();
            LoadData();
        }

        public void LoadData()
        {
            var departments = _depManager.GetAll();
            dataGridView1.Rows.Clear();
            foreach (var department in departments)
            {
                dataGridView1.Rows.Add(department.DepartmentId, department.DepartmentName, department.Location, department.EmployeeCount);
            }
            textBoxDepId.Text = GenerateId().ToString();
        }
        public int GenerateId()
        {
            var deps = _depManager.GetAll();
            int lastId = 0;
            if (deps.Count > 0)
            {
                lastId = deps.Max(dep => dep.DepartmentId);
            }
            return lastId + 1;
        }
        

        
    }
}