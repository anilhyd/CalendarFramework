#region Header Info
//-----------------------------------------------------------------------
// <copyright file="PrivilegeAttribute.cs" company="Calendar.Framework">
// Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Marks business method with privilege attribute for checking the user must have this privilege while accessing.</summary>
// <createdby>Desayya</createdby> 
// <createddate>25-Oct-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// Marks business method with privilege attribute for checking
    /// the user must have this privilege while accessing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class FeaturesAttribute : Attribute
    {
        /// <summary>
        /// Internal variable for storing the Name of the privilege.
        /// </summary>
        private List<string> features = null;

        /// <summary>
        /// Initializes a new instance of the PrivilegeAttribute class.
        /// </summary>
        /// <param name="privilege">Name of the privilege.</param>
        public FeaturesAttribute(params string[] features)
        {
            this.features = features.ToList();
        }

        /// <summary>
        /// Gets a value of Name.
        /// </summary>
        public List<string> Features
        {
            get
            {
                return this.features;
            }
        }
    }
}
