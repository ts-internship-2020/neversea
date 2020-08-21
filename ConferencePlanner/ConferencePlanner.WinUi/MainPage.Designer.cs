﻿namespace ConferencePlanner.WinUi
{
    partial class MainPage
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
            this.OrganizerTab = new System.Windows.Forms.TabPage();
            this.MainPageTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPageTab
            // 
            this.MainPageTab.Controls.Add(this.SpectatorTab);
            this.MainPageTab.Controls.Add(this.OrganizerTab);
            this.MainPageTab.Location = new System.Drawing.Point(3, 12);
            this.MainPageTab.Name = "MainPageTab";
            this.MainPageTab.SelectedIndex = 0;
            this.MainPageTab.Size = new System.Drawing.Size(794, 436);
            this.MainPageTab.TabIndex = 0;
            // 
            // SpectatorTab
            // 
            this.SpectatorTab.Location = new System.Drawing.Point(4, 24);
            this.SpectatorTab.Name = "SpectatorTab";
            this.SpectatorTab.Padding = new System.Windows.Forms.Padding(3);
            this.SpectatorTab.Size = new System.Drawing.Size(786, 408);
            this.SpectatorTab.TabIndex = 0;
            this.SpectatorTab.Text = "Spectator";
            this.SpectatorTab.UseVisualStyleBackColor = true;
            // 
            // OrganizerTab
            // 
            this.OrganizerTab.Location = new System.Drawing.Point(4, 24);
            this.OrganizerTab.Name = "OrganizerTab";
            this.OrganizerTab.Padding = new System.Windows.Forms.Padding(3);
            this.OrganizerTab.Size = new System.Drawing.Size(786, 408);
            this.OrganizerTab.TabIndex = 1;
            this.OrganizerTab.Text = "Organizer";
            this.OrganizerTab.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPageTab);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.MainPageTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainPageTab;
        private System.Windows.Forms.TabPage SpectatorTab;
        private System.Windows.Forms.TabPage OrganizerTab;
    }
}