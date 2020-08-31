namespace ConferencePlanner.WinUi.View
{
    partial class FormHomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomePage));
            this.panelSidebarMenu = new System.Windows.Forms.Panel();
            this.panelOrganizerSubmenu = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnConferences = new System.Windows.Forms.Button();
            this.btnOrganizer = new System.Windows.Forms.Button();
            this.btnSpectator = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelSidebarMenu.SuspendLayout();
            this.panelOrganizerSubmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebarMenu
            // 
            this.panelSidebarMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.panelSidebarMenu.Controls.Add(this.panelOrganizerSubmenu);
            this.panelSidebarMenu.Controls.Add(this.btnOrganizer);
            this.panelSidebarMenu.Controls.Add(this.btnSpectator);
            this.panelSidebarMenu.Controls.Add(this.panelLogo);
            this.panelSidebarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebarMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelSidebarMenu.Name = "panelSidebarMenu";
            this.panelSidebarMenu.Size = new System.Drawing.Size(239, 655);
            this.panelSidebarMenu.TabIndex = 0;
            // 
            // panelOrganizerSubmenu
            // 
            this.panelOrganizerSubmenu.Controls.Add(this.btnAddNew);
            this.panelOrganizerSubmenu.Controls.Add(this.btnConferences);
            this.panelOrganizerSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOrganizerSubmenu.Location = new System.Drawing.Point(0, 306);
            this.panelOrganizerSubmenu.Name = "panelOrganizerSubmenu";
            this.panelOrganizerSubmenu.Size = new System.Drawing.Size(239, 177);
            this.panelOrganizerSubmenu.TabIndex = 5;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddNew.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Location = new System.Drawing.Point(0, 79);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnAddNew.Size = new System.Drawing.Size(239, 79);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "  Add New";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnConferences
            // 
            this.btnConferences.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConferences.FlatAppearance.BorderSize = 0;
            this.btnConferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConferences.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConferences.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConferences.Image = ((System.Drawing.Image)(resources.GetObject("btnConferences.Image")));
            this.btnConferences.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConferences.Location = new System.Drawing.Point(0, 0);
            this.btnConferences.Name = "btnConferences";
            this.btnConferences.Padding = new System.Windows.Forms.Padding(18, 0, 0, 10);
            this.btnConferences.Size = new System.Drawing.Size(239, 79);
            this.btnConferences.TabIndex = 6;
            this.btnConferences.Text = "   Conferences";
            this.btnConferences.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConferences.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConferences.UseVisualStyleBackColor = true;
            this.btnConferences.Click += new System.EventHandler(this.btnConferences_Click);
            // 
            // btnOrganizer
            // 
            this.btnOrganizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrganizer.FlatAppearance.BorderSize = 0;
            this.btnOrganizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOrganizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrganizer.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOrganizer.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnOrganizer.Image = ((System.Drawing.Image)(resources.GetObject("btnOrganizer.Image")));
            this.btnOrganizer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrganizer.Location = new System.Drawing.Point(0, 227);
            this.btnOrganizer.Name = "btnOrganizer";
            this.btnOrganizer.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnOrganizer.Size = new System.Drawing.Size(239, 79);
            this.btnOrganizer.TabIndex = 2;
            this.btnOrganizer.Text = "  Organizer";
            this.btnOrganizer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrganizer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrganizer.UseVisualStyleBackColor = true;
            this.btnOrganizer.Click += new System.EventHandler(this.btnOrganizer_Click);
            this.btnOrganizer.MouseHover += new System.EventHandler(this.btnOrganizer_MouseHover);
            // 
            // btnSpectator
            // 
            this.btnSpectator.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSpectator.FlatAppearance.BorderSize = 0;
            this.btnSpectator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpectator.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSpectator.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSpectator.Image = ((System.Drawing.Image)(resources.GetObject("btnSpectator.Image")));
            this.btnSpectator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSpectator.Location = new System.Drawing.Point(0, 148);
            this.btnSpectator.Name = "btnSpectator";
            this.btnSpectator.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSpectator.Size = new System.Drawing.Size(239, 79);
            this.btnSpectator.TabIndex = 1;
            this.btnSpectator.Text = "  Spectator";
            this.btnSpectator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSpectator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSpectator.UseVisualStyleBackColor = true;
            this.btnSpectator.Click += new System.EventHandler(this.btnSpectator_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(239, 148);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(239, 148);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(89)))), ((int)(((byte)(227)))));
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnMaximize);
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(239, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(913, 87);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(876, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximize.Image")));
            this.btnMaximize.Location = new System.Drawing.Point(835, 12);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(25, 23);
            this.btnMaximize.TabIndex = 2;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(792, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(25, 23);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(321, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(264, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ALL CONFERENCES";
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(239, 87);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(913, 568);
            this.panelDesktop.TabIndex = 2;
            // 
            // FormHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1152, 655);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelSidebarMenu);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 590);
            this.Name = "FormHomePage";
            this.Text = "HomePage";
            this.panelSidebarMenu.ResumeLayout(false);
            this.panelOrganizerSubmenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebarMenu;
        private System.Windows.Forms.Button btnOrganizer;
        private System.Windows.Forms.Button btnSpectator;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panelOrganizerSubmenu;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnConferences;
    }
}

