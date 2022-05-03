#region Header Info
//-----------------------------------------------------------------------
// <copyright file="LocalBase.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Implements the machanism for calling Business Objects at runtime.</summary>
// <createdby>Desayya</createdby> 
// <createddate>26-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='Naveen' modifieddate='18-Oct-2011' revisionno='1'>Dyno form validations.</revision>
//  <revision modifiedby='Desayya' modifieddate='24-Jan-2012' revisionno='2'>Modified Dynamic forms realted methods. removed refelection calls.</revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces
using Calendar.Framework.AutoCodeGenerator;
using Calendar.Framework.Entity;
using Calendar.Framework.Rules;
using Calendar.Framework.Runtime;
using Calendar.Framework.Security;
using Calendar.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

#endregion

namespace Calendar.Framework
{
    /// <summary>
    /// Implements the machanism for calling Business Objects
    /// at runtime.
    /// </summary>
    internal class LocalBase
    {
        #region Constants

        /// <summary>
        /// Local varible for string Validatint Rules.
        /// </summary>
        private const string ValidateRules = "ValidateRules";

        /// <summary>
        /// Local variable for string RuleFailed.
        /// </summary>
        private const string RuleFailed = "RuleFailed";

        /// <summary>
        /// Local varible for string Error Message.
        /// </summary>
        private const string ErrorMessage = "Rules Failed";

        /// <summary>
        /// Local varible for method name Fetch.
        /// </summary>
        private const string FetchMethod = "Fetch";

        /// <summary>
        /// Local variable for string AutoCodeError.
        /// </summary>
        private const string AutoCodeError = "AutoCodeError";

        /// <summary>
        /// Local variable for string AutoCodeError.
        /// </summary>
        private const string AutoCodeErrorMessage = "Autocode Configuration is not available";

        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string InsertMethod = "Insert";

        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string BulkInsertMethod = "BulkInsert";

        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string UpdateMethod = "Update";
        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string DeleteMethod = "Delete";

        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string pattern = "#(.*?)#";

        /// <summary>
        /// Local varible for LucenySearchKey.
        /// </summary>
        private const string LucenySearchKey = "Saras.LuceneSearch.";

        /// <summary>
        /// Local varible for LucenySearchKey.
        /// </summary>
        private const string CreateIndex = "CreateIndex";

        /// <summary>
        /// Local varible for LucenySearchKey.
        /// </summary>
        private const string UpdateIndex = "UpdateIndex";

        /// <summary>
        /// Local varible for LucenySearchKey.
        /// </summary>
        private const string DeleteIndex = "DeleteIndex";

        /// <summary>
        /// Local varible for Workflow.
        /// </summary>
        private const string Workflow = "Workflow";

        #endregion

        #region Property : Application Context
        /// <summary>
        /// Gets or sets Application Context.
        /// </summary>
        internal ApplicationContext Context;
        #endregion

        #region Fetch
        /// <summary>
        /// Called by a factory method in a business class to retrieve
        /// an object, which is loaded with values from the data source.
        /// </summary>
        /// <param name="instance">Specific type of the business object.</param>
        /// <returns>Returns result object.</returns>
        internal object FetchObject(object instance)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            PageContext context = (PageContext)Reflection.MethodCaller.CallPropertyGetter(instance, "PageContext");
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Fetch").Replace("@EndTime", "@LB-Fetch"));
#endif

            object result = MethodCaller.CallMethod(instance, FetchMethod);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@LB-Fetch");
#endif
            return result;
        }

        internal T Fetch<T>(object instance)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            PageContext context = (PageContext)Reflection.MethodCaller.CallPropertyGetter(instance, "PageContext");
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Fetch").Replace("@EndTime", "@LB-Fetch"));
#endif

            T result = (T)MethodCaller.CallMethod(instance, FetchMethod);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@LB-Fetch");
#endif
            return result;
        }
        internal async Task<T> FetchAsync<T>(object instance)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            PageContext context = (PageContext)Reflection.MethodCaller.CallPropertyGetter(instance, "PageContext");
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Fetch").Replace("@EndTime", "@LB-Fetch"));
#endif

            T result = await (Task<T>)MethodCaller.CallMethod(instance, FetchMethod);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@LB-Fetch");
