#region Header Info
//-----------------------------------------------------------------------
// <copyright file="EntityRules.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Stores details about a specific rule. 
// </summary>
// <createdby>Deesayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces
using Calendar.Framework.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
#endregion

namespace Calendar.Framework.Rules
{
    /// <summary>
    /// Collection object holds the rules.
    /// </summary>
    [Serializable()]
    public class CollectionRules
    {
        /// <summary>
        /// List of Rules.
        /// </summary>
        private Collection<RuleMapping> rules = new Collection<RuleMapping>();

        /// <summary>
        /// Gets or sets the list of rules.
        /// </summary>
        public Collection<RuleMapping> Rules
        {
            get
            {
                return this.rules;
            }

            set
            {
                this.rules = value;
            }
        }
    }
}