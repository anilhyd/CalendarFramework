#region Header Info
//-----------------------------------------------------------------------
// <copyright file="TransactionalAttribute.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Marks a business method to run within
// the specified transactional context.</summary>
// <createdby>Desayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Utility;
using System;

#endregion

namespace Calendar.Framework
{
  /// <summary>
  /// Marks a business method to run within
  /// the specified transactional context.
  /// </summary>
  /// <remarks>
  /// <para>
  /// Each business object method may be marked with this attribute
  /// to indicate which type of transactional technology should
  /// be used by the Framework. The possible options
  /// are listed in the
  /// <see cref="TransactionalTypes">TransactionalTypes</see> enum.
  /// </para><para>
  /// If the Transactional attribute is not applied to a 
  /// method then the
  /// <see cref="TransactionalTypes.Manual">Manual</see> option
  /// is assumed.
  /// </para><para>
  /// If the Transactional attribute is applied with no explicit
  /// choice for transactionType then the
  /// TransactionScope option is assumed.
  /// </para><para>
  /// Both the EnterpriseServices and TransactionScope options provide
  /// 2-phase distributed transactional support.
  /// </para>
  /// </remarks>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class TransactionalAttribute : Attribute
    {
        /// <summary>
        /// Internal varible for storing the transaction type.
        /// </summary>
        private TransactionalTypes type;

        /// <summary>
        /// Initializes a new instance of the TransactionalAttribute class.
        /// Marks a method to run within a COM+
        /// transactional context.
        /// </summary>
        public TransactionalAttribute()
        {
            this.type = TransactionalTypes.TransactionScope;
        }

        /// <summary>
        /// Initializes a new instance of the TransactionalAttribute class.
        /// Marks a method to run within the specified
        /// type of transactional context.
        /// </summary>
        /// <param name="transactionType">
        /// Specifies the transactional context within which the
        /// method should run.</param>
        public TransactionalAttribute(TransactionalTypes transactionType)
        {
            this.type = transactionType;
        }

        /// <summary>
        /// Gets the type of transaction requested by the
        /// business object method.
        /// </summary>
        public TransactionalTypes TransactionType
        {
            get { return this.type; }
        }
    }
}