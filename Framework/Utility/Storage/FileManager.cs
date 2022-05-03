#region Header Info
//-----------------------------------------------------------------------
// <copyright file="FileManager.cs" company="Excel Soft India Pvt. Ltd.">
//  Copyright (c) Excel Soft India Pvt. Ltd. All rights reserved. Website: http://www.rudhvi.com.
// </copyright>
// <summary>Manager used to create the appropriate File provider by using configuration.</summary>
// <createdby>Desayya</createdby> 
// <createddate>03-April-2012</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Calendar.Framework.FileStorage
{
    /// <summary>
    /// Manager used to create the appropriate File provider by using configuration.
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Readonly Cache Interface.
        /// </summary>
        private static readonly Dictionary<string, FileStorageBase> fileProviders = new Dictionary<string, FileStorageBase>();
        #region Properties

        /// <summary>
        /// Gets the Cache provider.
        /// </summary>
        //private static FileStorageBase FileProvider
        //{
        //    get
        //    {
        //        string organizationId = default(string);
        //        if (SAF.Core.ApplicationContext.UserContext == null || SAF.Core.ApplicationContext.UserContext.OrganizationID == null || SAF.Core.ApplicationContext.UserContext.OrganizationID.Equals(default(string)))
        //            organizationId = SAF.Common.UtilityManager.OrganizationKey;
        //        else
        //            organizationId = SAF.Core.ApplicationContext.UserContext.OrganizationID;

        //        if (fileProviders.ContainsKey(organizationId))
        //            return fileProviders[organizationId];
        //        else
        //        {
        //            return GetFileProvider(organizationId);
        //        }
        //    }
        //}
        #endregion

        #region Static GetFileProvider

        /// <summary>
        /// Initializes static members of the <see cref="CacheManager"/> class.
        /// </summary>
        /// <param name="organizationkey">Organizaiton Key.</param>
        /// <returns>Returns Cache Object.</returns>
        private static FileStorageBase GetFileProvider(string organizationkey, string providername, FileConfig config)
        {
            FileStorageBase provider = null;
            if (fileProviders.ContainsKey(organizationkey))
                provider = fileProviders[organizationkey];
            else {
                switch (providername)
                {
                    case "WindowsFileStorage":
                        provider = new WindowsFileSystem.FileStore(config);
                        break;

                    //case "AzureBlobStorage":
                    //    provider = new AzureBlob.FileStore();
                    //    break;

                    case "AmazonS3storage":
                        provider = new AmazonS3.FileStore(config);
                        break;

                    case "FTPStorage":
                        provider = new Calendar.Framework.FileStorage.FTP.FileStore(config);
                        break;

                    //case "DatabaseStorage":
                    //    provider = new Database.FileStore();
                    //    break;

                    //case "CMSStorage":
                    //    provider = new CMS.FileStore();
                    //    break;

                    default:
                        // Write code here using reflection
                        break;
                }
            }

            fileProviders.Add(organizationkey, provider);

            return provider;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a file from the datastore.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        public static FileInfo GetFile(FileInfo file, string provider, FileConfig config)
        {
           return Decrypt(GetFileProvider(file.OriginalName, provider, config).GetFile(file.Id));
        }

        /// <summary>
        /// Gets a list with <see cref="FileInfo"></see> instances from the datastore.
        /// </summary>
        /// <returns>A list with <see cref="FileInfo"></see> objects when the datastore contains any files, or null otherwise.</returns>
        public static List<FileInfo> GetFiles(List<FileInfo> files, string provider, FileConfig config)
        {
            List<FileInfo> fileinfos = new List<FileInfo>();
            
            foreach (FileInfo file in files)
                fileinfos.Add(Decrypt(GetFileProvider(file.OriginalName, provider, config).GetFile(file.Id)));
            
            return fileinfos;
        }

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        public static bool SaveFile(FileInfo file, string provider, FileConfig config)
        {
            return GetFileProvider(file.OriginalName, provider, config).SaveFile(Encrypt(file));
        }

        /// <summary>
        /// Saves a file to the datastore. Depending on the configured provider, the actual file is saved on disk or in the datastore.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        public static bool SaveFiles(List<FileInfo> files, string provider, FileConfig config)
        {
            bool result = false;
            if (files.Count > 0)
            {
                foreach (FileInfo file in files)
                    Encrypt(file);

                result = GetFileProvider(files[0].OriginalName, provider, config).SaveFiles(files);
            }
            return result;
        }

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        public static bool DeleteFile(FileInfo file, string provider, FileConfig config)
        {
            return GetFileProvider(file.OriginalName, provider, config).DeleteFile(file.Id);
        }

        /// <summary>
        /// Deletes a files from the datastore.  Depending on the configured provider, the file is deleted from disk as well.
        /// </summary>
        /// <param name="id">The ID of the file in the database.</param>
        public static bool DeleteFiles(List<FileInfo> files, string provider, FileConfig config)
        {
            bool result = false;

            if (files.Count > 0)
            {
                List<Guid> ids = new List<Guid>();
                foreach (FileInfo file in files)
                    ids.Add(file.Id);
                result =  GetFileProvider(files[0].OriginalName, provider, config).DeleteFiles(ids);
            }
            return result;
        }


        private static FileInfo Encrypt(FileInfo file)
        {
            if (file.EncryptFile)
            {
                if(string.IsNullOrEmpty(file.EncryptProviderName))
                {
                    // Write code here for instantiate the Encrypt provider and call
                    // the  method.
                }
            }

            return file;
        }

        private static FileInfo Decrypt(FileInfo file)
        {
            if (file.EncryptFile)
            {
                if (string.IsNullOrEmpty(file.EncryptProviderName))
                {
                    // Write code here for instantiate the Decrypt provider and call
                    // the  method.
                }
            }

            return file;
        }
        #endregion
    }
}
