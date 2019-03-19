﻿using SharpShell.SharpPropertySheet;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatswordsTab.Shell
{
    public partial class SheetExtensionPage : SharpPropertyPage
    {
        private string FilePath;

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
            
            MessageService.Push("SetLocale");
            MessageService.Push(MessageService.GetLocale());

            MessageListener().Start();
        }

        protected override void OnPropertySheetApply()
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetApply");
            MessageService.Commit();
        }

        protected override void OnPropertySheetOK()
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK");
            MessageService.Commit();
        }

        private void Reload()
        {
            if (FilePath == null)
            {
                SetTxtTerminal("File could not recognized.");
            }
            else
            {
                MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertyPageInitialised");
                MessageService.Push(FilePath);
                MessageService.Commit();

                string response = MessageService.Pull();
                SetTxtTerminal(response);
                txtTerminal.Enabled = true;
            }
        }

        private Task MessageListener()
        {
            return new Task(() =>
            {
                Reload(); // first contact

                while (true)
                {
                    MessageService.Push("GetMessage");
                    MessageService.Commit();
                    string response = MessageService.Pull();

                    if (response == "Reload")
                    {
                        Reload();
                    }

                    Thread.Sleep(30000);
                }
            });
        }

        private void OnClick_btnAdd(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd");
            MessageService.Commit();
        }

        private void OnLoad_CatswordsTabPage(object sender, EventArgs e)
        {
            string language = MessageService.GetLocale();

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

            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnLoad_CatswordsTabPage");
            MessageService.Commit();
        }

        public void SetTxtTerminal(string text)
        {
            txtTerminal.Text = text;
        }
    }
}
