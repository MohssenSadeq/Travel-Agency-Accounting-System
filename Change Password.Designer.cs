namespace HejAndOmra
{
    partial class Change_Password
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
            this.Label4 = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.user_PwdTextBox = new System.Windows.Forms.TextBox();
            this.user_NameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.Label4.Location = new System.Drawing.Point(45, 86);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 17);
            this.Label4.TabIndex = 26;
            this.Label4.Text = "User Name:";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangePassword.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Location = new System.Drawing.Point(8, 256);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(280, 38);
            this.btnChangePassword.TabIndex = 24;
            this.btnChangePassword.Text = "&Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.Label3.Location = new System.Drawing.Point(5, 204);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(112, 17);
            this.Label3.TabIndex = 25;
            this.Label3.Text = "Confirm Password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(125, 165);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(110, 20);
            this.txtNewPassword.TabIndex = 22;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.Label2.Location = new System.Drawing.Point(26, 165);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(91, 17);
            this.Label2.TabIndex = 21;
            this.Label2.Text = "New Password:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.Label1.Location = new System.Drawing.Point(31, 127);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(86, 17);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Old Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(254, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 24);
            this.label6.TabIndex = 32;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(254, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(254, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 27);
            this.label7.TabIndex = 30;
            this.label7.Text = "*";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(125, 204);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(110, 22);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // user_PwdTextBox
            // 
            this.user_PwdTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.user_PwdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_PwdTextBox.Location = new System.Drawing.Point(125, 127);
            this.user_PwdTextBox.Name = "user_PwdTextBox";
            this.user_PwdTextBox.PasswordChar = '*';
            this.user_PwdTextBox.Size = new System.Drawing.Size(110, 22);
            this.user_PwdTextBox.TabIndex = 28;
            this.user_PwdTextBox.TextChanged += new System.EventHandler(this.user_PwdTextBox_TextChanged);
            // 
            // user_NameTextBox
            // 
            this.user_NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_NameTextBox.Location = new System.Drawing.Point(123, 86);
            this.user_NameTextBox.Name = "user_NameTextBox";
            this.user_NameTextBox.Size = new System.Drawing.Size(112, 22);
            this.user_NameTextBox.TabIndex = 27;
            this.user_NameTextBox.TextChanged += new System.EventHandler(this.user_NameTextBox_TextChanged);
            this.user_NameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user_NameTextBox_KeyPress);
            // 
            // Change_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 303);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.user_PwdTextBox);
            this.Controls.Add(this.user_NameTextBox);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.MaximizeBox = false;
            this.Name = "Change_Password";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Change_Password";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Change_Password_FormClosed);
            this.Load += new System.EventHandler(this.Change_Password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnChangePassword;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtNewPassword;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox user_PwdTextBox;
        private System.Windows.Forms.TextBox user_NameTextBox;
        private System.Windows.Forms.Label label6;
    }
}