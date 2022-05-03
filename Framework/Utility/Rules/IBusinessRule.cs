#region Header Info
//-----------------------------------------------------------------------
// <copyright file="IBusinessRule.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Interface defining a business/validation rule implementation. </summary>
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
    /// Interface defining a business/validation
    /// rule implementation.
    /// </summary>
    public interface IBusinessRule
    {
        /// <summary>
        /// Business or validation rule implementation.
        /// </summary>
        /// <returns>Retuns Boolean Value.</returns>
        bool Execute();
    }
}
