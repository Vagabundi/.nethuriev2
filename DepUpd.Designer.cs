namespace hrDep
{
    partial class DepUpd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.textBoxLoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDepCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDepName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDepId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(102, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Location";
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(128, 206);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(235, 30);
            this.buttonUpd.TabIndex = 12;
            this.buttonUpd.Text = "Update";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // textBoxLoc
            // 
            this.textBoxLoc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLoc.Location = new System.Drawing.Point(180, 114);
            this.textBoxLoc.Name = "textBoxLoc";
            this.textBoxLoc.Size = new System.Drawing.Size(270, 27);
            this.textBoxLoc.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(39, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Employees Count";
            // 
            // textBoxDepCount
            // 
            this.textBoxDepCount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDepCount.Location = new System.Drawing.Point(180, 159);
            this.textBoxDepCount.Name = "textBoxDepCount";
            this.textBoxDepCount.Size = new System.Drawing.Size(270, 27);
            this.textBoxDepCount.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(31, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Department Name";
            // 
            // textBoxDepName
            // 
            this.textBoxDepName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDepName.Location = new System.Drawing.Point(180, 71);
            this.textBoxDepName.Name = "textBoxDepName";
            this.textBoxDepName.Size = new System.Drawing.Size(270, 27);
            this.textBoxDepName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(58, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Department Id";
            // 
            // textBoxDepId
            // 
            this.textBoxDepId.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDepId.Location = new System.Drawing.Point(180, 29);
            this.textBoxDepId.Name = "textBoxDepId";
            this.textBoxDepId.ReadOnly = true;
            this.textBoxDepId.Size = new System.Drawing.Size(270, 27);
            this.textBoxDepId.TabIndex = 13;
            // 
            // DepUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 250);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.textBoxLoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDepCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDepName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDepId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepUpd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Department Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label4;
        private Button buttonUpd;
        private Label label3;
        private Label label2;
        private Label label1;
        public TextBox textBoxLoc;
        public TextBox textBoxDepCount;
        public TextBox textBoxDepName;
        public TextBox textBoxDepId;
    }
}