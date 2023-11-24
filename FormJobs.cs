using hrDep.Models;
using hrDep.Manager;

namespace hrDep
{
    public partial class JobsWin : Form
    {
        public JobsWin()
        {
            InitializeComponent();
        }
        JobManager _jobManager = new JobManager();
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxJobName.Text))
                {
                    MessageBox.Show("Please input job name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxJobName.Focus();
                    return;
                }
                if (double.Parse(textBoxMaxSal.Text) < double.Parse(textBoxMinSal.Text))
                {
                    MessageBox.Show("Maximal salary should not be bigger than minimal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaxSal.Focus();
                    return;
                }
                Job job = new Job();
                job.JobId = int.Parse(textBoxJobId.Text);
                job.JobName = textBoxJobName.Text;
                job.MinSalary = double.Parse(textBoxMinSal.Text);
                job.MaxSalary = double.Parse(textBoxMaxSal.Text);
                if (_jobManager.Add(job))
                {
                    MessageBox.Show("Job information has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Job information has not been saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void JobsWin_Load(object sender, EventArgs e)
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
                JobUpd frm = new JobUpd(this);
                frm.textBoxJobId.Text = row.Cells[0].Value.ToString();
                frm.textBoxJobName.Text = row.Cells[1].Value.ToString();
                frm.textBoxMinSal.Text = row.Cells[2].Value.ToString();
                frm.textBoxMaxSal.Text = row.Cells[3].Value.ToString();
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
                    bool isDelete = _jobManager.Delete(id);
                    if (isDelete)
                    {
                        MessageBox.Show("Job has been removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Rows.Remove(row);
                    }
                    else
                    {
                        MessageBox.Show("Job removal failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void buttonToEmps_Click(object sender, EventArgs e)
        {
            EmpsWin empWin = new EmpsWin();
            Hide();
            empWin.Show();
        }
        public void Reset()
        {
            textBoxJobId.Clear();
            textBoxMaxSal.Clear();
            textBoxMinSal.Clear();
            textBoxJobName.Clear();
            LoadData();
        }
        public void LoadData()
        {
            var jobs = _jobManager.GetAll();
            dataGridView1.Rows.Clear();
            foreach (var job in jobs)
            {
                dataGridView1.Rows.Add(job.JobId, job.JobName, job.MinSalary, job.MaxSalary);
            }
            textBoxJobId.Text = GenerateId().ToString();
        }
        public int GenerateId()
        {
            var jobs = _jobManager.GetAll();
            int lastId = 0;

            if (jobs.Count > 0)
            {
                lastId = jobs.Max(job => job.JobId);
            }

            return lastId + 1;
        }

        
    }
}
