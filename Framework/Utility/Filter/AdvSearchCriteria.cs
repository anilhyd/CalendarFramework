#region Header Info
//-----------------------------------------------------------------------
// <copyright file="ExpressionHelper.cs" company="Excel Soft India Pvt. Ltd.">
//  Copyright (c) Excel Soft India Pvt. Ltd. All rights reserved. Website: http://www.excelindia.com.
// </copyright>
// <summary>Manager used to create the appropriate Search provider by using configuration.</summary>
// <createdby>Anil Adla</createdby> 
// <createddate>26-02-2013</createddate>
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
using System.Linq.Expressions;
using System.Reflection;

#endregion

namespace BD.Framework.CoreFramework.Filter
{
    /// <summary>
    /// Advance search critiera inforamtion
    /// </summary>
    public class AdvSearchCriteria
    {
        /// <summary>
        /// Gets or sets the value of the Entity level no.
        /// </summary>
        public int LevelNo { get; set; }

        /// <summary>
        /// Gets or sets the value of the entiy name.
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the value of the Parent entity collection  names.
        /// </summary>
        public string ParentEntityCollectionName { get; set; }

        /// <summary>
        /// Gets or sets the value of the type of relation names.
        /// </summary>
        public string TypeOfRealation { get; set; }

        /// <summary>
        /// Gets or sets the list of criteria properties.
        /// </summary>
        public List<AdvCriteriaProp> CriteriaProperties { get; set; }
    }

    /// <summary>
    /// Class holds the Advance search criteria propery information.
    /// </summary>
    public class AdvCriteriaProp
    {
        /// <summary>
        /// Gets or sets the Proerty Name for search.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the Operator to apply.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the Data type of the property.
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the value to search.
        /// </summary>
        public object SearchValue { get; set; }

    }
}
