#region Header Info
//-----------------------------------------------------------------------
// <copyright file="BusinessRulesManager.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Manages the list of rules for a business type.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='Kasi' modifieddate='19-07-2011' revisionno=''>GetFeatureMetaData method is added for getting Feature table name, module name and field name</revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Calendar.Framework.Rules
{
    /// <summary>
    /// Manages the list of rules for a business type.
    /// </summary>
    public static class BusinessRulesManager
    {
        /// <summary>
        /// Maintains a list of all the per-type
        /// <see cref="CollectionRules"/> objects
        /// loaded in memory.
        /// </summary>
        private static Dictionary<string, CollectionRules> businessmanager =
            new Dictionary<string, CollectionRules>();

        /// <summary>
        /// Returns the rules from the manager.
        /// </summary>
        /// <param name="businessEntityCode">Name of the feature.</param>
        /// <returns>Rule collection.</returns>
        public static CollectionRules GetRulesManager(string businessEntityCode)
        {
            if (businessmanager.ContainsKey(businessEntityCode))
                return (CollectionRules)businessmanager[businessEntityCode];
            else return null;
        }

        /// <summary>
        /// Adds the rules to manger.
        /// </summary>
        /// <param name="businessEntityCode">Name of the feature.</param>
        /// <param name="rules">Collection of rules.</param>
        public static void AddRule(string businessEntityCode, CollectionRules rules)
        {
            // we have the list, add out new rule
            if (!businessmanager.ContainsKey(businessEntityCode))
                businessmanager.Add(businessEntityCode, rules);
        }

        /// <summary>
        /// Gets a value indicating whether a set of rules
        /// have been created for a given <see cref="Type" />.
        /// </summary>
        /// <param name="featureCode">Name of the feature.</param>
        /// <returns><see langword="true" /> If rules exist for the type.</returns>
        public static bool RulesExistFor(string businessEntityCode)
        {
            return businessmanager.ContainsKey(businessEntityCode);
        }

        /// <summary>
        /// Gets a value indicating whether a set of rules
        /// have been created for a given <see cref="Type" />.
        /// </summary>
        /// <param name="businessEntityCode">Name of the feature.</param>
        /// <param name="entityType">ENtity type.</param>
        /// <returns><see langword="true" />If rules exist for the type.</returns>
        public static IEnumerable<RuleMapping> GetRulesForEntity(string businessEntityCode, string entityName)
        {
            if (businessmanager.ContainsKey(businessEntityCode))
            {
                CollectionRules erules = (CollectionRules)businessmanager[businessEntityCode];
                var rules = from rule in erules.Rules
                            where rule.EntityName == entityName 
                            select rule;
                return rules;
            }

            return null;
        }

        /// <summary>
        /// It will gives TableName, module name, field name for given feature code
        /// </summary>
        /// <param name="FeatureCode"></param>
        /// <returns>Feature meta data</returns>
        /// 
        internal static Framework.FeatureMetadata GetFeatureMetaData(string FeatureCode, string PropertyName = null)
        {
            Framework.FeatureMetadata featureData = null;

            if (PropertyName == null || PropertyName.Length <= 0)
                PropertyName = "Code";


            //using (Saras.Framework.Entity.FrameworkEntities ent = new Saras.Framework.Entity.FrameworkEntities())
            //{
            //    featureData = (from f in ent.Feature
            //                   join m in ent.Module on f.ModuleId equals m.Id
            //                   join e in ent.Entity on f.Id equals e.PageId
            //                   join fld in ent.Field on e.EntityId equals fld.EntityId
            //                   where f.Code == FeatureCode && e.Occurrence == true && fld.FieldName == PropertyName  //fld.IsUniqueColumn == true
            //                   select new SAF.Common.FeatureMetadata
            //                   {
            //                       TableName = f.MainTable,
            //                       ModuleName = m.Name,
            //                       FieldName = fld.FieldName,
            //                       SequenceNo = fld.ColumnSequenceNo
            //                   }).FirstOrDefault();
            //}

            return featureData;
        }
    }
}
