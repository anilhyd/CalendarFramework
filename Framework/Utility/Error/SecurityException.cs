#region Header Info
//-----------------------------------------------------------------------
// <copyright file="InvalidCredentialException.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Raises when credentials are wrong sent by user/caller.</summary>
// <createdby>Desayya</createdby> 
// <createddate>7-Nov-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// Raises when credentials are wrong sent by user/caller.
    /// </summary>
    [Serializable]
    public class SecurityException : BDException
    {
        /// <summary>
        /// Local constant for Error Code Name.
        /// </summary>
        private const string Errorcode = "S001";

        /// <summary>
        /// Local varible will hold inner stack trace of the exception.
        /// </summary>
        private string innerStackTrace;

        /// <summary>
        /// Initializes a new instance of the SecurityException class.
        /// </summary>
        /// <param name="message">Message text describing the exception.</param>
        /// <param name="ex">Inner exception object.</param>
        public SecurityException(string message, System.Exception ex)
            : base(message, ex)
        {
            this.ErrorCode = Errorcode;

            if (ex != null)
                this.innerStackTrace = ex.StackTrace;
        }

#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new instance of the SecurityException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialiation context.</param>
        protected SecurityException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            this.ErrorCode = Errorcode;
            this.innerStackTrace = info.GetString("innerStackTrace");
        }
#endif
        /// <summary>
        /// Get the stack trace from the original exception.
        /// </summary>
        public override string StackTrace
        {
            get
            {
                return string.Format("{0}{1}{2}", this.innerStackTrace, Environment.NewLine, base.StackTrace);
            }
        }

        #if !SILVERLIGHT
        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("innerStackTrace", this.innerStackTrace);
        }
        #endif
    }
}
