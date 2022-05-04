#region Header Info
//-----------------------------------------------------------------------
// <copyright file="BusinessBase.cs" company="Calendar.Framework">
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

using Calendar.Framework.Rules;
using Calendar.Framework.Runtime;
using Calendar.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Calendar.Framework
{
    [Serializable()]
    public abstract class BusinessBase<T> : IBusinessBase<T>
    {

        #region Constants

        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string InsertMethod = "Insert";
        private const string InsertMethodAsync = "InsertAsync";

        /// <summary>
        /// Local varible for method name save.
        /// </summary>
        private const string BulkInsertMethod = "BulkInsert";
        private const string BulkInsertMethodAsync = "BulkInsertAsync";

        /// <summary>
        /// Local varible for method name update.
        /// </summary>
        private const string UpdateMethod = "Update";
        private const string UpdateMethodAsync = "UpdateAsync";

        /// <summary>
        /// Local varible for method name Delete.
        /// </summary>
        private const string DeleteMethod = "Delete";
        private const string DeleteMethodAsync = "DeleteAsync";

        /// <summary>
        /// Local varible for method name Delete.
        /// </summary>
        private const string BulkDeleteMethod = "BulkDelete";
        private const string BulkDeleteMethodAsync = "BulkDeleteAsync";

        /// <summary>
        /// Local varible for method name Fetch.
        /// </summary>
        private const string FetchMethod = "Fetch";
        private const string FetchMethodAsync = "FetchAsync";

        /// <summary>
        /// Local varible for method name Execute.
        /// </summary>
        private const string ExecuteMethod = "Execute";
        private const string ExecuteMethodAsync = "ExecuteAsync";

        /// <summary>
        /// Local varible for method name Execute.
        /// </summary>
        private const string FetchExecuteMethod = "FetchExecute";
        private const string FetchExecuteMethodAsync = "FetchExecuteAsync";
        #endregion

        private static Proxy proxy;

        #region Constructor

        /// <summary>
        /// Initializes static members of the BusinessBase class.
        /// Configure .NET Remoting to use a binary
        /// serialization technology even when using
        /// the HTTP channel. Also ensures that the
        /// user's Windows credentials are passed to
        /// the server appropriately.
        /// </summary>
        static BusinessBase()
        {
            proxy = new Proxy();
        }
        #endregion

        #region Property : Entity Object

        /// <summary>
        /// Gets or sets the Entity object.
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        /// Gets or sets the Entity object.
        /// </summary>
        public List<T> Entities { get; set; }

        #endregion

        #region Property : Criteria

        /// <summary>
        /// Gets or sets the filtring criteria.
        /// </summary>
        public Dictionary<string, string> Criteria { get; set; }
        public object CriteriaAdv { get; set; }
        #endregion

        #region Property : FrameworkResponse

        /// <summary>
        /// Gets or sets the filtring criteria.
        /// </summary>
        public FrameworkResponse response { get; set; }

        #endregion

        #region Property : PageContext

        /// <summary>
        /// Gets or sets the PageContext object.
        /// </summary>
        public PageContext PageContext { get; set; }

        #endregion

        #region IOperation Members

        /// <summary>
        /// Saves the object to the database.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Calling this method starts the save operation, causing the object
        /// to be inserted, updated or deleted within the database based on the
        /// object's current state.
        /// </para><para>
        /// It is important to note that this method returns a new version of the
        /// business object that contains any data updated during the save operation.
        /// You MUST update all object references to use this new version of the
        /// business object in order to have access to the correct object data.
        /// </para><para>
        /// You can override this method to add your own custom behaviors to the save
        /// operation. For instance, you may add some security checks to make sure
        /// the user can save the object. If all security checks pass, you would then
        /// invoke the base Save method via <c>base.Save().</c>.
        /// </para>
        /// </remarks>
        /// <param name="entity">Typed entity object.</param>
        /// <returns>A new object containing the saved values.</returns>
        public FrameworkResponse Insert(T entity)
        {
            this.Entity = entity;
            FrameworkResponse response = this.Process(InsertMethod);
            return response;
        }
        
        public async Task<FrameworkResponse> InsertAsync(T entity)
        {
            this.Entity = entity;
            FrameworkResponse response = await this.ProcessAsync(InsertMethodAsync);
            return response;
        }

        /// <summary>
        /// Saves the bulk objects to the database.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Calling this method starts the save operation, causing the object
        /// to be inserted, updated or deleted within the database based on the
        /// object's current state.
        /// </para><para>
        /// It is important to note that this method returns a new version of the
        /// business object that contains any data updated during the save operation.
        /// You MUST update all object references to use this new version of the
        /// business object in order to have access to the correct object data.
        /// </para><para>
        /// You can override this method to add your own custom behaviors to the save
        /// operation. For instance, you may add some security checks to make sure
        /// the user can save the object. If all security checks pass, you would then
        /// invoke the base Save method via <c>base.Save().</c>.
        /// </para>
        /// </remarks>
        /// <param name="entities">Typed entity object.</param>
        /// <returns>A new object containing the saved values.</returns>
        public FrameworkResponse BulkInsert(List<T> entities)
        {
            this.Entities = entities;
            return this.Process(BulkInsertMethod);
        }

        public async Task<FrameworkResponse> BulkInsertAsync(List<T> entities)
        {
            this.Entities = entities;
            return await this.ProcessAsync(BulkInsertMethodAsync);
        }

        /// <summary>
        /// Saves the object to the database.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Calling this method starts the save operation, causing the object
        /// to be inserted, updated or deleted within the database based on the
        /// object's current state.
        /// </para><para>
        /// It is important to note that this method returns a new version of the
        /// business object that contains any data updated during the save operation.
        /// You MUST update all object references to use this new version of the
        /// business object in order to have access to the correct object data.
        /// </para><para>
        /// You can override this method to add your own custom behaviors to the save
        /// operation. For instance, you may add some security checks to make sure
        /// the user can save the object. If all security checks pass, you would then
        /// invoke the base Save method via <c>base.Save().</c>.
        /// </para>
        /// </remarks>
        /// <param name="entity">Typed entity object.</param>
        /// <returns>A new object containing the saved values.</returns>
        public FrameworkResponse Update(T entity)
        {
            this.Entity = entity;
            return this.Process(UpdateMethod);
        }

        public async Task<FrameworkResponse> UpdateAsync(T entity)
        {
            this.Entity = entity;
            return await this.ProcessAsync(UpdateMethodAsync);
        }

        /// <summary>
        /// Deletes the object from the database.
        /// </summary>
        /// <param name="entity">Typed entity object.</param>
        /// <returns>A Response object containing the saved values and process status.</returns>
        public FrameworkResponse Delete(T entity)
        {
            this.Entity = entity;
            return this.Process(DeleteMethod);
        }
        public async Task<FrameworkResponse> DeleteAsync(T entity)
        {
            this.Entity = entity;
            return await this.ProcessAsync(DeleteMethodAsync);
        }

        /// <summary>
        /// Deletes the bulk objecta from the database.
        /// </summary>
        /// <param name="entities">Typed Entity object.</param>
        /// <returns>A Response object containing the saved values and process status.</returns>
        public FrameworkResponse BulkDelete(List<T> entities)
        {
            this.Entities = entities;
            return this.Process(BulkDeleteMethod);
        }
        public async Task<FrameworkResponse> BulkDeleteAsync(List<T> entities)
        {
            this.Entities = entities;
            return await this.ProcessAsync(BulkDeleteMethodAsync);
        }

        /// <summary>
        /// Fetches the results from the databased after applying the filters
        /// included in the criteria object.
        /// </summary>
        /// <param name="criteria">Fileter condistions.</param>
        /// <returns>Retusn  results.</returns>
        public object FetchObject(Dictionary<string, string> criteria)
        {
            object response = null;
            try
            {
                this.Criteria = criteria;
                response = proxy.FetchObject<T>(this, criteria, PageContext);
            }
            catch (FrameworkException)
            {
                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception)
            {
                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

            return response;
        }

        public T Fetch(Dictionary<string, string> criteria)
        {
            T response = default(T);
            try
            {
                this.Criteria = criteria;
                response = proxy.Fetch<T>(this, criteria, PageContext);
            }
            catch (FrameworkException)
            {
                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception)
            {
                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

            return response;
        }

        public async Task<T> FetchAsync(Dictionary<string, string> criteria)
        {
            T response = default(T);
            try
            {
                this.Criteria = criteria;
                response = await proxy.FetchAsync<T>(this, criteria, PageContext);
            }
            catch (FrameworkException)
            {
                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception)
            {
                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Fetches the results from the databased after applying the filters
        /// included in the criteria object.
        /// </summary>
        /// <param name="criteria">Fileter condistions.</param>
        /// <param name="method">Method Name.</param>
        /// <returns>Retusn  results.</returns>
        public List<T> ExceuteFetch(Dictionary<string, string> criteria, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            this.PageContext.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "BB-FetchExecute").Replace("@EndTime", "@BB-FetchExecute"));
#endif
            List<T> response = default(List<T>);
            try
            {
                this.Criteria = criteria;
#if FAKEBO
                // create an instance of the business object.
                return MethodCaller.CallMethod(this, method);
#endif
                response = proxy.ExecuteFetch<T>(this, criteria, method, PageContext);
            }
            //catch (SAF.Core.Security.LoginException)
            //{
            //    throw;
            //}
            catch (FrameworkException)
            {
                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception)
            {
                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(PageContext, start, DateTime.Now, "@BB-FetchExecute");
            UtilityManager.WriteTraceLog(start, FetchExecuteMethod, PageContext, null);
#endif

            return response;
        }
        public async Task<List<T>> ExceuteFetchAsync(Dictionary<string, string> criteria, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            this.PageContext.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "BB-FetchExecute").Replace("@EndTime", "@BB-FetchExecute"));
#endif
            List<T> response = default(List<T>);
            try
            {
                this.Criteria = criteria;
#if FAKEBO
                // create an instance of the business object.
                return MethodCaller.CallMethod(this, method);
#endif
                response = await proxy.ExecuteFetchAsync<T>(this, criteria, method, PageContext);
            }
            //catch (SAF.Core.Security.LoginException)
            //{
            //    throw;
            //}
            catch (FrameworkException)
            {
                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception)
            {
                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(PageContext, start, DateTime.Now, "@BB-FetchExecute");
            UtilityManager.WriteTraceLog(start, FetchExecuteMethod, PageContext, null);
#endif

            return response;
        }

        public object ExceuteFetchObject(Dictionary<string, string> criteria, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            this.PageContext.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "BB-FetchExecute").Replace("@EndTime", "@BB-FetchExecute"));
#endif
            object response = null;
            try
            {
                this.Criteria = criteria;
#if FAKEBO
                // create an instance of the business object.
                return MethodCaller.CallMethod(this, method);
#endif
                response = proxy.ExecuteFetch<T>(this, criteria, method, PageContext);
            }
            //catch (SAF.Core.Security.LoginException)
            //{
            //    throw;
            //}
            catch (FrameworkException)
            {
                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception)
            {
                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(PageContext, start, DateTime.Now, "@BB-FetchExecute");
            UtilityManager.WriteTraceLog(start, FetchExecuteMethod, PageContext, null);
#endif

            return response;
        }

        public async Task<FrameworkResponse> ExceuteFRAsync(Dictionary<string, string> criteria, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            this.PageContext.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "BB-FetchExecute").Replace("@EndTime", "@BB-FetchExecute"));
#endif
            FrameworkResponse response = default(FrameworkResponse);
            try
            {
                this.Criteria = criteria;
#if FAKEBO
                // create an instance of the business object.
                return MethodCaller.CallMethod(this, method);
#endif
                response = await proxy.ExceuteFRAsync<T>(this, criteria, method, PageContext);
            }
            //catch (SAF.Core.Security.LoginException)
            //{
            //    throw;
            //}
            catch (FrameworkException)
            {
                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception)
            {
                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(PageContext, start, DateTime.Now, "@BB-FetchExecute");
            UtilityManager.WriteTraceLog(start, FetchExecuteMethod, PageContext, null);
#endif

            return response;
        }

        public async Task<FrameworkResponse> ExceuteFRAsync(object criteria, string method)
        {
#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            DateTime start = DateTime.Now;
            this.PageContext.TraceMessage.Append(UtilityManager.TraceStart.Replace("@StartTime", start.ToString("dd/MM/yyyy HH:mm:ss:fffffff")).Replace("@Method", "BB-FetchExecute").Replace("@EndTime", "@BB-FetchExecute"));
#endif
            FrameworkResponse response = default(FrameworkResponse);
            try
            {
                this.CriteriaAdv = criteria;
#if FAKEBO
                // create an instance of the business object.
                return MethodCaller.CallMethod(this, method);
#endif
                response = await proxy.ExceuteFRAsync<T>(this, criteria, method, PageContext);
            }
            //catch (SAF.Core.Security.LoginException)
            //{
            //    throw;
            //}
            catch (FrameworkException)
            {
                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception)
            {
                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

#if TRACELOG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
            UtilityManager.ApendEndTraceString(PageContext, start, DateTime.Now, "@BB-FetchExecute");
            UtilityManager.WriteTraceLog(start, FetchExecuteMethod, PageContext, null);
#endif

            return response;
        }
        #endregion

        #region Excecute
        /// <summary>
        /// Saves the object to the database.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Calling this method starts the save operation, causing the object
        /// to be inserted, updated or deleted within the database based on the
        /// object's current state.
        /// </para><para>
        /// It is important to note that this method returns a new version of the
        /// business object that contains any data updated during the save operation.
        /// You MUST update all object references to use this new version of the
        /// business object in order to have access to the correct object data.
        /// </para><para>
        /// You can override this method to add your own custom behaviors to the save
        /// operation. For instance, you may add some security checks to make sure
        /// the user can save the object. If all security checks pass, you would then
        /// invoke the base Save method via <c>base.Save()</c>.
        /// </para>
        /// </remarks>
        /// <param name="entity">Typed entity object.</param>
        /// <param name="method">Method Name.</param>
        /// <returns>A new object containing the saved values.</returns>
        protected FrameworkResponse Execute(T entity, string method)
        {
            this.Entity = entity;
            FrameworkResponse response = this.Process(method);
            return response;
        }

        protected FrameworkResponse Execute(List<T> entities, string method)
        {
            this.Entities = entities;
            FrameworkResponse response = this.Process(method);
            return response;
        }

        /// <summary>
        /// Saves the object to the database.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Calling this method starts the save operation, causing the object
        /// to be inserted, updated or deleted within the database based on the
        /// object's current state.
        /// </para><para>
        /// It is important to note that this method returns a new version of the
        /// business object that contains any data updated during the save operation.
        /// You MUST update all object references to use this new version of the
        /// business object in order to have access to the correct object data.
        /// </para><para>
        /// You can override this method to add your own custom behaviors to the save
        /// operation. For instance, you may add some security checks to make sure
        /// the user can save the object. If all security checks pass, you would then
        /// invoke the base Save method via <c>base.Save()</c>.
        /// </para>
        /// </remarks>
        /// <param name="entity">Typed entity object.</param>
        /// <param name="method">Method Name.</param>
        /// <returns>A new object containing the saved values.</returns>
        protected async Task<FrameworkResponse> ExecuteAsync(Dictionary<string, string> criteria, string method)
        {
            this.Criteria = criteria;
            FrameworkResponse response = await this.ProcessAsync(method);
            return response;
        }

        protected async Task<FrameworkResponse> ExecuteAsync(T entity, string method)
        {
            this.Entity = entity;
            FrameworkResponse response = await this.ProcessAsync(method);
            return response;
        }

        protected async Task<FrameworkResponse> ExecuteAsync(List<T> entities, string method)
        {
            this.Entities = entities;
            FrameworkResponse response = await this.ProcessAsync(method);
            return response;
        }

        /// <summary>
        /// Saves the object to the database.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Calling this method starts the save operation, causing the object
        /// to be inserted, updated or deleted within the database based on the
        /// object's current state.
        /// </para><para>
        /// It is important to note that this method returns a new version of the
        /// business object that contains any data updated during the save operation.
        /// You MUST update all object references to use this new version of the
        /// business object in order to have access to the correct object data.
        /// </para><para>
        /// You can override this method to add your own custom behaviors to the save
        /// operation. For instance, you may add some security checks to make sure
        /// the user can save the object. If all security checks pass, you would then
        /// invoke the base Save method via <c>base.Save()</c>.
        /// </para>
        /// </remarks>
        /// <param name="entity">Typed entity object.</param>
        /// <param name="method">Method Name.</param>
        /// <returns>A new object containing the saved values.</returns>
        protected FrameworkResponse Execute(Dictionary<string, string> criteria, string method)
        {
            this.Criteria = criteria;
            FrameworkResponse response = this.Process(method);
            return response;
        }
        #endregion

        #region Process
        /// <summary>
        /// Executes the business method and calls the respective method in the business logic.
        /// </summary>
        /// <param name="method">Name of the method.</param>
        /// <returns>Returns response object.</returns>
        private FrameworkResponse Process(string method)
        {
            FrameworkResponse response = null;
            try
            {
                response = proxy.Process<T>(this, this.PageContext, method);
                if (response.Status == Status.Success)
                {
                    if (!(method.Equals(DeleteMethod) || method.Equals(BulkDeleteMethod)))
                        this.OnSaved(this.Entity);
                }
            }
            catch (BrokenRuleException ex)
            {
                //BrokenRuleException exception = new BrokenRuleException(ex.Message) { ErrorCode = ex.ErrorCode, BrokenRules = ex.BrokenRules, RowNumber = ex.RowNumber };
                //throw exception;
                response = new FrameworkResponse() { Status = Status.Failed };
                response.BrokenRules = ex.BrokenRules;
                response.Exception = ex;
                response.Message = ex.ToString();
                response.ErrorCode = "EFBR00001";
            }
            catch (CallMethodException ex)
            {
                if (ex.InnerException != null && ex.InnerException.ToString().Contains("REFERENCE constraint"))
                {
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "EF100002", RowNumber = 0, ErrorMessage = "EF100002" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "EF100002", ErrorCode = "EF100002" }; //ErrorMessage = ex.Message
                }
                else if (ex.InnerException != null && ex.InnerException.ToString().Contains("Dont have permission to execute this method"))
                {
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "SE0003", RowNumber = 0, ErrorMessage = "SE0003" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "SE0003", ErrorCode = "SE0003" }; //ErrorMessage = ex.Message
                }
                else if (ex.InnerException != null && ex.InnerException.ToString().Contains("modified or deleted since entities were loaded"))
                {
                    // Store update, insert, or delete statement affected an unexpected number of rows (0). Entities may have been modified 
                    // or deleted since entities were loaded. Refresh ObjectStateManager entries.
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "EF100003", RowNumber = 0, ErrorMessage = "EF100003" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "EF100003", ErrorCode = "EF100003" }; //ErrorMessage = ex.Message
                }
                else if (ex.Source.Equals("System.Data.Entity"))
                {
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "EF100001", RowNumber = 0, ErrorMessage = "EF100001" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "EF100001", ErrorCode = "EF100001" }; //ErrorMessage = ex.Message
                }
                else if (ex.InnerException != null && ex.InnerException.ToString().Contains("IntermittentTransaction"))
                {
                    string pagecode = string.Empty;
                    BDException exinner = ex.InnerException as BDException;
                    if (exinner != null)
                    {
                        if (exinner.DataObject != null && exinner.DataObject.Contains("PageCode"))
                        {
                            pagecode = exinner.DataObject["PageCode"].ToString();
                        }

                        response = new FrameworkResponse()
                        {
                            Status = Status.Failed,
                            Exception = exinner,
                            Message = exinner.ErrorMessage,
                            ErrorCode = exinner.ErrorCode,


                        }; //ErrorMessage = ex.Message

                        if (exinner.DataObject != null && exinner.DataObject.Contains("BrokenRules"))
                        {
                            response.BrokenRules = exinner.DataObject["BrokenRules"] as BrokenRulesCollection;
                        }
                        string stackTrace = string.Empty;
                        if (response.Exception != null)
                            stackTrace = response.Exception.StackTrace;
                        try
                        {
                            //SAF.Notification.ExceptionLogManager.Log(string.Empty, response.Message, this.PageContext.PageCode, method, response.ErrorCode, stackTrace, this.Entity);
                        }
                        catch (Exception exintmet)
                        {
                            BDException saraex = new BDException("IntermittentTransaction", response.Exception);
                            saraex.DataObject = new Dictionary<string, object>();
                            saraex.DataObject.Add("PageCode", this.PageContext.PageCode);
                            saraex.DataObject.Add("Entity", this.Entity);

                            saraex.DataObject.Add("BrokenRules", response.BrokenRules);
                            saraex.ErrorCode = response.ErrorCode;
                            saraex.ErrorMessage = response.Message;

                            throw saraex;
                        }
                    }
                }
                else
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = ex, Message = ex.Message, ErrorCode = ex.ErrorCode };
                }

            }
            catch (SecurityException ex)
            {
                if (ex.Message.ToString().Contains("Dont have permission to execute this method"))
                {
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "SE0003", RowNumber = 0, ErrorMessage = "SE0003" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "SE0003", ErrorCode = "SE0003" }; //ErrorMessage = ex.Message
                }
                else
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = ex, Message = ex.ErrorMessage, ErrorCode = string.Empty };
            }
            catch (BDException ex)
            {
                Type type = ex.GetType();

                // BDException exception = (BDException)BD.Runtime.MethodCaller.CreateInstance(type);
                BDException exception = new BDException() { Source = "DAL", ErrorCode = string.Empty, RowNumber = 0, ErrorMessage = "EF100001" };
                exception.ErrorCode = ex.ErrorCode;

                if (ex.Source.ToString().Equals("System.Data.Entity"))
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = ex, Message = ex.Message, ErrorCode = "EF100001" };

                if (ex.InnerException != null && ex.InnerException.ToString().Contains("Dont have permission to execute this method"))
                {
                    //BDException exception = new BDException() { Source = "DAL", ErrorCode = "SE0003", RowNumber = 0, ErrorMessage = SAF.Properties.Resources.SE0003 };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "SE0003", ErrorCode = "SE0003" }; //ErrorMessage = ex.Message
                }
                else if (ex.ToString().Contains("LicenseFail"))
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "LicenseFail", ErrorCode = "LicenseFail" }; //ErrorMessage = ex.Message
                }
                else if (ex.ToString().Contains("LicenseExpiry"))
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "LicenseExpiry", ErrorCode = "LicenseViolation" }; //ErrorMessage = ex.Message
                }
                else if (ex.ToString().Contains("LicenseOrganizationFail"))
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "LicenseOrganizationFail", ErrorCode = "LicenseViolation" }; //ErrorMessage = ex.Message
                }
                else if (ex.ToString().Contains("LicenseDataFail"))
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "LicenseDataFail", ErrorCode = "LicenseDataFail" }; //ErrorMessage = ex.Message
                }
                else
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = ex, Message = ex.ErrorMessage, ErrorCode = ex.ErrorCode };
                //throw exception;

                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception ex)
            {
                response = new FrameworkResponse() { Status = Status.Failed, Exception = new BDException(ex.Message, ex), Message = ex.Message, ErrorCode = "EEX002" };
                BDException exception = new BDException(ex.Message) { ErrorCode = "EX001" };

                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

            if (response.Status == Status.Failed)
            {
                string stackTrace = string.Empty;
                if (response.Exception != null)
                    stackTrace = response.Exception.StackTrace;
                try
                {
                    //SAF.Notification.ExceptionLogManager.Log(string.Empty, response.Message, this.PageContext.PageCode, method, response.ErrorCode, stackTrace, this.Entity);
                }
                //catch (System.Transactions.TransactionException ex)
                catch (Exception ex)
                {
                    BDException saraex = new BDException("IntermittentTransaction", response.Exception);
                    saraex.DataObject = new Dictionary<string, object>();
                    saraex.DataObject.Add("PageCode", this.PageContext.PageCode);
                    saraex.DataObject.Add("Entity", this.Entity);
                    saraex.DataObject.Add("BrokenRules", response.BrokenRules);

                    saraex.ErrorCode = response.ErrorCode;
                    saraex.ErrorMessage = response.Message;

                    throw saraex;
                }
            }
            return response;
        }

        private async Task<FrameworkResponse> ProcessAsync(string method)
        {
            FrameworkResponse response = null;
            try
            {
                response = await proxy.ProcessAsync<T>(this, this.PageContext, method);
                if (response.Status == Status.Success)
                {
                    if (!(method.Equals(DeleteMethod) || method.Equals(BulkDeleteMethod)))
                        this.OnSaved(this.Entity);
                }
            }
            catch (BrokenRuleException ex)
            {
                //BrokenRuleException exception = new BrokenRuleException(ex.Message) { ErrorCode = ex.ErrorCode, BrokenRules = ex.BrokenRules, RowNumber = ex.RowNumber };
                //throw exception;
                response = new FrameworkResponse() { Status = Status.Failed };
                response.BrokenRules = ex.BrokenRules;
                response.Exception = ex;
                response.Message = ex.ToString();
                response.ErrorCode = "EFBR00001";
            }
            catch (CallMethodException ex)
            {
                if (ex.InnerException != null && ex.InnerException.ToString().Contains("REFERENCE constraint"))
                {
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "EF100002", RowNumber = 0, ErrorMessage = "EF100002" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "EF100002", ErrorCode = "EF100002" }; //ErrorMessage = ex.Message
                }
                else if (ex.InnerException != null && ex.InnerException.ToString().Contains("Dont have permission to execute this method"))
                {
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "SE0003", RowNumber = 0, ErrorMessage = "SE0003" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "SE0003", ErrorCode = "SE0003" }; //ErrorMessage = ex.Message
                }
                else if (ex.InnerException != null && ex.InnerException.ToString().Contains("modified or deleted since entities were loaded"))
                {
                    // Store update, insert, or delete statement affected an unexpected number of rows (0). Entities may have been modified 
                    // or deleted since entities were loaded. Refresh ObjectStateManager entries.
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "EF100003", RowNumber = 0, ErrorMessage = "EF100003" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "EF100003", ErrorCode = "EF100003" }; //ErrorMessage = ex.Message
                }
                else if (ex.Source.Equals("System.Data.Entity"))
                {
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "EF100001", RowNumber = 0, ErrorMessage = "EF100001" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "EF100001", ErrorCode = "EF100001" }; //ErrorMessage = ex.Message
                }
                else if (ex.InnerException != null && ex.InnerException.ToString().Contains("IntermittentTransaction"))
                {
                    string pagecode = string.Empty;
                    BDException exinner = ex.InnerException as BDException;
                    if (exinner != null)
                    {
                        if (exinner.DataObject != null && exinner.DataObject.Contains("PageCode"))
                        {
                            pagecode = exinner.DataObject["PageCode"].ToString();
                        }

                        response = new FrameworkResponse()
                        {
                            Status = Status.Failed,
                            Exception = exinner,
                            Message = exinner.ErrorMessage,
                            ErrorCode = exinner.ErrorCode,


                        }; //ErrorMessage = ex.Message

                        if (exinner.DataObject != null && exinner.DataObject.Contains("BrokenRules"))
                        {
                            response.BrokenRules = exinner.DataObject["BrokenRules"] as BrokenRulesCollection;
                        }
                        string stackTrace = string.Empty;
                        if (response.Exception != null)
                            stackTrace = response.Exception.StackTrace;
                        try
                        {
                            //SAF.Notification.ExceptionLogManager.Log(string.Empty, response.Message, this.PageContext.PageCode, method, response.ErrorCode, stackTrace, this.Entity);
                        }
                        catch (Exception exintmet)
                        {
                            BDException saraex = new BDException("IntermittentTransaction", response.Exception);
                            saraex.DataObject = new Dictionary<string, object>();
                            saraex.DataObject.Add("PageCode", this.PageContext.PageCode);
                            saraex.DataObject.Add("Entity", this.Entity);

                            saraex.DataObject.Add("BrokenRules", response.BrokenRules);
                            saraex.ErrorCode = response.ErrorCode;
                            saraex.ErrorMessage = response.Message;

                            throw saraex;
                        }
                    }
                }
                else
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = ex, Message = ex.Message, ErrorCode = ex.ErrorCode };
                }

            }
            catch (SecurityException ex)
            {
                if (ex.Message.ToString().Contains("Dont have permission to execute this method"))
                {
                    BDException exception = new BDException() { Source = "DAL", ErrorCode = "SE0003", RowNumber = 0, ErrorMessage = "SE0003" };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "SE0003", ErrorCode = "SE0003" }; //ErrorMessage = ex.Message
                }
                else
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = ex, Message = ex.ErrorMessage, ErrorCode = string.Empty };
            }
            catch (BDException ex)
            {
                Type type = ex.GetType();

                // BDException exception = (BDException)BD.Runtime.MethodCaller.CreateInstance(type);
                BDException exception = new BDException() { Source = "DAL", ErrorCode = string.Empty, RowNumber = 0, ErrorMessage = "EF100001" };
                exception.ErrorCode = ex.ErrorCode;

                if (ex.Source.ToString().Equals("System.Data.Entity"))
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = ex, Message = ex.Message, ErrorCode = "EF100001" };

                if (ex.InnerException != null && ex.InnerException.ToString().Contains("Dont have permission to execute this method"))
                {
                    //BDException exception = new BDException() { Source = "DAL", ErrorCode = "SE0003", RowNumber = 0, ErrorMessage = SAF.Properties.Resources.SE0003 };
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "SE0003", ErrorCode = "SE0003" }; //ErrorMessage = ex.Message
                }
                else if (ex.ToString().Contains("LicenseFail"))
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "LicenseFail", ErrorCode = "LicenseFail" }; //ErrorMessage = ex.Message
                }
                else if (ex.ToString().Contains("LicenseExpiry"))
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "LicenseExpiry", ErrorCode = "LicenseViolation" }; //ErrorMessage = ex.Message
                }
                else if (ex.ToString().Contains("LicenseOrganizationFail"))
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "LicenseOrganizationFail", ErrorCode = "LicenseViolation" }; //ErrorMessage = ex.Message
                }
                else if (ex.ToString().Contains("LicenseDataFail"))
                {
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = exception, Message = "LicenseDataFail", ErrorCode = "LicenseDataFail" }; //ErrorMessage = ex.Message
                }
                else
                    response = new FrameworkResponse() { Status = Status.Failed, Exception = ex, Message = ex.ErrorMessage, ErrorCode = ex.ErrorCode };
                //throw exception;

                // Logging the Exception, It will log all the exeception raised by server
                // Components, other than "VALEX" i.e. Business Or Validation Rules violation
                // LogManager.WriteExceptionLog(
            }
            catch (System.Exception ex)
            {
                response = new FrameworkResponse() { Status = Status.Failed, Exception = new BDException(ex.Message, ex), Message = ex.Message, ErrorCode = "EEX002" };
                BDException exception = new BDException(ex.Message) { ErrorCode = "EX001" };

                // Logging the Exception, It will log all the exeception raised by server Components.
                // LogManager.WriteExceptionLog(ex);
            }

            if (response.Status == Status.Failed)
            {
                string stackTrace = string.Empty;
                if (response.Exception != null)
                    stackTrace = response.Exception.StackTrace;
                try
                {
                    //SAF.Notification.ExceptionLogManager.Log(string.Empty, response.Message, this.PageContext.PageCode, method, response.ErrorCode, stackTrace, this.Entity);
                }
                //catch (System.Transactions.TransactionException ex)
                catch (Exception ex)
                {
                    BDException saraex = new BDException("IntermittentTransaction", response.Exception);
                    saraex.DataObject = new Dictionary<string, object>();
                    saraex.DataObject.Add("PageCode", this.PageContext.PageCode);
                    saraex.DataObject.Add("Entity", this.Entity);
                    saraex.DataObject.Add("BrokenRules", response.BrokenRules);

                    saraex.ErrorCode = response.ErrorCode;
                    saraex.ErrorMessage = response.Message;

                    throw saraex;
                }
            }
            return response;
        }
        #endregion

        #region Abstract methods
        /// <summary>
        /// Fetches the results from the databased after applying the filters
        /// included in the criteria object.
        /// </summary>
        /// <returns>Returns  results.</returns>
        protected abstract T Fetch();

        /// <summary>
        /// Abstract method for implementing the actual insert operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected abstract FrameworkResponse Insert();

        /// <summary>
        /// Abstract method for implementing the actual update operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected abstract FrameworkResponse Update();

        /// <summary>
        /// Abstract method for implementing the actual delete operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected abstract FrameworkResponse Delete();

        /// <summary>
        /// Abstract method for implementing the actual bulk insert operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected abstract FrameworkResponse BulkInsert();

        /// <summary>
        /// Abstract method for implementing the actual bulk delete operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected abstract FrameworkResponse BulkDelete();

        /// <summary>
        /// Abstract method for implementing the actual update operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        internal protected virtual FrameworkResponse ProcessInternal()
        {
            return new FrameworkResponse() { Status = Status.Success };
        }

        /// <summary>
        /// Fetches the results from the databased after applying the filters
        /// included in the criteria object.
        /// </summary>
        /// <returns>Returns  results.</returns>
        protected virtual async Task<T> FetchAsync()
        {
            return await Task.FromResult(default(T));
        }

        /// <summary>
        /// Abstract method for implementing the actual insert operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected virtual async Task<FrameworkResponse> InsertAsync()
        {
            return await Task.FromResult(default(FrameworkResponse));
        }

        /// <summary>
        /// Abstract method for implementing the actual update operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected virtual async Task<FrameworkResponse> UpdateAsync()
        {
            return await Task.FromResult(default(FrameworkResponse));
        }

        /// <summary>
        /// Abstract method for implementing the actual delete operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected virtual async Task<FrameworkResponse> DeleteAsync()
        {
            return await Task.FromResult(default(FrameworkResponse));
        }

        /// <summary>
        /// Abstract method for implementing the actual bulk insert operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected virtual async Task<FrameworkResponse> BulkInsertAsync()
        {
            return await Task.FromResult(default(FrameworkResponse));
        }

        /// <summary>
        /// Abstract method for implementing the actual bulk delete operation 
        /// in the business logic.
        /// </summary>
        /// <returns>A response object containing the saved values and process status.</returns>
        protected virtual async Task<FrameworkResponse> BulkDeleteAsync()
        {
            return await Task.FromResult(default(FrameworkResponse));
        }
        #endregion

        #region Events

        /// <summary>
        /// Raises the Saved event, indicating that the
        /// object has been saved, and providing a reference
        /// to the new object instance.
        /// </summary>
        /// <param name="newObject">The new object instance.</param>
        protected void OnSaved(T newObject)
        {
        }

        /// <summary>
        /// Raises the Saved event, indicating that the
        /// object has been saved, and providing a reference
        /// to the new object instance.
        /// </summary>
        /// <param name="newObject">The new object instance.</param>
        protected void OnSaved(List<T> newObject)
        {
        }

        /// <summary>
        /// Raises the Saved event, indicating that the
        /// object has been saved, and providing a reference
        /// to the new object instance.
        /// </summary>
        /// <param name="newObject">The new object instance.</param>
        protected void OnDeleted(T newObject)
        {
        }

        /// <summary>
        /// Raises the Saved event, indicating that the
        /// object has been saved, and providing a reference
        /// to the new object instance.
        /// </summary>
        /// <param name="newObject">The new object instance.</param>
        protected void OnDeleted(List<T> newObject)
        {
        }
        #endregion
    }
}
