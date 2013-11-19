using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libWyvernzora.IO;

namespace RenEx
{
    /// <summary>
    /// FileNameDescriptor specialized for RenEx.
    /// Stores the original file name and the renaming outcome.
    /// </summary>
    public class RenExFileNameDescriptor : FileNameDescriptor, IEquatable<FileNameDescriptor>
    {
        #region Nested Types

        [Flags]
        public enum RenameState
        {
            None = 0,
            Preview = 1,
            Applied = 2,
            Error = 4,
            Warning = 8
        }

        #endregion

        private readonly String path;
        
        /// <summary>
        /// Constructor.
        /// Creates a copy of another FileNameDescriptor instance.
        /// </summary>
        public RenExFileNameDescriptor(FileNameDescriptor descriptor)
        {
            path = descriptor.ToString();

            Directory = descriptor.Directory;
            FileName = descriptor.FileName;
            Extensions = descriptor.Extensions;

            MarkForDelete = false;
            ErrorObject = null;
        }

        /// <summary>
        /// Constructor.
        /// Initializes a new instance.
        /// </summary>
        /// <param name="path">File path to analyze.</param>
        /// <param name="config">Extension configuration.</param>
        public RenExFileNameDescriptor(string path, Configuration.ExtensionConfig config)
            : base(path, config.MaximumExtensions, config.Validator)
        {
            this.path = path;
        }

        #region Rule changes and Refresh

        /// <summary>
        /// Changes analysis rules and refreshes the descriptor.
        /// </summary>
        /// <param name="config">New comfiguration.</param>
        public void ChangeRule(Configuration.ExtensionConfig config)
        {
            AnalyzeFilePath(path, config.MaximumExtensions, config.Validator);
        }

        #endregion

        #region Transformed File Names

        private String transformedDirectory;
        private String transformedFileName;
        private String transformedExtensions;

        /// <summary>
        /// Gets or sets the directory component after transformation.
        /// </summary>
        public String TransformedDirectory
        {
            get { return transformedDirectory ?? Directory; }
            set { transformedDirectory = value; }
        }

        /// <summary>
        /// Gets or sets the file name component after the transformation.
        /// </summary>
        public String TransformedFileName
        {
            get { return transformedFileName ?? FileName; }
            set { transformedFileName = value; }
        }

        /// <summary>
        /// Gets or sets the extension component after the transformation.
        /// </summary>
        public String TransformedExtensions
        {
            get { return transformedExtensions ?? Extensions; }
            set { transformedExtensions = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the file is marked for deletion.
        /// </summary>
        public Boolean MarkForDelete { get; set; }

        /// <summary>
        /// Gets the file path after transformation.
        /// </summary>
        public String TransformedFilePath
        {get { return TransformedDirectory + "\\" + TransformedFileName + TransformedExtensions; }}

        /// <summary>
        /// Gets a value indicating whether the file descriptor was modified.
        /// </summary>
        public Boolean IsTransformed
        { get { return !StringComparer.CurrentCultureIgnoreCase.Equals(ToString(), TransformedFilePath); } }

        /// <summary>
        /// Clears all transformations made and restores the original file name.
        /// </summary>
        public void ClearTransformations()
        {
            MarkForDelete = false;
            transformedDirectory = null;
            transformedExtensions = null;
            transformedFileName = null;
        }

        #endregion

        /// <summary>
        /// Gets or sets the renaming state of the descriptor.
        /// </summary>
        public RenameState State { get; set; }

        /// <summary>
        /// Gets or sets the Exception object associated to the transforming process.
        /// The value is null if no error occured.
        /// </summary>
        public Exception ErrorObject { get; set; }

        public bool Equals(FileNameDescriptor other)
        {
            return StringComparer.CurrentCultureIgnoreCase.Equals(this.ToString(), other.ToString());
        }
    }
}
