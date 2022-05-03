#region Header Info
//-----------------------------------------------------------------------
// <copyright file="CallMethodException.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Excpetion class for Method.</summary>
// <createdby>Desayya</createdby> 
// <createddate>11-July-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Security.Permissions;

#if SILVERLIGHT
using Csla.Serialization;
#endif

#endregion

namespace Calendar.Framework.Runtime
{
  /// <summary>
  /// This exception is returned from the 
  /// CallMethod method in the server-side DataPortal
  /// and contains the exception thrown by the
  /// underlying business object method that was
  /// being invoked.
  /// </summary>
  [Serializable()]
  public class CallMethodException : BDException
  {
      #region Constants
      /// <summary>
      /// Local Constant string for InnerStackTrace.
      /// </summary>
      private const string InnerStackTrace = "innerStackTrace";

      /// <summary>
      /// Local Constant string for Formated string.
      /// </summary>
      private const string Format = "{0}{1}{2}";
      #endregion
      /// <summary>
      /// Initializes a new instance of the CallMethodException class..
      /// </summary>
      /// <param name="message">Message text describing the exception.</param>
      /// <param name="ex">Inner exception object.</param>
      public CallMethodException(string message, System.Exception ex)
          : base(message, ex)
      {
      }

#if !SILVERLIGHT
      /// <summary>
      /// Initializes a new instance of the CallMethodException class. Creates an instance of the object for deserialization.
      /// </summary>
      /// <param name="info">Serialization info.</param>
      /// <param name="context">Serialiation context.</param>
      protected CallMethodException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
      {
          this.InnerStckTrace = info.GetString(InnerStackTrace);
      } 
#endif

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
          return string.Format(Format, this.InnerStckTrace, Environment.NewLine, base.StackTrace);
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
      info.AddValue(InnerStackTrace, this.InnerStckTrace);
    }
#endif
  }
}