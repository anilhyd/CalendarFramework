#region Header Info
//-----------------------------------------------------------------------
// <copyright file="AttributeMethodInfo.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>stores the attribues added to the methods.</summary>
// <createdby>Desayya</createdby> 
// <createddate>28-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='N. Desayya' modifieddate='17-3-2011' revisionno='2.0'>
//  Added new methods for supporting the Notification Framework. Added code for getting the LogMessageCode and
//  Log Columns</revision>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Utility;
using System;
using System.Collections.Generic;

#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// Stores the attribues added to the methods.
    /// </summary>
    internal class AttributeMethodInfo
    {
        /// <summary>
        /// Initializes a new instance of the AttributeMethodInfo class.
        /// </summary>
        public AttributeMethodInfo()
        {
            this.Cachable = false;
            this.TransactionalType = TransactionalTypes.Manual;
            this.AllowAccessToSuperAdmin = false;
            this.DependencyCheck = false;
        }

        /// <summary>
        /// Initializes a new instance of the AttributeMethodInfo class.
        /// </summary>
        /// <param name="info">Method object.</param>
        public AttributeMethodInfo(System.Reflection.MethodInfo info) : this()
        {
            if (info != null)
            {
                this.Cachable = IsCachable(info);
                this.TransactionalType = GetTransactionalType(info);
                this.AllowAccessToSuperAdmin = IsAllowAccessToSuperAdmin(info);
                this.Privilege = this.GetPrivilege(info);
                this.LogMessageCode = this.GetLogMessageCode(info);
                this.LogColumns = this.GetLogColumns(info);
                this.LogMessageTitle = this.GetLogMessageTitle(info);
            }
        }

        #region Properties

        /// <summary>
        /// Gets a value indicating whether true or false.
        /// </summary> 
        public bool DependencyCheck { get; private set; }

        /// <summary>
        /// Gets a value indicating whether true or false.
        /// </summary> 
        public bool Cachable { get; private set; }

        /// <summary>
        /// Gets a value indicating whether true or false.
        /// </summary> 
        public CacheDuration Duration { get; private set; }

        /// <summary>
        /// Gets a value indicating whether transactional type.
        /// </summary>
        public TransactionalTypes TransactionalType { get; private set; }

        /// <summary>
        /// Gets a value indicating whether Allow Access to Superadmin atrribute as set or not.
        /// </summary> 
        public bool AllowAccessToSuperAdmin { get; private set; }

        /// <summary>
        /// Gets a value for Privilege.
        /// </summary>
        public string Privilege { get; private set; }

        /// <summary>
        /// Gets a value for Logging Message Code.
        /// </summary>
        public string LogMessageCode { get; private set; }

        /// <summary>
        /// Gets a value for Logging Message Title.
        /// </summary>
        public string LogMessageTitle { get; private set; }

        /// <summary>
        /// Gets a value for Logging Columns.
        /// </summary>
        public List<string> LogColumns { get; private set; }

        /// <summary>
        ///  Gets a value indicating type of License.
        /// </summary>
        public LicenseTypes LicenseType { get; private set; }
        
        /// <summary>
        ///  Gets a value for LicenseParameter.
        /// </summary>
        public string LicenseParameter { get; private set; }
        #endregion

 
        /// <summary>
        /// Checks whether cachable attribute has been added or not.
        /// </summary>
        /// <param name="method">Method information.</param>
        /// <returns>Returns tru/false.</returns>
        private bool IsCachable(System.Reflection.MethodInfo method)
        {
            bool result = false;
            if (Attribute.IsDefined(method, typeof(CacheAttribute), false))
            {
                result = true;
                CacheAttribute attrib = (CacheAttribute)Attribute.GetCustomAttribute(method, typeof(CacheAttribute));
                this.Duration = attrib.Duration;
            }
            return result;
        }

        /// <summary>
        /// Checks whether transactional attribute has been added or not.
        /// </summary>
        /// <param name="method">Method information.</param>
        /// <returns>Returns tru/false.</returns>
        private static bool IsTransactionalMethod(System.Reflection.MethodInfo method)
        {
            return Attribute.IsDefined(method, typeof(TransactionalAttribute));
        }

        /// <summary>
        /// Checks whether cachable attribute has been added or not.
        /// </summary>
        /// <param name="method">Method information.</param>
        /// <returns>Returns tru/false.</returns>
        private static bool IsAllowAccessToSuperAdmin(System.Reflection.MethodInfo method)
        {
            return Attribute.IsDefined(method, typeof(AllowAccessToSuperAdminAttribute), false);
        }

        /// <summary>
        /// Returns the Transaction type value assigned.
        /// </summary>
        /// <param name="method">Method information.</param>
        /// <returns>Returns Transaction type.</returns>
        private static TransactionalTypes GetTransactionalType(System.Reflection.MethodInfo method)
        {
            TransactionalTypes result;
            if (IsTransactionalMethod(method))
            {
                TransactionalAttribute attrib = (TransactionalAttribute)Attribute.GetCustomAttribute(method, typeof(TransactionalAttribute));
                result = attrib.TransactionType;
            }
            else
                result = TransactionalTypes.Manual;

            return result;
        }

        /// <summary>
        /// Checks whether transactional attribute has been added or not.
        /// </summary>
        /// <param name="method">Method information.</param>
        /// <returns>Returns tru/false.</returns>
        private string GetPrivilege(System.Reflection.MethodInfo method)
        {
            string result = string.Empty;
            if (Attribute.IsDefined(method, typeof(PrivilegeAttribute), false))
            {
                PrivilegeAttribute attrib = (PrivilegeAttribute)Attribute.GetCustomAttribute(method, typeof(PrivilegeAttribute));
                return attrib.Name;
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// Checks whether LogMessageCode attribute has been added or not. If Yes returns Message code 
        /// otherwise return String.Empty
        /// </summary>
        /// <param name="method">Method information.</param>
        /// <returns>Returns MessageCode.</returns>
        private string GetLogMessageCode(System.Reflection.MethodInfo method)
        {
            string result = string.Empty;
            if (Attribute.IsDefined(method, typeof(LogMessageCodeAttribute), false))
            {
                LogMessageCodeAttribute attrib = (LogMessageCodeAttribute)Attribute.GetCustomAttribute(method, typeof(LogMessageCodeAttribute));
                return attrib.MessageCode;
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// Checks whether Message Title attribute has been added or not. If Yes returns Message Title 
        /// otherwise return String.Empty
        /// </summary>
        /// <param name="method">Method information.</param>
        /// <returns>Returns Message Title.</returns>
        private string GetLogMessageTitle(System.Reflection.MethodInfo method)
        {
            string result = string.Empty;
            if (Attribute.IsDefined(method, typeof(LogMessageCodeAttribute), false))
            {
                LogMessageCodeAttribute attrib = (LogMessageCodeAttribute)Attribute.GetCustomAttribute(method, typeof(LogMessageCodeAttribute));
                return attrib.MessageTitle;
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// Retuns all Log Column names.
        /// </summary>
        /// <param name="method">Method information.</param>
        /// <returns>Returns List<ColumnNames></ColumnNames>.</returns>
        private List<string> GetLogColumns(System.Reflection.MethodInfo method)
        {
            object[] attrs = method.GetCustomAttributes(false);
            List<string> result = new List<string>();
            foreach (object column in attrs)
            {
                if (column.GetType().Equals(typeof(LogColumnAttribute)))
                {
                    LogColumnAttribute attribute = column as LogColumnAttribute;
                    result.Add(attribute.ColumnName);
                }
            }
            return result;
        }
    }
}