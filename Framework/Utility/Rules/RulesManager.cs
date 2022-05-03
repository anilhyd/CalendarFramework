#region Header Info
//-----------------------------------------------------------------------
// <copyright file="RulesManager.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Stores details about a specific rule.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ModuleResource = SAF.Properties.Resources;
using Calendar.Framework.Entity;
using Calendar.Framework.Runtime;
using Calendar.Framework.Utility;

#endregion

namespace Calendar.Framework.Rules
{
    /// <summary>
    /// Rule manager will hold collection of rules into it.
    /// </summary>
    public class RulesManager
    {
        /// <summary>
        /// Maintains a list of all the per-type
        /// <see cref="CollectionRules"/> objects
        /// loaded in memory.
        /// </summary>
        private static Dictionary<string, CollectionRules> managers = new Dictionary<string, CollectionRules>();

        /// <summary>
        /// Returns the collection from the rule manager.
        /// </summary>
        /// <param name="businessEntityCode">Name of the feature.</param>
        /// <returns>Returns the rule collection.</returns>
        public static CollectionRules GetRulesManager(string businessEntityCode)
        {
            if (managers.ContainsKey(businessEntityCode))
                return (CollectionRules)managers[businessEntityCode];
            else return null;
        }

        /// <summary>
        /// Adds the rule collection.
        /// </summary>
        /// <param name="businessEntityCode">Name of the feature.</param>
        /// <param name="rules">Collection of rules.</param>
        public static void AddRule(string businessEntityCode, CollectionRules rules)
        {
            // we have the list, add out new rule
            if (!managers.ContainsKey(businessEntityCode))
                managers.Add(businessEntityCode, rules);
        }

        /// <summary>
        /// Ads the rule to rule manager.
        /// </summary>
        /// <param name="businessEntityCode">Name of the feature.</param>
        /// <param name="rule">Rule object.</param>
        public static void AddRule(string businessEntityCode, RuleMapping rule)
        {
            // we have the list, add out new rule
            CollectionRules rules = GetRulesManager(businessEntityCode);
            if (rules != null)
            {
                rules.Rules.Add(rule);
            }
            else
            { 
                rules = new CollectionRules();
                rules.Rules.Add(rule);
                AddRule(businessEntityCode, rules);
            }
        }

        /// <summary>
        /// Gets a value indicating whether a set of rules
        /// have been created for a given <see cref="Type" />.
        /// </summary>
        /// <param name="businessEntityCode">
        /// Type of business object for which the rules apply.
        /// </param>
        /// <returns><see langword="true" />If rules exist for the type.</returns>
        public static bool RulesExistFor(string businessEntityCode)
        {
            return managers.ContainsKey(businessEntityCode);
        }

        /// <summary>
        /// Gets a value indicating whether a set of rules
        /// have been created for a given <see cref="Type" />.
        /// </summary>
        /// <param name="businessEntityCode">
        /// Type of business object for which the rules apply.
        /// </param>
        /// <param name="entitytype">Enitty type.</param>
        /// <returns><see langword="true" />If rules exist for the type.</returns>
        public static IEnumerable<RuleMapping> GetRulesForEntity(string businessEntityCode, string entityName)
        {
            if (managers.ContainsKey(businessEntityCode))
            {   
                CollectionRules erules = (CollectionRules)managers[businessEntityCode];
                var rules = from rule in erules.Rules
                            where rule.EntityName == entityName
                            select rule;
                return rules;
            }

            return null;
        }

        /// <summary>
        /// Gets a value indicating whether a set of rules
        /// have been created for a given businessEntityCode <see cref="Type" />.
        /// </summary>
        /// <param name="businessEntityCode">Feature Code for getting the Rules.</param>
        /// <returns><see langword="true" /> If rules exist for the type.</returns>
        public static IEnumerable<RuleMapping> GetRulesForEntity(string businessEntityCode)
        {
            if (managers.ContainsKey(businessEntityCode))
            {
                return managers[businessEntityCode].Rules;
            }

            return null;
        }

