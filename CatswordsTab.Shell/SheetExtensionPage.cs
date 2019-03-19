﻿using SharpShell.SharpPropertySheet;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CatswordsTab.Shell
{
    public partial class SheetExtensionPage : SharpPropertyPage
    {
        private string FilePath = "";

        public SheetExtensionPage()
        {
            InitializeComponent();
        }

        public void SetFilePath(string filepath)
        {
            FilePath = filepath;
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            SetFilePath(parent.SelectedItemPaths.First());
            
            MessageClient.Push("SetLocale");
            MessageClient.Push(MessageClient.GetLocale());
            MessageClient.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertyPageInitialised");
            MessageClient.Push(FilePath);
            MessageClient.Commit();

            string response = MessageClient.Pull();
            SetTxtTerminal(response);
            txtTerminal.Enabled = true;
        }

        protected override void OnPropertySheetApply()
        {
            MessageClient.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetApply");
            MessageClient.Commit();
        }

        protected override void OnPropertySheetOK()
        {
            MessageClient.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK");
            MessageClient.Commit();
        }

        private void OnClick_btnAdd(object sender, EventArgs e)
        {
            MessageClient.Push("CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd");
            MessageClient.Commit();
        }

        public void SetTxtTerminal(string text)
        {
            txtTerminal.Text = text;
        }

        private void OnLoad_CatswordsTabPage(object sender, EventArgs e)
        {
            string language = MessageClient.GetLocale();

            PageTitle = Properties.Resources.PageTitle_en;

            labelTitle.Text = Properties.Resources.labelTitle_en;
            btnAdd.Text = Properties.Resources.btnAdd_en;
            txtTerminal.Text = Properties.Resources.txtTerminal_en;
            
            if (language == "ko")
            {
                PageTitle = Properties.Resources.PageTitle_ko;
                labelTitle.Text = Properties.Resources.labelTitle_ko;
                btnAdd.Text = Properties.Resources.btnAdd_ko;
                txtTerminal.Text = Properties.Resources.txtTerminal_ko;
            }

            MessageClient.Push("CatswordsTab.Shell.SheetExtensionPage.OnLoad_CatswordsTabPage");
            MessageClient.Commit();
        }
    }
}