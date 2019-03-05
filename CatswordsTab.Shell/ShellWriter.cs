using CatswordsTab.Shell.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab.Shell
{
    public partial class ShellWriter : Form
    {
        private string dataReport = "";
   
        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public ShellWriter()
        {
            Initialize();
        }

        public void setTxtReplyEmail(string email)
        {
            txtReplyEmail.Text = email;
        }

        private void InitializeLocalization()
        {
            btnSend.Text = "저장";
            labelMessage.Text = "남기실 말";
            cbAgreement.Text = "개인정보 수집 및 이용 약관에 동의합니다.";
            labelTitle.Text = "의견작성";
            labelReplyEmail.Text = "회신 전자우편 주소 (선택)";
            this.Text = "의견작성";
        }

        private void InitializeFont()
        {
            this.Font = ShellHelper.GetFont();
            btnSend.Font = ShellHelper.GetFont(12F);
            labelMessage.Font = ShellHelper.GetFont();
            cbAgreement.Font = ShellHelper.GetFont();
            labelTitle.Font = ShellHelper.GetFont(20F);
            labelReplyEmail.Font = ShellHelper.GetFont();
            txtMessage.Font = ShellHelper.GetFont();
        }

        private void OpenAuthWindow()
        {
            ShellHelper.TabAuth = new ShellAuth();
            ShellHelper.TabAuth.Show();
        }

        private void OpenExpertWindow()
        {
            ShellHelper.TabExpert = new ShellExpert();
            ShellHelper.TabExpert.Show();
        }

        private void CatswordsTabWriter_Load(object sender, EventArgs e)
        {
            ShellHelper.TabWriter = this;
            ActiveControl = txtMessage;

            try
            {
                // login by guest credential
                ShellHelper.DoLogin("guest.tab@catswords.com", "d3nexkz9UkP8ur77");
            } catch
            {
                // open auth window
                OpenAuthWindow();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            if (cbAgreement.Checked == false)
            {
                MessageBox.Show("개인정보 수집 및 이용 약관에 동의하셔야 합니다.");
            }
            else
            {
                // write data
                TabItem obj = new TabItem
                {
                    HashMd5 = ShellHelper.TabPage.FileMd5,
                    HashSha1 = ShellHelper.TabPage.FileSha1,
                    HashCrc32 = ShellHelper.TabPage.FileCrc32,
                    HashSha256 = ShellHelper.TabPage.FileSha256,
                    HashHead32 = ShellHelper.TabPage.FileHead32,
                    Extension = ShellHelper.TabPage.FileExt,
                    Message = txtMessage.Text,
                    ReplyEmail = txtReplyEmail.Text,
                    Language = ShellHelper.TabPage.CurrentLanguage,
                    Report = ShellHelper.ReportData,
                };
                string jsonData = obj.ToJson();
                string response = ShellHelper.RequestPost("/_/items/catswords_tab", jsonData);
                TabResponse jsonResponse = JsonConvert.DeserializeObject<TabResponse>(response);
                if (jsonResponse.Data.Id > 0)
                {
                    ShellHelper.TabPage.InitializeTerminal();
                    MessageBox.Show("등록이 완료되었습니다.");
                    this.Close();
                }
            }
        }

        private void txtReplyEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtReplyEmail.Text.ToLower();

            if(email == "/expert")
            {
                OpenExpertWindow();
            }
        }
    }
}
