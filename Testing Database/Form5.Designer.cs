namespace $safeprojectname$
{
    partial class Form5
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Designation = new System.Windows.Forms.Label();
            this.Registration_date = new System.Windows.Forms.Label();
            this.NIC = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Member_Name = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EXP_date = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Book_Issued = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Book_Issued);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EXP_date);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Designation);
            this.groupBox1.Controls.Add(this.Registration_date);
            this.groupBox1.Controls.Add(this.NIC);
            this.groupBox1.Controls.Add(this.Email);
            this.groupBox1.Controls.Add(this.Member_Name);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 197);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Welcome";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "NIC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Email Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Registration Date";
            // 
            // Designation
            // 
            this.Designation.AutoSize = true;
            this.Designation.Location = new System.Drawing.Point(6, 18);
            this.Designation.Name = "Designation";
            this.Designation.Size = new System.Drawing.Size(45, 13);
            this.Designation.TabIndex = 5;
            this.Designation.Text = "Member";
            // 
            // Registration_date
            // 
            this.Registration_date.AutoSize = true;
            this.Registration_date.Location = new System.Drawing.Point(129, 86);
            this.Registration_date.Name = "Registration_date";
            this.Registration_date.Size = new System.Drawing.Size(89, 13);
            this.Registration_date.TabIndex = 4;
            this.Registration_date.Text = "Registration Date";
            // 
            // NIC
            // 
            this.NIC.AutoSize = true;
            this.NIC.Location = new System.Drawing.Point(129, 64);
            this.NIC.Name = "NIC";
            this.NIC.Size = new System.Drawing.Size(25, 13);
            this.NIC.TabIndex = 3;
            this.NIC.Text = "NIC";
            this.NIC.Click += new System.EventHandler(this.Dept_Name_Click);
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(129, 40);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(32, 13);
            this.Email.TabIndex = 2;
            this.Email.Text = "Email";
            // 
            // Member_Name
            // 
            this.Member_Name.AutoSize = true;
            this.Member_Name.Location = new System.Drawing.Point(129, 18);
            this.Member_Name.Name = "Member_Name";
            this.Member_Name.Size = new System.Drawing.Size(76, 13);
            this.Member_Name.TabIndex = 1;
            this.Member_Name.Text = "Member Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Expiry Date";
            // 
            // EXP_date
            // 
            this.EXP_date.AutoSize = true;
            this.EXP_date.Location = new System.Drawing.Point(129, 114);
            this.EXP_date.Name = "EXP_date";
            this.EXP_date.Size = new System.Drawing.Size(61, 13);
            this.EXP_date.TabIndex = 9;
            this.EXP_date.Text = "Expiry Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "No of Book Issued";
            // 
            // Book_Issued
            // 
            this.Book_Issued.AutoSize = true;
            this.Book_Issued.Location = new System.Drawing.Point(129, 141);
            this.Book_Issued.Name = "Book_Issued";
            this.Book_Issued.Size = new System.Drawing.Size(95, 13);
            this.Book_Issued.TabIndex = 11;
            this.Book_Issued.Text = "No of Book Issued";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 363);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Members_Section";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Designation;
        private System.Windows.Forms.Label Registration_date;
        private System.Windows.Forms.Label NIC;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Member_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Book_Issued;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label EXP_date;
        private System.Windows.Forms.Button button1;

    }
}