#region Header Info
//-----------------------------------------------------------------------
// <copyright file="DynamicMemberHandle.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Handles Dynamic members.</summary>
// <createdby>Desayya</createdby> 
// <createddate>11-July-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

#endregion

namespace Calendar.Framework.Runtime
{
    /// <summary>
    /// Handles Dynamic members.
    /// </summary>
    internal class DynamicMemberHandle
    {
        /// <summary>
        /// Initializes a new instance of the DynamicMemberHandle class.
        /// </summary>
        /// <param name="memberName">Namae of the property/method.</param>
        /// <param name="memberType">Type of member.</param>
        /// <param name="dynamicMemberGet">Dynamic delegate for get.</param>
        /// <param name="dynamicMemberSet">Dynamic delegate for set.</param>
        public DynamicMemberHandle(string memberName, Type memberType, DynamicMemberGetDelegate dynamicMemberGet, DynamicMemberSetDelegate dynamicMemberSet)
        {
            this.MemberName = memberName;
            this.MemberType = memberType;
            this.DynamicMemberGet = dynamicMemberGet;
            this. DynamicMemberSet = dynamicMemberSet;
        }

        /// <summary>
        /// Initializes a new instance of the DynamicMemberHandle class.
        /// </summary>
        /// <param name="info">Discovers the attributes of a property and provides access to property metadata.</param>
        public DynamicMemberHandle(PropertyInfo info) :
            this(
                info.Name,
                info.PropertyType,
                DynamicMethodHandlerFactory.CreatePropertyGetter(info),
                DynamicMethodHandlerFactory.CreatePropertySetter(info))
        { 
        }

        /// <summary>
        /// Initializes a new instance of the DynamicMemberHandle class.
        /// </summary>
        /// <param name="info">Discovers the attributes of a field and provides access to field metadata.</param>
        public DynamicMemberHandle(FieldInfo info) :
            this(
                info.Name,
                info.FieldType,
                DynamicMethodHandlerFactory.CreateFieldGetter(info),
                DynamicMethodHandlerFactory.CreateFieldSetter(info))
        {
        }

        /// <summary>
        /// Gets Name of the member.
        /// </summary>
        public string MemberName { get; private set; }

        /// <summary>
        /// Gets Type of the member.
        /// </summary>
        public Type MemberType { get; private set; }

        /// <summary>
        /// Gets Dynamic delegate for get.
        /// </summary>
        public DynamicMemberGetDelegate DynamicMemberGet { get; private set; }

        /// <summary>
        /// Gets the Dynamic delegate for set.
        /// </summary>
        public DynamicMemberSetDelegate DynamicMemberSet { get; private set; }
    }
}