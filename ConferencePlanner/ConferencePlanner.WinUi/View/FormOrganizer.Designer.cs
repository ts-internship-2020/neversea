using Microsoft.VisualBasic.CompilerServices;

namespace ConferencePlanner.WinUi.View
{
    partial class FormOrganizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrganizer));
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnPagesNumber = new System.Windows.Forms.Button();
            this.dgvOrganiser = new System.Windows.Forms.DataGridView();
            this.comboBoxPagesNumber = new System.Windows.Forms.ComboBox();
            this.btnFromTo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganiser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(460, 15);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(41, 42);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click_1);
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(509, 16);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 39);
            this.btnNext.TabIndex = 12;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
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
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
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
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged_1);
            // 
            // btnPagesNumber
            // 
            this.btnPagesNumber.BackColor = System.Drawing.Color.White;
            this.btnPagesNumber.FlatAppearance.BorderSize = 0;
            this.btnPagesNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPagesNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPagesNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagesNumber.Image = ((System.Drawing.Image)(resources.GetObject("btnPagesNumber.Image")));
            this.btnPagesNumber.Location = new System.Drawing.Point(604, 19);
            this.btnPagesNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPagesNumber.Name = "btnPagesNumber";
            this.btnPagesNumber.Size = new System.Drawing.Size(40, 37);
            this.btnPagesNumber.TabIndex = 10;
            this.btnPagesNumber.UseVisualStyleBackColor = false;
            // 
            // dgvOrganiser
            // 
            this.dgvOrganiser.AllowUserToAddRows = false;
            this.dgvOrganiser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrganiser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvOrganiser.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrganiser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrganiser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrganiser.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvOrganiser.Location = new System.Drawing.Point(14, 104);
            this.dgvOrganiser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvOrganiser.MinimumSize = new System.Drawing.Size(900, 474);
            this.dgvOrganiser.Name = "dgvOrganiser";
            this.dgvOrganiser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOrganiser.Size = new System.Drawing.Size(900, 474);
            this.dgvOrganiser.TabIndex = 0;
            this.dgvOrganiser.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOrganiser_DataBindingComplete);
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
            this.comboBoxPagesNumber.Location = new System.Drawing.Point(651, 27);
            this.comboBoxPagesNumber.Name = "comboBoxPagesNumber";
            this.comboBoxPagesNumber.Size = new System.Drawing.Size(45, 23);
            this.comboBoxPagesNumber.TabIndex = 13;
            this.comboBoxPagesNumber.SelectedIndex = 0;
            this.comboBoxPagesNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxPagesNumber_SelectedIndexChanged_1);
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
            // FormOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 599);
            this.Controls.Add(this.comboBoxPagesNumber);
            this.Controls.Add(this.dgvOrganiser);
            this.Controls.Add(this.btnPagesNumber);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.btnFromTo);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormOrganizer";
            this.Text = "Your Conferences";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganiser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnPagesNumber;
        private System.Windows.Forms.DataGridView dgvOrganiser;
        private System.Windows.Forms.ComboBox comboBoxPagesNumber;
        private System.Windows.Forms.Button btnFromTo;
    }
}