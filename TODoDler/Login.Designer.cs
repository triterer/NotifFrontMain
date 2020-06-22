namespace TODoDler
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
            this.TB_Login = new System.Windows.Forms.TextBox();
            this.TB_Pass = new System.Windows.Forms.TextBox();
            this.BT_Enter = new System.Windows.Forms.Button();
            this.LB_Login = new System.Windows.Forms.Label();
            this.LB_Pass = new System.Windows.Forms.Label();
            this.TB_Reg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_Login
            // 
            this.TB_Login.Location = new System.Drawing.Point(28, 39);
            this.TB_Login.Name = "TB_Login";
            this.TB_Login.Size = new System.Drawing.Size(286, 20);
            this.TB_Login.TabIndex = 0;
            this.TB_Login.Text = "User";
            // 
            // TB_Pass
            // 
            this.TB_Pass.Location = new System.Drawing.Point(28, 82);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.PasswordChar = '*';
            this.TB_Pass.Size = new System.Drawing.Size(286, 20);
            this.TB_Pass.TabIndex = 1;
            this.TB_Pass.Text = "User";
            // 
            // BT_Enter
            // 
            this.BT_Enter.Location = new System.Drawing.Point(28, 116);
            this.BT_Enter.Name = "BT_Enter";
            this.BT_Enter.Size = new System.Drawing.Size(133, 38);
            this.BT_Enter.TabIndex = 2;
            this.BT_Enter.Text = "Login";
            this.BT_Enter.UseVisualStyleBackColor = true;
            this.BT_Enter.Click += new System.EventHandler(this.BT_Enter_Click);
            // 
            // LB_Login
            // 
            this.LB_Login.AutoSize = true;
            this.LB_Login.Location = new System.Drawing.Point(25, 23);
            this.LB_Login.Name = "LB_Login";
            this.LB_Login.Size = new System.Drawing.Size(36, 13);
            this.LB_Login.TabIndex = 3;
            this.LB_Login.Text = "Login:";
            // 
            // LB_Pass
            // 
            this.LB_Pass.AutoSize = true;
            this.LB_Pass.Location = new System.Drawing.Point(25, 66);
            this.LB_Pass.Name = "LB_Pass";
            this.LB_Pass.Size = new System.Drawing.Size(59, 13);
            this.LB_Pass.TabIndex = 3;
            this.LB_Pass.Text = "Password: ";
            // 
            // TB_Reg
            // 
            this.TB_Reg.Location = new System.Drawing.Point(181, 116);
            this.TB_Reg.Name = "TB_Reg";
            this.TB_Reg.Size = new System.Drawing.Size(133, 38);
            this.TB_Reg.TabIndex = 2;
            this.TB_Reg.Text = "Registration";
            this.TB_Reg.UseVisualStyleBackColor = true;
            this.TB_Reg.Click += new System.EventHandler(this.BT_Reg_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 166);
            this.Controls.Add(this.LB_Pass);
            this.Controls.Add(this.LB_Login);
            this.Controls.Add(this.TB_Reg);
            this.Controls.Add(this.BT_Enter);
            this.Controls.Add(this.TB_Pass);
            this.Controls.Add(this.TB_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Login;
        private System.Windows.Forms.TextBox TB_Pass;
        private System.Windows.Forms.Button BT_Enter;
        private System.Windows.Forms.Label LB_Login;
        private System.Windows.Forms.Label LB_Pass;
        private System.Windows.Forms.Button TB_Reg;
    }
}