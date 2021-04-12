namespace HejAndOmra
{
    partial class Login
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.User_ID = new System.Windows.Forms.Label();
            this.Password_ = new System.Windows.Forms.Label();
            this.UserID = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Crimson;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.linkLabel1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(220, 248);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(142, 22);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Change Password";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.pic1);
            this.metroPanel1.Controls.Add(this.linkLabel1);
            this.metroPanel1.Controls.Add(this.comboBox1);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.User_ID);
            this.metroPanel1.Controls.Add(this.Password_);
            this.metroPanel1.Controls.Add(this.UserID);
            this.metroPanel1.Controls.Add(this.Password);
            this.metroPanel1.Controls.Add(this.btnCancel);
            this.metroPanel1.Controls.Add(this.btnOK);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(18, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(513, 285);
            this.metroPanel1.TabIndex = 41;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // pic1
            // 
            this.pic1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pic1.Image = global::HejAndOmra.Properties.Resources.photo;
            this.pic1.InitialImage = global::HejAndOmra.Properties.Resources.photo;
            this.pic1.Location = new System.Drawing.Point(16, 57);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(171, 152);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 253;
            this.pic1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DisplayFocus = true;
            this.comboBox1.FontWeight = MetroFramework.MetroComboBoxWeight.Bold;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 23;
            this.comboBox1.Items.AddRange(new object[] {
            "Manager",
            "User"});
            this.comboBox1.Location = new System.Drawing.Point(224, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(230, 29);
            this.comboBox1.Style = MetroFramework.MetroColorStyle.Black;
            this.comboBox1.TabIndex = 252;
            this.comboBox1.UseSelectable = true;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(124, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 251;
            this.label2.Text = "User Type";
            // 
            // User_ID
            // 
            this.User_ID.AutoSize = true;
            this.User_ID.BackColor = System.Drawing.Color.Transparent;
            this.User_ID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.User_ID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_ID.ForeColor = System.Drawing.Color.Black;
            this.User_ID.Location = new System.Drawing.Point(216, 57);
            this.User_ID.Name = "User_ID";
            this.User_ID.Size = new System.Drawing.Size(92, 22);
            this.User_ID.TabIndex = 248;
            this.User_ID.Text = "User Name";
            // 
            // Password_
            // 
            this.Password_.AutoSize = true;
            this.Password_.BackColor = System.Drawing.Color.Transparent;
            this.Password_.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Password_.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_.ForeColor = System.Drawing.Color.Black;
            this.Password_.Location = new System.Drawing.Point(216, 116);
            this.Password_.Name = "Password_";
            this.Password_.Size = new System.Drawing.Size(81, 22);
            this.Password_.TabIndex = 249;
            this.Password_.Text = "Password";
            // 
            // UserID
            // 
            this.UserID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserID.Location = new System.Drawing.Point(224, 83);
            this.UserID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(187, 29);
            this.UserID.TabIndex = 244;
            this.UserID.TextChanged += new System.EventHandler(this.UserID_TextChanged);
            this.UserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserID_KeyPress);
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(224, 142);
            this.Password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(187, 29);
            this.Password.TabIndex = 245;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(378, 179);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 34);
            this.btnCancel.TabIndex = 247;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.LawnGreen;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.Location = new System.Drawing.Point(223, 179);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(125, 34);
            this.btnOK.TabIndex = 246;
            this.btnOK.Text = "&Login";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // Login
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(552, 360);
            this.Controls.Add(this.metroPanel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Login";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.LinkLabel linkLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroComboBox comboBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label User_ID;
        public System.Windows.Forms.Label Password_;
        public System.Windows.Forms.TextBox UserID;
        public System.Windows.Forms.TextBox Password;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pic1;
    }
}