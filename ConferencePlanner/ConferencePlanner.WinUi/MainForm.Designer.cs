namespace ConferencePlanner.WinUi
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
            this.lb_welcome = new System.Windows.Forms.Label();
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
            this.btn_enterEmail.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_enterEmail.ForeColor = System.Drawing.SystemColors.Info;
            this.btn_enterEmail.Location = new System.Drawing.Point(188, 276);
            this.btn_enterEmail.MaximumSize = new System.Drawing.Size(132, 31);
            this.btn_enterEmail.MinimumSize = new System.Drawing.Size(132, 31);
            this.btn_enterEmail.Name = "btn_enterEmail";
            this.btn_enterEmail.Size = new System.Drawing.Size(132, 31);
            this.btn_enterEmail.TabIndex = 0;
            this.btn_enterEmail.Text = "COME IN";
            this.btn_enterEmail.UseVisualStyleBackColor = false;
            this.btn_enterEmail.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_welcome
            // 
            this.lb_welcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_welcome.AutoSize = true;
            this.lb_welcome.BackColor = System.Drawing.Color.AliceBlue;
            this.lb_welcome.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_welcome.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_welcome.Location = new System.Drawing.Point(189, 48);
            this.lb_welcome.Name = "lb_welcome";
            this.lb_welcome.Size = new System.Drawing.Size(131, 36);
            this.lb_welcome.TabIndex = 3;
            this.lb_welcome.Text = "Welcome";
            this.lb_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_email
            // 
            this.tb_email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_email.BackColor = System.Drawing.SystemColors.Window;
            this.tb_email.Location = new System.Drawing.Point(218, 167);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(161, 23);
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
            this.lb_email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_email.AutoSize = true;
            this.lb_email.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_email.Location = new System.Drawing.Point(129, 170);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(83, 15);
            this.lb_email.TabIndex = 5;
            this.lb_email.Text = "Email Address";
            // 
            // chkb_email
            // 
            this.chkb_email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkb_email.AutoSize = true;
            this.chkb_email.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkb_email.Location = new System.Drawing.Point(277, 196);
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
            this.Controls.Add(this.chkb_email);
            this.Controls.Add(this.lb_welcome);
            this.Controls.Add(this.lb_email);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.btn_enterEmail);
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
        private System.Windows.Forms.Label lb_welcome;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Label lb_email;
        private System.Windows.Forms.CheckBox chkb_email;
    }
}