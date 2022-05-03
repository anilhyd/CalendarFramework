#region Header Info
//-----------------------------------------------------------------------
// <copyright file="CriteriaField.cs" company="Excel Soft India Pvt. Ltd.">
//  Copyright (c) Excel Soft India Pvt. Ltd. All rights reserved. Website: http://www.excelindia.com.
// </copyright>
// <summary>Holds the criteria information.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>17-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BD.Framework.Utility;

#endregion

namespace BD.Framework.CoreFramework.Filter
{
    [DataContract(IsReference = true)]
    [Serializable]
    /// <summary>
    /// Object carries the filtering data.
    /// </summary>
    public class CriteriaField
    {
        [DataMember]
        /// <summary>
        /// Gets or sets the Column Name.
        /// </summary>
        public string FieldName { get; set; }

        [DataMember]
        /// <summary>
        /// Gets or sets the Value of the Column.
        /// </summary>
        public object Value { get; set; }

        [DataMember]
        /// <summary>
        /// Gets or sets the Value of the Column.
        /// </summary>
        public object Value2 { get; set; }

        [DataMember]
        /// <summary>
        /// Gets or sets the DataType of the Column.
        /// </summary>
        public DataType DataType { get; set; }

        [DataMember]
        /// <summary>
        /// Gets or sets the Operater.
        /// </summary>
        public Operator Operator { get; set; }

        [DataMember]
        /// <summary>
        /// Gets or sets the Condition for building the where query.
        /// </summary>
        public Condition Condition { get; set; }
    }
}
  