#endif
            return result;
        }

        /// <summary>
        /// Called by a factory method in a business class to retrieve
        /// an object, which is loaded with values from the data source.
        /// </summary>
        /// <param name="instance">Specific type of the business object.</param>
        /// <param name="method">Method Name.</param>
        /// <returns>Returns result object.</returns>
        public object FetchExecuteObject(object instance, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            PageContext context = (PageContext)Reflection.MethodCaller.CallPropertyGetter(instance, "PageContext");
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-FetchExecute").Replace("@EndTime", "@LB-FetchExecute"));
#endif
            object result = MethodCaller.CallMethod(instance, method);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@LB-FetchExecute");
#endif
            return result;
        }

        public T FetchExecute<T>(object instance, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            PageContext context = (PageContext)Reflection.MethodCaller.CallPropertyGetter(instance, "PageContext");
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-FetchExecute").Replace("@EndTime", "@LB-FetchExecute"));
#endif
            T result = (T)MethodCaller.CallMethod(instance, method);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@LB-FetchExecute");
#endif
            return result;
        }
        public async Task<T> FetchExecuteAsync<T>(object instance, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            PageContext context = (PageContext)Reflection.MethodCaller.CallPropertyGetter(instance, "PageContext");
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-FetchExecute").Replace("@EndTime", "@LB-FetchExecute"));
#endif
            T result = await (Task<T>)MethodCaller.CallMethod(instance, method);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(context, start, DateTime.Now, "@LB-FetchExecute");
#endif
            return result;
        }
        #endregion

        #region Process
        /// <summary>
        /// Executes the business method and calls the respective method in the business logic.
        /// </summary>
        /// <param name="instance">Actual Business object.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>Returns response object.</returns>
        internal FrameworkResponse Process<T>(object instance, string methodName)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            PageContext context = (PageContext)Reflection.MethodCaller.CallPropertyGetter(instance, "PageContext");
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Process").Replace("@EndTime", "@LB-Process"));
#endif


#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                DateTime rulesStart = DateTime.Now;
                context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", rulesStart.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Process-RulesExecution").Replace("@EndTime", "@LB-Process-RulesExecution"));
#endif
            IBusinessBase<T> businessBase = instance as IBusinessBase<T>;
            PageContext pagecontext = businessBase.PageContext;
            // Checking Autocode Configuration and calling Auto Code.


#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                UtilityManager.ApendEndTraceString(context, autoCodeStart, DateTime.Now);
                DateTime logictart = DateTime.Now;
                context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", logictart.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Actual Business Logic"));
#endif

            // create an instance of the business object.
            FrameworkResponse response = (FrameworkResponse)MethodCaller.CallMethod(instance, methodName);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                UtilityManager.ApendEndTraceString(context, logictart, DateTime.Now);
#endif


            return response;
        }

        internal async Task<FrameworkResponse> ProcessAsync<T>(object instance, string methodName)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            PageContext context = (PageContext)Reflection.MethodCaller.CallPropertyGetter(instance, "PageContext");
            context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Process").Replace("@EndTime", "@LB-Process"));
#endif


#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                DateTime rulesStart = DateTime.Now;
                context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", rulesStart.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Process-RulesExecution").Replace("@EndTime", "@LB-Process-RulesExecution"));
#endif
            IBusinessBase<T> businessBase = instance as IBusinessBase<T>;
            PageContext pagecontext = businessBase.PageContext;
            // Checking Autocode Configuration and calling Auto Code.


#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                UtilityManager.ApendEndTraceString(context, autoCodeStart, DateTime.Now);
                DateTime logictart = DateTime.Now;
                context.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", logictart.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "LB-Actual Business Logic"));
#endif

            // create an instance of the business object.
            FrameworkResponse response = await (Task<FrameworkResponse>)MethodCaller.CallMethod(instance, methodName);

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
                UtilityManager.ApendEndTraceString(context, logictart, DateTime.Now);
#endif


            return response;
        }
        #endregion

    }
}
