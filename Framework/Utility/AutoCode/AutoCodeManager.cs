#region Header Info
//-----------------------------------------------------------------------
// <copyright file="AutoCodeManager.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Manager used for accessing the AutoCode Geneartor API.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>2-Feb-2011</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Entity;
using System;
using System.Collections.Generic;
#endregion

namespace Calendar.Framework.AutoCodeGenerator
{
    /// <summary>
    ///  Manager used for accessing the AutoCode Geneartor API.
    /// </summary>
    public class AutoCodeManager
    {
        #region Fetch
        /// <summary>
        /// Returns the AutoCode object.
        /// </summary>
        /// <param name="autocodeId">Autocode ID.</param>
        /// <returns>Returns AutoCode object.</returns>
        public static AutoCode Fetch(string autocodeId)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.Fetch(autocodeId);
        }

        /// <summary>
        /// Returns the AutoCode Object found for the supplied Organiation Code and Feature Code, otherwise returns null.
        /// </summary>
        /// <param name="organizationId">Organizaion ID.</param>
        /// <param name="featureId">Feature Id.</param>
        /// <returns>Returns Auto Code Object.</returns>
        public static AutoCode Fetch(string organizationId, string featureId)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.Fetch(organizationId, featureId);
        }

        /// <summary>
        /// Returns the AutoCode Object found for the supplied Organiation Code and Feature Code, otherwise returns null.
        /// </summary>
        /// <param name="organizationCode">Organizaion Code.</param>
        /// <param name="featureCode">Feature Code.</param>
        /// <returns>Returns Auto Code Object.</returns>
        public static AutoCode FetchUsingCode(string organizationCode, string featureCode)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.FetchUsingCode(organizationCode, featureCode);
        }

        /// <summary>
        /// Returns the List of AutoCode objects which are belongs to Organization.
        /// </summary>
        /// <param name="organizationCode">Organization Code.</param>
        /// <returns>Returns List of AutoCode objects based on the criteria.</returns>
        public static List<AutoCode> FetchUsingOrganizationCode(string organizationCode)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.FetchUsingOrganizationCode(organizationCode);
        }
        #endregion

        #region Insert
        /// <summary>
        /// Saves the AutoCode object into Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        public static bool Insert(AutoCode autocode)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.Insert(autocode);
        }
        #endregion

        #region Update
        /// <summary>
        /// Updates the changes of AutoCode object into Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        public static bool Update(AutoCode autocode)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.Update(autocode);
        }


        /// <summary>
        /// Updates the changes of AutoCode object into Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        public static bool UpdateAutoCode(AutoCode autocode)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.UpdateAutoCode(autocode);
        }

        #endregion

        #region Delete
        /// <summary>
        /// Deletes AutoCode object From the Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        public static bool Delete(AutoCode autocode)
        {
            //AutoCodeLogic logic = new AutoCodeLogic();
            //return logic.Delete(autocode);
            return true;
        }
        #endregion

        #region Get AutoCode
        /// <summary>
        /// Returns the AutoCode object if found for supplied data, otherwise throws exception.
        /// </summary>
        /// <param name="organizationCode">Code of the Parent Organization which the AutoCode belongs to.</param>
        /// <param name="suborganizationCode">Code of the SubOrganization.</param>
        /// <param name="featureCode">Code of the Feature.</param>
        /// <param name="featureinstanceValue">Instance value of the feature.</param>
        /// <param name="generationdate">Generation date.</param>
        /// <returns>Returns Generated auto code for specified Parameters.</returns>
        public static string GetAutoCode(string organizationCode, string suborganizationCode, string featureCode, string featureinstanceValue, DateTime generationdate)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.GetAutoCode(organizationCode, suborganizationCode, featureCode, featureinstanceValue, generationdate);
        }

        /// <summary>
        /// Returns the AutoCode object if found for supplied data, otherwise throws exception.
        /// </summary>
        /// <param name="organizationID">ID of the Parent Organization which the AutoCode belongs to.</param>
        /// <param name="suborganizationID">ID of the SubOrganization.</param>
        /// <param name="featureID">ID of the Feature.</param>
        /// <param name="featureinstanceValue">Instance value of the feature.</param>
        /// <param name="generationdate">Generation date.</param>
        /// <returns>Returns Generated auto code for specified Parameters.</returns>
        public static string GetAutoCodeUsingIdForBackDate(string organizationID, string suborganizationID, string featureID, string featureinstanceValue, DateTime generationdate)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.GetAutoCodeUsingIdForBackDate(organizationID, suborganizationID, featureID, featureinstanceValue, generationdate);
        }

        /// <summary>
        /// Returns the AutoCode object if found for supplied data, otherwise throws exception.
        /// </summary>
        /// <param name="organizationCode">Code of the Parent Organization which the AutoCode belongs to.</param>
        /// <param name="suborganizationCode">Code of the SubOrganization.</param>
        /// <param name="featureCode">Code of the Feature.</param>
        /// <param name="featureinstanceValue">Instance value of the feature.</param>
        /// <returns>Returns Generated auto code for specified Parameters.</returns>
        public static string GetAutoCode(string organizationCode, string suborganizationCode, string featureCode, string featureinstanceValue)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.GetAutoCode(organizationCode, suborganizationCode, featureCode, featureinstanceValue);
        }

        /// <summary>
        /// Returns the AutoCode object if found for supplied data, otherwise throws exception.
        /// </summary>
        /// <param name="organizationID">ID of the Parent Organization which the AutoCode belongs to.</param>
        /// <param name="suborganizationID">ID of the SubOrganization.</param>
        /// <param name="featureID">ID of the Feature.</param>
        /// <param name="featureinstanceValue">Instance value of the feature.</param>
        /// <returns>Returns Generated auto code for specified Parameters.</returns>
        public static string GetAutoCodeUsingIds(string organizationID, string suborganizationID, string featureID, string featureinstanceValue, string periodid = null)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.GetAutoCodeUsingIds(organizationID, suborganizationID, featureID, featureinstanceValue, periodid);
        }
        #endregion 

        #region IsAutoCodeConfigured

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="organizationCode">Organiztion Code.</param>
        /// <param name="featureCode">Feature Code Data.</param>
        /// <returns>true/false based on the configuration.</returns>
        public static bool IsAutoCodeConfigured(string organizationCode, string featureCode)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.IsAutoCodeConfigured(organizationCode, featureCode);
        }

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="featureCode">Feature Code Data.</param>
        /// <returns>true/false based on the configuration.</returns>
        public static bool IsAutoCodeConfigured(string featureCode)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.IsAutoCodeConfigured(featureCode);
        }

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="organizationId">Organization Data.</param>
        /// <param name="featureId">Feature Data.</param>
        /// <returns></returns>
        public static bool IsAutoCodeConfiguredByID(string organizationId, string featureId)
        {
            AutoCodeLogic logic = new AutoCodeLogic();
            return logic.IsAutoCodeConfiguredByID(organizationId, featureId);
        }
        #endregion
    }
}
