#region Header Info
//-----------------------------------------------------------------------
// <copyright file="BrokenRulesCollection.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Collection object for holding the broken rules.</summary>
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
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Calendar.Framework.Entity;
using Calendar.Framework.Utility;

#endregion

namespace Calendar.Framework.Rules
{
    /// <summary>
    /// Collection object for holding the broken rules.
    /// </summary>
    [Serializable]
    public class BrokenRulesCollection : List<BrokenRule>
    {
        /// <summary>
        /// Internal varibale for storing the error count.
        /// </summary>
        private int errorCount;

        /// <summary>
        /// Internal varible for storing the warning count.
        /// </summary>
        private int warningCount;

        /// <summary>
        /// Internal varible for storing the Informantion count.
        /// </summary>
        private int infoCount;

        /// <summary>
        /// Internal varible for storing the custom collection.
        /// </summary>
        private bool customList;

        /// <summary>
        /// Private revision variable.
        /// </summary>
        private int revision;

        /// <summary>
        /// Initializes a new instance of the BrokenRulesCollection class.
        /// </summary>
        internal BrokenRulesCollection()
        {
        }

        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Error.
        /// </summary>
        /// <value>An integer value.</value>
        public int ErrorCount
        {
            get { return this.errorCount; }
        }

        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Warning.
        /// </summary>
        /// <value>An integer value.</value>
        public int WarningCount
        {
            get { return this.warningCount; }
        }

        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Information.
        /// </summary>
        /// <value>An integer value.</value>
        public int InformationCount
        {
            get { return this.infoCount; }
        }

        /// <summary>
        /// Gets the current revision number of
        /// the collection.
        /// </summary>
        /// <remarks>
        /// The revision value changes each time an
        /// item is added or removed from the collection.
        /// </remarks>
        public int Revision
        {
            get { return this.revision; }
        }

        /// <summary>
        /// Gets an empty collection on which the Merge()
        /// method may be called to merge in data from
        /// other BrokenRuleCollection objects.
        /// </summary>
        /// <returns>Returns broken rule collection.</returns>
        public static BrokenRulesCollection CreateCollection()
        {
            BrokenRulesCollection result = new BrokenRulesCollection();
            result.customList = true;
            return result;
        }

        /// <summary>
        /// Returns the first <see cref="BrokenRule" /> object
        /// corresponding to the specified property.
        /// </summary>
        /// <remarks>
        /// Code in a business object or UI can also use this value to retrieve
        /// the first broken rule in <see cref="BrokenRulesCollection" /> that corresponds
        /// to a specfic property on the object.
        /// </remarks>
        /// <param name="property">The name of the property affected by the rule.</param>
        /// <returns>
        /// The first BrokenRule object corresponding to the specified property, or null if 
        /// there are no rules defined for the property.
        /// </returns>
        public BrokenRule GetFirstBrokenRule(string property)
        {
            return this.GetFirstMessage(property, RuleSeverity.Error);
        }

        /// <summary>
        /// Returns the first <see cref="BrokenRule" /> object
        /// corresponding to the specified property.
        /// </summary>
        /// <remarks>
        /// Code in a business object or UI can also use this value to retrieve
        /// the first broken rule in <see cref="BrokenRulesCollection" /> that corresponds
        /// to a specfic property.
        /// </remarks>
        /// <param name="property">The name of the property affected by the rule.</param>
        /// <returns>
        /// The first BrokenRule object corresponding to the specified property, or Nothing
        /// (null in C#) if there are no rules defined for the property.
        /// </returns>
        public BrokenRule GetFirstMessage(string property)
        {
            foreach (BrokenRule item in this)
                if (item.Property == property)
                    return item;
            return null;
        }

        /// <summary>
        /// Returns the first <see cref="BrokenRule"/> object
        /// corresponding to the specified property
        /// and severity.
        /// </summary>
        /// <param name="property">The name of the property affected by the rule.</param>
        /// <param name="severity">The severity of broken rule to return.</param>
        /// <returns>
        /// The first BrokenRule object corresponding to the specified property, or Nothing
        /// (null in C#) if there are no rules defined for the property.
        /// </returns>
        public BrokenRule GetFirstMessage(string property, RuleSeverity severity)
        {
            foreach (BrokenRule item in this)
                if (item.Property == property && item.Severity == severity)
                    return item;
            return null;
        }

        /// <summary>
        /// Adds rule to Rules manager.
        /// </summary>
        /// <param name="rule">Actual rule object.</param>
        /// <param name="index">Index of the rule.</param>
        /// <param name="ruleType">Type of the rule.</param>
        public void Add(RuleMapping rule, int index, RuleType ruleType)
        {
            BrokenRule broken = new BrokenRule() { Index = index, RuleName = rule.Rule.Name, Property = rule.PropertyName, Source = rule.EntityName, ErrorCode = rule.Rule.ErrorCode, RuleType = ruleType };
            this.Remove(broken);
            this.IncrementCount(broken);
            this.Add(broken);
        }

        /// <summary>
        /// Returns the text of all broken rule descriptions, each
        /// separated by a <see cref="Environment.NewLine" />.
        /// </summary>
        /// <returns>The text of all broken rule descriptions.</returns>
        public override string ToString()
        {
            return this.ToString(Environment.NewLine);
        }

