#region Header Info
//-----------------------------------------------------------------------
// <copyright file="FileStore.cs" company="Excel Soft India Pvt. Ltd.">
//  Copyright (c) Excel Soft India Pvt. Ltd. All rights reserved. Website: http://www.rudhvi.com.
// </copyright>
// <summary>Stores the file into the Windows File System.</summary>
// <createdby>Desayya</createdby> 
// <createddate>03-April-2012</createddate>
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
using System.IO;
using Calendar.Framework.Configuration;

#endregion

namespace Calendar.Framework.FileStorage.WindowsFileSystem
{
    /// <summary>
    /// Stores the file into the Windows File System.
    /// </summary>
    internal class FileStore : FileStorageBase
    {
        FileConfig _fileConfig;
        internal FileStore(FileConfig config)
        {
            _fileConfig = config;
        }
        /// <summary>
        /// Gets a file from the datastore.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal override FileInfo GetFile(Guid id)
        {
            string path = _fileConfig.UploadsFolder + id.ToString();
            return new FileInfo() { FileData = GetFile(path), Id = id };
        }

        /// <summary>
        /// Gets a list with <see cref="FileInfo"></see> instances from the datastore.
        /// </summary>
        /// <returns>A list with <see cref="FileInfo"></see> objects when the datastore contains any files, or null otherwise.</returns>
        internal override List<FileInfo> GetFiles(List<Guid> ids)
        {
            string path = _fileConfig.UploadsFolder;

            List<FileInfo> files = new List<FileInfo>();

            foreach (Guid id in ids)
                files.Add(new FileInfo() { FileData = GetFile(path +  id.ToString()), Id = id });
            
            return files;
        }

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        internal override bool SaveFile(FileInfo file)
        {
            // storing the file on disk.
            const int bufferSize = 1024;
            string path = _fileConfig.UploadsFolder;
            
            // Will Create the directory if not exists.
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            path += file.Id;

            using (System.IO.Stream inputStream = new System.IO.MemoryStream(file.FileData))
            {
                using (System.IO.Stream outputStream = System.IO.File.OpenWrite(path))
                {
                    byte[] buffer = new Byte[bufferSize];
                    int numbytes;
                    while ((numbytes = inputStream.Read(buffer, 0, bufferSize)) > 0)
                    {
                        outputStream.Write(buffer, 0, numbytes);
                    }
                    inputStream.Close();
                    outputStream.Close();
                }
            }

            file.SavedFilePath = path;
            return true;
        }

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        internal override bool SaveFiles(List<FileInfo> files)
        {
            foreach (FileInfo file in files)
            {
                this.SaveFile(file);
            }

            return true;
        }

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal override bool DeleteFile(Guid id)
        {
            string path = _fileConfig.UploadsFolder + id.ToString();
            System.IO.File.Delete(path);
            return true;
        }

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal override bool DeleteFiles(List<Guid> ids)
        {
            foreach(Guid id in ids)
                this.DeleteFile(id);
            
            return true;
        }

        #region Private Methods

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private byte[] GetFile(string fileName)
        {

            byte[] result = null;
            if (File.Exists(fileName))
            {
                using (System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {

                    // attach filestream to binary reader. 

                    System.IO.BinaryReader reader = new System.IO.BinaryReader(fileStream);

                    // get total byte length of the file. 
                    long totalBypes = new System.IO.FileInfo(fileName).Length;

                    result = reader.ReadBytes((Int32)totalBypes);
                    reader.Close();
                }
            }
            return result;
        }

        #endregion
    }
}
