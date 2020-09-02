namespace ConferencePlanner.WinUi.View
{
    partial class FormAddConferenceDistrict
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
            System.Windows.Forms.Button btnBackDistrict;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddConferenceDistrict));
            System.Windows.Forms.Button btnNextDistrict;
            System.Windows.Forms.Panel panelPagesControl;
            this.dgvDistricts = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboBoxPagesNumber = new System.Windows.Forms.ComboBox();
            this.btnPagesNumber = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            btnBackDistrict = new System.Windows.Forms.Button();
            btnNextDistrict = new System.Windows.Forms.Button();
            panelPagesControl = new System.Windows.Forms.Panel();
            panelPagesControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackDistrict
            // 
            btnBackDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            btnBackDistrict.FlatAppearance.BorderSize = 0;
            btnBackDistrict.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnBackDistrict.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnBackDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBackDistrict.Image = ((System.Drawing.Image)(resources.GetObject("btnBackDistrict.Image")));
            btnBackDistrict.Location = new System.Drawing.Point(9, 7);
            btnBackDistrict.Name = "btnBackDistrict";
            btnBackDistrict.Size = new System.Drawing.Size(42, 33);
            btnBackDistrict.TabIndex = 34;
            btnBackDistrict.UseVisualStyleBackColor = true;
            btnBackDistrict.Click += new System.EventHandler(this.btnBackDistrict_Click);
            // 
            // btnNextDistrict
            // 
            btnNextDistrict.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnNextDistrict.FlatAppearance.BorderSize = 0;
            btnNextDistrict.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnNextDistrict.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnNextDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNextDistrict.Image = ((System.Drawing.Image)(resources.GetObject("btnNextDistrict.Image")));
            btnNextDistrict.Location = new System.Drawing.Point(52, 7);
            btnNextDistrict.Name = "btnNextDistrict";
            btnNextDistrict.Size = new System.Drawing.Size(42, 33);
            btnNextDistrict.TabIndex = 34;
            btnNextDistrict.UseVisualStyleBackColor = true;
            btnNextDistrict.Click += new System.EventHandler(this.btnNextDistrict_Click);
            // 
            // panelPagesControl
            // 
            panelPagesControl.Controls.Add(btnBackDistrict);
            panelPagesControl.Controls.Add(btnNextDistrict);
            panelPagesControl.Location = new System.Drawing.Point(663, 179);
            panelPagesControl.Name = "panelPagesControl";
            panelPagesControl.Size = new System.Drawing.Size(102, 46);
            panelPagesControl.TabIndex = 35;
            // 
            // dgvDistricts
            // 
            this.dgvDistricts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDistricts.BackgroundColor = System.Drawing.Color.White;
            this.dgvDistricts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDistricts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistricts.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDistricts.Location = new System.Drawing.Point(33, 27);
            this.dgvDistricts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDistricts.MultiSelect = false;
            this.dgvDistricts.Name = "dgvDistricts";
            this.dgvDistricts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDistricts.Size = new System.Drawing.Size(277, 204);
            this.dgvDistricts.TabIndex = 28;
            this.dgvDistricts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistricts_CellDoubleClick);
            this.dgvDistricts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistricts_CellEndEdit);
            this.dgvDistricts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDistricts_DataBindingComplete);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(518, 28);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 27);
            this.txtSearch.TabIndex = 29;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(690, 16);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 46);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // comboBoxPagesNumber
            // 
            this.comboBoxPagesNumber.FormattingEnabled = true;
            this.comboBoxPagesNumber.Items.AddRange(new object[] {
            4,
            5,
            6,
            7,
            8,
            9,
            10});
            this.comboBoxPagesNumber.Location = new System.Drawing.Point(628, 82);
            this.comboBoxPagesNumber.Name = "comboBoxPagesNumber";
            this.comboBoxPagesNumber.Size = new System.Drawing.Size(45, 25);
            this.comboBoxPagesNumber.TabIndex = 13;
            this.comboBoxPagesNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxPagesNumber_SelectedIndexChanged);
            // 
            // btnPagesNumber
            // 
            this.btnPagesNumber.FlatAppearance.BorderSize = 0;
            this.btnPagesNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPagesNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagesNumber.Image = ((System.Drawing.Image)(resources.GetObject("btnPagesNumber.Image")));
            this.btnPagesNumber.Location = new System.Drawing.Point(690, 70);
            this.btnPagesNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPagesNumber.Name = "btnPagesNumber";
            this.btnPagesNumber.Size = new System.Drawing.Size(50, 46);
            this.btnPagesNumber.TabIndex = 32;
            this.btnPagesNumber.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(635, 132);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 41);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDelete_MouseClick);
            // 
            // FormAddConferenceDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 271);
            this.Controls.Add(panelPagesControl);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPagesNumber);
            this.Controls.Add(this.comboBoxPagesNumber);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvDistricts);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAddConferenceDistrict";
            this.Text = "FormAddConferenceDistrict";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddConferenceDistrict_FormClosing);
            panelPagesControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDistricts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboBoxPagesNumber;
        private System.Windows.Forms.Button btnPagesNumber;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBackDistrict;
        private System.Windows.Forms.Button btnNextDistrict;
        private System.Windows.Forms.Panel panelPagesControl;
    }
}