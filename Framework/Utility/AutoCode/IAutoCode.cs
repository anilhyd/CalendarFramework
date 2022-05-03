#region Header Info
//-----------------------------------------------------------------------
// <copyright file="IAutoCode.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Interface for implementing the AutoCode generation.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>2-Feb-2011</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
#endregion

namespace Calendar.Framework.Entity
{
    /// <summary>
    /// Interface for implementing the AutoCode generation.
    /// </summary>
    public interface IAutoCode
    {
        /// <summary>
        /// Returns the List of AutoCode objects which are belongs to Organization.
        /// </summary>
        /// <param name="autocodeId">AutoCode ID.</param>
        /// <returns>Returns List of AutoCode objects based on the criteria.</returns>
        AutoCode Fetch(string autocodeId);

        /// <summary>
        /// Returns the AutoCode Object found for the supplied Organiation Code and Feature Code, otherwise returns null.
        /// </summary>
        /// <param name="organizationCode">Organizaion Code.</param>
        /// <param name="featureCode">Feature Code.</param>
        /// <returns>Returns Auto Code Object.</returns>
        AutoCode Fetch(string organizationCode, string featureCode);

        /// <summary>
        /// Saves the AutoCode object into Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        bool Insert(AutoCode autocode);

        /// <summary>
        /// Updates the changes of AutoCode object into Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        bool Update(AutoCode autocode);

        /// <summary>
        /// Deletes AutoCode object From the Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        //bool Delete(AutoCode autocode);

        /// <summary>
        /// Returns the AutoCode object if found for supplied data, otherwise throws exception.
        /// </summary>
        /// <param name="organizationCode">Code of the Parent Organization which the AutoCode belongs to.</param>
        /// <param name="suborganizationCode">Code of the SubOrganization.</param>
        /// <param name="featureCode">Code of the Feature.</param>
        /// <param name="featureinstanceValue">Instance value of the feature.</param>
        /// <param name="generationdate">Generation date.</param>
        /// <returns>Returns Generated auto code for specified Parameters.</returns>
        string GetAutoCode(string organizationCode, string suborganizationCode, string featureCode, string featureinstanceValue, DateTime generationdate);

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="featureCode">Feature Code Data.</param>
        /// <returns>true/false based on the configuration.</returns>
        bool IsAutoCodeConfigured(string organizationCode, string featureCode);

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="featureCode">Feature Code Data.</param>
        /// <returns>true/false based on the configuration.</returns>
        bool IsAutoCodeConfigured(string featureCode);

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="organizationId">Organization Id.</param>
        /// <param name="featureCode">Feature Code Data.</param>
        /// <returns>true/false based on the configuration.</returns>
        bool IsAutoCodeConfiguredByID(string organizationId, string featureId);
    }
}
