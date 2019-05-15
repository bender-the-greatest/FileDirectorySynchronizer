using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectorySynchronizer
{
    public delegate void SynchronizerChangedHandler(object sender, SynchronizerChangedHandlerEventArgs e);
    public class SynchronizerChangedHandlerEventArgs : EventArgs
    {
        public Synchronizer ChangedSynchronizer { get; private set; }

        public SynchronizerChangedHandlerEventArgs(Synchronizer synchronizer)
        {
            this.ChangedSynchronizer = synchronizer;
        }
    }
}
