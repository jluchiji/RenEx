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
            Error = 4
        }

        #endregion
        
        /// <summary>
        /// Constructor.
        /// Creates a copy of another FileNameDescriptor instance.
        /// </summary>
        public RenExFileNameDescriptor(FileNameDescriptor descriptor)
        {
            Directory = descriptor.Directory;
            FileName = descriptor.FileName;
            Extensions = descriptor.Extensions;

            MarkForDelete = false;
            IsApplied = false;
            ErrorObject = null;
        }

        /// <summary>
        /// Constructor.
        /// Initializes a new instance.
        /// </summary>
        /// <param name="path">File path to analyze.</param>
        /// <param name="maxExt">Maximum </param>
        /// <param name="validator"></param>
        public RenExFileNameDescriptor(string path, int maxExt = 2, IFileExtValidator validator = null)
            : base(path, maxExt, validator)
        { }
        
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

        #endregion

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
