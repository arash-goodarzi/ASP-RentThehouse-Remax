namespace prjCsRemax.GUI
{
    partial class frmLogin
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgent = new System.Windows.Forms.Button();
            this.txtPassAgent = new System.Windows.Forms.TextBox();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.lblPassAgent = new System.Windows.Forms.Label();
            this.lblUserAgent = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.txtPassAdmin = new System.Windows.Forms.TextBox();
            this.txtUserAdmin = new System.Windows.Forms.TextBox();
            this.lblPassAdmin = new System.Windows.Forms.Label();
            this.lblUserAdmin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgent);
            this.groupBox2.Controls.Add(this.txtPassAgent);
            this.groupBox2.Controls.Add(this.txtUserAgent);
            this.groupBox2.Controls.Add(this.lblPassAgent);
            this.groupBox2.Controls.Add(this.lblUserAgent);
            this.groupBox2.Location = new System.Drawing.Point(446, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 179);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agent";
            // 
            // btnAgent
            // 
            this.btnAgent.Location = new System.Drawing.Point(66, 140);
            this.btnAgent.Name = "btnAgent";
            this.btnAgent.Size = new System.Drawing.Size(100, 23);
            this.btnAgent.TabIndex = 2;
            this.btnAgent.Text = "login";
            this.btnAgent.UseVisualStyleBackColor = true;
            this.btnAgent.Click += new System.EventHandler(this.btnAgent_Click);
            // 
            // txtPassAgent
            // 
            this.txtPassAgent.Location = new System.Drawing.Point(66, 98);
            this.txtPassAgent.Name = "txtPassAgent";
            this.txtPassAgent.PasswordChar = '*';
            this.txtPassAgent.Size = new System.Drawing.Size(100, 20);
            this.txtPassAgent.TabIndex = 1;
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Location = new System.Drawing.Point(66, 57);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.Size = new System.Drawing.Size(100, 20);
            this.txtUserAgent.TabIndex = 0;
            // 
            // lblPassAgent
            // 
            this.lblPassAgent.AutoSize = true;
            this.lblPassAgent.Location = new System.Drawing.Point(9, 106);
            this.lblPassAgent.Name = "lblPassAgent";
            this.lblPassAgent.Size = new System.Drawing.Size(52, 13);
            this.lblPassAgent.TabIndex = 1;
            this.lblPassAgent.Text = "password";
            // 
            // lblUserAgent
            // 
            this.lblUserAgent.AutoSize = true;
            this.lblUserAgent.Location = new System.Drawing.Point(6, 57);
            this.lblUserAgent.Name = "lblUserAgent";
            this.lblUserAgent.Size = new System.Drawing.Size(53, 13);
            this.lblUserAgent.TabIndex = 0;
            this.lblUserAgent.Text = "username";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdmin);
            this.groupBox1.Controls.Add(this.txtPassAdmin);
            this.groupBox1.Controls.Add(this.txtUserAdmin);
            this.groupBox1.Controls.Add(this.lblPassAdmin);
            this.groupBox1.Controls.Add(this.lblUserAdmin);
            this.groupBox1.Location = new System.Drawing.Point(98, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administator";
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(66, 140);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(100, 23);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "login";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // txtPassAdmin
            // 
            this.txtPassAdmin.Location = new System.Drawing.Point(66, 98);
            this.txtPassAdmin.Name = "txtPassAdmin";
            this.txtPassAdmin.PasswordChar = '*';
            this.txtPassAdmin.Size = new System.Drawing.Size(100, 20);
            this.txtPassAdmin.TabIndex = 1;
            // 
            // txtUserAdmin
            // 
            this.txtUserAdmin.Location = new System.Drawing.Point(66, 57);
            this.txtUserAdmin.Name = "txtUserAdmin";
            this.txtUserAdmin.Size = new System.Drawing.Size(100, 20);
            this.txtUserAdmin.TabIndex = 0;
            // 
            // lblPassAdmin
            // 
            this.lblPassAdmin.AutoSize = true;
            this.lblPassAdmin.Location = new System.Drawing.Point(9, 106);
            this.lblPassAdmin.Name = "lblPassAdmin";
            this.lblPassAdmin.Size = new System.Drawing.Size(52, 13);
            this.lblPassAdmin.TabIndex = 4;
            this.lblPassAdmin.Text = "password";
            // 
            // lblUserAdmin
            // 
            this.lblUserAdmin.AutoSize = true;
            this.lblUserAdmin.Location = new System.Drawing.Point(6, 57);
            this.lblUserAdmin.Name = "lblUserAdmin";
            this.lblUserAdmin.Size = new System.Drawing.Size(53, 13);
            this.lblUserAdmin.TabIndex = 3;
            this.lblUserAdmin.Text = "username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(156, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(389, 45);
            this.label5.TabIndex = 2;
            this.label5.Text = "REMAX COMPANY";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(754, 463);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLogin";
            this.Text = "Remax Program";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPassAgent;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.Label lblPassAgent;
        private System.Windows.Forms.Label lblUserAgent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassAdmin;
        private System.Windows.Forms.TextBox txtUserAdmin;
        private System.Windows.Forms.Label lblPassAdmin;
        private System.Windows.Forms.Label lblUserAdmin;
        private System.Windows.Forms.Button btnAgent;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label label5;

    }
}