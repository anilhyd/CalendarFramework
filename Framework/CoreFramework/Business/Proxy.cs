using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Calendar.Framework.Utility;
using Calendar.Framework.Cache;
using Calendar.Framework.Entity;
using Calendar.Framework.Runtime;
using Calendar.Framework.Database;
using System.Threading.Tasks;

namespace Calendar.Framework
{
    internal class Proxy
    {
        #region Constants
        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string InsertMethod = "Insert";

        /// <summary>
        /// Local varible for method name Update.
        /// </summary>
        private const string UpdateMethod = "Update";

        /// <summary>
        /// Local varible for method name Delete.
        /// </summary>
        private const string DeleteMethod = "Delete";

        /// <summary>
        /// Local varible for method name Fetch.
        /// </summary>
        private const string FetchMethod = "FetchAsync";

        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string BulkInsertMethod = "BulkInsert";

        /// <summary>
        /// Local varible for method name Bulk Delete.
        /// </summary>
        private const string BulkDeleteMethod = "BulkDelete";

        /// <summary>
        /// Local constant for storing IF Cahce Name.
        /// </summary>
        private const string IFCacheName = "BD.IF";

        /// <summary>
        /// Local constant for storing IF Cahce Name.
        /// </summary>
        private const string SecurityObject = "BD.SecurityObjeect";

        /// <summary>
        /// Local varible for colon sysmbol.
        /// </summary>
        private const char Colon = ':';


        #endregion

        #region Property : Application Context
        /// <summary>
        /// Gets or sets Application Context.
        /// </summary>
        internal ApplicationContext Context;
        #endregion

        #region Fetch
        /// <summary>
        /// Called by the business object's Fetch() method to fetch records.
        /// </summary>
        /// <param name="instance">Specific type of the business object.</param>
        /// <param name="criteria">Filter Criteria.</param>
        /// <returns>A reference to the updated business object.</returns>
        internal object FetchObject<T>(object instance, Dictionary<string, string> criteria, PageContext context)
        {
            return this.Fetch<T>(instance, criteria, ApplicationContext.TransactionType, context);
        }
        internal T Fetch<T>(object instance, Dictionary<string, string> criteria, PageContext context)
        {
            return this.Fetch<T>(instance, criteria, ApplicationContext.TransactionType, context);
        }
        internal async Task<T> FetchAsync<T>(object instance, Dictionary<string, string> criteria, PageContext context)
        {
            return await this.FetchAsync<T>(instance, criteria, ApplicationContext.TransactionType, context);
        }

        /// <summary>
        /// Called by the business object's Fetch() method to fetch records.
        /// </summary>
        /// <param name="instance">Entity Object Instance.</param>
        /// <param name="criteria">Search Criteria Object.</param>
        /// <param name="method">Method Name.</param>
        /// <returns>Return Fetch Result object.</returns>
        internal List<T> ExecuteFetch<T>(object instance, Dictionary<string, string> criteria, string method, PageContext context)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Fetch").Replace("@EndTime", "@RP-Fetch"));
#endif
            //UserContext userContext = Context.UserContext;
            //if (userContext == null)
            //    throw new LoginException("SE0001", null) { ErrorCode = "SE0001" };

            List<T> objs = default(List<T>);
            LocalBase local = new LocalBase();
            objs = local.FetchExecute<List<T>>(instance, method);


#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@RP-Fetch");
#endif

            return objs;
        }
        internal async Task<List<T>> ExecuteFetchAsync<T>(object instance, Dictionary<string, string> criteria, string method, PageContext context)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Fetch").Replace("@EndTime", "@RP-Fetch"));
#endif
            //UserContext userContext = Context.UserContext;
            //if (userContext == null)
            //    throw new LoginException("SE0001", null) { ErrorCode = "SE0001" };

            List<T> objs = default(List<T>);
            LocalBase local = new LocalBase();
            objs = await local.FetchExecuteAsync<List<T>>(instance, method);


#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@RP-Fetch");
#endif

