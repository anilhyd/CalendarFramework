#region Header Info
//-----------------------------------------------------------------------
// <copyright file="Criteria.cs" company="Excel Soft India Pvt. Ltd.">
//  Copyright (c) Excel Soft India Pvt. Ltd. All rights reserved. Website: http://www.excelindia.com.
// </copyright>
// <summary>It provides the search filter information to the seach.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>17-Sept-2010</createddate>
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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Linq.Expressions;
using BD.Framework.Utility;

#endregion

namespace BD.Framework.CoreFramework.Filter
{
    [DataContract]
    [Serializable]
    /// <summary>
    /// It provides the search filter information to the seach.
    /// </summary>
    public class Criteria
    {
        #region Property : CriteriaColumns

        /// <summary>
        /// Represents list of fields.
        /// </summary>
        private Collection<CriteriaField> searchFields = new Collection<CriteriaField>();

        /// <summary>
        /// Gets or sets the Page number. Results rows will return based on page no. and size of the page.
        /// Default value is 1
        /// </summary>
        private int pageNo = 1;

        /// <summary>
        /// Gets of sets whether paging is enabled or not. 
        /// Default is true and it will return page sized no. of records and 
        /// this page size value has been taken from the configuration.
        /// </summary>
        private bool paging = false;

        [DataMember]
        /// <summary>
        /// Gets or sets the Search fields
        /// </summary>
        public Collection<CriteriaField> SearchFields
        {
            get
            {
                return this.searchFields;
            }

            set
            {
                this.searchFields = value;
            }
        }

        #endregion

        #region Properties

        [DataMember]
        /// <summary>
        /// Gets or sets the feature code for the Search/Index
        /// </summary>
        public string FeatureCode { get; set; }

        [DataMember]
        /// <summary>
        /// Gets or sets the module code. 
        /// Index files has been created under the module and feaure.
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// Gets or sets the Unique ID.
        /// </summary>
        public string UniqueID { get; set; }

        /// <summary>
        /// Gets or sets the TransactionID
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// Gets or sets the TransactionID
        /// </summary>
        public bool AllHits { get; set; }

        /// <summary>
        /// Gets or sets the AssemblyName
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// Gets or sets the NameSpaceWithClassName
        /// </summary>
        public string NameSpaceWithClassName { get; set; }

        /// <summary>
        /// Gets or sets the MethodName
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets or sets the WhereCondition
        /// </summary>
        public string WhereCondition { get; set; }

        /// <summary>
        /// Gets or sets the SearchType
        /// </summary>
        public SearchType SearchType { get; set; }

        /// <summary>
        /// Gets or sets the SearchType
        /// </summary>
        public string ViewByOption { get; set; }

        /// <summary>
        /// Gets or sets the Sort Column Name for the Search/Index
        /// </summary>
        [NonSerialized]
        private Expression<Func<EntityBase, bool>> expression = null;
        
        public Expression<Func<EntityBase, bool>> WhereExpression
        {
            get
            {
                return expression;
            }
            set
            {
                expression = value;
            }
        }

        /// <summary>
        /// Gets or sets the Sort Column Name for the Search/Index
        /// </summary>
        public SAF.Core.PageContext PickerPageContext { get; set; }

        /// <summary>
        /// Gets or sets the Sort Column Name for the Search/Index
        /// </summary>
        public string SortColumnName { get; set; }


        /// <summary>
        /// Gets or sets the Sort Column Name for the Search/Index
        /// </summary>
        public string SortExpression { get; set; }

        /// <summary>
        /// Gets or sets the SearchPickerSearch
        /// </summary>
        public bool SearchPickerSearch { get; set; }

        /// <summary>
        /// Gets or sets the SearchPickerSearch
        /// </summary>
        public bool IsAllPagesDataRequired { get; set; }

        /// <summary>
        /// Gets or sets the SearchPickerSearch
        /// </summary>
        public Dictionary<string, string> UserCustomCriteria { get; set; }

        /// <summary>
        /// Gets or sets the SearchPickerSearch
        /// </summary>
        public string LockedRecordIdCollection { get; set; }

        /// <summary>
        /// Gets or sets the Page number. Results rows will return based on page no. and size of the page.
        /// Default value is 1
        /// </summary>
        public int PageNumber 
        {
            get
            {
                return this.pageNo;
            }

            set
            {
                this.pageNo = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether paging is enabled or not. 
        /// Default is true and it will return page sized no. of records and 
        /// this page size value has been taken from the configuration.
        /// </summary>
        public bool PagingEnabled 
        {
            get
            {
                return this.paging;
            }

            set
            {
                this.paging = value;
            }
        }

        #endregion

        #region Indexer

        /// <summary>
        /// index indxer
        /// </summary>
        /// <param name="index">index of item</param>
        /// <returns>Returns CriteriaField object</returns>
        public CriteriaField this[int index]
        {
            get
            {
                return this.SearchFields[index];
            }

            set
            {
                this.SearchFields.Insert(index, value);
            }
        }

        /// <summary>
        /// Criteria Name of the Indexer
        /// </summary>
        /// <param name="name">Criteria Column Name</param>
        /// <returns>Returns CriteriaField object</returns>
        public CriteriaField this[string name]
        {
            get
            {
                var criteria = from c in this.SearchFields
                               where c.FieldName == name
                               select c;
                if (criteria.Count() > 0)
                    return criteria.First();
                else
                    return null;
            }

            set
            {
                this.SearchFields.Add(value);
            }
        }
        #endregion

        #region Add
        /// <summary>
        /// Adds the criteria fields to list.
        /// </summary>
        /// <param name="field">field object</param>
        public void Add(CriteriaField field)
        {
            this.SearchFields.Add(field);
        }
        #endregion

        #region Dynamic Where Propeties
        /// <summary>
        /// Gets or sets the value of the Parameter expression of Base Type
        /// </summary>
        public ParameterExpression ParamExpression { get; set; }

        /// <summary>
        /// Gets or sets the Where expression based on given type of parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Expression<Func<T, bool>> GetExpression<T>()
        {
            return Expression.Lambda<Func<T, bool>>(this.DynamicWhereExpression, this.ParamExpression);
        }

        /// <summary>
        /// Gets or sets the value of the Advace search criteria.
        /// </summary>
        public List<AdvSearchCriteria> AdavcenceSearchCriteria { get; set; }


        /// <summary>
        /// Gets or sets the value of the DynamicWhere Expression.
        /// </summary>
        public Expression DynamicWhereExpression { get; set; }

        /// <summary>
        /// Gets or sets the value fo the fearure Table
        /// </summary>
        public string DBSearchFeatureCode { get; set; }


        #endregion
    }
}
