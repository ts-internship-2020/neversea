namespace ConferencePlanner.WinUi.View
{
    partial class FormSpectator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpectator));
            this.dgvSpectator = new System.Windows.Forms.DataGridView();
            this.panelSpeaker = new System.Windows.Forms.Panel();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnPagesNumber = new System.Windows.Forms.Button();
            this.btnFromTo = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.comboBoxPagesNumber = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpectator)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSpectator
            // 
            this.dgvSpectator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSpectator.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvSpectator.BackgroundColor = System.Drawing.Color.White;
            this.dgvSpectator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSpectator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpectator.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvSpectator.Location = new System.Drawing.Point(7, 99);
            this.dgvSpectator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvSpectator.Name = "dgvSpectator";
            this.dgvSpectator.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSpectator.Size = new System.Drawing.Size(828, 474);
            this.dgvSpectator.TabIndex = 0;
            this.dgvSpectator.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpectator_CellContentClick_2);
            // 
            // panelSpeaker
            // 
            this.panelSpeaker.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panelSpeaker.Location = new System.Drawing.Point(843, 155);
            this.panelSpeaker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelSpeaker.Name = "panelSpeaker";
            this.panelSpeaker.Size = new System.Drawing.Size(138, 150);
            this.panelSpeaker.TabIndex = 1;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.BackColor = System.Drawing.Color.White;
            this.txtSearchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchBar.Location = new System.Drawing.Point(481, 23);
            this.txtSearchBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(146, 23);
            this.txtSearchBar.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(433, 21);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 31);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(26, 23);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(117, 23);
            this.dtpStart.TabIndex = 4;
            this.dtpStart.CloseUp += new System.EventHandler(this.dtpStart_CloseUp);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(250, 23);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(126, 23);
            this.dtpEnd.TabIndex = 5;
            this.dtpEnd.CloseUp += new System.EventHandler(this.dtpEnd_CloseUp);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(827, 527);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(61, 58);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // btnPagesNumber
            // 
            this.btnPagesNumber.BackColor = System.Drawing.Color.White;
            this.btnPagesNumber.FlatAppearance.BorderSize = 0;
            this.btnPagesNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPagesNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagesNumber.Image = ((System.Drawing.Image)(resources.GetObject("btnPagesNumber.Image")));
            this.btnPagesNumber.Location = new System.Drawing.Point(680, 18);
            this.btnPagesNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPagesNumber.Name = "btnPagesNumber";
            this.btnPagesNumber.Size = new System.Drawing.Size(40, 37);
            this.btnPagesNumber.TabIndex = 10;
            this.btnPagesNumber.UseVisualStyleBackColor = false;
            // 
            // btnFromTo
            // 
            this.btnFromTo.BackColor = System.Drawing.Color.White;
            this.btnFromTo.CausesValidation = false;
            this.btnFromTo.FlatAppearance.BorderSize = 0;
            this.btnFromTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFromTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFromTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromTo.Image = ((System.Drawing.Image)(resources.GetObject("btnFromTo.Image")));
            this.btnFromTo.Location = new System.Drawing.Point(170, 16);
            this.btnFromTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFromTo.Name = "btnFromTo";
            this.btnFromTo.Size = new System.Drawing.Size(50, 40);
            this.btnFromTo.TabIndex = 11;
            this.btnFromTo.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(920, 527);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(61, 58);
            this.btnNext.TabIndex = 12;
            this.btnNext.UseVisualStyleBackColor = false;
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
            this.comboBoxPagesNumber.Location = new System.Drawing.Point(727, 23);
            this.comboBoxPagesNumber.Name = "comboBoxPagesNumber";
            this.comboBoxPagesNumber.Size = new System.Drawing.Size(45, 23);
            this.comboBoxPagesNumber.TabIndex = 13;
            // 
            // FormSpectator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 599);
            this.Controls.Add(this.comboBoxPagesNumber);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFromTo);
            this.Controls.Add(this.btnPagesNumber);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.panelSpeaker);
            this.Controls.Add(this.dgvSpectator);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormSpectator";
            this.Text = "Conferences to Attend";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpectator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSpectator;
        private System.Windows.Forms.Panel panelSpeaker;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnPagesNumber;
        private System.Windows.Forms.Button btnFromTo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox comboBoxPagesNumber;
    }
}