#region Header Info
//-----------------------------------------------------------------------
// <copyright file="ValidationRulesManager.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Manages the list of rules for a validation type.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>24-Sept-2010</createddate>
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
using System.Collections;
using Calendar.Framework.Entity;
#endregion

namespace Calendar.Framework.Rules
{
    /// <summary>
    /// Manages the list of rules for a validation type.
    /// </summary>
    public static class ValidationRulesManager
    {
        /// <summary>
        /// Maintains a list of all the per-type
        /// <see cref="CollectionRules"/> objects
        /// loaded in memory.
        /// </summary>
        private static Dictionary<string, CollectionRules> validationmanager = new Dictionary<string, CollectionRules>();

        /// <summary>
        /// Returns the rule manager.
        /// </summary>
        /// <param name="businessEntityCode">Name of the screen</param>
        /// <returns>Rules collection.</returns>
        public static CollectionRules GetRulesManager(string businessEntityCode)
        {
            if (validationmanager.ContainsKey(businessEntityCode))
                return (CollectionRules)validationmanager[businessEntityCode];
            else return null;
        }

        /// <summary>
        /// Ads the rule to the manager
        /// </summary>
        /// <param name="businessEntityCode">Name of the screen</param>
        /// <param name="rules">Collection of rules</param>
        public static void AddRule(string businessEntityCode, CollectionRules rules)
        {
            // we have the list, add out new rule
            if (!validationmanager.ContainsKey(businessEntityCode))
                validationmanager.Add(businessEntityCode, rules);
        }


        /// <summary>
        /// Gets a value indicating whether a set of rules
        /// have been created for a given <see cref="Type" />.
        /// </summary>
        /// <param name="businessEntityCode">
        /// Type of business object for which the rules apply.
        /// </param>
        /// <returns><see langword="true" /> if rules exist for the type.</returns>
        public static bool RulesExistFor(string businessEntityCode)
        {
            return validationmanager.ContainsKey(businessEntityCode);
        }

        /// <summary>
        /// Gets a value indicating whether a set of rules
        /// have been created for a given <see cref="Type" />.
        /// </summary>
        /// <param name="businessEntityCode">
        /// Type of business object for which the rules apply.
        /// </param>
        /// <param name="entityType">entity type</param>
        /// <returns><see langword="true" /> if rules exist for the type.</returns>
        public static IEnumerable<RuleMapping> GetRulesForEntity(string businessEntityCode, string entityName)
        {
            if (validationmanager.ContainsKey(businessEntityCode))
            {
                CollectionRules erules = (CollectionRules)validationmanager[businessEntityCode];
                return from rule in erules.Rules
                            where rule.EntityName == entityName
                            select rule;
            }
            return null;
        }
    }
}
