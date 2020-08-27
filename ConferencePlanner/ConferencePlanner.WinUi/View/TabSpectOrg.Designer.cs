namespace ConferencePlanner.WinUi.View
{
    partial class TabSpectOrg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabSpectOrg));
            this.panelTabSpectOrg = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOrganizer = new System.Windows.Forms.Button();
            this.panelSpectator = new System.Windows.Forms.Panel();
            this.btnSpectator = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelTabSpectOrg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSpectator.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabSpectOrg
            // 
            this.panelTabSpectOrg.Controls.Add(this.panel1);
            this.panelTabSpectOrg.Controls.Add(this.panelSpectator);
            this.panelTabSpectOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTabSpectOrg.Location = new System.Drawing.Point(0, 0);
            this.panelTabSpectOrg.Name = "panelTabSpectOrg";
            this.panelTabSpectOrg.Size = new System.Drawing.Size(800, 155);
            this.panelTabSpectOrg.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOrganizer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(400, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 155);
            this.panel1.TabIndex = 1;
            // 
            // btnOrganizer
            // 
            this.btnOrganizer.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnOrganizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOrganizer.FlatAppearance.BorderSize = 0;
            this.btnOrganizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrganizer.Font = new System.Drawing.Font("Segoe UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOrganizer.ForeColor = System.Drawing.Color.Lavender;
            this.btnOrganizer.Image = ((System.Drawing.Image)(resources.GetObject("btnOrganizer.Image")));
            this.btnOrganizer.Location = new System.Drawing.Point(0, 0);
            this.btnOrganizer.Name = "btnOrganizer";
            this.btnOrganizer.Padding = new System.Windows.Forms.Padding(0, 8, 0, 1);
            this.btnOrganizer.Size = new System.Drawing.Size(400, 155);
            this.btnOrganizer.TabIndex = 0;
            this.btnOrganizer.Text = "ORGANIZER";
            this.btnOrganizer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOrganizer.UseVisualStyleBackColor = false;
            this.btnOrganizer.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelSpectator
            // 
            this.panelSpectator.Controls.Add(this.btnSpectator);
            this.panelSpectator.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSpectator.Location = new System.Drawing.Point(0, 0);
            this.panelSpectator.Name = "panelSpectator";
            this.panelSpectator.Size = new System.Drawing.Size(400, 155);
            this.panelSpectator.TabIndex = 0;
            // 
            // btnSpectator
            // 
            this.btnSpectator.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSpectator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSpectator.FlatAppearance.BorderSize = 0;
            this.btnSpectator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpectator.Font = new System.Drawing.Font("Segoe UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSpectator.ForeColor = System.Drawing.Color.Lavender;
            this.btnSpectator.Image = ((System.Drawing.Image)(resources.GetObject("btnSpectator.Image")));
            this.btnSpectator.Location = new System.Drawing.Point(0, 0);
            this.btnSpectator.Name = "btnSpectator";
            this.btnSpectator.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnSpectator.Size = new System.Drawing.Size(400, 155);
            this.btnSpectator.TabIndex = 0;
            this.btnSpectator.Text = "SPECTATOR";
            this.btnSpectator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSpectator.UseVisualStyleBackColor = false;
            this.btnSpectator.Click += new System.EventHandler(this.btnSpectator_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 420);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(800, 30);
            this.panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.MintCream;
            this.lblTitle.Location = new System.Drawing.Point(655, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(67, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HOME";
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 155);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(800, 265);
            this.panelDesktop.TabIndex = 2;
            // 
            // TabSpectOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelTabSpectOrg);
            this.Name = "TabSpectOrg";
            this.Text = "TabSpectOrg";
            this.panelTabSpectOrg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelSpectator.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTabSpectOrg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOrganizer;
        private System.Windows.Forms.Panel panelSpectator;
        private System.Windows.Forms.Button btnSpectator;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelDesktop;
    }
}