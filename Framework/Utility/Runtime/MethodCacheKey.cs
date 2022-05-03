#region Header Info
//-----------------------------------------------------------------------
// <copyright file="MethodCacheKey.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Cache manager for holding the Cache keys.</summary>
// <createdby>Desayya</createdby> 
// <createddate>11-July-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;

#endregion

namespace Calendar.Framework.Runtime
{
    /// <summary>
    /// Cache manager for holding the Cache keys.
    /// </summary>
    internal class MethodCacheKey
    {
        /// <summary>
        /// Key to Hash.
        /// </summary>
        private int hashKey;

        /// <summary>
        /// Initializes a new instance of the MethodCacheKey class
        /// Constructor with Parameters Name, method and types.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="methodName">Nane of the method.</param>
        /// <param name="paramTypes">Parameter types.</param>
        public MethodCacheKey(string typeName, string methodName, Type[] paramTypes)
        {
            this.TypeName = typeName;
            this.MethodName = methodName;
            this.ParamTypes = paramTypes;

            this.hashKey = typeName.GetHashCode();
            this.hashKey = this.hashKey ^ methodName.GetHashCode();
            foreach (Type item in paramTypes)
                this.hashKey = this.hashKey ^ item.Name.GetHashCode();
        }

        /// <summary>
        /// Gets the Name of the type to be cached.
        /// </summary>
        public string TypeName { get; private set; }

        /// <summary>
        /// Gets the Name of the method to be cached.
        /// </summary>
        public string MethodName { get; private set; }

        /// <summary>
        /// Gets the Parameter types to be cached.
        /// </summary>
        public Type[] ParamTypes { get; private set; }

        /// <summary>
        /// Verifies the objet with cahce.
        /// </summary>
        /// <param name="obj">Object to be checked.</param>
        /// <returns>Returns true/false based on the comparision.</returns>
        public override bool Equals(object obj)
        {
            MethodCacheKey key = obj as MethodCacheKey;
            if (key != null &&
                key.TypeName == this.TypeName &&
                key.MethodName == this.MethodName &&
                this.ArrayEquals(key.ParamTypes, this.ParamTypes))
                return true;

            return false;
        }

        /// <summary>
        /// Return the key for hash.
        /// </summary>
        /// <returns>Returns the key for hash.</returns>
        public override int GetHashCode()
        {
            return this.hashKey;
        }

        /// <summary>
        /// Verifies two arrays are equal or not.
        /// </summary>
        /// <param name="a1">First Array.</param>
        /// <param name="a2">Second Array.</param>
        /// <returns>Returns True/fase based on the comparision.</returns>
        private bool ArrayEquals(Type[] a1, Type[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int pos = 0; pos < a1.Length; pos++)
                if (a1[pos] != a2[pos])
                    return false;
            return true;
        }
    }
}