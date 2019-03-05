using Newtonsoft.Json.Linq;
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
    public partial class ShellExpert : Form
    {
        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalzation();
            InitializeFont();
        }

        public ShellExpert()
        {
            Initialize();
        }

        private void InitializeLocalzation()
        {
            this.Text = "전문가 모드";
            labelTitle.Text = "전문가 모드";
            btnLogin.Text = "로그인";
        }

        private void InitializeFont()
        {
            this.Font = ShellHelper.GetFont();
            labelTitle.Font = ShellHelper.GetFont(20F);
            btnLogin.Font = ShellHelper.GetFont(12F);
        }

        private void OpenAuthWindow()
        {
            ShellHelper.TabAuth = new ShellAuth();
            ShellHelper.TabAuth.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenAuthWindow();
        }

        private void CatswordsTabExpert_Load(object sender, EventArgs e)
        {
            ShellHelper.TabExpert = this;
            txtHashMd5.Text = ShellHelper.TabPage.FileMd5;
            txtHashSha1.Text = ShellHelper.TabPage.FileSha1;
            txtHashCrc32.Text = ShellHelper.TabPage.FileCrc32;
            txtHashHead32.Text = ShellHelper.TabPage.FileHead32;
            txtHashSha256.Text = ShellHelper.TabPage.FileSha256;
            txtExtension.Text = ShellHelper.TabPage.FileExt;
            txtLanguage.Text = ShellHelper.TabPage.CurrentLanguage;
            txtAnalytics.Text = ShellHelper.ReportData;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            JObject obj = new JObject
            {
                { "hash_md5", txtHashMd5.Text },
                { "hash_sha1", txtHashSha1.Text },
                { "hash_crc32", txtHashCrc32.Text },
                { "hash_sha256", txtHashSha256.Text },
                { "hash_head32", txtHashHead32.Text },
                { "extension", txtExtension.Text },
                { "language", txtLanguage.Text }
            };
            string response = ShellHelper.RequestPost("/portal/?route=tab", obj.ToString());
            ShellHelper.TabPage.SetTxtTerminalText(response);
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            txtAnalytics.Text = ShellHelper.ReportData;
        }
    }
}
