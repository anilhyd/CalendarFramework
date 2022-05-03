#region Header Info
//-----------------------------------------------------------------------
// <copyright file="BrokenRuleException.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>This exception is returned from the 
// CallMethod method in the server-side 
// and contains the exception thrown by the
// underlying business object method that was
// being invoked.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Rules;
using System;

#endregion

namespace Calendar.Framework
{
  /// <summary>
  /// This exception is returned from the 
  /// CallMethod method in the server-side 
  /// and contains the exception thrown by the
  /// underlying business object method that was
  /// being invoked.
  /// </summary>
    [Serializable()]
    public class BrokenRuleException : BDException
    {
        #region Constants

        /// <summary>
        /// Local constant string for Innerstacktrace.
        /// </summary>
        private const string LocalInnerStackTrace = "innerStackTrace ";

        /// <summary>
        /// Local constant string for ErrorCode.
        /// </summary>
        private const string LocalErrorCode = "ErrorCode";

        /// <summary>
        /// Local constant string for RowNumber.
        /// </summary>
        private const string LocalRowNumber = "RowNumber";

        /// <summary>
        /// Local constant string for MessageString.
        /// </summary>
        private const string LocalMessageString = "MessageString";

        /// <summary>
        /// Local constant string for Facade.
        /// </summary>
        private const string LocalFacade = "Facade";

        /// <summary>
        /// Local constant string for BrokenRules.
        /// </summary>
        private const string LocalBrokenRules = "BrokenRules";

        /// <summary>
        /// Local constant string for Format.
        /// </summary>
        private const string LocalFormat = "{0}{1}{2}";
        #endregion
        
        #region  Variables
        /// <summary>
        /// ErrorLevel member variable, which holds the level of the specified exception.
        /// </summary>
        private string innerStackTrace;
        #endregion

        #region Exception
        /// <summary>
        /// Initializes a new instance of the BrokenRuleException class.
        /// </summary>
        public BrokenRuleException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BrokenRuleException class.
        /// </summary>
        /// <param name="message">Message text describing the exception.</param>
        /// <param name="ex">Inner exception object.</param>
        public BrokenRuleException(string message, System.Exception ex) : base(message, ex)
        {
            this.innerStackTrace = ex.StackTrace;
        }

        /// <summary>
        ///  Initializes a new instance of the BrokenRuleException class.
        /// </summary>
        /// <param name="message">Message string.</param>
        public BrokenRuleException(string message) : base(message)
        {
        }
        #endregion

        #region Exception
        /// <summary>
        /// Initializes a new instance of the BrokenRuleException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialiation context.</param>
        protected BrokenRuleException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            this.innerStackTrace = info.GetString(LocalInnerStackTrace);
            this.MessageString = info.GetString(LocalMessageString);
            this.ErrorCode = info.GetString(LocalErrorCode);
            this.RowNumber = info.GetInt32(LocalRowNumber);
            this.BrokenRules = (BrokenRulesCollection)info.GetValue(LocalBrokenRules, typeof(BrokenRulesCollection));
        }
        #endregion

        #region  Properties

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
                return string.Format(LocalFormat, this.innerStackTrace, Environment.NewLine, base.StackTrace);
            }
        }
        #endregion

        #region  Property : MessageString
        /// <summary>
        /// Gets or sets Property to set custom message.
        /// </summary>         
        public string MessageString { get; set; }
        #endregion

        #region Property : BrokenRulesCollection
        /// <summary>
        /// Gets or sets the broken rule collection.
        /// </summary>
        public BrokenRulesCollection BrokenRules { get; set; }
        #endregion
        #endregion

        #region GetObjectData
        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(LocalInnerStackTrace, this.innerStackTrace);
            info.AddValue(LocalErrorCode, this.ErrorCode);
            info.AddValue(LocalRowNumber, this.RowNumber);
            info.AddValue(LocalMessageString, this.MessageString);
            info.AddValue(LocalBrokenRules, this.BrokenRules);
        }
        #endregion
    }
}