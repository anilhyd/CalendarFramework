#region Header Info
//-----------------------------------------------------------------------
// <copyright file="BrokenRule.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Stores details about a specific broken business rule. </summary>
// <createdby>Deesayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Calendar.Framework.Rules
{
    /// <summary>
    /// Stores details about a specific broken business rule.
    /// </summary>
    [Serializable()]
    public class BrokenRule
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="BrokenRule"/> class.
        ///  Sets the Default Severity to Error.
        /// </summary>
        public BrokenRule()
        {
            this.Severity = RuleSeverity.Error;
            this.Index = -1;
        }

        /// <summary>
        /// Gets or sets the  Source of the broken rule.
        /// </summary>
        /// <value>The name of the rule.</value>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the name of the broken rule.
        /// </summary>
        /// <value>The name of the rule.</value>
        public string RuleName { get; set; }

        /// <summary>
        /// Gets or sets the description of the broken rule.
        /// </summary>
        /// <value>The description of the rule.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the  property affected by the broken rule.
        /// </summary>
        /// <value>The property affected by the rule.</value>
        public string Property { get; set; }

        /// <summary>
        /// Gets or sets the severity of the broken rule.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public RuleSeverity Severity { get; set; }

        /// <summary>
        /// Gets or sets the Index of the Entity
        /// Its applicable only for List Items.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the  Error Message code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the rule type.
        /// </summary>
        public RuleType RuleType { get; set; }
    }
}
