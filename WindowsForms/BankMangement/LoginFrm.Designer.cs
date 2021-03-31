namespace BankMangement
{
    partial class LoginFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCLogin = new System.Windows.Forms.Button();
            this.txtEnterPassword = new System.Windows.Forms.TextBox();
            this.btnRWindow = new System.Windows.Forms.Button();
            this.txtEnterUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter User Name";
            // 
            // btnCLogin
            // 
            this.btnCLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLogin.Location = new System.Drawing.Point(259, 228);
            this.btnCLogin.Name = "btnCLogin";
            this.btnCLogin.Size = new System.Drawing.Size(90, 41);
            this.btnCLogin.TabIndex = 5;
            this.btnCLogin.Text = "Login";
            this.btnCLogin.UseVisualStyleBackColor = true;
            this.btnCLogin.Click += new System.EventHandler(this.btnCLogin_Click);
            // 
            // txtEnterPassword
            // 
            this.txtEnterPassword.AccessibleName = "";
            this.txtEnterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterPassword.Location = new System.Drawing.Point(259, 166);
            this.txtEnterPassword.Name = "txtEnterPassword";
            this.txtEnterPassword.Size = new System.Drawing.Size(232, 26);
            this.txtEnterPassword.TabIndex = 7;
            // 
            // btnRWindow
            // 
            this.btnRWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRWindow.Location = new System.Drawing.Point(394, 228);
            this.btnRWindow.Name = "btnRWindow";
            this.btnRWindow.Size = new System.Drawing.Size(90, 41);
            this.btnRWindow.TabIndex = 6;
            this.btnRWindow.Text = "Register";
            this.btnRWindow.UseVisualStyleBackColor = true;
            this.btnRWindow.Click += new System.EventHandler(this.btnRWindow_Click);
            // 
            // txtEnterUserName
            // 
            this.txtEnterUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterUserName.Location = new System.Drawing.Point(259, 98);
            this.txtEnterUserName.Name = "txtEnterUserName";
            this.txtEnterUserName.Size = new System.Drawing.Size(232, 26);
            this.txtEnterUserName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter Password";
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCLogin);
            this.Controls.Add(this.txtEnterPassword);
            this.Controls.Add(this.btnRWindow);
            this.Controls.Add(this.txtEnterUserName);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCLogin;
        private System.Windows.Forms.TextBox txtEnterPassword;
        private System.Windows.Forms.Button btnRWindow;
        private System.Windows.Forms.TextBox txtEnterUserName;
        private System.Windows.Forms.Label label2;
    }
}