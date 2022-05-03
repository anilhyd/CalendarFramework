#region Header Info
//-----------------------------------------------------------------------
// <copyright file="Feature.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Entity class will provide the Feature properties.</summary>
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
    /// Entity class will provide the Feature properties.
    /// </summary>
    [Serializable]
    public class Feature
    {
        /// <summary>
        /// Local Variable for storing the permisssions.
        /// </summary>
        private List<Permission> permissions = null;

        /// <summary>
        /// Local variable for storing the misc permissions.
        /// </summary>
        private List<Permission> miscPermissions = null;
        
        /// <summary>
        /// Gets the Feature Id.
        /// </summary>
        public string FeatureId { get; internal set; }

        /// <summary>
        /// Gets the Feature Code.
        /// </summary>
        public string FeatureCode { get; internal set; }
        
        /// <summary>
        /// Gets the Feature Name.
        /// </summary>
        public string FeatureName { get; internal set; }
        
        /// <summary>
        /// Gets the Object Security Applicable or not to the feature.
        /// </summary>
        public bool IsObjectSecurityApplicable { get; internal set; }

        /// <summary>
        /// Gets the perimissions associated to the feature.
        /// </summary>
        public List<Permission> Permissions 
        {
            get
            {
                if (permissions == null)
                    permissions = new List<Permission>();

                return permissions;
            }

            internal set
            {
                permissions = value;
            }
        }

        /// <summary>
        /// Gets the perimissions associated to the feature.
        /// </summary>
        public List<Permission> MiscPermissions
        {
            get
            {
                if (miscPermissions == null)
                    miscPermissions = new List<Permission>();

                return miscPermissions;
            }

            internal set
            {
                miscPermissions = value;
            }
        }

        public bool IsAutoCodeConfigurable { get; internal set; }
        public bool IsPeriodSpecific { get; internal set; }

        /// <summary>
        /// Gets the Feature Name.
        /// </summary>
        public Int16 TaggedLevel { get; internal set; }
    }
}
