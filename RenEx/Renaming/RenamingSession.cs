using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using libWyvernzora.Core;
using libWyvernzora.Collections;

namespace RenEx
{
    /// <summary>
    /// Renaming session with all the variables contained in it.
    /// </summary>
    public class RenamingSession : IEnumerable<RenExFileNameDescriptor>
    {
        // Temporary maps ONLY for determining duplicates
        private Dictionary<String, RenExFileNameDescriptor> results; 

        // File List
        private Dictionary<String, RenExFileNameDescriptor> files;


        /// <summary>
        /// Constructor.
        /// Initializes a new instance.
        /// </summary>
        public RenamingSession()
        {
            files = new Dictionary<string, RenExFileNameDescriptor>(StringComparer.CurrentCultureIgnoreCase);
            results = new Dictionary<string, RenExFileNameDescriptor>(StringComparer.CurrentCultureIgnoreCase);

            Rules = new RenamingRuleCollection();
        }


        #region Properties

        /// <summary>
        /// Gets the rule collection for the session.
        /// </summary>
        public RenamingRuleCollection Rules
        { get; private set; }

        #endregion

        #region File Management

        /// <summary>
        /// Adds a file to the session.
        /// </summary>
        /// <param name="path">Original file path.</param>
        public void AddFile(String path)
        {
            // Skip file if it is already in the files list
            if (files.ContainsKey(path))
                return;

            // Add File
            var extConfig = Configuration.Instance.GetCurrentExtensionSettings();
            files.Add(path, new RenExFileNameDescriptor(path, extConfig));
        }

        /// <summary>
        /// Adds a collection of files to the session.
        /// </summary>
        /// <param name="paths">Original file paths.</param>
        public void AddFile(IEnumerable<String> paths)
        {
            foreach (var p in paths)
                AddFile(p);
        }

        /// <summary>
        /// Removes a file from the session.
        /// </summary>
        /// <param name="path">Original file path.</param>
        public void RemoveFile(String path)
        {
            if (files.ContainsKey(path))
                files.Remove(path);
        }

        /// <summary>
        /// Removes files from the session.
        /// </summary>
        /// <param name="paths">Original file paths.</param>
        public void RemoveFiles(IEnumerable<String> paths)
        {
            foreach (var p in paths.ToArray())
                RemoveFile(p);
        }

        /// <summary>
        /// Removes renames that have been applied without errors.
        /// </summary>
        public void RemoveApplied()
        {
            var keys = from f in files.Values
                       where
                           f.State.HasFlag(RenExFileNameDescriptor.RenameState.Applied) &&
                           !f.State.HasFlag(RenExFileNameDescriptor.RenameState.Error)
                       select f.ToString();
            RemoveFiles(keys);
        }

        /// <summary>
        /// Clears all files from the session.
        /// </summary>
        public void Clear()
        {
            results.Clear();
            files.Clear();
            Rules.DirectoryRules.Clear();
            Rules.ExtensionRules.Clear();
            Rules.NameRules.Clear();
        }

        #endregion

        #region Error & Warning Detection

        /// <summary>
        /// Gets a value indicating whether there are warnings in the session.
        /// </summary>
        public Boolean HasWarnings
        {
            get
            {
                return
                    (from f in files.Values where f.State.HasFlag(RenExFileNameDescriptor.RenameState.Warning) select f)
                        .Any();
            }
        }

        /// <summary>
        /// Gets a value indicating whether there are errors in the session.
        /// </summary>
        public Boolean HasErrors
        {
            get
            {
                return
                    (from f in files.Values where f.State.HasFlag(RenExFileNameDescriptor.RenameState.Error) select f)
                        .Any();
            }
        } 

        #endregion

        #region Preview & Applying Renaming

        public void UpdatePreview(Configuration.ExtensionConfig config)
        {
            // Clear result map
            results.Clear();

            // Update Preview
            foreach (var f in files.Values.Where(f => !f.State.HasFlag(RenExFileNameDescriptor.RenameState.Applied) || f.State.HasFlag(RenExFileNameDescriptor.RenameState.Error)))
            {
                // Update Rule
                if (config != null)
                    f.ChangeRule(config);

                // Clear Error Object
                f.ErrorObject = null;
                f.State = RenExFileNameDescriptor.RenameState.Preview;

                // Apply Rules
                Rules.TransformSingle(f);

                // Add to result map and check to redundancy
                if (results.ContainsKey(f.TransformedFilePath))
                {
                    // Duplicate! Warn user.
                    f.State |= RenExFileNameDescriptor.RenameState.Warning;
                    f.ErrorObject = new Exception("Current rule set results in duplicate results.");
                } else results.Add(f.TransformedFilePath, f);
            }
        }

        public void ApplyRenaming(Action<Int32, String> progress = null)
        {
            // Update Preview
            UpdatePreview(null);

            // Create a copy of files
            RenExFileNameDescriptor[] tempFiles = files.Values.ToArray();

            for (int i = 0; i < tempFiles.Length; i++)
            {
                try
                {
                    var f = tempFiles[i];

                    // Skip if the file was applied without errors
                    if (f.State.HasFlag(RenExFileNameDescriptor.RenameState.Applied) &&
                        !f.State.HasFlag(RenExFileNameDescriptor.RenameState.Error))
                        continue;

                    // Mark as applied
                    f.State = RenExFileNameDescriptor.RenameState.Applied;  // Mark as applied

                    // Apply Renaming
                    if (f.MarkForDelete) 
                        File.Delete(f.ToString());  // Delete file if it was marked for delete
                    else if (f.IsTransformed)
                        File.Move(f.ToString(), f.TransformedFilePath);     // Rename the file if it was changed

                    // Report Progress
                    Int32 p = (Int32) ((i * 100.0) / tempFiles.Length);
                    if (progress != null)
                        progress(p, f.FileName);
                }
                catch (Exception x)
                {
                    tempFiles[i].State |= RenExFileNameDescriptor.RenameState.Error;
                    tempFiles[i].ErrorObject = x;
                }
            }
        }

        #endregion


        public IEnumerator<RenExFileNameDescriptor> GetEnumerator()
        {
            return files.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return files.Values.GetEnumerator();
        }
    }
}
