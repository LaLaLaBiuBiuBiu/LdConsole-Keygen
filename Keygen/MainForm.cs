using System;
using System.Windows.Forms;

namespace Keygen
{
    public partial class MainForm : Form
    {
        private string filePAth;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, EventArgs e)
        {
            try
            {
                button_authorization.Enabled = false;
                button_filePath.Enabled = false;
                button_redCode.Enabled = false;
                if (string.IsNullOrEmpty(filePAth))
                {
                    MessageBox.Show("未选择保存路径");
                    return;
                }
                if (string.IsNullOrEmpty(textBox_user.Text))
                {
                    MessageBox.Show("用户名为空");
                    return;
                }

                Tuple<byte[], byte[]> tuple1 = DecryptHelper.GetDecryptFileByte();
                CommonFunctions.WriteTempIrs(EncryptHelper.GetEncryptFileByte(tuple1.Item1, tuple1.Item2, textBox_computerCode.Text, "abcdefghijklmnopqrstuvwxyzabcdef", textBox_user.Text));
                CommonFunctions.WritetrInfoPf1(EncryptHelper.GetEncryptFileByte(tuple1.Item1, tuple1.Item2, textBox_computerCode.Text, CommonFunctions.GetMd5(), textBox_user.Text), filePAth);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button_authorization.Enabled = true;
                button_filePath.Enabled = true;
                button_redCode.Enabled = true;
                progressBar1.Value = 0;
                this.ActiveControl = button_authorization;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBox_computerCode.Text = CommonFunctions.GetComputerCode();
            textBox_filePath.Text = filePAth = AppDomain.CurrentDomain.BaseDirectory;
            CommonFunctions.GetMd5Progress += ProgressEvent;
            this.ActiveControl = button_authorization;
        }

        private void FilePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            textBox_filePath.Text = filePAth = folderBrowserDialog.SelectedPath;
            this.ActiveControl = button_authorization;
        }

        private void RedCode_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_user.Text, out _))
            {
                textBox_regCode.Text = CommonFunctions.GetRegCode(textBox_user.Text).ToUpper();
            }
            else
            {
                MessageBox.Show("计算用户名要求纯数字");
            }
            this.ActiveControl = button_authorization;
        }

        private void User_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ProgressEvent(object sender, EventArgs e)
        {
            Progress progressEventArgs = e as Progress;
            Invoke(new Action(() =>
            {
                progressBar1.Value = progressEventArgs.V2;
            }));
        }
    }
}