using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using libWyvernzora.IO;

namespace RenEx
{
    public partial class ProcessingDialog : Form
    {

        public ProcessingDialog(KeyValuePair<FileNameDescriptor, FileNameDescriptor>[] renaming)
        {
            InitializeComponent();

            this.Shown += (@s, a) => ApplyRenaming(renaming);
        }

        /// <summary>
        /// Renaming results.
        /// Key is file name descriptor, value is error message (null if everything ok).
        /// </summary>
        public KeyValuePair<String, String>[] RenameResult { get; private set; }

        public void ApplyRenaming(KeyValuePair<FileNameDescriptor, FileNameDescriptor>[] renaming)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;

            bw.DoWork += (@s, a) =>
                {
                    var scheme = a.Argument as KeyValuePair<FileNameDescriptor, FileNameDescriptor>[];

                    if (scheme == null)
                    {
                        a.Result = new Object[] {false, null};
                        return;
                    }


                    var result = new KeyValuePair<String, String>[scheme.Length];
                    for (int i = 0; i < scheme.Length; i++)
                    {
                        if (bw.CancellationPending) break;

                        try
                        {
                            FileNameDescriptor original = scheme[i].Key;
                            FileNameDescriptor destination = scheme[i].Value;

                            int progress = (int) ((double) i / scheme.Length * 100);
                            bw.ReportProgress(progress, original.FileName);
    
                            // Make sure destination dir is there
                            if (!Directory.Exists(destination.Directory))
                                Directory.CreateDirectory(destination.Directory);

                            // Move file
                            File.Move(original.ToString(), destination.ToString());

                            // Report success
                            result[i] = new KeyValuePair<String, String>(original.ToString(), null);
                        }
                        catch (Exception x)
                        {
                            result[i] = new KeyValuePair<String, String>(scheme[i].Key.ToString(), x.Message);
                        }
                    }

                    a.Result = result;
                };
            bw.ProgressChanged += (@s, a) =>
                {
                    lblProgressDetails.Text = (String) a.UserState;
                    pbOverall.Value = a.ProgressPercentage;
                };
            bw.RunWorkerCompleted += (@s, a) =>
                {
                    RenameResult = (KeyValuePair<String, String>[]) a.Result;
                    Close();
                };
            bw.RunWorkerAsync(renaming);
        }
    }
}
