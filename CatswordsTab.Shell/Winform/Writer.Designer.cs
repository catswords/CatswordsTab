﻿namespace CatswordsTab.Shell.Winform
{
    partial class Writer
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbAgreement = new System.Windows.Forms.CheckBox();
            this.labelReplyEmail = new System.Windows.Forms.Label();
            this.txtReplyEmail = new System.Windows.Forms.TextBox();
            this.btnDonate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(41, 46);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(126, 37);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "labelTitle";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(26, 135);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(78, 15);
            this.labelMessage.TabIndex = 8;
            this.labelMessage.Text = "labelMessage";
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(28, 155);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(358, 97);
            this.txtMessage.TabIndex = 9;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSend.Image = global::CatswordsTab.Shell.Properties.Resources.iconsdb_white_check_mark_3_32;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSend.Location = new System.Drawing.Point(259, 43);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(127, 40);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "btnSend";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.OnClick_btnSend);
            // 
            // cbAgreement
            // 
            this.cbAgreement.AutoSize = true;
            this.cbAgreement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAgreement.Location = new System.Drawing.Point(27, 340);
            this.cbAgreement.Name = "cbAgreement";
            this.cbAgreement.Size = new System.Drawing.Size(98, 19);
            this.cbAgreement.TabIndex = 17;
            this.cbAgreement.Text = "cbAgreement";
            this.cbAgreement.UseVisualStyleBackColor = true;
            // 
            // labelReplyEmail
            // 
            this.labelReplyEmail.AutoSize = true;
            this.labelReplyEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReplyEmail.Location = new System.Drawing.Point(25, 275);
            this.labelReplyEmail.Name = "labelReplyEmail";
            this.labelReplyEmail.Size = new System.Drawing.Size(90, 15);
            this.labelReplyEmail.TabIndex = 18;
            this.labelReplyEmail.Text = "labelReplyEmail";
            // 
            // txtReplyEmail
            // 
            this.txtReplyEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReplyEmail.Location = new System.Drawing.Point(27, 295);
            this.txtReplyEmail.Name = "txtReplyEmail";
            this.txtReplyEmail.Size = new System.Drawing.Size(358, 23);
            this.txtReplyEmail.TabIndex = 19;
            this.txtReplyEmail.TextChanged += new System.EventHandler(this.OnChanged_txtReplyEmail);
            // 
            // btnDonate
            // 
            this.btnDonate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonate.Image = global::CatswordsTab.Shell.Properties.Resources.become_a_patron_button;
            this.btnDonate.Location = new System.Drawing.Point(27, 383);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(219, 38);
            this.btnDonate.TabIndex = 20;
            this.btnDonate.Text = "btnDonate";
            this.btnDonate.UseVisualStyleBackColor = true;
            this.btnDonate.Click += new System.EventHandler(this.OnClick_btnDonate);
            // 
            // Writer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CatswordsTab.Shell.Properties.Resources.iconfinder_pencil_01_374624;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(420, 444);
            this.Controls.Add(this.btnDonate);
            this.Controls.Add(this.txtReplyEmail);
            this.Controls.Add(this.labelReplyEmail);
            this.Controls.Add(this.cbAgreement);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Writer";
            this.Text = "CatswordTabWriter";
            this.Load += new System.EventHandler(this.OnLoad_Writer);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox cbAgreement;
        private System.Windows.Forms.Label labelReplyEmail;
        private System.Windows.Forms.TextBox txtReplyEmail;
        private System.Windows.Forms.Button btnDonate;
    }
}