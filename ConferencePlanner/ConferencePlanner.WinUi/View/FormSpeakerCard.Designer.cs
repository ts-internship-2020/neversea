namespace ConferencePlanner.WinUi.View
{
    partial class FormSpeakerCard
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.pictureBoxSpeaker = new System.Windows.Forms.PictureBox();
            this.pictureBoxLike1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLike2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLike3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLike4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLike5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpeaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(11, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "labelName";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNationality.Location = new System.Drawing.Point(11, 108);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(103, 17);
            this.lblNationality.TabIndex = 0;
            this.lblNationality.Text = "labelNationality";
            // 
            // pictureBoxSpeaker
            // 
            this.pictureBoxSpeaker.Location = new System.Drawing.Point(45, 2);
            this.pictureBoxSpeaker.Name = "pictureBoxSpeaker";
            this.pictureBoxSpeaker.Size = new System.Drawing.Size(72, 66);
            this.pictureBoxSpeaker.TabIndex = 1;
            this.pictureBoxSpeaker.TabStop = false;
            // 
            // pictureBoxLike1
            // 
            this.pictureBoxLike1.Location = new System.Drawing.Point(10, 136);
            this.pictureBoxLike1.Name = "pictureBoxLike1";
            this.pictureBoxLike1.Size = new System.Drawing.Size(23, 25);
            this.pictureBoxLike1.TabIndex = 1;
            this.pictureBoxLike1.TabStop = false;
            // 
            // pictureBoxLike2
            // 
            this.pictureBoxLike2.Location = new System.Drawing.Point(39, 136);
            this.pictureBoxLike2.Name = "pictureBoxLike2";
            this.pictureBoxLike2.Size = new System.Drawing.Size(23, 25);
            this.pictureBoxLike2.TabIndex = 1;
            this.pictureBoxLike2.TabStop = false;
            // 
            // pictureBoxLike3
            // 
            this.pictureBoxLike3.Location = new System.Drawing.Point(68, 136);
            this.pictureBoxLike3.Name = "pictureBoxLike3";
            this.pictureBoxLike3.Size = new System.Drawing.Size(23, 25);
            this.pictureBoxLike3.TabIndex = 1;
            this.pictureBoxLike3.TabStop = false;
            // 
            // pictureBoxLike4
            // 
            this.pictureBoxLike4.Location = new System.Drawing.Point(97, 136);
            this.pictureBoxLike4.Name = "pictureBoxLike4";
            this.pictureBoxLike4.Size = new System.Drawing.Size(23, 25);
            this.pictureBoxLike4.TabIndex = 1;
            this.pictureBoxLike4.TabStop = false;
            // 
            // pictureBoxLike5
            // 
            this.pictureBoxLike5.Location = new System.Drawing.Point(126, 136);
            this.pictureBoxLike5.Name = "pictureBoxLike5";
            this.pictureBoxLike5.Size = new System.Drawing.Size(23, 25);
            this.pictureBoxLike5.TabIndex = 1;
            this.pictureBoxLike5.TabStop = false;
            // 
            // FormSpeakerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(159, 168);
            this.Controls.Add(this.pictureBoxLike5);
            this.Controls.Add(this.pictureBoxLike4);
            this.Controls.Add(this.pictureBoxLike3);
            this.Controls.Add(this.pictureBoxLike2);
            this.Controls.Add(this.pictureBoxLike1);
            this.Controls.Add(this.pictureBoxSpeaker);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSpeakerCard";
            this.Text = "FormSpeakerCard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpeaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.PictureBox pictureBoxSpeaker;
        private System.Windows.Forms.PictureBox pictureBoxLike1;
        private System.Windows.Forms.PictureBox pictureBoxLike2;
        private System.Windows.Forms.PictureBox pictureBoxLike3;
        private System.Windows.Forms.PictureBox pictureBoxLike4;
        private System.Windows.Forms.PictureBox pictureBoxLike5;
    }
}