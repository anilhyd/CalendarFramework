#region Header Info
//-----------------------------------------------------------------------
// <copyright file="FileStorageBase.cs" company="Excel Soft India Pvt. Ltd.">
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
    /// Abstract clas which contains the functionality for implementing the fIle provider
    /// </summary>
    internal abstract class FileStorageBase
    {
        /// <summary>
        /// Gets or sets the configured Uploads folder when the provider stores files on disk. Returns null otherwise.
        /// </summary>
        internal virtual string UploadsFolder { get; set; }

        /// <summary>
        /// Gets a file from the datastore.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal abstract FileInfo GetFile(Guid id);

        /// <summary>
        /// Gets a list with <see cref="FileInfo"></see> instances from the datastore.
        /// </summary>
        /// <returns>A list with <see cref="FileInfo"></see> objects when the datastore contains any files, or null otherwise.</returns>
        internal abstract List<FileInfo> GetFiles(List<Guid> ids);

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        internal abstract bool SaveFile(FileInfo file);

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        internal abstract bool SaveFiles(List<FileInfo> files);

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal abstract bool DeleteFile(Guid id);

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal abstract bool DeleteFiles(List<Guid> ids);
    }
}
