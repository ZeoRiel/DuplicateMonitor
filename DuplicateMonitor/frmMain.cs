using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DuplicateMonitor;

namespace DuplicateMonitor
{
    public partial class frmMain : Form
    {
        FileHashStore FHS = new FileHashStore();

        FileSystemWatcher fsw;

        public frmMain()
        {
            InitializeComponent();
            

            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           

        }

        public string MyText 
        {
            get {return textBoxOut.Text; }
            set {textBoxOut.Text = textBoxOut.Text + Environment.NewLine + value; }
        }

        //  This method is called when a file is created, changed, or deleted.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {


            //  Show that a file has been created, changed, or deleted.
            WatcherChangeTypes wct = e.ChangeType;
                                    
            
            FileSystemWatcher ParentFSW = source as FileSystemWatcher;
            frmMain ParentForm = ParentFSW.SynchronizingObject as frmMain;
            ParentForm.MyText = "File {0} {1}" + e.FullPath + wct.ToString();

        }

        //  This method is called when a file is renamed.
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            //  Show that a file has been renamed.
            WatcherChangeTypes wct = e.ChangeType;
            FileSystemWatcher ParentFSW = source as FileSystemWatcher;
            frmMain ParentForm = ParentFSW.SynchronizingObject as frmMain;
            ParentForm.MyText = "File {0} {2} to {1}" + e.OldFullPath + e.FullPath + wct.ToString();

            
        }

        //  This method is called when the FileSystemWatcher detects an error.
        private static void OnError(object source, ErrorEventArgs e)
        {
            FileSystemWatcher ParentFSW = source as FileSystemWatcher;
            frmMain ParentForm = ParentFSW.SynchronizingObject as frmMain;

            //  Show that an error has been detected.
            ParentForm.MyText = "The FileSystemWatcher has detected an error";
            //  Give more information if the error is due to an internal buffer overflow.
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                //  This can happen if Windows is reporting many file system events quickly 
                //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
                //  rate of events. The InternalBufferOverflowException error informs the application
                //  that some of the file system events are being lost.
                 ParentForm.MyText = "The file system watcher experienced an internal buffer overflow: " + e.GetException().Message;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {


        }

        private void chkStartStop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartStop.Checked == true)
            {
                //  Create a FileSystemWatcher to monitor all files on drive C.
                if (fsw == null)
                {

                    fsw = new FileSystemWatcher("C:\\");
                    //  Register a handler that gets called when a 
                    //  file is created, changed, or deleted.
                    fsw.Changed += new FileSystemEventHandler(OnChanged);

                    fsw.Created += new FileSystemEventHandler(OnChanged);

                    fsw.Deleted += new FileSystemEventHandler(OnChanged);

                    //  Register a handler that gets called when a file is renamed.
                    fsw.Renamed += new RenamedEventHandler(OnRenamed);

                    //  Register a handler that gets called if the 
                    //  FileSystemWatcher needs to report an error.

                    fsw.Error += new ErrorEventHandler(OnError);
                }
                fsw.SynchronizingObject = this;


                //  Watch for changes in LastAccess and LastWrite times, and
                //  the renaming of files or directories. 
                fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                fsw.IncludeSubdirectories = true;

                //  Begin watching.
                fsw.EnableRaisingEvents = true;
                chkStartStop.Text = "Stop";
            }
            else
            {
                chkStartStop.Text = "Start";
                fsw.EnableRaisingEvents = false;
            }
        }
    }
 }

