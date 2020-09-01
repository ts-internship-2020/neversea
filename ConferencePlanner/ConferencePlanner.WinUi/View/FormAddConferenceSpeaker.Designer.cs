namespace ConferencePlanner.WinUi.View
{
    partial class FormAddConferenceSpeaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddConferenceSpeaker));
            this.dgvSpeakers = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboBoxPagesNumber = new System.Windows.Forms.ComboBox();
            this.btnPagesNumber = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpeakers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSpeakers
            // 
            this.dgvSpeakers.BackgroundColor = System.Drawing.Color.White;
            this.dgvSpeakers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSpeakers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpeakers.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvSpeakers.Location = new System.Drawing.Point(33, 27);
            this.dgvSpeakers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSpeakers.MultiSelect = false;
            this.dgvSpeakers.Name = "dgvSpeakers";
            this.dgvSpeakers.Size = new System.Drawing.Size(452, 204);
            this.dgvSpeakers.TabIndex = 28;
            this.dgvSpeakers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpeakers_CellEndEdit);
            this.dgvSpeakers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSpeakers_DataBindingComplete);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(9, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 33);
            this.button2.TabIndex = 34;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(9, 7);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(42, 33);
            this.btnPrevious.TabIndex = 34;
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(52, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 33);
            this.button3.TabIndex = 34;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(663, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(102, 46);
            this.panel1.TabIndex = 35;
            // 
            // FormAddConferenceSpeaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 271);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPagesNumber);
            this.Controls.Add(this.comboBoxPagesNumber);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvSpeakers);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAddConferenceSpeaker";
            this.Text = "FormAddConferenceSpeaker";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpeakers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSpeakers;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboBoxPagesNumber;
        private System.Windows.Forms.Button btnPagesNumber;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
    }
}