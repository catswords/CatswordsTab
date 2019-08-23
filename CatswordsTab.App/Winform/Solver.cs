﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatswordsTab.App.Winform
{
    public partial class Solver : Form
    {
        public Solver()
        {
            InitializeComponent();

            Text = T._(Text);
            labelTitle.Text = T._(labelTitle.Text);
            labelManifest.Text = T._(labelManifest.Text);
            labelExport.Text = T._(labelExport.Text);
            labelManifest.Text = T._(labelManifest.Text);
            btnUnlock.Text = T._(btnUnlock.Text);
            btnOpenManifest.Text = T._(btnOpenManifest.Text);
            btnOpenExport.Text = T._(btnOpenExport.Text);
        }

        private string ChooseFile()
        {
            string filename = null;
            OpenFileDialog fd;
            
            fd = new OpenFileDialog
            {
                Title = T._("Choose your file...")
            };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                filename = fd.FileName;
            }

            return filename;
        }

        private void OnClick_btnOpenManifest(object sender, EventArgs e)
        {
            string filename = ChooseFile();
            txtManifestFilename.Text = filename;
        }

        private void OnClick_btnOpenExport(object sender, EventArgs e)
        {
            string filename = ChooseFile();
            txtExportFilename.Text = filename;
        }
    }
}
