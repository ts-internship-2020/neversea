namespace ConferencePlanner.WinUi
{
    partial class HomePage
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
            this.MainPageTab = new System.Windows.Forms.TabControl();
            this.SpectatorTab = new System.Windows.Forms.TabPage();
            this.tlpSpectator = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.dgvConferences = new System.Windows.Forms.DataGridView();
            this.OrganizerTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOrganiser = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.MainPageTab.SuspendLayout();
            this.SpectatorTab.SuspendLayout();
            this.tlpSpectator.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConferences)).BeginInit();
            this.OrganizerTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganiser)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPageTab
            // 
            this.MainPageTab.Controls.Add(this.SpectatorTab);
            this.MainPageTab.Controls.Add(this.OrganizerTab);
            this.MainPageTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPageTab.Location = new System.Drawing.Point(0, 0);
            this.MainPageTab.Name = "MainPageTab";
            this.MainPageTab.SelectedIndex = 0;
            this.MainPageTab.Size = new System.Drawing.Size(800, 450);
            this.MainPageTab.TabIndex = 0;
            // 
            // SpectatorTab
            // 
            this.SpectatorTab.Controls.Add(this.tlpSpectator);
            this.SpectatorTab.Location = new System.Drawing.Point(4, 24);
            this.SpectatorTab.Name = "SpectatorTab";
            this.SpectatorTab.Padding = new System.Windows.Forms.Padding(3);
            this.SpectatorTab.Size = new System.Drawing.Size(792, 422);
            this.SpectatorTab.TabIndex = 0;
            this.SpectatorTab.Text = "Spectator";
            this.SpectatorTab.UseVisualStyleBackColor = true;
            // 
            // tlpSpectator
            // 
            this.tlpSpectator.AutoScroll = true;
            this.tlpSpectator.ColumnCount = 3;
            this.tlpSpectator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.08F));
            this.tlpSpectator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.84F));
            this.tlpSpectator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.08F));
            this.tlpSpectator.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlpSpectator.Controls.Add(this.dgvConferences, 1, 1);
            this.tlpSpectator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpectator.Location = new System.Drawing.Point(3, 3);
            this.tlpSpectator.Name = "tlpSpectator";
            this.tlpSpectator.RowCount = 2;
            this.tlpSpectator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpSpectator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tlpSpectator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSpectator.Size = new System.Drawing.Size(786, 416);
            this.tlpSpectator.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.lblEnd, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpStart, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpEnd, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblStart, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 3);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(100, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblEnd
            // 
            this.lblEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEnd.ForeColor = System.Drawing.Color.Black;
            this.lblEnd.Location = new System.Drawing.Point(328, 14);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(91, 21);
            this.lblEnd.TabIndex = 1;
            this.lblEnd.Text = "To";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpStart
            // 
            this.dtpStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStart.CalendarForeColor = System.Drawing.Color.CornflowerBlue;
            this.dtpStart.CalendarTitleForeColor = System.Drawing.Color.CornflowerBlue;
            this.dtpStart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpStart.Location = new System.Drawing.Point(100, 11);
            this.dtpStart.MaximumSize = new System.Drawing.Size(400, 30);
            this.dtpStart.MinimumSize = new System.Drawing.Size(50, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(222, 27);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpEnd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpEnd.Location = new System.Drawing.Point(425, 11);
            this.dtpEnd.MaximumSize = new System.Drawing.Size(350, 30);
            this.dtpEnd.MinimumSize = new System.Drawing.Size(50, 20);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(224, 27);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // lblStart
            // 
            this.lblStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStart.ForeColor = System.Drawing.Color.Black;
            this.lblStart.Location = new System.Drawing.Point(3, 14);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(91, 21);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "From";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgvConferences
            // 
            this.dgvConferences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConferences.BackgroundColor = System.Drawing.Color.White;
            this.dgvConferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConferences.GridColor = System.Drawing.Color.White;
            this.dgvConferences.Location = new System.Drawing.Point(66, 57);
            this.dgvConferences.Name = "dgvConferences";
            this.dgvConferences.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvConferences.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvConferences.Size = new System.Drawing.Size(652, 356);
            this.dgvConferences.TabIndex = 1;
            this.dgvConferences.Text = "dataGridView1";
            this.dgvConferences.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConferences_CellContentClick);
            // 
            // OrganizerTab
            // 
            this.OrganizerTab.Controls.Add(this.tableLayoutPanel2);
            this.OrganizerTab.Location = new System.Drawing.Point(4, 24);
            this.OrganizerTab.Name = "OrganizerTab";
            this.OrganizerTab.Padding = new System.Windows.Forms.Padding(3);
            this.OrganizerTab.Size = new System.Drawing.Size(792, 422);
            this.OrganizerTab.TabIndex = 1;
            this.OrganizerTab.Text = "Organizer";
            this.OrganizerTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.080808F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.83839F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.080808F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(786, 416);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker2, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(66, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(652, 48);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(328, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "To";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 10);
            this.dateTimePicker1.MaximumSize = new System.Drawing.Size(350, 30);
            this.dateTimePicker1.MinimumSize = new System.Drawing.Size(50, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(222, 27);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker2.Location = new System.Drawing.Point(425, 10);
            this.dateTimePicker2.MaximumSize = new System.Drawing.Size(350, 30);
            this.dateTimePicker2.MinimumSize = new System.Drawing.Size(50, 20);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(224, 27);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.dgvOrganiser, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(66, 57);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(652, 356);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // dgvOrganiser
            // 
            this.dgvOrganiser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrganiser.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrganiser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrganiser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrganiser.GridColor = System.Drawing.Color.White;
            this.dgvOrganiser.Location = new System.Drawing.Point(3, 3);
            this.dgvOrganiser.Name = "dgvOrganiser";
            this.dgvOrganiser.Size = new System.Drawing.Size(646, 296);
            this.dgvOrganiser.TabIndex = 0;
            this.dgvOrganiser.Text = "dataGridView1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(3, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(646, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Conference";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPageTab);
            this.Name = "HomePage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.MainPageTab.ResumeLayout(false);
            this.SpectatorTab.ResumeLayout(false);
            this.tlpSpectator.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConferences)).EndInit();
            this.OrganizerTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganiser)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion



        private System.Windows.Forms.TabControl MainPageTab;
        private System.Windows.Forms.TabPage SpectatorTab;
        private System.Windows.Forms.TabPage OrganizerTab;
        private System.Windows.Forms.TableLayoutPanel tlpSpectator;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DataGridView dgvConferences;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView dgvOrganiser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvOrganizer;
    }
}