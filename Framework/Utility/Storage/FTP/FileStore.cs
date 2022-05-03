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
using System.Net;
using System.IO;
using Calendar.Framework.Configuration;

#endregion

namespace Calendar.Framework.FileStorage.FTP
{
    /// <summary>
    /// TODO: Update summary.
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
            FtpWebRequest request = this.GetRequest(id.ToString());
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FileInfo file = new FileInfo() {Id = id };

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            file.FileData = memoryStream.ToArray(); 
            return file;
        }

        /// <summary>
        /// Gets a list with <see cref="FileInfo"></see> instances from the datastore.
        /// </summary>
        /// <returns>A list with <see cref="FileInfo"></see> objects when the datastore contains any files, or null otherwise.</returns>
        internal override List<FileInfo> GetFiles(List<Guid> ids)
        {
            List<FileInfo> files = new List<FileInfo>();
            foreach (Guid id in ids)
                files.Add(this.GetFile(id));

            return files;
        }

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        internal override bool SaveFile(FileInfo file)
        {
            FtpWebRequest request = this.GetRequest(file.Id.ToString());
            request.Method = WebRequestMethods.Ftp.UploadFile;
            
            request.ContentLength = file.FileData.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(file.FileData, 0, file.FileData.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();

            return true;
        }

        /// <summary>
        /// Creates and returns the FTP Web Request.
        /// </summary>
        /// <returns>Returns FtpWebRequest object.</returns>
        private FtpWebRequest GetRequest(string filename)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_fileConfig.ConnectionName + filename);
            request.Proxy = null;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(_fileConfig.UserId, _fileConfig.Password);
            return request;
        }

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        internal override bool SaveFiles(List<FileInfo> files)
        {
            foreach (FileInfo file in files)
                this.SaveFile(file);
            
            return true;
        }

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal override bool DeleteFile(Guid id)
        {
            FtpWebRequest request = this.GetRequest(id.ToString());
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            return true;
        }

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal override bool DeleteFiles(List<Guid> ids)
        {
            foreach (Guid id in ids)
                this.DeleteFile(id);

            return true;
        }

    }
}