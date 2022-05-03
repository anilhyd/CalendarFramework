#region Header Info
//-----------------------------------------------------------------------
// <copyright file="CacheAttribute.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Marks a business fetch method is able cache returned items itself. it will verify cache store and inserts 
// new method info object if not found.</summary>
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
using System.Collections.Generic;
using System.Text;

#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// Marks a business fetch method is able cache returned items
    /// itself. it will verify cache store and inserts new method info
    /// object if not found.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute : Attribute
    {

        /// <summary>
        /// Specifies the expiry time.
        /// </summary>
        private CacheDuration caheDuration = CacheDuration.None;

        /// <summary>
        /// Holds the Name of the the uniqeidentifier.
        /// </summary>
        private string uniqueId = string.Empty;

        /// <summary>
        ///  Initializes a new instance of the CacheAttribute class.
        /// </summary>
        /// <param name="duration">CacheDuration Object.</param>
        public CacheAttribute(CacheDuration duration)
        {
            this.caheDuration = duration;
        }

        /// <summary>
        ///  Initializes a new instance of the CacheAttribute class.
        /// </summary>
        public CacheAttribute()
        {
        }

        /// <summary>
        /// Gets the Cache Duration type.
        /// </summary>
        public CacheDuration Duration
        {
            get
            {
                return caheDuration;
            }
        }
    }
}