            return objs;
        }

        internal object ExecuteFetchObject<T>(object instance, Dictionary<string, string> criteria, string method, PageContext context)
        {
            return this.FetchObject<T>(instance, criteria, ApplicationContext.TransactionType, context, method);
        }

        /// <summary> 
        /// Called by the business object's Fetch() method to fetch records.
        /// </summary>
        /// <param name="instance">Specific type of the business object.</param>
        /// <param name="criteria">Filter Criteria.</param>
        /// <param name="transactionType">Transction type.</param>
        /// <returns>A reference to the updated business object.</returns>
        internal T Fetch<T>(object instance, Dictionary<string, string> criteria, TransactionalTypes transactionType, PageContext context, string method = null)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Fetch").Replace("@EndTime", "@RP-Fetch"));
#endif
            AttributeMethodInfo info = null;

            if (method == null)
                method = FetchMethod;

            info = MethodCache.GetMethodInfo(instance.GetType(), method, null);

            //UserContext userContext = Context.UserContext;
            //if (userContext == null)
            //    throw new LoginException("SE0001", null) { ErrorCode = "SE0001" };

            T obj;
            LocalBase local = new LocalBase();
            if (method == null)
                obj = local.Fetch<T>(instance);
            else
                obj = local.FetchExecute<T>(instance, method);


#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@RP-Fetch");
#endif

            return obj;
        }
        internal object FetchObject<T>(object instance, Dictionary<string, string> criteria, TransactionalTypes transactionType, PageContext context, string method = null)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Fetch").Replace("@EndTime", "@RP-Fetch"));
#endif
            AttributeMethodInfo info = null;

            if (method == null)
                method = FetchMethod;

            info = MethodCache.GetMethodInfo(instance.GetType(), method, null);

            //UserContext userContext = Context.UserContext;

            //if (userContext == null)
            //    throw new LoginException("SE0001", null) { ErrorCode = "SE0001" };

            EntityBase entity = (instance as IBusinessBase<T>).Entity as EntityBase;

            object obj = null;

            LocalBase local = new LocalBase();
            if (method == null)
                obj = local.FetchObject(instance);
            else
                obj = local.FetchExecuteObject(instance, method);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@RP-Fetch");
#endif

            return obj;
        }
        internal async Task<T> FetchAsync<T>(object instance, Dictionary<string, string> criteria, TransactionalTypes transactionType, PageContext context, string method = null)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Fetch").Replace("@EndTime", "@RP-Fetch"));
#endif
            AttributeMethodInfo info = null;

            if (method == null)
                method = FetchMethod;

            info = MethodCache.GetMethodInfo(instance.GetType(), method, null);

            //UserContext userContext = Context.UserContext;
            //if (userContext == null)
            //    throw new LoginException("SE0001", null) { ErrorCode = "SE0001" };

            T obj;
            LocalBase local = new LocalBase();
            if (method == null)
                obj = await local.FetchAsync<T>(instance);
            else
                obj = await local.FetchExecuteAsync<T>(instance, method);


#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@RP-Fetch");
#endif

            return obj;
        }


        #endregion

        #region Process
        /// <summary>
        /// Called by the business object's Insert()/Update()/Delete()/BulkInsert()/BulkDelete() method to
        /// insert the object in the database.
        /// </summary>
        /// <remarks>
        /// Note that this method returns a reference to the updated business object.
        /// If the server-side DataPortal is running remotely, this will be a new and
        /// different object from the original, and all object references MUST be updated
        /// to use this new object.
        /// </remarks>
        /// <typeparam name="T">Type of Entity Object.</typeparam>
        /// <param name="instance">Specific type of the business object.</param>
        /// <param name="context">Page context object.</param>
        /// <param name="method">Method Name.</param>
        /// <returns>A reference to the updated business object.</returns>
        internal FrameworkResponse Process<T>(object instance, PageContext context, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Process").Replace("@EndTime", "@RP-Process"));
#endif

            AttributeMethodInfo info = MethodCache.GetMethodInfo(instance.GetType(), method, null);

            FrameworkResponse response = null;

            UserContext userContext = null;
            //UserContext userContext = Context.UserContext;


            //if (userContext == null)
            //    throw new LoginException("SE0001", null) { ErrorCode = "SE0001" };

            //string featurecode = (string)MethodCaller.GetConstFieldValue(instance, "FeatureCode");
            //object featureCodes = instance.GetType().GetCustomAttributes(typeof(FeaturesAttribute), true).FirstOrDefault();

            List<T> entities = null;
            T entity = default(T);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                DateTime defaultStart = DateTime.Now;
                context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", defaultStart.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Process-AssignDefaultValues"));
