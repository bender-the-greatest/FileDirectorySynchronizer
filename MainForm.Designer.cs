namespace FileDirectorySynchronizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpFile = new System.Windows.Forms.GroupBox();
            this.lsvFileMirrors = new System.Windows.Forms.ListView();
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDestPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSync = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpManageFiles = new System.Windows.Forms.GroupBox();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.grpManageDirs = new System.Windows.Forms.GroupBox();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpFile.SuspendLayout();
            this.grpManageFiles.SuspendLayout();
            this.grpManageDirs.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // grpFile
            // 
            this.grpFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFile.Controls.Add(this.lsvFileMirrors);
            this.grpFile.Location = new System.Drawing.Point(0, 27);
            this.grpFile.Name = "grpFile";
            this.grpFile.Size = new System.Drawing.Size(639, 244);
            this.grpFile.TabIndex = 2;
            this.grpFile.TabStop = false;
            this.grpFile.Text = "Files to Mirror";
            // 
            // lsvFileMirrors
            // 
            this.lsvFileMirrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPath,
            this.colDestPath,
            this.colType,
            this.colSync});
            this.lsvFileMirrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvFileMirrors.FullRowSelect = true;
            this.lsvFileMirrors.Location = new System.Drawing.Point(3, 16);
            this.lsvFileMirrors.MultiSelect = false;
            this.lsvFileMirrors.Name = "lsvFileMirrors";
            this.lsvFileMirrors.Size = new System.Drawing.Size(633, 225);
            this.lsvFileMirrors.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvFileMirrors.TabIndex = 0;
            this.lsvFileMirrors.UseCompatibleStateImageBehavior = false;
            this.lsvFileMirrors.View = System.Windows.Forms.View.Details;
            this.lsvFileMirrors.SelectedIndexChanged += new System.EventHandler(this.fileListView_SelectedIndexChanged);
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 200;
            // 
            // colDestPath
            // 
            this.colDestPath.Text = "Sync With";
            this.colDestPath.Width = 205;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 92;
            // 
            // colSync
            // 
            this.colSync.Text = "Sync Type";
            this.colSync.Width = 132;
            // 
            // grpManageFiles
            // 
            this.grpManageFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpManageFiles.Controls.Add(this.btnRemoveFile);
            this.grpManageFiles.Controls.Add(this.btnAddFile);
            this.grpManageFiles.Location = new System.Drawing.Point(3, 277);
            this.grpManageFiles.Name = "grpManageFiles";
            this.grpManageFiles.Size = new System.Drawing.Size(108, 48);
            this.grpManageFiles.TabIndex = 1;
            this.grpManageFiles.TabStop = false;
            this.grpManageFiles.Text = "Manage Files";
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Enabled = false;
            this.btnRemoveFile.Location = new System.Drawing.Point(58, 19);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(25, 23);
            this.btnRemoveFile.TabIndex = 1;
            this.btnRemoveFile.Text = "-";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(27, 19);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(25, 23);
            this.btnAddFile.TabIndex = 0;
            this.btnAddFile.Text = "+";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // grpManageDirs
            // 
            this.grpManageDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpManageDirs.Controls.Add(this.btnRemoveFolder);
            this.grpManageDirs.Controls.Add(this.btnAddFolder);
            this.grpManageDirs.Location = new System.Drawing.Point(117, 277);
            this.grpManageDirs.Name = "grpManageDirs";
            this.grpManageDirs.Size = new System.Drawing.Size(108, 48);
            this.grpManageDirs.TabIndex = 2;
            this.grpManageDirs.TabStop = false;
            this.grpManageDirs.Text = "Manage Folders";
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Enabled = false;
            this.btnRemoveFolder.Location = new System.Drawing.Point(58, 19);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(25, 23);
            this.btnRemoveFolder.TabIndex = 3;
            this.btnRemoveFolder.Text = "-";
            this.btnRemoveFolder.UseVisualStyleBackColor = true;
            this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemoveFolder_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(27, 19);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(25, 23);
            this.btnAddFolder.TabIndex = 2;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "FileMirror";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 332);
            this.Controls.Add(this.grpManageDirs);
            this.Controls.Add(this.grpManageFiles);
            this.Controls.Add(this.grpFile);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpFile.ResumeLayout(false);
            this.grpManageFiles.ResumeLayout(false);
            this.grpManageDirs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpFile;
        private System.Windows.Forms.ListView lsvFileMirrors;
        private System.Windows.Forms.GroupBox grpManageFiles;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.GroupBox grpManageDirs;
        private System.Windows.Forms.Button btnRemoveFolder;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ColumnHeader colSync;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ColumnHeader colDestPath;
    }
}

