#region Header Info
//-----------------------------------------------------------------------
// <copyright file="LogMessageCodeAttribute.cs" company="Calendar.Framework">
// Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Marks business method with MessgeCode attribute for getting the messsage string from resouece file.</summary>
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
    /// Marks business method with MessgeCode attribute for getting the messsage string from resouece file.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class LogMessageCodeAttribute : Attribute
    {
        /// <summary>
        /// Internal variable for storing the MessageCode.
        /// </summary>
        private string messageCode = string.Empty;

        /// <summary>
        /// Internal variable for storing the MessageCode.
        /// </summary>
        private string messageTitle = string.Empty;

        /// <summary>
        /// Initializes a new instance of the LogMessageCodeAttribute class.
        /// </summary>
        /// <param name="code">Resource code for the Message.</param>
        public LogMessageCodeAttribute(string code)
        {
            this.messageCode = code;
        }

        /// <summary>
        /// Initializes a new instance of the LogMessageCodeAttribute class.
        /// </summary>
        /// <param name="code">Resource code for the Message.</param>
        /// <param name="messageTitle">Title of the message</param>
        public LogMessageCodeAttribute(string code, string messageTitle)
        {
            this.messageCode = code;
            this.messageTitle = messageTitle;
        }

        /// <summary>
        /// Gets a value for Message Code.
        /// </summary>
        public string MessageTitle
        {
            get
            {
                return this.messageTitle;
            }
        }

        /// <summary>
        /// Gets a value for Message Code.
        /// </summary>
        public string MessageCode
        {
            get
            {
                return this.messageCode;
            }
        }
    }
}
