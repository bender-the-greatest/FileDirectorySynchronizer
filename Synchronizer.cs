using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDirectorySynchronizer
{
    public partial class Synchronizer
    {
        public enum SynchronizerStatus
        {
            STOPPED,
            STARTED,
            ERROR
        }

        private readonly FileSystemWatcher mySourceWatcher = null;
        private readonly FileSystemWatcher myDestinationWatcher = null;

        public event SynchronizerChangedHandler SynchronizerChanged;

        public SyncType SyncType { get; private set; }
        public FileType FileType { get; private set; }
        public string SourcePath { get; private set; }
        public string DestinationPath { get; private set; }
        public SynchronizerStatus Status { get; private set; }
        public string Info { get; private set; }

        public Synchronizer(string sourcePath, string destinationPath, SyncType syncType, FileType fileType)
        {
            this.mySourceWatcher = new FileSystemWatcher(sourcePath)
            {
                NotifyFilter = NotifyFilters.LastWrite |
                    NotifyFilters.Attributes |
                    NotifyFilters.Size,
                Filter = fileType == FileType.File ?
                    Path.GetFileName(sourcePath) : string.Empty,
                IncludeSubdirectories = fileType == FileType.Directory
            };

            if(syncType == SyncType.TwoWay)
            {
                this.myDestinationWatcher = new FileSystemWatcher(destinationPath)
                {
                    NotifyFilter = NotifyFilters.LastWrite |
                        NotifyFilters.Attributes |
                        NotifyFilters.Size,
                    Filter = fileType == FileType.File ?
                        Path.GetFileName(destinationPath) : string.Empty,
                    IncludeSubdirectories = fileType == FileType.Directory
                };
            }

            this.SyncType = syncType;
            this.FileType = fileType;
            this.SourcePath = sourcePath;
            this.DestinationPath = destinationPath;

            this.mySourceWatcher.Deleted += this.OnSourceChanged;
            this.mySourceWatcher.Changed += this.OnSourceChanged;
            this.mySourceWatcher.Created += this.OnSourceChanged;
            this.mySourceWatcher.Renamed += this.OnSourceRenamed;

            this.myDestinationWatcher.Changed += this.OnDestinationChanged;
            this.myDestinationWatcher.Created += this.OnDestinationChanged;
            this.myDestinationWatcher.Changed += this.OnDestinationChanged;
            this.myDestinationWatcher.Renamed += this.OnDestinationRenamed;

            this.Status = SynchronizerStatus.STOPPED;
        }

        public void Start()
        {
            this.mySourceWatcher.EnableRaisingEvents = true;
            this.myDestinationWatcher.EnableRaisingEvents = true;
            this.Status = SynchronizerStatus.STARTED;
        }

        public void Stop()
        {
            this.mySourceWatcher.EnableRaisingEvents = false;
            this.myDestinationWatcher.EnableRaisingEvents = false;
            this.Status = SynchronizerStatus.STOPPED;
        }

        private static void fastCopy(string sourcePath, string destinationPath)
        {
            int bufferSize = 512 * 1024;
            byte[] dataBuffer = new byte[bufferSize];
            using (FileStream fsr = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
            {
                using (BinaryReader br = new BinaryReader(fsr))
                {
                    using (FileStream fsw = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.Read, bufferSize))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fsw))
                        {
                            for(int read = br.Read(dataBuffer, 0, bufferSize); read != 0; read = br.Read(dataBuffer, 0, bufferSize))
                            {
                                bw.Write(dataBuffer, 0, read);
                            }
                        }
                    }
                }
            }
        }
    }
}
