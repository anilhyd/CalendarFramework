#region Header Info
//-----------------------------------------------------------------------
// <copyright file="InvalidPermissionException.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Raises when user don't have permission to execute the calling method.</summary>
// <createdby>Desayya</createdby> 
// <createddate>7-Nov-2010</createddate>
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
    /// Raises when user don't have permission to execute the calling method.
    /// </summary>
    [Serializable]
    public class LoginException : SecurityException
    {
        /// <summary>
        /// Local constant for Error Code Name.
        /// </summary>
        private const string ConstantErrorCode = "S003";

        /// <summary>
        /// Local varible will hold inner stack trace of the exception.
        /// </summary>
        private string innerStackTrace;

        /// <summary>
        /// Initializes a new instance of the LoginException class.
        /// </summary>
        /// <param name="message">Message text describing the exception.</param>
        /// <param name="ex">Inner exception object.</param>
        public LoginException(string message, System.Exception ex)
            : base(message, ex)
        {
            this.ErrorCode = ConstantErrorCode;
            if (ex != null)
                this.innerStackTrace = ex.StackTrace;
        }

#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new instance of the LoginException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialiation context.</param>
        protected LoginException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            this.ErrorCode = ConstantErrorCode;
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
