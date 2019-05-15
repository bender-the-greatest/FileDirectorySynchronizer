using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileDirectorySynchronizer
{
    public enum SyncType
    {
        OneWay,
        TwoWay
    }

    public enum FileType
    {
        File,
        Directory
    }

    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class MirrorSettings
    {
        public event EventHandler<EventArgs> SettingsUpdated;

        private readonly Object myLockingObject = new Object();

        public List<Setting> Settings { get; private set; }

        public MirrorSettings()
        {
            this.Settings = new List<Setting>();
        }

        public int AddPath(string path, string destinationPath, SyncType syncType, FileType fileType)
        {
            lock (this.myLockingObject)
            {
                int ogCount = this.Settings.Count;

                try
                {
                    this.Settings.Add(new Setting
                    {
                        Path = path,
                        DestinationPath = destinationPath,
                        SyncType = syncType,
                        FileType = fileType
                    });
                }
                catch (Exception e)
                {
                    while (this.Settings.Count > ogCount) { this.Settings.RemoveAt(this.Settings.Count - 1); }
                    throw e;
                }

                fireUpdatedEvent();
                return this.Settings.Count - 1;
            }
        }

        private void fireUpdatedEvent()
        {
            this.SettingsUpdated?.Invoke(this, EventArgs.Empty);
        }

        public Setting RemovePath(int targetIndex)
        {
            lock (this.myLockingObject)
            {
                int ogCount = this.Settings.Count;

                // store off the original setting in case the removal fails
                Setting ogSetting = this.Settings[targetIndex];

                try
                {
                    this.Settings.RemoveAt(targetIndex);
                }
                catch (Exception e)
                {
                    // put everything back the way it was before rethrowing
                    if (this.Settings.Count != ogCount) { this.Settings.Insert(targetIndex, ogSetting); }
                    throw e;
                }

                fireUpdatedEvent();
                return ogSetting;
            }
        }

        public class Setting
        {
            public string Path { get; set; }
            public string DestinationPath { get; set; }
            public SyncType SyncType { get; set; }
            public FileType FileType { get; set; }

            public Setting() { }
        }
    }
}
