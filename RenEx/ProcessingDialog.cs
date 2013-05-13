using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using libWyvernzora.Core;
using libWyvernzora.IO;

namespace RenEx
{
    public partial class ProcessingDialog : Form
    {

        public ProcessingDialog(Pair<RenExFileNameDescriptor, RenExFileNameDescriptor>[] renaming)
        {
            InitializeComponent();

            this.Shown += (@s, a) => ApplyRenaming(renaming);
        }

        /// <summary>
        /// Renaming results.
        /// Key is file name descriptor, value is error message (null if everything ok).
        /// </summary>
        public Pair<RenExFileNameDescriptor, Boolean>[] RenameResult { get; private set; }

        public void ApplyRenaming(Pair<RenExFileNameDescriptor, RenExFileNameDescriptor>[] renaming)
        {
            BackgroundWorker bw = new BackgroundWorker {WorkerReportsProgress = true, WorkerSupportsCancellation = true};

            bw.DoWork += (@s, a) =>
                {
                    var scheme = a.Argument as Pair<RenExFileNameDescriptor, RenExFileNameDescriptor>[];

                    if (scheme == null)
                    {
                        a.Result = new Object[] {false, null};
                        return;
                    }


                    var result = new Pair<RenExFileNameDescriptor, Boolean>[scheme.Length];
                    for (int i = 0; i < scheme.Length; i++)
                    {
                        if (bw.CancellationPending) break;

                        try
                        {
                            RenExFileNameDescriptor original = scheme[i].First;
                            RenExFileNameDescriptor destination = scheme[i].Second;

                            int progress = (int) ((double) i / scheme.Length * 100);
                            bw.ReportProgress(progress, original.FileName);

                            if (destination.MarkForDelete)
                            {
                                // Delete the file if it is marked for deletion
                                File.Delete(original.ToString());
                            }
                            else
                            {
                                // Make sure destination dir is there
                                if (!Directory.Exists(destination.Directory))
                                    Directory.CreateDirectory(destination.Directory);

                                // Move file
                                File.Move(original.ToString(), destination.ToString());
                            }
                            // Report success
                            result[i] = new Pair<RenExFileNameDescriptor, Boolean>(original, true);
                        }
                        catch (Exception x)
                        {
                            scheme[i].First.ErrorObject = x;
                            result[i] = new Pair<RenExFileNameDescriptor, Boolean>(scheme[i].First, false);
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
                    RenameResult = (Pair<RenExFileNameDescriptor, Boolean>[]) a.Result;
                    Close();
                };
            bw.RunWorkerAsync(renaming);
        }
    }
}
