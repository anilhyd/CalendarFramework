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
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using Calendar.Framework.Configuration;
using Amazon;

#endregion

namespace Calendar.Framework.FileStorage.AmazonS3
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal class FileStore : FileStorageBase
    {
        FileConfig _fileConfig;
        public FileStore(FileConfig config) 
        {
            _fileConfig = config;
        }

        /// <summary>
        /// Gets a file from the datastore.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal override FileInfo GetFile(Guid id)
        {
            ListObjectsRequest request = new ListObjectsRequest
            {
                BucketName = _fileConfig.BucketName,
                Prefix = "EmployeeImages/" + id         
            };
            FileInfo file = new FileInfo() { Id = id };

            using (var client = new AmazonS3Client(_fileConfig.AccessKey, _fileConfig.SecretKey, RegionEndpoint.GetBySystemName(_fileConfig.Region)))
            {
                ListObjectsResponse response = client.ListObjectsAsync(request).Result;
                if (response.S3Objects.Count > 0)
                {
                    var objres = client.GetObjectAsync(new GetObjectRequest { BucketName = _fileConfig.BucketName, Key = response.S3Objects[0].Key }).Result;
                    var bytes = new byte[objres.ResponseStream.Length];
                    objres.ResponseStream.Read(bytes, 0, bytes.Length);

                    file.FileData = bytes;
                }
            }
           
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
            using (var client = new AmazonS3Client(_fileConfig.AccessKey, _fileConfig.SecretKey, RegionEndpoint.GetBySystemName(_fileConfig.Region)))
            {
                var photoRequest = new PutObjectRequest
                {
                    BucketName = _fileConfig.BucketName,
                    Key = "EmployeeImages/" + file.Id.ToString(),
                    InputStream = new MemoryStream(file.FileData),
                    ContentType = "application/x-binary",
                    AutoCloseStream = true
                };
                var ires = client.PutObjectAsync(photoRequest).Result;
            }
            return true;
        }

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        internal override bool SaveFiles(List<FileInfo> files)
        {
            using (var client = new AmazonS3Client(_fileConfig.AccessKey, _fileConfig.SecretKey, RegionEndpoint.GetBySystemName(_fileConfig.Region)))
            {

                foreach (FileInfo file in files)
                {
                    var photoRequest = new PutObjectRequest
                    {
                        BucketName = _fileConfig.BucketName,
                        Key = "EmployeeImages/" + file.Id.ToString(),
                        InputStream = new MemoryStream(file.FileData),
                        ContentType = "application/x-binary",
                        AutoCloseStream = true
                    };
                    var ires = client.PutObjectAsync(photoRequest).Result;
                }
            }
            return true;
        }

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        internal override bool DeleteFile(Guid id)
        {
            //using (AmazonS3Client s3Client = new AmazonS3Client())
            //{
            //    using (DeleteObjectResponse response = s3Client.DeleteObject(request))
            //    {
            //    }
            //}
            return true;
        }

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="ids">List ids to be deleted from the amazon s3</param>
        /// <returns>Return True/False</returns>
        internal override bool DeleteFiles(List<Guid> ids)
        {
            foreach (Guid id in ids)
                DeleteFile(id);

            return true;
        }
    }
}