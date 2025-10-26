namespace LastMileAPP
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UsernameText = new TextBox();
            PasswordText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            LoginButton = new Button();
            SuspendLayout();
            // 
            // UsernameText
            // 
            UsernameText.Location = new Point(108, 26);
            UsernameText.Name = "UsernameText";
            UsernameText.Size = new Size(234, 23);
            UsernameText.TabIndex = 0;
            // 
            // PasswordText
            // 
            PasswordText.Location = new Point(108, 82);
            PasswordText.Name = "PasswordText";
            PasswordText.Size = new Size(234, 23);
            PasswordText.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 34);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 90);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(174, 133);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(75, 23);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.MouseClick += LoginButton_MouseClick;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 190);
            Controls.Add(LoginButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordText);
            Controls.Add(UsernameText);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameText;
        private TextBox PasswordText;
        private Label label1;
        private Label label2;
        private Button LoginButton;
    }
}
