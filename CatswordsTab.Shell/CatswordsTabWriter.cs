﻿using CatswordsTab.Shell.Model;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using Newtonsoft.Json;
using PeNet;
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
    public partial class CatswordsTabWriter : Form
    {
        private string dataReport = "";
   
        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public CatswordsTabWriter()
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
            this.Font = CatswordsTabHelper.GetFont();
            btnSend.Font = CatswordsTabHelper.GetFont(12F);
            labelMessage.Font = CatswordsTabHelper.GetFont();
            cbAgreement.Font = CatswordsTabHelper.GetFont();
            labelTitle.Font = CatswordsTabHelper.GetFont(20F);
            labelReplyEmail.Font = CatswordsTabHelper.GetFont();
            txtMessage.Font = CatswordsTabHelper.GetFont();
        }

        private void OpenAuthWindow()
        {
            CatswordsTabHelper.TabAuth = new CatswordsTabAuth();
            CatswordsTabHelper.TabAuth.Show();
        }

        private void OpenExpertWindow()
        {
            CatswordsTabHelper.TabExpert = new CatswordsTabExpert();
            CatswordsTabHelper.TabExpert.Show();
        }

        private void CatswordsTabWriter_Load(object sender, EventArgs e)
        {
            CatswordsTabHelper.TabWriter = this;
            ActiveControl = txtMessage;

            try
            {
                // login by guest credential
                CatswordsTabHelper.DoLogin("guest.tab@catswords.com", "d3nexkz9UkP8ur77");
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
                // do analyze
                CatswordsTabHelper.DoAnalyze();

                // write data
                TabItem obj = new TabItem
                {
                    HashMd5 = CatswordsTabHelper.TabPage.FileMd5,
                    HashSha1 = CatswordsTabHelper.TabPage.FileSha1,
                    HashCrc32 = CatswordsTabHelper.TabPage.FileCrc32,
                    HashSha256 = CatswordsTabHelper.TabPage.FileSha256,
                    HashHead32 = CatswordsTabHelper.TabPage.FileHead32,
                    Extension = CatswordsTabHelper.TabPage.FileExt,
                    Message = txtMessage.Text,
                    ReplyEmail = txtReplyEmail.Text,
                    Language = CatswordsTabHelper.TabPage.CurrentLanguage,
                    Report = CatswordsTabHelper.ReportData,
                };
                string jsonData = obj.ToJson();
                string response = CatswordsTabHelper.RequestPost("/_/items/catswords_tab", jsonData);
                TabResponse jsonResponse = JsonConvert.DeserializeObject<TabResponse>(response);
                if (jsonResponse.Data.Id > 0)
                {
                    CatswordsTabHelper.TabPage.InitializeTerminal();
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
