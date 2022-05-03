using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Calendar.Framework.Configuration;
using System.Text.Json;

namespace Calendar.Framework
{
    public class CoreController : ControllerBase
    {
        #region Configuration
        /// <summary>
        /// Gets or sets the Configuration.
        /// </summary>
        public Config Config { get; internal set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="config"></param>
        public CoreController(Config config) {
            this.Config = config;
        }
        #endregion;

        #region Session

        /// <summary>
        /// Adds the string value to Session.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void SetSessionString(string key, string value) {
            HttpContext.Session.SetString(key, value);
        }

        /// <summary>
        /// Gets the string value from session object.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetSessionString(string key)
        {
            return HttpContext.Session.GetString(key);
        }

        /// <summary>
        /// Adds the int to session object.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void SetSessionInt(string key, int value)
        {
            HttpContext.Session.SetInt32(key, value);
        }

        /// <summary>
        /// Returns the int value from the sesssion.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int? GetSessionInt(string key)
        {
            return HttpContext.Session.GetInt32(key);
        }

        /// <summary>
        /// Adds serializable object to session.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void SetSession<T>(string key, T value)
        {
            HttpContext.Session.SetString(key, JsonSerializer.Serialize(value));
        }

        /// <summary>
        /// Returns the object from session object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected T? GetSession<T>(string key)
        {
            var value = HttpContext.Session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        #endregion

        #region OnActionExecuting Event

        /// <summary>
        /// OnActionExecuting Event
        /// </summary>
        /// <param name="context"></param>
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //    if (context.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        // Construting the Organization configuration.
        //        Config = new OrgConfig();
        //        Config.OrgKey = context.HttpContext.Session.GetString(UtilityManager.OrganizatoinId);
        //        Config.CacheType = context.HttpContext.Session.GetString(cahceType);
        //        Config.Connection = context.HttpContext.Session.GetString(connectionString);
        //    }
        //}
        #endregion

        #region PageContext
        //protected USERS GetUser()
        //{
        //    USERS user = null;
        //    try
        //    {
        //        user = JsonConvert.DeserializeObject<USERS>(HttpContext.Session.GetString("user"));
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return user;
        //}

        protected PageContext GetPageContext(string pagecode)
        {
            PageContext context = new PageContext();
            context.PageCode = pagecode;
            context.FeatureID = pagecode;
            //USERS user = GetUser();
            //if (user != null)
            //{
            //    context.UserID = user.ID;
            //}
            return context;
        }
        #endregion
    }
}
