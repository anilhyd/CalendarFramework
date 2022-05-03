#region Header Info
//-----------------------------------------------------------------------
// <copyright file="FeatureMetadata.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Provides the attributes for Feature metadata enttiy.</summary>
// <createdby>Kasi P</createdby> 
// <createddate>19-July-2011</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// Provides the attributes for Feature metadata enttiy.
    /// </summary>
    internal class FeatureMetadata
    {
        /// <summary>
        /// Gets or sets table name value.
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets Module Name value.
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Gets or sets Field name value.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets SequenceNo value.
        /// </summary>
        public short SequenceNo { get; set; }
    }
}
