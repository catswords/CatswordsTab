using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab.Shell
{
    public partial class ShellAuth : Form
    {
        private ShellWriter CatswordsTabWriter = null;

        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public ShellAuth()
        {
            Initialize();
        }

        private void InitializeLocalization()
        {
            btnLogin.Text = "로그인";
            labelUsername.Text = "사용자 이메일";
            labelPassword.Text = "사용자 열쇠글";
            labelTitle.Text = "인증";
            labelCopyright.Text = "(c) 2019 Catswords Research.";
            this.Text = "인증";
        }

        private void InitializeFont()
        {
            this.Font = ShellHelper.GetFont();
            labelTitle.Font = ShellHelper.GetFont(20F);
            btnLogin.Font = ShellHelper.GetFont(12F);
            labelUsername.Font = ShellHelper.GetFont();
            labelPassword.Font = ShellHelper.GetFont();
            labelCopyright.Font = ShellHelper.GetFont();
            txtUsername.Font = ShellHelper.GetFont();
            txtPassword.Font = ShellHelper.GetFont();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try { 
                ShellHelper.DoLogin(txtUsername.Text, txtPassword.Text);
                MessageBox.Show("로그인 하였습니다.");

                if (CatswordsTabWriter != null)
                {
                    CatswordsTabWriter.setTxtReplyEmail(txtUsername.Text);
                }

                this.Close();
            } catch
            {
                MessageBox.Show("사용자 이름 또는 열쇠글을 확인하세요.");
            }
            
        }

        private void CatswordsTabAuth_Load(object sender, EventArgs e)
        {
            ShellHelper.TabAuth = this;
            ActiveControl = txtUsername;
        }
    }
}
