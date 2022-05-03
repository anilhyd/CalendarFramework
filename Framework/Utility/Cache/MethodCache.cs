#region Header Info
//-----------------------------------------------------------------------
// <copyright file="MethodCache.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Gets a reference to the cached method for
// the specified business object type.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>28-Aug-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Runtime;
using System;
using System.Collections.Generic;

#endregion

namespace Calendar.Framework.Cache
{
    /// <summary>
    /// Gets a reference to the cached method for
    /// the specified business object type.
    /// </summary>
    internal class MethodCache
    {
        /// <summary>
        /// Internal dictionary for storing the cache object.
        /// </summary>
        private static Dictionary<MethodCacheKey, AttributeMethodInfo> cache = new Dictionary<MethodCacheKey, AttributeMethodInfo>();

        /// <summary>
        /// Returns the attribute infromation for the method.
        /// </summary>
        /// <param name="objectType">Type of the object to be parsed.</param>
        /// <param name="methodName">Name of the method to be parsed.</param>
        /// <param name="parameters">List of Parameters.</param>
        /// <returns>Returns method attributes.</returns>
        public static AttributeMethodInfo GetMethodInfo(Type objectType, string methodName, params object[] parameters)
        {
            var key = new MethodCacheKey(objectType.Name, methodName, MethodCaller.GetParameterTypes(parameters));
            AttributeMethodInfo result = null;
            if (!cache.TryGetValue(key, out result))
            {
                lock (cache)
                {
                    if (!cache.TryGetValue(key, out result))
                    {
                        result = new AttributeMethodInfo(MethodCaller.GetMethod(objectType, methodName, parameters));
                        cache.Add(key, result);
                    }
                }
            }

            return result;
        }
    }
}
