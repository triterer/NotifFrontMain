namespace TODoDler
{
    partial class Registration
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
            this.LB_Pass = new System.Windows.Forms.Label();
            this.LB_Login = new System.Windows.Forms.Label();
            this.TB_Pass = new System.Windows.Forms.TextBox();
            this.TB_Login = new System.Windows.Forms.TextBox();
            this.TB_Reg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_Pass
            // 
            this.LB_Pass.AutoSize = true;
            this.LB_Pass.Location = new System.Drawing.Point(18, 65);
            this.LB_Pass.Name = "LB_Pass";
            this.LB_Pass.Size = new System.Drawing.Size(59, 13);
            this.LB_Pass.TabIndex = 6;
            this.LB_Pass.Text = "Password: ";
            // 
            // LB_Login
            // 
            this.LB_Login.AutoSize = true;
            this.LB_Login.Location = new System.Drawing.Point(18, 22);
            this.LB_Login.Name = "LB_Login";
            this.LB_Login.Size = new System.Drawing.Size(36, 13);
            this.LB_Login.TabIndex = 7;
            this.LB_Login.Text = "Login:";
            // 
            // TB_Pass
            // 
            this.TB_Pass.Location = new System.Drawing.Point(21, 81);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.Size = new System.Drawing.Size(286, 20);
            this.TB_Pass.TabIndex = 5;
            // 
            // TB_Login
            // 
            this.TB_Login.Location = new System.Drawing.Point(21, 38);
            this.TB_Login.Name = "TB_Login";
            this.TB_Login.Size = new System.Drawing.Size(286, 20);
            this.TB_Login.TabIndex = 4;
            // 
            // TB_Reg
            // 
            this.TB_Reg.Location = new System.Drawing.Point(93, 116);
            this.TB_Reg.Name = "TB_Reg";
            this.TB_Reg.Size = new System.Drawing.Size(133, 38);
            this.TB_Reg.TabIndex = 8;
            this.TB_Reg.Text = "Registration";
            this.TB_Reg.UseVisualStyleBackColor = true;
            this.TB_Reg.Click += new System.EventHandler(this.TB_Reg_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 167);
            this.Controls.Add(this.TB_Reg);
            this.Controls.Add(this.LB_Pass);
            this.Controls.Add(this.LB_Login);
            this.Controls.Add(this.TB_Pass);
            this.Controls.Add(this.TB_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registration_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_Pass;
        private System.Windows.Forms.Label LB_Login;
        private System.Windows.Forms.TextBox TB_Pass;
        private System.Windows.Forms.TextBox TB_Login;
        private System.Windows.Forms.Button TB_Reg;
    }
}