
namespace IT488_Team
{
    partial class SetupForm
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
            this.databaseUsername = new System.Windows.Forms.TextBox();
            this.databasePassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.createDBButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.trackItServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // databaseUsername
            // 
            this.databaseUsername.Location = new System.Drawing.Point(146, 97);
            this.databaseUsername.Name = "databaseUsername";
            this.databaseUsername.Size = new System.Drawing.Size(100, 20);
            this.databaseUsername.TabIndex = 0;
            // 
            // databasePassword
            // 
            this.databasePassword.Location = new System.Drawing.Point(146, 143);
            this.databasePassword.Name = "databasePassword";
            this.databasePassword.Size = new System.Drawing.Size(100, 20);
            this.databasePassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 21);
            this.label1.MaximumSize = new System.Drawing.Size(200, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "You\'ll need to setup the TrackIT database for your first time use. Please enter t" +
    "he information below and click \"Submit\" to create the database.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Default Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Default Password";
            // 
            // createDBButton
            // 
            this.createDBButton.Location = new System.Drawing.Point(161, 238);
            this.createDBButton.Name = "createDBButton";
            this.createDBButton.Size = new System.Drawing.Size(75, 23);
            this.createDBButton.TabIndex = 5;
            this.createDBButton.Text = "Create";
            this.createDBButton.UseVisualStyleBackColor = true;
            this.createDBButton.Click += new System.EventHandler(this.createDBButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Default Server";
            // 
            // trackItServer
            // 
            this.trackItServer.Location = new System.Drawing.Point(146, 186);
            this.trackItServer.Name = "trackItServer";
            this.trackItServer.Size = new System.Drawing.Size(100, 20);
            this.trackItServer.TabIndex = 6;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 319);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackItServer);
            this.Controls.Add(this.createDBButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.databasePassword);
            this.Controls.Add(this.databaseUsername);
            this.Name = "SetupForm";
            this.Text = "SetupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox databaseUsername;
        private System.Windows.Forms.TextBox databasePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createDBButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox trackItServer;
    }
}