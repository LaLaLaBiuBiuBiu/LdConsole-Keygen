namespace Keygen
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_computerCode = new System.Windows.Forms.TextBox();
            this.button_authorization = new System.Windows.Forms.Button();
            this.button_filePath = new System.Windows.Forms.Button();
            this.textBox_filePath = new System.Windows.Forms.TextBox();
            this.textBox_regCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.button_redCode = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码";
            // 
            // textBox_computerCode
            // 
            this.textBox_computerCode.Location = new System.Drawing.Point(72, 63);
            this.textBox_computerCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_computerCode.Name = "textBox_computerCode";
            this.textBox_computerCode.ReadOnly = true;
            this.textBox_computerCode.Size = new System.Drawing.Size(307, 25);
            this.textBox_computerCode.TabIndex = 1;
            // 
            // button_authorization
            // 
            this.button_authorization.Location = new System.Drawing.Point(134, 193);
            this.button_authorization.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_authorization.Name = "button_authorization";
            this.button_authorization.Size = new System.Drawing.Size(242, 29);
            this.button_authorization.TabIndex = 4;
            this.button_authorization.Text = "生成授权";
            this.button_authorization.UseVisualStyleBackColor = true;
            this.button_authorization.Click += new System.EventHandler(this.Authorization_Click);
            // 
            // button_filePath
            // 
            this.button_filePath.Location = new System.Drawing.Point(13, 193);
            this.button_filePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_filePath.Name = "button_filePath";
            this.button_filePath.Size = new System.Drawing.Size(115, 29);
            this.button_filePath.TabIndex = 5;
            this.button_filePath.Text = "选择保存路径";
            this.button_filePath.UseVisualStyleBackColor = true;
            this.button_filePath.Click += new System.EventHandler(this.FilePath_Click);
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_filePath.Location = new System.Drawing.Point(13, 92);
            this.textBox_filePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_filePath.Multiline = true;
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.ReadOnly = true;
            this.textBox_filePath.Size = new System.Drawing.Size(366, 88);
            this.textBox_filePath.TabIndex = 6;
            // 
            // textBox_regCode
            // 
            this.textBox_regCode.Location = new System.Drawing.Point(72, 34);
            this.textBox_regCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_regCode.Name = "textBox_regCode";
            this.textBox_regCode.ReadOnly = true;
            this.textBox_regCode.Size = new System.Drawing.Size(307, 25);
            this.textBox_regCode.TabIndex = 8;
            this.textBox_regCode.Text = "73B4C0ED7DD7BF5A03ABD5155DD25560";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "注册码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "用户编号";
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(90, 4);
            this.textBox_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_user.MaxLength = 10;
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(120, 25);
            this.textBox_user.TabIndex = 10;
            this.textBox_user.Text = "1111111111";
            this.textBox_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.User_KeyPress);
            // 
            // button_redCode
            // 
            this.button_redCode.Location = new System.Drawing.Point(216, 4);
            this.button_redCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_redCode.Name = "button_redCode";
            this.button_redCode.Size = new System.Drawing.Size(163, 26);
            this.button_redCode.TabIndex = 11;
            this.button_redCode.Text = "计算注册码";
            this.button_redCode.UseVisualStyleBackColor = true;
            this.button_redCode.Click += new System.EventHandler(this.RedCode_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.LawnGreen;
            this.progressBar1.Location = new System.Drawing.Point(5, 235);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(371, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(388, 270);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_redCode);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_regCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_filePath);
            this.Controls.Add(this.button_filePath);
            this.Controls.Add(this.button_authorization);
            this.Controls.Add(this.textBox_computerCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_computerCode;
        private System.Windows.Forms.Button button_authorization;
        private System.Windows.Forms.Button button_filePath;
        private System.Windows.Forms.TextBox textBox_filePath;
        private System.Windows.Forms.TextBox textBox_regCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.Button button_redCode;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

