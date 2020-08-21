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
            this.lb_hello = new System.Windows.Forms.Label();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lb_email = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_enterEmail
            // 
            this.btn_enterEmail.Location = new System.Drawing.Point(328, 309);
            this.btn_enterEmail.Name = "btn_enterEmail";
            this.btn_enterEmail.Size = new System.Drawing.Size(132, 31);
            this.btn_enterEmail.TabIndex = 0;
            this.btn_enterEmail.Text = "COME IN";
            this.btn_enterEmail.UseVisualStyleBackColor = true;
            this.btn_enterEmail.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_hello
            // 
            this.lb_hello.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_hello.AutoSize = true;
            this.lb_hello.BackColor = System.Drawing.Color.LightBlue;
            this.lb_hello.Location = new System.Drawing.Point(358, 57);
            this.lb_hello.Name = "lb_hello";
            this.lb_hello.Size = new System.Drawing.Size(70, 15);
            this.lb_hello.TabIndex = 3;
            this.lb_hello.Text = "Hello World";
            this.lb_hello.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // tb_email
            // 
            this.tb_email.BackColor = System.Drawing.SystemColors.Window;
            this.tb_email.Location = new System.Drawing.Point(286, 171);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(233, 23);
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
            this.lb_email.Location = new System.Drawing.Point(199, 174);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(81, 15);
            this.lb_email.TabIndex = 5;
            this.lb_email.Text = "Email Address";
            this.lb_email.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.lb_email);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.lb_hello);
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
        private System.Windows.Forms.Label lb_hello;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Label lb_email;
    }
}