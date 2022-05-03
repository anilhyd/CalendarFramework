#region Header Info
//-----------------------------------------------------------------------
// <copyright file="LogColumnAttribute.cs" company="Calendar.Framework">
// Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Marks business method with the list of Column Name attribute for accessing the data from the object.</summary>
// <createdby>Desayya</createdby> 
// <createddate>17-March-2011</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;

#endregion
namespace Calendar.Framework
{
    /// <summary>
    /// Marks business method with the list of Column Name attribute
    /// for accessing the data from the object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple= true)]
    public class LogColumnAttribute : Attribute
    {
        /// <summary>
        /// Internal variable for storing the MessageCode.
        /// </summary>
        private string columnName = string.Empty;

        /// <summary>
        /// Initializes a new instance of the LogMessageCodeAttribute class.
        /// </summary>
        /// <param name="code">Resource code for the Message.</param>
        public LogColumnAttribute(string column)
        {
            this.columnName = column;
        }

        /// <summary>
        /// Gets a value for Message Code.
        /// </summary>
        public string ColumnName
        {
            get
            {
                return this.columnName;
            }
        }
    }
}
