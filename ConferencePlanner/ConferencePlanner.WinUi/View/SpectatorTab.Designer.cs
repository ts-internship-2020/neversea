namespace ConferencePlanner.WinUi.View
{
    partial class SpectatorTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpectatorTab));
            this.dgvSpectator = new System.Windows.Forms.DataGridView();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnStartDate = new System.Windows.Forms.Button();
            this.btnEndDate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpectator)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSpectator
            // 
            this.dgvSpectator.BackgroundColor = System.Drawing.Color.White;
            this.dgvSpectator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpectator.GridColor = System.Drawing.Color.White;
            this.dgvSpectator.Location = new System.Drawing.Point(265, 18);
            this.dgvSpectator.Name = "dgvSpectator";
            this.dgvSpectator.Size = new System.Drawing.Size(507, 202);
            this.dgvSpectator.TabIndex = 0;
            this.dgvSpectator.Text = "dataGridView1";
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchBar.Location = new System.Drawing.Point(102, 35);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(144, 27);
            this.txtSearchBar.TabIndex = 2;
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(102, 102);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(144, 27);
            this.dtpStart.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 171);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 27);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(12, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 63);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnStartDate
            // 
            this.btnStartDate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnStartDate.FlatAppearance.BorderSize = 0;
            this.btnStartDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartDate.Image = ((System.Drawing.Image)(resources.GetObject("btnStartDate.Image")));
            this.btnStartDate.Location = new System.Drawing.Point(12, 87);
            this.btnStartDate.Name = "btnStartDate";
            this.btnStartDate.Size = new System.Drawing.Size(75, 63);
            this.btnStartDate.TabIndex = 4;
            this.btnStartDate.UseVisualStyleBackColor = false;
            // 
            // btnEndDate
            // 
            this.btnEndDate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEndDate.FlatAppearance.BorderSize = 0;
            this.btnEndDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEndDate.Image = ((System.Drawing.Image)(resources.GetObject("btnEndDate.Image")));
            this.btnEndDate.Location = new System.Drawing.Point(12, 156);
            this.btnEndDate.Name = "btnEndDate";
            this.btnEndDate.Size = new System.Drawing.Size(75, 63);
            this.btnEndDate.TabIndex = 4;
            this.btnEndDate.UseVisualStyleBackColor = false;
            // 
            // SpectatorTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 226);
            this.Controls.Add(this.btnEndDate);
            this.Controls.Add(this.btnStartDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.dgvSpectator);
            this.Name = "SpectatorTab";
            this.Text = "SpectatorTab";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpectator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSpectator;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnStartDate;
        private System.Windows.Forms.Button btnEndDate;
    }
}