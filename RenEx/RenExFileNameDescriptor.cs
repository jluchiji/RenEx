using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libWyvernzora.IO;

namespace RenEx
{
    /// <summary>
    /// FileNameDescriptor specialized for RenEx.
    /// </summary>
    public class RenExFileNameDescriptor : FileNameDescriptor, IEquatable<FileNameDescriptor>
    {
        /// <summary>
        /// Constructor.
        /// Initializes a new default instance.
        /// </summary>
        internal RenExFileNameDescriptor()
            : base("AAA\\AAA.AAA", 0, null)
        {
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

        /// <summary>
        /// Gets or sets a value indicating whether the file is marked for deletion.
        /// </summary>
        public Boolean MarkForDelete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the renaming rule
        /// has been applied to the descriptor.
        /// </summary>
        public Boolean IsApplied { get; set; }

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
