#region Header Info
//-----------------------------------------------------------------------
// <copyright file="BusinessRule.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Base class used to create business and validation rules.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>29-Nov-2010</createddate>
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

namespace Calendar.Framework.Rules
{
    /// <summary>
    /// Base class used to create business and validation rules.
    /// </summary>
    public abstract class BusinessRule : IBusinessRule
    {
        /// <summary>
        /// Local variable for storing the Entity object.
        /// </summary>
        protected internal object Entity = null;

        /// <summary>
        /// Business or validation rule implementation.
        /// </summary>
        /// <returns>Retuns Boolean Value.</returns>
        public abstract bool Execute();

        /// <summary>
        /// Business or validation rule implementation.
        /// </summary>
        /// <returns>Retuns Boolean Value.</returns>
        bool IBusinessRule.Execute()
        {
            return this.Execute();
        }
    }
}