        /// <summary>
        /// Returns the text of all broken rule descriptions
        /// for a specific severity, each
        /// separated by a <see cref="Environment.NewLine" />.
        /// </summary>
        /// <param name="severity">The severity of rules to
        /// include in the result.</param>
        /// <returns>The text of all broken rule descriptions
        /// matching the specified severtiy.</returns>
        public string ToString(RuleSeverity severity)
        {
            return this.ToString(Environment.NewLine, severity);
        }

        /// <summary>
        /// Returns the text of all broken rule descriptions.
        /// </summary>
        /// <param name="separator">
        /// String to place between each broken rule description.
        /// </param>
        /// <returns>The text of all broken rule descriptions.</returns>
        public string ToString(string separator)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            bool first = true;
            foreach (BrokenRule item in this)
            {
                if (first)
                    first = false;
                else
                    result.Append(separator);
                result.Append(item.Description);
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns the text of all broken rule descriptions
        /// for a specific severity.
        /// </summary>
        /// <param name="separator">
        /// String to place between each broken rule description.
        /// </param>
        /// <param name="severity">The severity of rules to
        /// include in the result.</param>
        /// <returns>The text of all broken rule descriptions
        /// matching the specified severtiy.</returns>
        public string ToString(string separator, RuleSeverity severity)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            bool first = true;
            foreach (BrokenRule item in this)
            {
                if (item.Severity == severity)
                {
                    if (first)
                        first = false;
                    else
                        result.Append(separator);
                    result.Append(item.Description);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns a string array containing all broken
        /// rule descriptions.
        /// </summary>
        /// <returns>The text of all broken rule descriptions
        /// matching the specified severtiy.</returns>
        public new string[] ToArray()
        {
            List<string> result = new List<string>();
            foreach (BrokenRule item in this)
                result.Add(item.Description);
            return result.ToArray();
        }

        /// <summary>
        /// Returns a string array containing all broken
        /// rule descriptions.
        /// </summary>
        /// <param name="severity">The severity of rules
        /// to include in the result.</param>
        /// <returns>The text of all broken rule descriptions
        /// matching the specified severtiy.</returns>
        public string[] ToArray(RuleSeverity severity)
        {
            List<string> result = new List<string>();
            foreach (BrokenRule item in this)
                if (item.Severity == severity)
                    result.Add(item.Description);
            return result.ToArray();
        }

        #region Custom List

        /// <summary>
        /// Merges data from the supplied list into this
        /// list, changing the rule names to be unique
        /// based on the source value.
        /// </summary>
        /// <param name="source">
        /// A unique source name for each list being
        /// merged into this master list.
        /// </param>
        /// <param name="list">
        /// A list to merge into this master list.
        /// </param>
        /// <remarks>
        /// This method is intended to allow merging of
        /// all BrokenRulesCollection objects in a business
        /// object graph into a single list. To this end,
        /// no attempt is made to remove duplicates during
        /// the merge process. Also, the source parameter
        /// value must be unqiue for each object instance
        /// in the graph, or rule name collisions may
        /// occur.
        /// </remarks>
        public void Merge(string source, BrokenRulesCollection list)
        {
            if (!this.customList)
                throw new NotSupportedException("BrokenRulesMergeException");
            foreach (BrokenRule item in list)
            {
                BrokenRule newItem = new BrokenRule() { Source = source, Severity = item.Severity, Description = item.Description, Property = item.Property, RuleName = item.RuleName };
                this.IncrementCount(newItem);
                this.Add(newItem);
            }
        }

        #endregion

        /// <summary>
        /// Removes the rule from collection.
        /// </summary>
        /// <param name="rule">Failed rule.</param>
        internal new void Remove(BrokenRule rule)
        {
            // we loop through using a numeric counter because
            // removing items within a foreach isn't reliable
            for (int index = 0; index < Count; index++)
                if (this[index].RuleName == rule.RuleName && this[index].Property == rule.Property)
                {
                    this.DecrementCount(this[index]);
                    this.RemoveAt(index);
                    break;
                }
        }

        /// <summary>
        /// Increments the collection count.
        /// </summary>
        /// <param name="item">Failed rule.</param>
        private void IncrementCount(BrokenRule item)
        {
            this.IncrementRevision();
            switch (item.Severity)
            {
                case RuleSeverity.Error:
                    this.errorCount += 1;
                    break;
                case RuleSeverity.Warning:
                    this.warningCount += 1;
                    break;
                case RuleSeverity.Information:
                    this.infoCount += 1;
                    break;
            }
        }

        /// <summary>
        /// Decrements the collection count.
        /// </summary>
        /// <param name="item">Failed rule.</param>
        private void DecrementCount(BrokenRule item)
        {
            this.IncrementRevision();
            switch (item.Severity)
            {
                case RuleSeverity.Error:
                    this.errorCount -= 1;
                    break;
                case RuleSeverity.Warning:
                    this.warningCount -= 1;
                    break;
                case RuleSeverity.Information:
                    this.infoCount -= 1;
                    break;
            }
        }

        #region Revision

        /// <summary>
        /// Increments the revision.
        /// </summary>
        private void IncrementRevision()
        {
            this.revision = (this.revision + 1) % int.MaxValue;
        }
        #endregion
    }
}