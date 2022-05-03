#region Header Info
//-----------------------------------------------------------------------
// <copyright file="ICache.cs" company="">
//  Copyright (c) BD Pvt. Ltd. All rights reserved.
// </copyright>
// <summary>Inteface for implementing the Cache.</summary>
// <createdby>Desayya</createdby> 
// <createddate>26-Oct-2018</createddate>
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

#endregion

namespace Calendar.Framework.Cache
{
    /// <summary>
    /// Interface for implementing the different cache provider.
    /// </summary>
    public interface ICache
    {
        #region Properties

        /// <summary>
        /// Gets or sets Default expiration time in milli seconds.
        /// </summary>
        long DefaultExpirationTime { get; set; }

        /// <summary>
        /// Gets or sets the object into cache.
        /// </summary>
        /// <param name="key">Name of the key.</param>
        /// <returns>Returns Object form the cache.</returns>
        object this[string key] 
        { 
            get; set; 
        }

        #endregion

        #region Add

        /// <summary>
        /// Adds object to the cache for the max amount of time.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="value">Object value.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        bool AddString(string key, string value, string region = null);

        /// <summary>
        /// Adds object to the cache for the max amount of time.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="value">Object value.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        bool AddType<T>(string key, T value, string region = null);

        ///// <summary>
        /////  Adds object to the cache for the max amount of time.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="key"></param>
        ///// <param name="value"></param>
        ///// <param name="region"></param>
        ///// <returns></returns>
        //bool AddCacheJson<T>(string key, T value, string region = null);

        ///// <summary>
        ///// Adds object to the cache for Default Expire time if bDefaultExpire.
        ///// is set to true otherwise for max amount of time.
        ///// </summary>
        ///// <param name="key">String key.</param>
        ///// <param name="value">Object value.</param>
        ///// <param name="defaultExpire">Expiration work on default time.</param>
        ///// <param name="region">Optional Name of the region.</param>
        ///// <returns>Return true/false.</returns>
        //bool Add(string key, object value, bool defaultExpire, string region = null);

        ///// <summary>
        ///// Add objects for specified about of time. Time is specified in milli seconds.
        ///// </summary>
        ///// <param name="key">String key.</param>
        ///// <param name="value">Object value.</param>
        ///// <param name="numofMilliSeconds">Life span of the object.</param>
        ///// <param name="region">Optional Name of the region.</param>
        ///// <returns>Return true/false.</returns>
        //bool Add(string key, object value, long numofMilliSeconds, string region = null);
        
        ///// <summary>
        ///// Add objects for specified about of time. Time is specified in milli seconds.
        ///// </summary>
        ///// <param name="key">String key.</param>
        ///// <param name="value">Object value.</param>
        ///// <param name="numofMilliSeconds">Life span of the object.</param>
        ///// <param name="region">Optional Name of the region.</param>
        ///// <returns>Return true/false.</returns>
        //bool AddType<T>(string key, T value, long numofMilliSeconds, string region = null);

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        bool BulkAdd(List<KeyValuePair<string, object>> values, string region = null);

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        bool BulkAddString(List<KeyValuePair<string, string>> values, string region = null);

        #endregion

        #region Get

        /// <summary>
        /// Return the object from cached based on the key otherwise just returns null.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns Object form the cache.</returns>
        string GetString(string key, string region = null);

        T GetType<T>(string key, string region = null);

        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        IEnumerable<KeyValuePair<string, object>> BulkGet(IEnumerable<string> keys, string region = null);

        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        IEnumerable<KeyValuePair<string, string>> BulkGetString(IEnumerable<string> keys, string region = null);

        /// <summary>
        /// Return all object belongs to the region.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>IEnumerable Key Value pair.</returns>
        IEnumerable<KeyValuePair<string, object>> GetObjectsByRegion(string region);

        /// <summary>
        /// Return all object belongs to the region.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>IEnumerable Key Value pair.</returns>
        IEnumerable<KeyValuePair<string, string>> GetStringByRegion(string region);

        #endregion

        #region Remove

        /// <summary>
        /// Clears everything from the cache on all servers.
        /// </summary>
        /// <returns>Returns tru/fase.</returns>
        bool RemoveAll();
        
        /// <summary>
        /// Removes the an object from cache.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns removed object.</returns>
        object Remove(string key, string region = null);

        /// <summary>
        /// Removes the an objects within the region from cache.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>Returns true/false based on the success.</returns>
        bool RemoveRegion(string region);

        #endregion

        #region KeyExists

        /// <summary>
        /// Checks if the key exists in memory.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true if exists, otherwise returns false.</returns>
        bool KeyExists(string key, string region = null);

        #endregion
   
    }
}
