﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileDirectorySynchronizer.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FileDirectorySynchronizer.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File and Directory Synchronizer.
        /// </summary>
        internal static string AppTitle {
            get {
                return ResourceManager.GetString("AppTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Is this a bidirectional sync?.
        /// </summary>
        internal static string AskIfBidirectionalPrompt {
            get {
                return ResourceManager.GetString("AskIfBidirectionalPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Canceled operation.
        /// </summary>
        internal static string CancelOperationPrompt {
            get {
                return ResourceManager.GetString("CancelOperationPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred.
        /// </summary>
        internal static string ErrorOccurredTitle {
            get {
                return ResourceManager.GetString("ErrorOccurredTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to quit?.
        /// </summary>
        internal static string ExitApplicationPrompt {
            get {
                return ResourceManager.GetString("ExitApplicationPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a destination file path.
        /// </summary>
        internal static string FilePickerDestinationWindowTitle {
            get {
                return ResourceManager.GetString("FilePickerDestinationWindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a source file.
        /// </summary>
        internal static string FilePickerSourceWindowTitle {
            get {
                return ResourceManager.GetString("FilePickerSourceWindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a destination folder path.
        /// </summary>
        internal static string FolderPickerDestinationWindowTitle {
            get {
                return ResourceManager.GetString("FolderPickerDestinationWindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a source folder.
        /// </summary>
        internal static string FolderPickerSourceWindowTitle {
            get {
                return ResourceManager.GetString("FolderPickerSourceWindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have nothing selected..
        /// </summary>
        internal static string NothingSelectedPrompt {
            get {
                return ResourceManager.GetString("NothingSelectedPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The source and destination are the same..
        /// </summary>
        internal static string SourceAndDestinationMatchPrompt {
            get {
                return ResourceManager.GetString("SourceAndDestinationMatchPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Either the source or destination is not set..
        /// </summary>
        internal static string SourceOrDestinationEmptyPrompt {
            get {
                return ResourceManager.GetString("SourceOrDestinationEmptyPrompt", resourceCulture);
            }
        }
    }
}