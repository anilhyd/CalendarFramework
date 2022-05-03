#region Header Info
//-----------------------------------------------------------------------
// <copyright file="FileInfo.cs" company="Excel Soft India Pvt. Ltd.">
//  Copyright (c) Excel Soft India Pvt. Ltd. All rights reserved. Website: http://www.rudhvi.com.
// </copyright>
// <summary>The File class abstracts behavior for uploaded files that are stored in a datastore.</summary>
// <createdby>Desayya</createdby> 
// <createddate>02-April-2012</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Calendar.Framework.FileStorage
{
    /// <summary>
    /// The File class abstracts behavior for uploaded files that are stored in a datastore.
    /// It allows you to save an uploaded file in the datastore and retrieve it again.
    /// </summary>
    public class FileInfo
    {
        /// <summary>
        /// Gets or sets the unique id of the uploaded file.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time the file was uploaded.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the content type of the file.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the original name of the file.
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// Gets or sets whether the file can be encrypted or not.
        /// </summary>
        public bool EncryptFile { get; set; }

        /// <summary>
        /// Gets or sets the Name of the encrypting module.
        /// </summary>
        public string EncryptProviderName { get; set; }

        /// <summary>
        /// Gets or sets the file data.
        /// When this property does not contain data, then <see cref="FileUrl"/> contains
        /// the virtual path to the file starting from the Uploads folder.
        /// </summary>
        public byte[] FileData { get; set; }

        /// <summary>
        /// Gets the url of the file.
        /// </summary>
        public string SavedFilePath { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this instance contains the actual file data.
        /// When ContainsFile is true, it means the actual file is held in <see cref="FileData"></see>.
        /// When ContainsFile is false, then <see cref="FileUrl"></see> contains the virtual path
        /// to the file on disk.
        /// </summary>
        public bool ContainsFile
        {
            get
            {
                return FileData != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        KeyValuePair<string, Object> _parameters = new KeyValuePair<string, object>();

        /// <summary>
        /// 
        /// </summary>
        public KeyValuePair<string, object> Parameters 
        { 
            get
            {
                return _parameters;
            }

            set
            {
                _parameters = value;
            }
        }

    }
}
