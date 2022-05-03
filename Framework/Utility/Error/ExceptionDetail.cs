#region Header Info
//-----------------------------------------------------------------------
// <copyright file="ExceptionDetail.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>ExceptionDetail object which contains the Exception details.</summary>
// <createdby>Desayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;

#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Serializable]
    public class ExceptionDetail
    {
        /// <summary>
        /// Default Contstructor.
        /// </summary>
        public ExceptionDetail()
        { 
        }

        /// <summary>
        /// Constructor for assigning the exection data.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ColumnName"></param>
        /// <param name="message"></param>
        public ExceptionDetail(string Id, string ColumnName, string Message)
        {
            this.Id = Id;
            this.ColumnName = ColumnName;
            this.Message = Message;
        }

        /// <summary>
        /// Gets or sets the Id value.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Column Name.
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        public string Message { get; set; }
    }
}
