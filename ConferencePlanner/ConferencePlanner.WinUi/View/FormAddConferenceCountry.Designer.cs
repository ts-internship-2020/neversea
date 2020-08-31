namespace ConferencePlanner.WinUi.View
{
    partial class FormAddConferenceCountry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddConferenceCountry));
            this.btnPagesNumber = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.dgvCountries = new System.Windows.Forms.DataGridView();
            this.comboBoxPagesNumber = new System.Windows.Forms.ComboBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountries)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPagesNumber
            // 
            this.btnPagesNumber.FlatAppearance.BorderSize = 0;
            this.btnPagesNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPagesNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagesNumber.Image = ((System.Drawing.Image)(resources.GetObject("btnPagesNumber.Image")));
            this.btnPagesNumber.Location = new System.Drawing.Point(276, 82);
            this.btnPagesNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPagesNumber.Name = "btnPagesNumber";
            this.btnPagesNumber.Size = new System.Drawing.Size(50, 46);
            this.btnPagesNumber.TabIndex = 32;
            this.btnPagesNumber.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(276, 28);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 46);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.BackColor = System.Drawing.Color.White;
            this.txtSearchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchBar.Location = new System.Drawing.Point(104, 40);
            this.txtSearchBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(155, 27);
            this.txtSearchBar.TabIndex = 29;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // dgvCountries
            // 
            this.dgvCountries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCountries.BackgroundColor = System.Drawing.Color.White;
            this.dgvCountries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCountries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountries.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCountries.Location = new System.Drawing.Point(390, 4);
            this.dgvCountries.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCountries.MultiSelect = false;
            this.dgvCountries.Name = "dgvCountries";
            this.dgvCountries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCountries.Size = new System.Drawing.Size(360, 264);
            this.dgvCountries.TabIndex = 28;
            this.dgvCountries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountries_CellDoubleClick);
            this.dgvCountries.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountries_CellEndEdit);
            this.dgvCountries.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCountries_DataBindingComplete);
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
            this.comboBoxPagesNumber.Location = new System.Drawing.Point(214, 94);
            this.comboBoxPagesNumber.Name = "comboBoxPagesNumber";
            this.comboBoxPagesNumber.Size = new System.Drawing.Size(45, 25);
            this.comboBoxPagesNumber.TabIndex = 13;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.FlatAppearance.BorderSize = 0;
            this.btnDeleteSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSelected.Image")));
            this.btnDeleteSelected.Location = new System.Drawing.Point(285, 144);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(31, 41);
            this.btnDeleteSelected.TabIndex = 33;
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDeleteSelected_MouseClick);
            // 
            // FormAddConferenceCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 271);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.comboBoxPagesNumber);
            this.Controls.Add(this.btnPagesNumber);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.dgvCountries);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAddConferenceCountry";
            this.Text = "FormAddConferenceCountry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddConferenceCountry_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPagesNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.DataGridView dgvCountries;
        private System.Windows.Forms.ComboBox comboBoxPagesNumber;
        private System.Windows.Forms.Button btnDeleteSelected;
    }
}