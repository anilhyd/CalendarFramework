#region Header Info
//-----------------------------------------------------------------------
// <copyright file="PageContext.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Provides Page context information.</summary>
// <createdby>Desayya</createdby> 
// <createddate>20-Jan-2022</createddate>
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
    [Serializable]
    public class PageContext
    {
        /// <summary>
        /// Gets the Current Page code accessed by the user.
        /// </summary>
        public string PageCode { get; internal set; }

        /// <summary>
        /// Gets the Current Page FeatureID accessed by the user.
        /// </summary>
        public string FeatureID { get; internal set; }

        /// <summary>
        /// Gets the User Last application accessed time.
        /// </summary>
        public DateTime LastAccessedTime { get; internal set; }

        /// <summary>
        /// Gets the UserID for the feature.
        /// </summary>
        public string UserID { get; internal set; }

        /// <summary>
        /// Gets the Current Page code accessed by the user for Auto code.
        /// </summary>
        public Boolean IsTransactionRequired { get; internal set; }
    }
}
