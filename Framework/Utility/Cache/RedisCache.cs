using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Calendar.Framework.Cache
{
    internal  class RedisCache : ICache 
    {

        private IDatabase database = null;
        private IConfiguration configuration;
        private IHttpContextAccessor httpContextAccessor;
        private readonly string organization = string.Empty;

        #region
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="httpContextAccessor"></param>
        public RedisCache(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            configuration = config;
            this.httpContextAccessor = httpContextAccessor;
            string redisCon = configuration["Cache:Connection"];
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisCon);
            database = redis.GetDatabase();
            organization = httpContextAccessor.HttpContext.Session.GetString(UtilityManager.OrganizatoinId);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context">Application Context</param>
        public RedisCache(ApplicationContext context)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("");
            database = redis.GetDatabase();
        }
        #endregion


        public long DefaultExpirationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #region Add

        /// <summary>
        /// Adds object to the cache for the max amount of time.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="value">Object value.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool AddString(string key, string value, string region = null)
        {
            return database.StringSet(this.GetKey(key), value);
        }

        /// <summary>
        /// Adds object to the cache for the max amount of time.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="value">Object value.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool AddType<T>(string key, T value, string region = null)
        {
            string json = JsonConvert.SerializeObject(value);
            return database.StringSet(this.GetKey(key), json);
        }

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool BulkAdd(List<KeyValuePair<string, object>> values, string region = null)
        {
            string json = string.Empty;
            bool result = false;
            foreach (KeyValuePair<string, object> value in values)
            {
                json = JsonConvert.SerializeObject(value.Value);
                result = database.StringSet(this.GetKey(value.Key), json);
            }
            return result;

        }

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool BulkAddString(List<KeyValuePair<string, string>> values, string region = null)
        {
            bool result = false;
            foreach (KeyValuePair<string, string> value in values)
            {
                result = database.StringSet(this.GetKey(value.Key), value.Value);
            }
            return result;

        }

        #endregion

        #region Get

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get => database.StringGet(key); set => throw new NotImplementedException();
        }

        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        public IEnumerable<KeyValuePair<string, object>> BulkGet(IEnumerable<string> keys, string region = null)
        {
            object val = null;
            List<KeyValuePair<string, object>> values = new List<KeyValuePair<string, object>>();
            foreach (string key in keys)
            {
                val = JsonConvert.DeserializeObject(database.StringGet(this.GetKey(key)));
                values.Add(new KeyValuePair<string, object>(key, val));
            }
            return values;
        }

        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        public IEnumerable<KeyValuePair<string, string>> BulkGetString(IEnumerable<string> keys, string region = null)
        {
            string val = string.Empty; ;
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
            foreach (string key in keys)
            {
                val = database.StringGet(this.GetKey(key));
                values.Add(new KeyValuePair<string, string>(key, val));
            }
            return values;
        }

        /// <summary>
        /// Return all object belongs to the region.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>IEnumerable Key Value pair.</returns>
        public IEnumerable<KeyValuePair<string, object>> GetObjectsByRegion(string region)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Return the object from cached based on the key otherwise just returns null.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns Object form the cache.</returns>
        public string GetString(string key, string region = null)
        {
            return database.StringGet(this.GetKey(key));
        }

        /// <summary>
        /// Return all object belongs to the region.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>IEnumerable Key Value pair.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetStringByRegion(string region)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the object from cached based on the key otherwise just returns null.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns Object form the cache.</returns>
        public T GetType<T>(string key, string region = null)
        {
            return JsonConvert.DeserializeObject<T>(database.StringGet(this.GetKey(key)));
        }
        #endregion

        #region Key Exists

        /// <summary>
        /// Checks if the key exists in memory.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true if exists, otherwise returns false.</returns>
        public bool KeyExists(string key, string region = null)
        {
            return database.KeyExists(this.GetKey(key));
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the an object from cache.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns removed object.</returns>
        public object Remove(string key, string region = null)
        {
            return database.KeyDelete(this.GetKey(key));
        }

        /// <summary>
        /// Clears everything from the cache on all servers.
        /// </summary>
        /// <returns>Returns tru/fase.</returns>
        public bool RemoveAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the an objects within the region from cache.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>Returns true/false based on the success.</returns>
        public bool RemoveRegion(string region)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Generate Key
        /// <summary>
        /// Appends the key with required perameters
        /// </summary>
        /// <param name="key">Name of the key.</param>
        /// <returns></returns>
        private string GetKey(string key)
        {
            return key + organization;
        }
        #endregion
    }
}