        public static void CheckRules(object entity, ref BrokenRulesCollection brokenRule, IEnumerable<RuleMapping> rules, int index, PageContext context = null)
        {
            bool result = false;

#if PARALLEL
            BrokenRulesCollection failedRules = new BrokenRulesCollection();
            Parallel.ForEach(rules, rule =>
            {
#else
            foreach (RuleMapping rule in rules)
            {
#endif
                result = false;
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                DateTime start = DateTime.Now;
                if (context != null)
                    context.TraceMessage.Append(SAF.Common.UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")));
#endif
                try
                {
                    switch (rule.Rule.Name)
                    {
                        case "StringRequired":
                            result = CommonRules.StringRequired(entity, rule);
                            break;

                        case "StringMaxLength":
                            result = CommonRules.StringMaxLength(entity, rule);
                            break;

                        case "StringMaxLengthIfNotNull":
                            result = CommonRules.StringMaxLengthIfNotNull(entity, rule);
                            break;

                        case "StringMinLengthIfNotNull":
                            result = CommonRules.StringMinLengthIfNotNull(entity, rule);
                            break;

                        case "StringMinLength":
                            result = CommonRules.StringMinLength(entity, rule);
                            break;
                        case "IntegerMaxValue":
                            result = CommonRules.IntegerMaxValue(entity, rule);
                            break;
                        case "IntegerMinValue":
                            result = CommonRules.IntegerMinValue(entity, rule);
                            break;
                        case "DoubleMaxValue":
                            result = CommonRules.DoubleMaxValue(entity, rule);
                            break;
                        case "DoubleMinValue":
                            result = CommonRules.DoubleMinValue(entity, rule);
                            break;
                        case "DateMaxValue":
                            result = CommonRules.DateMaxValue(entity, rule);
                            break;
                        case "DateMinValue":
                            result = CommonRules.DateMinValue(entity, rule);
                            break;
                        case "DecimalMaxValue":
                            result = CommonRules.DecimalMaxValue(entity, rule);
                            break;
                        case "DecimalMinValue":
                            result = CommonRules.DecimalMinValue(entity, rule);
                            break;
                        case "RegExMatch":
                            result = CommonRules.RegExMatch(entity, rule);
                            break;
                        case "CheckUniquenessInOrganization":
                            result = CommonRules.CheckUniquenessInOrganization(entity, rule);
                            break;
                        case "CheckUniquenessInBusinessUnit":
                            result = CommonRules.CheckUniquenessInBusinessUnit(entity, rule);
                            break;
                        default:
                            if (rule.Rule.RuleType)
                            {
                                //string fullqualifiedrulename = rule.Rule.ClassName;
                                //string typeName = rule.Rule.Name + ", " + rule.Rule.AssemblyName;
                                string typeName = rule.Rule.ClassName + ", " + rule.Rule.AssemblyName;
                                Type type = Type.GetType(typeName);
                                if (type != null)
                                {
                                    BusinessRule businessRule = (BusinessRule)MethodCaller.CreateInstance(type);
                                    businessRule.Entity = entity;
                                    result = businessRule.Execute();
                                }
                                else
                                    result = false;
                            }

                            break;
                    }
                }
                catch
                {
                    BDException ex = new BDException("RuleExecutionFailed");

                    // ex.ErrorCode = "VALEX01";
                    ex.Source = "<Error Desc='Rule Execution Failed'><RuleType>" + rule.ToString() + "<RuleType/><RuleName>" + rule.Rule.Name + "</RuleName><Entity>" + rule.EntityName + "</Entity></Error>";
                    throw ex;
                }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                if (context != null)
                {
                    context.TraceMessage = context.TraceMessage.Replace("@Method", rule.EntityName + "." + rule.PropertyName + "::" + rule.RuleId);
                    SAF.Common.UtilityManager.ApendEndTraceString(context, start, DateTime.Now);
                }
#endif
#if PARALLEL
                if (!result)
                {
                    failedRules.Add(rule, index, SAF.Common.RuleType.BusinessRule);
                }
            });
            if (brokenRule == null)
                brokenRule = new BrokenRulesCollection();

            brokenRule.AddRange(failedRules);
#else
                if (!result)
                {
                    if (brokenRule == null)
                        brokenRule = new BrokenRulesCollection();
                    brokenRule.Add(rule, index, RuleType.BusinessRule);
                    index++;
                }
            }
#endif
        }
    }
}
