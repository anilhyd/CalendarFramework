#region Header Info
//-----------------------------------------------------------------------
// <copyright file="FileEncryptBase.cs" company="Excel Soft India Pvt. Ltd.">
//  Copyright (c) Excel Soft India Pvt. Ltd. All rights reserved. Website: http://www.rudhvi.com.
// </copyright>
// <summary>The File class abstracts behavior for uploaded files that are stored in a datastore.</summary>
// <createdby>Desayya</createdby> 
// <createddate>31-May-2012</createddate>
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
    /// Abstract method for encrypting the File.
    /// </summary>
    public abstract class FileEncryptBase
    {
        /// <summary>
        /// Encrypts the stream by applying the custom encrypt.
        /// </summary>
        /// <param name="fileData">Data to be encrypted.</param>
        /// <returns>Returns Encrypted Byte[] data.</returns>
        public abstract byte[] EncryptFile(byte[] fileData);

        /// <summary>
        /// Decrypt the stream by applying the custom encrypt.
        /// </summary>
        /// <param name="fileData">Data to be decrypted.</param>
        /// <returns>Returns Decrypted Byte[] data.</returns>
        public abstract byte[] DecryptFile(byte[] fileData);
    }
}