#endif

            entities = (instance as IBusinessBase<T>).Entities;

            //if (method.Equals(BulkInsertMethod) || method.Equals(BulkDeleteMethod))
            if (entities != null && entities.Count > 0)
            {
                entities = (instance as IBusinessBase<T>).Entities;

                if (!method.Equals(BulkDeleteMethod))
                    foreach (object tracker in entities)
                        AssignDefaultValues(tracker, userContext);
                else
                {
                }
            }
            else
            {
                entity = (instance as IBusinessBase<T>).Entity;

                if (entity != null)
                {
                    if (!method.Equals(DeleteMethod))
                        AssignDefaultValues(entity, userContext);
                }
            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, defaultStart, DateTime.Now);
#endif

            if (context.IsTransactionRequired)
            {
                using (TransactionScope tr = new TransactionScope())
                {
                    LocalBase localbase = new LocalBase();
                    response = localbase.Process<T>(instance, method);
                    if (response.Status == Status.Success)
                    {
                        tr.Complete();
                    }
                }
            }
            else
            {
                LocalBase localbase = new LocalBase();
                response = localbase.Process<T>(instance, method);
            }

            // Code for Sending the Simple Business Event to Notification Framework
            if (response.Status == Status.Success)
            {

                //// Auditing
                ////if (method != null && method.ToString().ToLower().Equals("update"))  //context.IsAuditEnabled &&
                ////{
                //if (entity != null)
                //    AuditEventManager.Log<T>(entity, context, method);
                //else if (entities != null)
                //    AuditEventManager.Log<T>(entities, context, method);
                //}

                // Clearing Visiting
                // Clearing State Changes

                if (!method.Equals(BulkInsertMethod) && !method.Equals(BulkDeleteMethod))
                {
                    if (entity as EntityBase != null)
                    {
                        foreach (EntityBase entityObject in (entity as EntityBase).EntityObjects)
                        {
                            entityObject.IsVisited = false;
                            entityObject.RowState = EntityState.Unchanged;
                        }
                    }
                }
            }
            else if (response.Status == Status.Failed)
            {

            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@RP-Process");
#endif

            return response;
        }
        internal async Task<FrameworkResponse> ProcessAsync<T>(object instance, PageContext context, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Process").Replace("@EndTime", "@RP-Process"));
#endif

            AttributeMethodInfo info = MethodCache.GetMethodInfo(instance.GetType(), method, null);

            FrameworkResponse response = null;

            UserContext userContext = null;
            //UserContext userContext = Context.UserContext;


            //if (userContext == null)
            //    throw new LoginException("SE0001", null) { ErrorCode = "SE0001" };

            //string featurecode = (string)MethodCaller.GetConstFieldValue(instance, "FeatureCode");
            //object featureCodes = instance.GetType().GetCustomAttributes(typeof(FeaturesAttribute), true).FirstOrDefault();

            List<T> entities = null;
            T entity = default(T);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                DateTime defaultStart = DateTime.Now;
                context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", defaultStart.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "RP-Process-AssignDefaultValues"));
#endif

            entities = (instance as IBusinessBase<T>).Entities;

            //if (method.Equals(BulkInsertMethod) || method.Equals(BulkDeleteMethod))
            if (entities != null && entities.Count > 0)
            {
                entities = (instance as IBusinessBase<T>).Entities;

                if (!method.Equals(BulkDeleteMethod))
                    foreach (object tracker in entities)
                        AssignDefaultValues(tracker, userContext);
                else
                {
                }
            }
            else
            {
                entity = (instance as IBusinessBase<T>).Entity;

                if (entity != null)
                {
                    if (!method.Equals(DeleteMethod))
                        AssignDefaultValues(entity, userContext);
                }
            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, defaultStart, DateTime.Now);
#endif

            if (context.IsTransactionRequired)
            {
                using (TransactionScope tr = new TransactionScope())
                {
                    LocalBase localbase = new LocalBase();
                    response = await localbase.ProcessAsync<T>(instance, method);
                    if (response.Status == Status.Success)
                    {
                        tr.Complete();
                    }
                }
            }
            else
            {
                LocalBase localbase = new LocalBase();
                response = await localbase.ProcessAsync<T>(instance, method);
            }

            // Code for Sending the Simple Business Event to Notification Framework
            if (response.Status == Status.Success)
            {

                //// Auditing
                ////if (method != null && method.ToString().ToLower().Equals("update"))  //context.IsAuditEnabled &&
                ////{
                //if (entity != null)
                //    AuditEventManager.Log<T>(entity, context, method);
                //else if (entities != null)
                //    AuditEventManager.Log<T>(entities, context, method);
                //}

                // Clearing Visiting
                // Clearing State Changes

                if (!method.Equals(BulkInsertMethod) && !method.Equals(BulkDeleteMethod))
                {
                    if (entity as EntityBase != null)
                    {
                        foreach (EntityBase entityObject in (entity as EntityBase).EntityObjects)
                        {
                            entityObject.IsVisited = false;
                            entityObject.RowState = EntityState.Unchanged;
                        }
                    }
                }
            }
            else if (response.Status == Status.Failed)
            {

            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@RP-Process");
#endif

            return response;
        }
        #endregion

        /// <summary>
        /// Generates the Cache key by using the assembly type, method name and Parameters.
        /// </summary>
        /// <param name="instance">Business logic object.</param>
        /// <param name="method">Name of the method.</param>
        /// <param name="criteria">Filter criteria object.</param>
        /// <returns>Returns the cache key.</returns>
        private string GetCacheKey(object instance, string method, Dictionary<string, string> criteria)
        {
            StringBuilder cacheKey = new StringBuilder();

            cacheKey.Append(instance.GetType().Assembly.GetName().Name);
            cacheKey.Append(Colon);
            cacheKey.Append(instance.GetType().Name);
            cacheKey.Append(Colon);
            cacheKey.Append(method);
            if (criteria != null)
            {
                foreach (KeyValuePair<string, string> field in criteria)
                {
                    cacheKey.Append(field.Key);
                    cacheKey.Append(Colon);
                    cacheKey.Append(field.Value);
                    cacheKey.Append(Colon);
                }
            }

            return cacheKey.ToString();
        }

        private void SaveObjectIntoCache(AttributeMethodInfo info, string cacheKey, object obj, object instance)
        {
            long expiry = default(long);

            switch (info.Duration)
            {
                case CacheDuration.LongDuration:
                    //expiry = SAF.Config.CachingConfigurator.GetCachingConfigData(SAF.Common.UtilityManager.OrganizationKey).LongDurationExpire;
                    break;
                case CacheDuration.MediumDuration:
                    //expiry = SAF.Config.CachingConfigurator.GetCachingConfigData(SAF.Common.UtilityManager.OrganizationKey).MediumDurationExpire;
                    break;
                case CacheDuration.ShortDuration:
                    //expiry = SAF.Config.CachingConfigurator.GetCachingConfigData(SAF.Common.UtilityManager.OrganizationKey).ShortDurationExpire;
                    break;
                default:
                    //expiry = SAF.Config.CachingConfigurator.GetCachingConfigData(SAF.Common.UtilityManager.OrganizationKey).DefaultCacheExpire;
                    break;
            }
            if ((obj as EntityBase) == null)
                // Adding colleciton object into cache using the region. This region will be 
                // cleared if any one of the object has been added, modified or deleted.
                //Cache.CacheManager.AddType<object>(cacheKey, obj, expiry, instance.GetType().Name);
                CacheManager.AddType<object>(cacheKey, obj, instance.GetType().Name);
            else
                // Adding Object to cache with out region.
                //Cache.CacheManager.AddType<object>(cacheKey, obj, expiry);
                CacheManager.AddType<object>(cacheKey, obj);

        }

        private void AssignDefaultValues<T>(T entity, UserContext context)
        { 
            
        }
    }
}
