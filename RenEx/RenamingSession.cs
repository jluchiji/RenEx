using System;
using System.Collections.Generic;
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
            foreach (var p in paths)
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

        #region Preview & Applying Renaming

        public void UpdatePreview(Configuration.ExtensionConfig config)
        {
            // Clear result map
            results.Clear();

            // Update Preview
            foreach (var f in files.Values.Where(f => !f.State.HasFlag(RenExFileNameDescriptor.RenameState.Applied) || f.State.HasFlag(RenExFileNameDescriptor.RenameState.Error)))
            {
                // Update Rule
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
