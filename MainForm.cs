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
        private bool myReallyClosing = false;
        private MirrorSettings myMirrorSettings = new MirrorSettings();

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

        private void reloadListView()
        {
            this.lsvFileMirrors.Items.Clear();
            for (int x = 0; x < this.myMirrorSettings.Settings.Count; x++)
            {
                // Set the columns for the list view item
                string[] cols = new string[4];
                cols[0] = this.myMirrorSettings.Settings[x].Path;
                cols[1] = this.myMirrorSettings.Settings[x].DestinationPath;

                switch (this.myMirrorSettings.Settings[x].FileType)
                {
                    case FileType.Directory:
                        cols[2] = FileType.Directory.ToString();
                        break;
                    case FileType.File:
                        cols[2] = FileType.Directory.ToString();
                        break;
                    default:
                        cols[2] = "Unknown";
                        break;
                }

                switch (this.myMirrorSettings.Settings[x].SyncType)
                {
                    case SyncType.OneWay:
                        cols[3] = SyncType.OneWay.ToString();
                        break;
                    case SyncType.TwoWay:
                        cols[3] = SyncType.TwoWay.ToString();
                        break;
                    default:
                        cols[3] = "Unknown";
                        break;
                }
                ListViewItem item = new ListViewItem(cols)
                {
                    Tag = x
                };
                lsvFileMirrors.Items.Add(item);
            }
            this.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(Properties.Resources.ExitApplicationPrompt, Properties.Resources.AppTitle, MessageBoxButtons.YesNo))
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
            SyncType syncType = askIfBidirectional() == DialogResult.Yes ? SyncType.TwoWay : SyncType.OneWay;
            IDictionary paths = this.pickPaths(FileType.File);
            if (paths != null)
            {
                int newIndex = -1;
                try
                {
                    newIndex = this.myMirrorSettings.AddPath((string)paths["sourcePath"], (string)paths["destPath"], syncType, FileType.File);
                    // Properties.Settings.Default.Save(); // TODO: Figure out why I can only get one save out of this
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Properties.Resources.ErrorOccurredTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (newIndex > -1)
                        this.myMirrorSettings.RemovePath(newIndex);
                }
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            SyncType syncType = askIfBidirectional() == DialogResult.Yes ? SyncType.TwoWay : SyncType.OneWay;
            IDictionary paths = this.pickPaths(FileType.Directory);
            if (paths != null)
            {
                int newIndex = -1;

                try
                {
                    newIndex = this.myMirrorSettings.AddPath((string)paths["sourcePath"], (string)paths["destPath"], syncType, FileType.Directory);
                    // Properties.Settings.Default.Save(); // TODO: Figure out why I can only get one save out of this
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Properties.Resources.ErrorOccurredTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (newIndex > -1)
                        this.myMirrorSettings.RemovePath(newIndex);
                }
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            this.removeSelectedFileMirror();
        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            this.removeSelectedFileMirror();
        }

        private void removeSelectedFileMirror()
        {
            if(this.lsvFileMirrors.SelectedItems.Count > 0)
            {
                int removeIndex = (int)this.lsvFileMirrors.SelectedItems[0].Tag;
                MirrorSettings.Setting ogSetting = null;
                try
                {
                    ogSetting = this.myMirrorSettings.RemovePath(removeIndex);
                    // Properties.Settings.Default.Save(); // TODO: Figure out why I can only get one save out of this
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message, Properties.Resources.ErrorOccurredTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (ogSetting != null)
                        this.myMirrorSettings.AddPath(ogSetting.Path, ogSetting.DestinationPath, ogSetting.SyncType, ogSetting.FileType);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.NothingSelectedPrompt, Properties.Resources.AppTitle, MessageBoxButtons.OK);
            }
        }

        private void showCanceledDialog()
        {
            MessageBox.Show(Properties.Resources.CancelOperationPrompt, Properties.Resources.AppTitle, MessageBoxButtons.OK);
        }

        private void setPickerTitle(object picker, string text)
        {
            if(picker is VistaOpenFileDialog ofd)
            {
                ofd.Title = text;
            } else if(picker is VistaFolderBrowserDialog fbd)
            {
                fbd.Description = text;
            } else
            {
                throw new ArgumentException("Unknown dialog type", "picker");
            }
        }

        private string getPickerPath(object picker)
        {
            if (picker is VistaOpenFileDialog ofd)
            {
                return ofd.Multiselect && ofd.FileNames != null ?
                    string.Join("|", ofd.FileNames) : ofd.FileName;
            }

            if (picker is VistaFolderBrowserDialog fbd)
            {
                return fbd.SelectedPath;
            }

            throw new ArgumentException("Unknown dialog type", "picker");
        }

        private DialogResult askIfBidirectional()
        {
            return MessageBox.Show(Properties.Resources.AskIfBidirectionalPrompt, Properties.Resources.AppTitle, MessageBoxButtons.YesNo);
        }

        private Dictionary<string, string> pickPaths(FileType fileType)
        {
            string sourceTitle = null;
            string destTitle = null;
            dynamic browser = null;

            switch (fileType)
            {
                case FileType.Directory:
                    sourceTitle = Properties.Resources.FolderPickerSourceWindowTitle;
                    destTitle = Properties.Resources.FolderPickerDestinationWindowTitle;
                    browser = new VistaFolderBrowserDialog
                    {
                        UseDescriptionForTitle = true
                    };
                    break;
                case FileType.File:
                    sourceTitle = Properties.Resources.FilePickerSourceWindowTitle;
                    destTitle = Properties.Resources.FilePickerDestinationWindowTitle;
                    browser = new VistaOpenFileDialog()
                    {
                        Multiselect = false,
                        SupportMultiDottedExtensions = true,
                        CheckFileExists = false
                    };
                    break;
                default:
                    throw new ArgumentException($"Unexpected fileType {fileType}");
            }

            // pick the source path
            string sourcePath = null;
            this.setPickerTitle(browser, sourceTitle);
            switch (browser.ShowDialog())
            {
                case DialogResult.Cancel:
                    this.showCanceledDialog();
                    return null;

                default:
                    sourcePath = this.getPickerPath(browser);
                    break;
            }

            // pick the destination path
            string destPath = null;
            this.setPickerTitle(browser, destTitle);
            switch (browser.ShowDialog())
            {
                case DialogResult.Cancel:
                    this.showCanceledDialog();
                    return null;

                default:
                    destPath = this.getPickerPath(browser);
                    break;
            }

            // make sure neither path is null or empty somehow
            if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destPath))
            {
                MessageBox.Show(Properties.Resources.SourceOrDestinationEmptyPrompt, Properties.Resources.AppTitle, MessageBoxButtons.OK);
                this.showCanceledDialog();
                return null;
            }

            // make sure the paths are not the same
            if( string.Compare(sourcePath, destPath) == 0)
            {
                MessageBox.Show(Properties.Resources.SourceAndDestinationMatchPrompt, Properties.Resources.AppTitle, MessageBoxButtons.OK);
                this.showCanceledDialog();
                return null;
            }

            return new Dictionary<string, string>
            {
                { "sourcePath", sourcePath },
                { "destPath", destPath }
            };
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
