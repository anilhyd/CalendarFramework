#region Header Info
//-----------------------------------------------------------------------
// <copyright file="SarasException.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Base Exception class for supporting the range of exceptions.</summary>
// <createdby>Desayya</createdby> 
// <createddate>21-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// Base Exception class for supporting the range of exceptions.
    /// </summary>
    [Serializable]
    public class BDException : System.Exception
    {
        #region Constants
        /// <summary>
        /// Constant string for string formating.
        /// </summary>
        private const string Format = "{0}{1}{2}";
        #endregion

        /// <summary>
        /// ErrorLevel member variable, which holds the level of the specified exception.
        /// </summary>
        private string innerStackTrace;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the SarasException class.
        /// </summary>
        public BDException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SarasException class.
        /// </summary>
        /// <param name="message">Message text describing the exception.</param>
        /// <param name="ex">Inner exception object.</param>
        public BDException(string message, System.Exception ex) : base(message, ex)
        {
            if (ex != null)
            {
                this.innerStackTrace = ex.StackTrace;
                //this.Source = ex.Source;
            }
        }

        /// <summary>
        /// For Sending any required data as collection
        /// </summary>
        public IDictionary DataObject { get; set; }

        /// <summary>
        /// Initializes a new instance of the SarasException class.
        /// </summary>
        /// <param name="message">Message text describing the exception.</param>
        public BDException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SarasException class. object for deserialization.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialiation context.</param>
        protected BDException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            this.innerStackTrace = info.GetString("innerStackTrace");
            this.ErrorCode = info.GetString("ErrorCode");
            this.RowNumber = info.GetInt32("RowNumber");
        }

        // GetObjectData performs a custom serialization.
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Change the case of two properties, and then use the  
            // method of the base class.
            HelpLink = HelpLink.ToLower();
            Source = Source.ToUpper();

            base.GetObjectData(info, context);
        }

        #endregion

        #region StackTrace
        /// <summary>
        /// Get the stack trace from the original
        /// exception.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public override string StackTrace
        {
            get
            {
                return string.Format(Format, this.innerStackTrace, Environment.NewLine, base.StackTrace);
            }
        }
        #endregion

        #region  Properties

        #region Property : ErrorCode
        /// <summary>
        /// Gets or sets the ErrorCode property, returns the errorCode for the error specified.
        /// </summary>
        public string ErrorCode { get; set; }
        #endregion

        #region  Property : RowNumber

        /// <summary>
        /// Gets or sets the Property to set RowNumber.
        /// </summary>         
        public int RowNumber { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the Innser stack trace.
        /// </summary>
        /// 
        internal string InnerStckTrace
        {
            get
            {
                return this.innerStackTrace;
            }

            set
            {
                this.innerStackTrace = value;
            }
        }
        #endregion

        #region Property : ErrorMessage
        /// <summary>
        /// Gets or sets the ErrorCode property, returns the errorCode for the error specified.
        /// </summary>
        public string ErrorMessage { get; set; }
        #endregion
    }
}
