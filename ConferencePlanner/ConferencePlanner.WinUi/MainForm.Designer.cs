﻿namespace ConferencePlanner.WinUi
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btn_enterEmail = new System.Windows.Forms.Button();
            this.lb_hello = new System.Windows.Forms.Label();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lb_email = new System.Windows.Forms.Label();
            this.chkb_email = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_enterEmail
            // 
            this.btn_enterEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_enterEmail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_enterEmail.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_enterEmail.Location = new System.Drawing.Point(269, 300);
            this.btn_enterEmail.Name = "btn_enterEmail";
            this.btn_enterEmail.Size = new System.Drawing.Size(132, 31);
            this.btn_enterEmail.TabIndex = 0;
            this.btn_enterEmail.Text = "COME IN";
            this.btn_enterEmail.UseVisualStyleBackColor = true;
            this.btn_enterEmail.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_hello
            // 
            this.lb_hello.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_hello.AutoSize = true;
            this.lb_hello.BackColor = System.Drawing.SystemColors.Window;
            this.lb_hello.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_hello.Location = new System.Drawing.Point(269, 48);
            this.lb_hello.Name = "lb_hello";
            this.lb_hello.Size = new System.Drawing.Size(150, 31);
            this.lb_hello.TabIndex = 3;
            this.lb_hello.Text = "Hello World";
            // 
            // tb_email
            // 
            this.tb_email.BackColor = System.Drawing.SystemColors.Window;
            this.tb_email.Location = new System.Drawing.Point(242, 171);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(217, 23);
            this.tb_email.TabIndex = 4;
            this.tb_email.Enter += new System.EventHandler(this.tb_email_Enter);
            this.tb_email.Leave += new System.EventHandler(this.tb_email_Leave);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_email.Location = new System.Drawing.Point(155, 174);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(83, 15);
            this.lb_email.TabIndex = 5;
            this.lb_email.Text = "Email Address";
            // 
            // chkb_email
            // 
            this.chkb_email.AutoSize = true;
            this.chkb_email.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkb_email.Location = new System.Drawing.Point(355, 200);
            this.chkb_email.Name = "chkb_email";
            this.chkb_email.Size = new System.Drawing.Size(102, 19);
            this.chkb_email.TabIndex = 7;
            this.chkb_email.Text = "Remember Me";
            this.chkb_email.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(640, 450);
            this.ControlBox = false;
            this.Controls.Add(this.chkb_email);
            this.Controls.Add(this.lb_hello);
            this.Controls.Add(this.lb_email);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.btn_enterEmail);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button btn_enterEmail;
        private System.Windows.Forms.Label lb_hello;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Label lb_email;
        private System.Windows.Forms.CheckBox chkb_email;
    }
}