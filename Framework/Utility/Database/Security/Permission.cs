#region Header Info
//-----------------------------------------------------------------------
// <copyright file="Permission.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Entity class will provide the Permissions associated to the feature.</summary>
// <createdby>Desayya</createdby> 
// <createddate>23-May-2011</createddate>
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

namespace Calendar.Framework.Security
{
    /// <summary>
    /// Entity class will provide the Permissions associated to the feature.
    /// </summary>
    [Serializable]
    public class Permission
    {
        /// <summary>
        /// Gets the Permission name.
        /// </summary>
        public string PermissionName { get; internal set; }
        
        /// <summary>
        /// Gets the Access Level value.
        /// </summary>
        public int AccessLevel { get; internal set; }

        /// <summary>
        /// Gets the AccessLevel Name.
        /// </summary>
        public string AccessLevelName { get; internal set; }
    }
}
