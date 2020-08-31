namespace ConferencePlanner.WinUi.View
{
    partial class FormAddConferenceCity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddConferenceCity));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboBoxPagesCount = new System.Windows.Forms.ComboBox();
            this.btnPagesCount = new System.Windows.Forms.Button();
            this.dgvCities = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.panelPageControls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).BeginInit();
            this.panelPageControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(104, 40);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 27);
            this.txtSearch.TabIndex = 29;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(276, 31);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 46);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // comboBoxPagesCount
            // 
            this.comboBoxPagesCount.FormattingEnabled = true;
            this.comboBoxPagesCount.Items.AddRange(new object[] {
            4,
            5,
            6,
            7,
            8,
            9,
            10});
            this.comboBoxPagesCount.Location = new System.Drawing.Point(214, 97);
            this.comboBoxPagesCount.Name = "comboBoxPagesCount";
            this.comboBoxPagesCount.Size = new System.Drawing.Size(45, 25);
            this.comboBoxPagesCount.TabIndex = 13;
            // 
            // btnPagesCount
            // 
            this.btnPagesCount.FlatAppearance.BorderSize = 0;
            this.btnPagesCount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPagesCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagesCount.Image = ((System.Drawing.Image)(resources.GetObject("btnPagesCount.Image")));
            this.btnPagesCount.Location = new System.Drawing.Point(276, 85);
            this.btnPagesCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPagesCount.Name = "btnPagesCount";
            this.btnPagesCount.Size = new System.Drawing.Size(50, 46);
            this.btnPagesCount.TabIndex = 32;
            this.btnPagesCount.UseVisualStyleBackColor = true;
            // 
            // dgvCities
            // 
            this.dgvCities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCities.BackgroundColor = System.Drawing.Color.White;
            this.dgvCities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCities.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCities.Location = new System.Drawing.Point(437, 4);
            this.dgvCities.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCities.MultiSelect = false;
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCities.Size = new System.Drawing.Size(277, 204);
            this.dgvCities.TabIndex = 28;
            this.dgvCities.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCities_CellEndEdit);
            this.dgvCities.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCities_DataBindingComplete);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(285, 144);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(31, 41);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDelete_MouseClick);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNextPage.Image")));
            this.btnNextPage.Location = new System.Drawing.Point(52, 7);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(42, 33);
            this.btnNextPage.TabIndex = 34;
            this.btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPreviousPage.FlatAppearance.BorderSize = 0;
            this.btnPreviousPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPreviousPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousPage.Image")));
            this.btnPreviousPage.Location = new System.Drawing.Point(9, 7);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(42, 33);
            this.btnPreviousPage.TabIndex = 34;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            // 
            // panelPageControls
            // 
            this.panelPageControls.Controls.Add(this.btnPreviousPage);
            this.panelPageControls.Controls.Add(this.btnNextPage);
            this.panelPageControls.Location = new System.Drawing.Point(249, 193);
            this.panelPageControls.Name = "panelPageControls";
            this.panelPageControls.Size = new System.Drawing.Size(102, 46);
            this.panelPageControls.TabIndex = 35;
            // 
            // FormAddConferenceCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 271);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvCities);
            this.Controls.Add(this.btnPagesCount);
            this.Controls.Add(this.comboBoxPagesCount);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panelPageControls);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAddConferenceCity";
            this.Text = "FormAddConferenceCity";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).EndInit();
            this.panelPageControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboBoxPagesCount;
        private System.Windows.Forms.Button btnPagesCount;
        private System.Windows.Forms.DataGridView dgvCities;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Panel panelPageControls;
    }
}