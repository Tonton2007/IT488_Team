namespace IT488_Team
{
    partial class logIn
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
            this.label2 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.OkLogin = new System.Windows.Forms.Button();
            this.loginExit = new System.Windows.Forms.Button();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(156, 55);
            this.userName.Margin = new System.Windows.Forms.Padding(2);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(167, 20);
            this.userName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(156, 115);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // OkLogin
            // 
            this.OkLogin.Location = new System.Drawing.Point(156, 208);
            this.OkLogin.Margin = new System.Windows.Forms.Padding(2);
            this.OkLogin.Name = "OkLogin";
            this.OkLogin.Size = new System.Drawing.Size(50, 22);
            this.OkLogin.TabIndex = 4;
            this.OkLogin.Text = "Ok";
            this.OkLogin.UseVisualStyleBackColor = true;
            this.OkLogin.Click += new System.EventHandler(this.OkLogin_Click);
            // 
            // loginExit
            // 
            this.loginExit.Location = new System.Drawing.Point(280, 208);
            this.loginExit.Margin = new System.Windows.Forms.Padding(2);
            this.loginExit.Name = "loginExit";
            this.loginExit.Size = new System.Drawing.Size(50, 21);
            this.loginExit.TabIndex = 5;
            this.loginExit.Text = "Exit";
            this.loginExit.UseVisualStyleBackColor = true;
            this.loginExit.Click += new System.EventHandler(this.loginExit_Click);
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(93, 169);
            this.ServerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(41, 13);
            this.ServerLabel.TabIndex = 6;
            this.ServerLabel.Text = "Server:";
            this.ServerLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(156, 169);
            this.ServerTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(267, 20);
            this.ServerTextBox.TabIndex = 7;
            // 
            // logIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.ServerTextBox);
            this.Controls.Add(this.ServerLabel);
            this.Controls.Add(this.loginExit);
            this.Controls.Add(this.OkLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "logIn";
            this.Text = "logIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button OkLogin;
        private System.Windows.Forms.Button loginExit;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.TextBox ServerTextBox;
    }
}