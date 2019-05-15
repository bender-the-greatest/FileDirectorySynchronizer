using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ookii.Dialogs.WinForms;

namespace FileDirectorySynchronizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if(Properties.Settings.Default.MirrorSettings == null)
            {
                Properties.Settings.Default.MirrorSettings = this.myMirrorSettings;
            } else
            {
                this.myMirrorSettings = Properties.Settings.Default.MirrorSettings;
            }

            this.Text = Properties.Resources.AppTitle;
            this.notifyIcon1.Icon = this.Icon;
            reloadListView();

            this.myMirrorSettings.SettingsUpdated += onMirrorSettingsUpdated;
        }

        private void onMirrorSettingsUpdated(object sender, EventArgs e)
        {
            reloadListView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(
                Properties.Resources.ExitApplicationPrompt,
                Properties.Resources.AppTitle,
                MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    this.myReallyClosing = true;
                    Properties.Settings.Default.Save();
                    Application.Exit();
                    break;
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.myReallyClosing;
            this.Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            this.addFile();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            this.addFolder();
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            this.removeSelectedFileMirror();
        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            this.removeSelectedFileMirror();
        }

        private void fileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lsvFileMirrors.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lsvFileMirrors.SelectedIndices[0];
                this.btnRemoveFile.Enabled = this.myMirrorSettings.Settings[selectedIndex].FileType == FileType.File;
                this.btnRemoveFolder.Enabled = this.myMirrorSettings.Settings[selectedIndex].FileType == FileType.Directory;
            } else
            {
                this.btnRemoveFolder.Enabled = this.btnRemoveFile.Enabled = false;
            }
        }
    }
}
