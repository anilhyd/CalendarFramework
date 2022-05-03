#region Header Info
//-----------------------------------------------------------------------
// <copyright file="UserContext.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Provides user context information.</summary>
// <createdby>Desayya</createdby> 
// <createddate>9-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces
using System;
using System.Security.Principal;
#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// Provides self-describing  user context information.
    /// </summary>
    [Serializable]
    public class UserContext
    {
        /// <summary>
        /// Gets the User Name.
        /// </summary>
        public string UserName { get; internal set; }

        /// <summary>
        /// Gets the User ID.
        /// </summary>
        public string UserID { get; internal set; }

        /// <summary>
        /// Gets the UserType
        /// </summary>
        public decimal UserType { get; internal set; }

        /// <summary>
        /// Gets the User Logon time.
        /// </summary>
        public DateTime LogonTime { get; internal set; }

        /// <summary>
        /// Gets the LoginType of the user.
        /// </summary>
        public decimal LoginType { get; internal set; }

        /// <summary>
        /// Gets or sets the RoleName
        /// </summary>
        public string RoleName { get; internal set; }

        /// <summary>
        /// Gets or sets the roleid
        /// </summary>
        public string RoleID { get; internal set; }
    }
}
