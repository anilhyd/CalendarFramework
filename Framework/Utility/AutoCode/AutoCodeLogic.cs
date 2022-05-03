#region Header Info
//-----------------------------------------------------------------------
// <copyright file="AutoCodeLogic.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Businesss logic Implementation for Autocode Generation.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>3-Feb-2011</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using Calendar.Framework.Entity;
using Calendar.Framework.Security;
#endregion

namespace Calendar.Framework.AutoCodeGenerator
{
    /// <summary>
    ///  Businesss logic Implementation for Autocode Generation.
    /// </summary>
    internal class AutoCodeLogic : IAutoCode
    {
        #region contant & Local variable declration

        /// <summary>
        /// String Constant for AutoCodePart.
        /// </summary>
        private const string Autocodepart = "AutoCodePart";

        /// <summary>
        /// String Constant for AutoCodeCounter.
        /// </summary>
        private const string Autocodcounter = "AutoCodeCounter";

        /// <summary>
        /// String Constant for AutoCodePart.AutoCodeCounter.
        /// </summary>
        private const string Autcodepartdotautocodecounter = "AutoCodePart.AutoCodeCounter";

        /// <summary>
        /// String Constant for AutoCodeView.
        /// </summary>
        private const string Autocodeview = "AutoCodeView";

        /// <summary>
        /// String Constant for AutocodeNotConfigure.
        /// </summary>
        private const string Autocodenotconfigure = "AutocodeNotConfigure";

        /// <summary>
        /// String Constant for ProvideBackDate.
        /// </summary>
        private const string Providebackdate = "ProvideBackDate";

        /// <summary>
        /// String Constant for AutoCodeInsertFailureForSubOrg.
        /// </summary>
        private const string AutoCodeInsertFailureForSubOrg = "AutoCodeInsertFailureForSubOrg";

        /// <summary>
        /// Used for getting format type if format type came as integer value.
        /// </summary>
        private string[] formats = { "MMM", "MMMM", "yyyy", "yy", "YEAR-WEEK", "Month-Week", "ddMMyyyy", "MMddyyyy", "yyyyMMdd", "MMyyyy", "MMyy", "MMMYYYY", "MMMMyyyy", "ddd", "dd" };

        #endregion

        #region Fetch
        /// <summary>
        /// Returns the AutoCode Object found for the supplied autocode ID, otherwise returns null.
        /// </summary>
        /// <param name="autocodeID">AutoCode ID.</param>
        /// <returns>Returns Auto Code Object.</returns>
        public AutoCode Fetch(string autocodeID)
        {
            AutoCode autocode = null;
            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    autocode = (from o in entity.AutoCode.Include(Autocodepart)
            //                where o.AutoCodeID == autocodeID
            //                select o).FirstOrDefault();
            //}

            return autocode;
        }

        /// <summary>
        /// Returns the AutoCode Object found for the supplied Organiation ID and Feature ID, otherwise returns null.
        /// </summary>
        /// <param name="organizationId">Organizaion ID.</param>
        /// <param name="featureId">Feature ID.</param>
        /// <returns>Returns Auto Code Object.</returns>
        public AutoCode Fetch(string organizationId, string featureId)
        {
            AutoCode autocode = null;

            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    autocode = (from code in entity.AutoCode.Include(Autocodepart)
            //                where code.OrganizationID == organizationId && code.FeatureID == featureId
            //                select code).FirstOrDefault();
            //}

            return autocode;
        }

        /// <summary>
        /// Returns the AutoCode Object found for the supplied Organiation Code and Feature Code, otherwise returns null.
        /// </summary>
        /// <param name="organizationCode">Organizaion Code.</param>
        /// <param name="featureCode">Feature Code.</param>
        /// <returns>Returns Auto Code Object.</returns>
        public AutoCode FetchUsingCode(string organizationCode, string featureCode)
        {
            AutoCode autocode = null;

            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    autocode = (from code in entity.AutoCode.Include(Autocodepart)
            //                join o in entity.Organization on code.OrganizationID equals o.Id
            //                join f in entity.Feature on code.FeatureID equals f.Id
            //                where o.Code == organizationCode && f.Code == featureCode
            //                select code).FirstOrDefault();

            //    // EF 4.0 is unale to understand the query if If we include "AutoCodePart" into above
            //    // query. for fixing this issue additinal query has been called. The below query may be deleted
            //    // in the feature EF version.
            //    var parts = (from p in entity.AutoCodePart
            //                 where p.AutoCodeID == autocode.AutoCodeID
            //                 select p).ToList();
            //}

            return autocode;
        }

        /// <summary>
        /// Returns the List of AutoCode objects which are belongs to Organization.
        /// </summary>
        /// <param name="organizationCode">Organization Code.</param>
        /// <returns>Returns List of AutoCode objects based on the criteria.</returns>
        public List<AutoCode> FetchUsingOrganizationCode(string organizationCode)
        {
            List<AutoCode> autocode = null;

            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    autocode = (from code in entity.AutoCode.Include(Autocodepart)
            //                join o in entity.Organization on code.OrganizationID equals o.Id
            //                where o.Code == organizationCode
            //                select code).ToList();

            //    // EF 4.0 is unale to understand the query if If we include "AutoCodePart" into above
            //    // query. for fixing this issue additinal query has been called. The below code may be deleted
            //    // in the feature EF version.
            //    string autocodeid = string.Empty;
            //    if (autocode.Count > 0)
            //    {
            //        autocodeid = autocode[0].AutoCodeID;

            //        var parts = (from p in entity.AutoCodePart
            //                     where p.AutoCodeID == autocodeid
            //                     select p).ToList();
            //    }
            //}

            return autocode;
        }

        #endregion

        #region Insert
        /// <summary>
        /// Saves the AutoCode object into Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        public bool Insert(AutoCode autocode)
        {
            int results = 0;

            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    //if (autocode.IsModified == false)
            //    //{
            //    //    entity.AutoCode.ApplyChanges(autocode);
            //    //    results = entity.SaveChanges();
            //    //}
            //    //else
            //    //{

            //    var organization = (from org in entity.Organization
            //                        where org.Id == autocode.OrganizationID
            //                        select org).FirstOrDefault();

            //    // commented by Ravindra : type in organization is removed
            //    // if (organization.Type == true)
            //    //    throw new SAF.Exception.SarasException(SAF.Properties.Resources.ResourceManager.GetString(AutoCodeInsertFailureForSubOrg)) { ErrorCode = "AC0003" };

            //    //change by meraj 26-09-2012
            //    //var autoCode = (from code in entity.AutoCode
            //    //                where code.FeatureID == autocode.FeatureID && code.OrganizationID == autocode.OrganizationID && code.RecordState == 0
            //    //                select code).FirstOrDefault();


            //    var auto = from a in entity.AutoCode
            //               where a.OrganizationID == autocode.OrganizationID && a.FeatureID == autocode.FeatureID
            //               group a by new { a.FeatureID, a.OrganizationID } into grp
            //               select new { FeatureId = grp.Key.FeatureID, OrganizationId = grp.Key.OrganizationID, ConfigVersion = grp.Max(o => o.ConfigVersion) };

            //    var existingautocode = (from a in entity.AutoCode
            //                            join a2 in auto on new { FeatureId = a.FeatureID, OrganizationId = a.OrganizationID, ConfigVersion = a.ConfigVersion } equals new { FeatureId = a2.FeatureId, OrganizationId = a2.OrganizationId, ConfigVersion = a2.ConfigVersion }
            //                            select a).FirstOrDefault();

            //    //change by meraj 26-09-2012 ends here

            //    if (existingautocode == null)
            //    {
            //        // initiliazing the configuration version to 1
            //        autocode.ConfigVersion = 1;

            //        entity.AutoCode.Add(autocode);

            //        // Fetches all the sub-organization belongs to the organzation
            //        var subogaranizations = from o in entity.BusinessUnit
            //                                where o.OrganizationID == autocode.OrganizationID
            //                                select o.Id;

            //        if (subogaranizations != null)
            //        {
            //            // Has to write the code for inserting the data into AutoCodeCounter table.
            //            //for (int icount = 0, numberofparts = autocode.NumberOfParts; icount < numberofparts; icount++)
            //            foreach (AutoCodePart autopart in autocode.AutoCodePart)
            //            {
            //                if (autopart.PartType == 3)
            //                {
            //                    foreach (string sborganizationid in subogaranizations)
            //                    {
            //                        AutoCodeCounter counter = new AutoCodeCounter();
            //                        counter.CounterId = Guid.NewGuid().ToString();
            //                        counter.AutoCodeID = autocode.AutoCodeID;
            //                        counter.OrganizationGroupID = autocode.OrganizationGroupID;
            //                        counter.OrganizationID = autocode.OrganizationID;
            //                        counter.BusinessUnitID = sborganizationid;
            //                        counter.DnamicPartValue = string.Empty;
            //                        counter.CounterValue = autopart.CounterStartValue;
            //                        counter.LastResetDateTime = DateTime.Now;
            //                        counter.PartOrder = autopart.PartOrder;

            //                        // counter.AssignDefaultValues(ApplicationContext.UserContext);

            //                        // Default Columns;
            //                        counter.CreatedBy = autocode.CreatedBy;
            //                        counter.CreatedDate = autocode.CreatedDate;
            //                        counter.LastUpdatedBy = autocode.LastUpdatedBy;
            //                        counter.LastUpdatedDate = autocode.LastUpdatedDate;
            //                        counter.OrganizationGroupID = autocode.OrganizationGroupID;
            //                        counter.OrganizationID = autocode.OrganizationID;
            //                        counter.BusinessUnitID = sborganizationid;
            //                        counter.RecordState = 0;
            //                        counter.WorkflowState = autocode.WorkflowState;
            //                        counter.OBSCode = autocode.OBSCode;
            //                        counter.LanguageId = autocode.LanguageId;
            //                        counter.VersionNo = "";
            //                        counter.IsEditable = true;


            //                        entity.AutoCodeCounter.Add(counter);
            //                    }
            //                }
            //            } // for loop ends.
            //        }

            //        results = entity.SaveChanges();
            //    }
            //    else
            //    {
            //        // if record exist.
            //        autocode.ConfigVersion = existingautocode.ConfigVersion;
            //        return this.Update(autocode);
            //    }

            //}

            return results > 0 ? true : false;
        }

        #endregion

        #region Update
        /// <summary>
        /// Updates the changes of AutoCode object into Database.
        /// </summary>
        /// <param name="autocode">AutoCode object with values.</param>
        /// <returns>Returns true/false.</returns>
        public bool Update(AutoCode autocode)
        {
            int results = 0;

            // if autocode config value is set before calling update then the next two line will be deleted.
            byte configValue = (byte)autocode.ConfigVersion;

            #region AutoCode Entries

            AutoCode autocodeNew = new AutoCode();
            autocodeNew.AutoCodeID = Guid.NewGuid().ToString();
            autocodeNew.FeatureID = autocode.FeatureID;
            autocodeNew.NumberOfParts = autocode.NumberOfParts;
            autocodeNew.Separator = autocode.Separator;
            autocodeNew.ConfigVersion = ++autocode.ConfigVersion;
            autocodeNew.CodeFormat = autocode.CodeFormat;
            autocodeNew.IsCodeConfigured = autocode.IsCodeConfigured;

            autocodeNew.CreatedBy = autocode.CreatedBy;
            autocodeNew.CreatedDate = DateTime.Now;
            autocodeNew.LastUpdatedBy = autocode.LastUpdatedBy;
            autocodeNew.LastUpdatedDate = DateTime.Now;
            autocodeNew.OrganizationGroupID = autocode.OrganizationGroupID;
            autocodeNew.OrganizationID = autocode.OrganizationID;
            autocodeNew.BusinessUnitID = autocode.BusinessUnitID;
            autocodeNew.OBSCode = autocode.OBSCode;
            autocodeNew.WorkflowState = autocode.WorkflowState;
            autocodeNew.RecordState = 0;
            autocodeNew.VersionNo = "";
            autocodeNew.IsEditable = true;
            autocodeNew.LanguageId = autocode.LanguageId;

            #endregion

            autocode.ConfigVersion = (byte)(configValue + 1);

            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    var subogaranizations = from o in entity.Organization
            //                            where o.OrganizationID == autocode.OrganizationID
            //                            select o.Id;

            //    if (subogaranizations != null)
            //    {
            //        // Has to write the code for inserting the data into AutoCodeCounter table.
            //        // for (int i = 0; i < autocode.NumberOfParts; i++)
            //        foreach (AutoCodePart part in autocode.AutoCodePart)
            //        {
            //            AutoCodePart codePart = new AutoCodePart();

            //            codePart.AutoCodeID = autocodeNew.AutoCodeID;
            //            codePart.PartType = part.PartType;
            //            codePart.DynamicType = part.DynamicType;
            //            codePart.Value = part.Value;
            //            codePart.CounterStartValue = part.CounterStartValue;
            //            codePart.CounterLength = part.CounterLength;
            //            codePart.CounterResetBy = part.CounterResetBy;
            //            codePart.PartOrder = part.PartOrder;

            //            codePart.CreatedBy = autocode.CreatedBy;
            //            codePart.CreatedDate = autocode.CreatedDate;
            //            codePart.LastUpdatedBy = autocode.LastUpdatedBy;
            //            codePart.LastUpdatedDate = autocode.LastUpdatedDate;
            //            codePart.OrganizationGroupID = autocode.OrganizationGroupID;
            //            codePart.OrganizationID = autocode.OrganizationID;
            //            codePart.BusinessUnitID = autocode.BusinessUnitID;
            //            codePart.OBSCode = autocode.OBSCode;
            //            codePart.WorkflowState = autocode.WorkflowState;
            //            codePart.RecordState = 0;
            //            codePart.VersionNo = "";
            //            codePart.IsEditable = true;
            //            codePart.LanguageId = autocode.LanguageId;

            //            autocodeNew.AutoCodePart.Add(codePart);

            //            if (part.PartType == 3)
            //            {
            //                foreach (string sborganizationid in subogaranizations)
            //                {
            //                    AutoCodeCounter counter = new AutoCodeCounter();
            //                    counter.CounterId = Guid.NewGuid().ToString();
            //                    counter.AutoCodeID = autocode.AutoCodeID;
            //                    counter.OrganizationGroupID = autocode.OrganizationGroupID;
            //                    counter.OrganizationID = autocode.OrganizationID;
            //                    counter.BusinessUnitID = sborganizationid;
            //                    counter.DnamicPartValue = string.Empty;
            //                    counter.CounterValue = part.CounterStartValue;
            //                    counter.LastResetDateTime = DateTime.Now;
            //                    counter.PartOrder = part.PartOrder;

            //                    // Default Columns;
            //                    counter.CreatedBy = autocode.CreatedBy;
            //                    counter.CreatedDate = autocode.CreatedDate;
            //                    counter.LastUpdatedBy = autocode.LastUpdatedBy;
            //                    counter.LastUpdatedDate = autocode.LastUpdatedDate;
            //                    counter.OrganizationGroupID = autocode.OrganizationGroupID;
            //                    counter.OrganizationID = autocode.OrganizationID;
            //                    counter.BusinessUnitID = autocode.BusinessUnitID;
            //                    counter.RecordState = 0;
            //                    counter.WorkflowState = autocode.WorkflowState;
            //                    counter.OBSCode = autocode.OBSCode;
            //                    counter.VersionNo = "";
            //                    counter.IsEditable = true;
            //                    counter.LanguageId = autocode.LanguageId;

            //                    codePart.AutoCodeCounter.Add(counter);
            //                }
            //            } // End of PartType = 3
            //        } // End of AutoCode Part
            //    }

            //    entity.AutoCode.Add(autocodeNew);
            //    results = entity.SaveChanges();
            //}

            return results > 0 ? true : false;
        }


        public bool UpdateAutoCode(AutoCode autocodeNew)
        {
            int results = 0;
            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    var subogaranizations = from o in entity.Organization
            //                            where o.OrganizationID == autocodeNew.OrganizationID
            //                            select o.Id;

            //    if (subogaranizations != null)
            //    {
            //        // Has to write the code for inserting the data into AutoCodeCounter table.
            //        // for (int i = 0; i < autocode.NumberOfParts; i++)
            //        foreach (AutoCodePart part in autocodeNew.AutoCodePart)
            //        {
            //            if (part.PartType == 3)
            //            {
            //                foreach (string sborganizationid in subogaranizations)
            //                {
            //                    AutoCodeCounter counter = new AutoCodeCounter();
            //                    counter.CounterId = Guid.NewGuid().ToString();
            //                    counter.AutoCodeID = autocodeNew.AutoCodeID;
            //                    counter.OrganizationGroupID = autocodeNew.OrganizationGroupID;
            //                    counter.OrganizationID = autocodeNew.OrganizationID;
            //                    counter.BusinessUnitID = sborganizationid;
            //                    counter.DnamicPartValue = string.Empty;
            //                    counter.CounterValue = part.CounterStartValue;
            //                    counter.LastResetDateTime = DateTime.Now;
            //                    counter.PartOrder = part.PartOrder;

            //                    #region Common Column
            //                    // Default Columns;
            //                    counter.CreatedBy = autocodeNew.CreatedBy;
            //                    counter.CreatedDate = autocodeNew.CreatedDate;
            //                    counter.LastUpdatedBy = autocodeNew.LastUpdatedBy;
            //                    counter.LastUpdatedDate = autocodeNew.LastUpdatedDate;
            //                    counter.OrganizationGroupID = autocodeNew.OrganizationGroupID;
            //                    counter.OrganizationID = autocodeNew.OrganizationID;
            //                    counter.BusinessUnitID = autocodeNew.BusinessUnitID;
            //                    counter.RecordState = 0;
            //                    counter.WorkflowState = autocodeNew.WorkflowState;
            //                    counter.OBSCode = autocodeNew.OBSCode;
            //                    counter.VersionNo = "";
            //                    counter.IsEditable = true;
            //                    counter.LanguageId = autocodeNew.LanguageId;
            //                    #endregion

            //                    part.AutoCodeCounter.Add(counter);
            //                }
            //            } // End of PartType = 3
            //        } // End of AutoCode Part
            //    }
            //    entity.AutoCode.Attach(autocodeNew);
            //    entity.Entry(autocodeNew).State = System.Data.Entity.EntityState.Modified;

            //    results = entity.SaveChanges();
            //}
            return results > 0 ? true : false;
        }


        #endregion


        #region GetAutoCode

        /// <summary>
        /// Returns autocode.
        /// </summary>
        /// <param name="organizationCode">Organization Code.</param>
        /// <param name="suborganizationCode">Sub organization Code.</param>
        /// <param name="featureCode">Feature code.</param>
        /// <param name="featureinstanceValue">Feature Instance value.</param>
        /// /// <param name="generationdate">Generation date.</param>
        /// <returns>Returns string.</returns>
        public string GetAutoCode(string organizationCode, string suborganizationCode, string featureCode, string featureinstanceValue, DateTime generationdate)
        {
            //if (generationdate.Date > DateTime.Now.Date)
            //    throw new SAF.Exception.SarasException(SAF.Properties.Resources.ResourceManager.GetString(Providebackdate)) { ErrorCode = "AC0002" };

            //string strAutoCode = string.Empty; // stores and return the calculating auto code.
            //string strNewCounterValue = string.Empty;

            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    // Getting autocode
            //    var autocodes = from code in entity.AutoCode.Include(Autocodepart).Include(Autcodepartdotautocodecounter)
            //                    join o in entity.Organization on code.OrganizationID equals o.Id
            //                    join f in entity.Feature on code.FeatureID equals f.Id
            //                    where o.Code == organizationCode && f.Code == featureCode && code.RecordState == 0
            //                    select code;

            //    if (autocodes.Count() == 0)
            //        throw new SAF.Exception.SarasException(SAF.Properties.Resources.ResourceManager.GetString(Autocodenotconfigure)) { ErrorCode = "AC0001" };

            //    string strautocodeID = autocodes.FirstOrDefault().AutoCodeID.ToString();

            //    // EF 4.0 is unale to understand the query if If we include "AutoCodePart" into above
            //    // query. for fixing this issue additinal query has been called. The below query may be deleted
            //    // in the feature EF version.
            //    var parts = (from p in entity.AutoCodePart.Include(Autocodcounter)
            //                 where p.AutoCodeID == strautocodeID
            //                 select p).ToList();

            //    byte? configValue = (from m in autocodes
            //                         select m.ConfigVersion).Max();

            //    var autocode = (from auto in autocodes
            //                    where auto.ConfigVersion == configValue
            //                    select auto).FirstOrDefault();

            //    if (autocode == null)
            //        throw new SAF.Exception.SarasException(SAF.Properties.Resources.ResourceManager.GetString(Autocodenotconfigure)) { ErrorCode = "AC0001" };

            //    if (suborganizationCode == null || suborganizationCode == string.Empty)
            //        suborganizationCode = organizationCode;

            //    foreach (AutoCodePart part in autocode.AutoCodePart)
            //    {
            //        switch (part.PartType)
            //        {
            //            case 1:
            //                #region static
            //                strAutoCode = strAutoCode + part.Value + autocode.Separator;
            //                break;
            //                #endregion
            //            case 2:
            //                #region dynamic
            //                string dynamicValue;
            //                if (part.DynamicType != 7)
            //                {
            //                    dynamicValue = this.GetDynamicPartValue(part.DynamicType, part.Value, generationdate, organizationCode, suborganizationCode);
            //                }
            //                else
            //                {
            //                    dynamicValue = featureinstanceValue;
            //                }

            //                strAutoCode = strAutoCode + dynamicValue + autocode.Separator;
            //                break;
            //                #endregion
            //            case 3: // Counter
            //                #region  Counter

            //                string strSubOrgID = (from rcd in entity.BusinessUnit where rcd.Code == suborganizationCode select rcd.Id).FirstOrDefault().ToString();
            //                byte type = 7;
            //                var partdynamic = from prt in autocode.AutoCodePart
            //                                  where prt.DynamicType == type
            //                                  select prt;
            //                int newcounterValue = 0;
            //                if (partdynamic.Count() == 0)
            //                {
            //                    DateTime nearestdate = this.GetNearestDate(generationdate, autocode.AutoCodeID, part.PartOrder, part.CounterResetBy, featureinstanceValue);
            //                    if (nearestdate.Date == DateTime.Now.Date)
            //                    {
            //                        AutoCodeCounter autocodecounter = this.CreateCounterObject(part, part.CounterStartValue, strSubOrgID);
            //                        autocodecounter.LastResetDateTime = generationdate;
            //                        newcounterValue = autocodecounter.CounterValue = autocodecounter.CounterValue + 1;
            //                        entity.AutoCodeCounter.Add(autocodecounter);
            //                        entity.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        var autoCdCounter = (from cntr in entity.AutoCodeCounter
            //                                             join o in entity.BusinessUnit on cntr.BusinessUnitID equals o.Id
            //                                             where o.Code == suborganizationCode && cntr.PartOrder == part.PartOrder && cntr.LastResetDateTime == nearestdate
            //                                             select cntr).FirstOrDefault();
            //                        if (autoCdCounter != null)
            //                        {
            //                            newcounterValue = autoCdCounter.CounterValue + 1;
            //                            if (generationdate > autoCdCounter.LastResetDateTime)
            //                                autoCdCounter.LastResetDateTime = generationdate;
            //                            autoCdCounter.CounterValue = newcounterValue;
            //                            entity.SaveChanges();
            //                        }
            //                        else
            //                        {
            //                            AutoCodeCounter autocodecounter = this.CreateCounterObject(part, part.CounterStartValue, strSubOrgID);
            //                            autocodecounter.LastResetDateTime = generationdate;
            //                            newcounterValue = autocodecounter.CounterValue = autocodecounter.CounterValue + 1;
            //                            entity.AutoCodeCounter.Add(autocodecounter);
            //                            entity.SaveChanges();
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    DateTime nearestdate = this.GetNearestDate(generationdate, autocode.AutoCodeID, part.PartOrder, part.CounterResetBy, featureinstanceValue);

            //                    if (nearestdate.Date == DateTime.Now.Date)
            //                    {
            //                        AutoCodeCounter autocodecounter = this.CreateCounterObject(part, part.CounterStartValue, strSubOrgID);
            //                        autocodecounter.LastResetDateTime = generationdate;
            //                        autocodecounter.DnamicPartValue = featureinstanceValue;
            //                        autocodecounter.CounterValue = newcounterValue = 1;
            //                        entity.AutoCodeCounter.Add(autocodecounter);
            //                        entity.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        var autoCdCounter = (from Cntr in part.AutoCodeCounter
            //                                             join o in entity.BusinessUnit on Cntr.BusinessUnitID equals o.Id
            //                                             where o.Code == suborganizationCode && Cntr.PartOrder == part.PartOrder && Cntr.DnamicPartValue == featureinstanceValue && Cntr.LastResetDateTime == nearestdate
            //                                             select Cntr).FirstOrDefault();
            //                        if (autoCdCounter == null)
            //                        {
            //                            AutoCodeCounter autocodecounter = this.CreateCounterObject(part, part.CounterStartValue, strSubOrgID);
            //                            autocodecounter.LastResetDateTime = generationdate;
            //                            newcounterValue = autocodecounter.CounterValue + 1;
            //                            autocodecounter.CounterValue = newcounterValue;
            //                            entity.AutoCodeCounter.Add(autocodecounter);
            //                            entity.SaveChanges();
            //                        }
            //                        else
            //                        {
            //                            autoCdCounter.CounterValue = autoCdCounter.CounterValue + 1;
            //                            autoCdCounter.LastResetDateTime = generationdate;
            //                            newcounterValue = autoCdCounter.CounterValue;
            //                        }
            //                    }
            //                }

            //                // string.Format("{0:d3}", i);
            //                strNewCounterValue = string.Format("{0:d" + part.CounterLength.ToString() + "}", newcounterValue);

            //                strAutoCode = strAutoCode + strNewCounterValue + autocode.Separator;
            //                break;
            //                #endregion
            //        }
            //    }

            //    // removing the last separator from the autocode string.
            //    strAutoCode = strAutoCode.Substring(0, strAutoCode.Length - autocode.Separator.Length);
            //}

            //return strAutoCode;
            return string.Empty;
        }

        /// <summary>
        /// Fetches the auto code for Back Dates.
        /// </summary>
        /// <param name="organizationID">Organization ID.</param>
        /// <param name="suborganizationID">Suborganization ID.</param>
        /// <param name="featureID">Feauture ID.</param>
        /// <param name="featureinstanceValue">Entity Supplied value.</param>
        /// <param name="generationdate">Back Data Value.</param>
        /// <returns>Backdated Autocodes.</returns>
        public string GetAutoCodeUsingIdForBackDate(string organizationID, string suborganizationID, string featureID, string featureinstanceValue, DateTime generationdate)
        {
            if (generationdate.Date > DateTime.Now.Date)
                throw new BDException("Providebackdate") { ErrorCode = "AC0002" };

            string strAutoCode = string.Empty; // stores and return the calculating auto code.
            //string strNewCounterValue = string.Empty;
            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    var autocodes = from auto in entity.AutoCode.Include(Autocodepart).Include(Autcodepartdotautocodecounter)
            //                    where auto.OrganizationID == organizationID && auto.FeatureID == featureID && auto.RecordState == 0
            //                    select auto;

            //    if (autocodes.Count() == 0)
            //        throw new SAF.Exception.SarasException(SAF.Properties.Resources.ResourceManager.GetString(Autocodenotconfigure)) { ErrorCode = "AC0001" };

            //    byte? configValue = (from m in autocodes
            //                         select m.ConfigVersion).Max();

            //    var autocode = (from auto in autocodes
            //                    where auto.ConfigVersion == configValue
            //                    select auto).FirstOrDefault();
            //    if (suborganizationID == null || suborganizationID == string.Empty)
            //        suborganizationID = organizationID;

            //    foreach (AutoCodePart part in autocode.AutoCodePart)
            //    {
            //        switch (part.PartType)
            //        {
            //            case 1:
            //                #region static
            //                strAutoCode = strAutoCode + part.Value + autocode.Separator;
            //                break;
            //                #endregion
            //            case 2:
            //                #region dynamic
            //                string dynamicValue;
            //                if (part.DynamicType != 7)
            //                {
            //                    string businessunitcode = this.GetBusinessCode(suborganizationID);
            //                    dynamicValue = this.GetDynamicPartValue(part.DynamicType, part.Value, generationdate, SAF.Common.OrganizationManager.GetCode(organizationID), businessunitcode);
            //                }
            //                else
            //                {
            //                    dynamicValue = featureinstanceValue;
            //                }

            //                strAutoCode = strAutoCode + dynamicValue + autocode.Separator;
            //                break;
            //                #endregion
            //            case 3: // Counter
            //                #region Counter
            //                byte type = 7;
            //                var partdynamic = from prt in autocode.AutoCodePart
            //                                  where prt.DynamicType == type
            //                                  select prt;
            //                int newcounterValue = 0;
            //                if (partdynamic.Count() == 0)
            //                {
            //                    DateTime nearestdate = this.GetNearestDate(generationdate, autocode.AutoCodeID, part.PartOrder, part.CounterResetBy, featureinstanceValue);
            //                    if (nearestdate.Date == DateTime.Now.Date)
            //                    {
            //                        AutoCodeCounter autocodecounter = this.CreateCounterObject(part, part.CounterStartValue, suborganizationID);
            //                        autocodecounter.LastResetDateTime = generationdate;
            //                        newcounterValue = autocodecounter.CounterValue + 1;
            //                        autocodecounter.CounterValue = newcounterValue;
            //                        entity.AutoCodeCounter.Add(autocodecounter);
            //                        entity.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        var autoCdCounter = (from cntr in entity.AutoCodeCounter
            //                                             where cntr.PartOrder == part.PartOrder && cntr.LastResetDateTime == nearestdate && cntr.BusinessUnitID == suborganizationID
            //                                             select cntr).FirstOrDefault();
            //                        if (autoCdCounter != null)
            //                        {
            //                            newcounterValue = autoCdCounter.CounterValue + 1;
            //                            if (generationdate > autoCdCounter.LastResetDateTime)
            //                                autoCdCounter.LastResetDateTime = generationdate;
            //                            autoCdCounter.CounterValue = newcounterValue;
            //                            entity.SaveChanges();
            //                        }
            //                        else
            //                        {
            //                            AutoCodeCounter autocodecounter = this.CreateCounterObject(part, part.CounterStartValue, suborganizationID);
            //                            autocodecounter.LastResetDateTime = generationdate;
            //                            newcounterValue = autocodecounter.CounterValue = autocodecounter.CounterValue + 1;
            //                            entity.AutoCodeCounter.Add(autocodecounter);
            //                            entity.SaveChanges();
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    DateTime nearestdate = this.GetNearestDate(generationdate, autocode.AutoCodeID, part.PartOrder, part.CounterResetBy, featureinstanceValue);

            //                    if (nearestdate.Date == DateTime.Now.Date)
            //                    {
            //                        AutoCodeCounter autocodecounter = this.CreateCounterObject(part, part.CounterStartValue, suborganizationID);
            //                        autocodecounter.LastResetDateTime = generationdate;
            //                        autocodecounter.DnamicPartValue = featureinstanceValue;
            //                        autocodecounter.CounterValue = newcounterValue = 1;
            //                        entity.AutoCodeCounter.Add(autocodecounter);
            //                        entity.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        var autoCdCounter = (from Cntr in part.AutoCodeCounter
            //                                             where Cntr.PartOrder == part.PartOrder && Cntr.DnamicPartValue == featureinstanceValue && Cntr.LastResetDateTime == nearestdate && Cntr.BusinessUnitID == suborganizationID
            //                                             select Cntr).FirstOrDefault();

            //                        if (autoCdCounter == null)
            //                        {
            //                            AutoCodeCounter autocodecounter = this.CreateCounterObject(part, part.CounterStartValue, suborganizationID);
            //                            autocodecounter.LastResetDateTime = generationdate;
            //                            newcounterValue = autocodecounter.CounterValue + 1;
            //                            autocodecounter.CounterValue = newcounterValue;
            //                            entity.AutoCodeCounter.Add(autocodecounter);
            //                            entity.SaveChanges();
            //                        }
            //                        else
            //                        {
            //                            autoCdCounter.CounterValue = autoCdCounter.CounterValue + 1;
            //                            autoCdCounter.LastResetDateTime = generationdate;
            //                            newcounterValue = autoCdCounter.CounterValue;
            //                        }
            //                    }

            //                    // inewcountervalue = this.GetCounterValueByDynamicTypeFeatureInstancebyOldDate(organizationCode, suborganizationCode, featureCode, featureinstanceValue, part.PartOrder, part.CounterResetBy, part.CounterStartValue, generationdate, counterRow);
            //                }

            //                strNewCounterValue = string.Format("{0:d" + part.CounterLength.ToString() + "}", newcounterValue);
            //                strAutoCode = strAutoCode + strNewCounterValue + autocode.Separator;
            //                break;
            //                #endregion
            //        }
            //    }

            //    // removing the last separator from the autocode string.
            //    strAutoCode = strAutoCode.Substring(0, strAutoCode.Length - autocode.Separator.Length);
            //}

            //return strAutoCode;
            return string.Empty;
        }

        /// <summary>
        /// Returns autocode.
        /// </summary>
        /// <param name="organizationCode">Organization Code.</param>
        /// <param name="suborganizationCode">Sub organization Code.</param>
        /// <param name="featureCode">Feature code.</param>
        /// <param name="featureinstanceValue">Feature Instance value.</param>
        /// <returns>Returns autocode.</returns>
        public string GetAutoCode(string organizationCode, string suborganizationCode, string featureCode, string featureinstanceValue)
        {
            //string strAutoCode = string.Empty; // stores and return the calculating auto code.
            //int inewcountervalue = 0; // stores the new counter value.
            //string strNewCounterValue = string.Empty;

            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    // AutoCode autocode = null;
            //    var autocodes = from code in entity.AutoCode.Include(Autocodepart).Include(Autcodepartdotautocodecounter)
            //                    join o in entity.Organization on code.OrganizationID equals o.Id
            //                    join f in entity.Feature on code.FeatureID equals f.Id
            //                    where o.Code == organizationCode && f.Code == featureCode && code.RecordState == 0
            //                    select code;

            //    if (autocodes.Count() == 0)
            //        throw new SAF.Exception.SarasException(SAF.Properties.Resources.ResourceManager.GetString(Autocodenotconfigure)) { ErrorCode = "AC0001" };

            //    string strautocodeID = autocodes.FirstOrDefault().AutoCodeID.ToString();

            //    // EF 4.0 is unale to understand the query if If we include "AutoCodePart" into above
            //    // query. for fixing this issue additinal query has been called. The below query may be deleted
            //    // in the feature EF version.
            //    var parts = (from p in entity.AutoCodePart.Include(Autocodcounter)
            //                 where p.AutoCodeID == strautocodeID
            //                 select p).ToList();

            //    byte? configValue = (from m in autocodes
            //                         select m.ConfigVersion).Max();

            //    // geting autocode from autocodes by latest config value.
            //    var autocode = (from auto in autocodes
            //                    where auto.ConfigVersion == configValue
            //                    select auto).FirstOrDefault();

            //    // If autocode is not there 
            //    if (autocode == null)
            //        throw new SAF.Exception.SarasException(SAF.Properties.Resources.ResourceManager.GetString(Autocodenotconfigure)) { ErrorCode = "AC0001" };
            //    if (suborganizationCode == null || suborganizationCode == string.Empty)
            //        suborganizationCode = organizationCode;

            //    #region Genereating Code

            //    // iterarting through every part.
            //    foreach (AutoCodePart part in autocode.AutoCodePart)
            //    {
            //        switch (part.PartType)
            //        {
            //            case 1:
            //                #region static
            //                strAutoCode = strAutoCode + part.Value + autocode.Separator;
            //                break;
            //                #endregion
            //            case 2:
            //                #region dynamic
            //                string dynamicValue;
            //                if (part.DynamicType != 7)
            //                {
            //                    dynamicValue = this.GetDynamicPartValue(part.DynamicType, part.Value, DateTime.Now, organizationCode, suborganizationCode);
            //                }
            //                else
            //                {
            //                    dynamicValue = featureinstanceValue;
            //                }

            //                strAutoCode = strAutoCode + dynamicValue + autocode.Separator;
            //                break;
            //                #endregion
            //            case 3: // Counter
            //                #region Counter
            //                byte type = 7;

            //                string strSubOrgID = (from rcd in entity.BusinessUnit where rcd.Code == suborganizationCode select rcd.Id).FirstOrDefault().ToString();
            //                var partdynamic = from prt in autocode.AutoCodePart
            //                                  where prt.DynamicType == type
            //                                  select prt;

            //                // Counter is created according to feature instance value if value is emplty get the couter row ad return the increased coutner
            //                // value. if feature instance value is there then check for counter with same fetaure instance value if not found add one more couter
            //                // with supplied feature instance value.
            //                // if (featureinstanceValue == null || featureinstanceValue == string.Empty)
            //                if (partdynamic.Count() == 0)
            //                {
            //                    var autoCdCounter1 = (from CntRow in part.AutoCodeCounter
            //                                          join o in entity.BusinessUnit on CntRow.BusinessUnitID equals o.Id
            //                                          where CntRow.PartOrder == part.PartOrder && o.Code == suborganizationCode && CntRow.DnamicPartValue == string.Empty
            //                                          orderby CntRow.LastResetDateTime
            //                                          select CntRow).ToList();
            //                    var autoCdCounter = autoCdCounter1.OrderByDescending(m => m.LastResetDateTime).ToList().FirstOrDefault();

            //                    // if organiztion is created after configureing the autocode so for that sub organization counter will none, so need add new record in couter table(else part)
            //                    if (autoCdCounter != null)
            //                    {
            //                        if (!this.IsCounterResetRequired((DateTime)autoCdCounter.LastResetDateTime, Convert.ToInt16(part.CounterResetBy)))
            //                        {
            //                            inewcountervalue = autoCdCounter.CounterValue + 1;
            //                            autoCdCounter.CounterValue = inewcountervalue;
            //                            autoCdCounter.LastResetDateTime = DateTime.Now.Date;
            //                            entity.SaveChanges();
            //                        }
            //                        else
            //                        {   // If reset is requierd.
            //                            AutoCodeCounter newcounter = this.CreateCounterObject(part, part.CounterStartValue, strSubOrgID);
            //                            inewcountervalue = part.CounterStartValue + 1;
            //                            newcounter.CounterValue = inewcountervalue;
            //                            entity.AutoCodeCounter.Add(newcounter);
            //                            entity.SaveChanges();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        AutoCodeCounter newcounter = this.CreateCounterObject(part, part.CounterStartValue, strSubOrgID);
            //                        inewcountervalue = newcounter.CounterValue = newcounter.CounterValue + 1;
            //                        newcounter.LastResetDateTime = DateTime.Now.Date;
            //                        entity.AutoCodeCounter.Add(newcounter);
            //                        entity.SaveChanges();
            //                    }
            //                }
            //                else
            //                {
            //                    var autoCdCounter = (from Cntr in entity.AutoCodeCounter
            //                                         join o in entity.BusinessUnit on Cntr.BusinessUnitID equals o.Id
            //                                         where Cntr.PartOrder == part.PartOrder && o.Code == suborganizationCode && Cntr.DnamicPartValue == featureinstanceValue
            //                                         orderby Cntr.LastResetDateTime descending
            //                                         select Cntr).FirstOrDefault();

            //                    // if counter is null for any case 1. featurevalie not there 2. new organization added
            //                    if (autoCdCounter == null || ((autoCdCounter.DnamicPartValue != featureinstanceValue) && autoCdCounter.DnamicPartValue != string.Empty))
            //                    {
            //                        AutoCodeCounter newcounter = this.CreateCounterObject(part, part.CounterStartValue, strSubOrgID);
            //                        newcounter.DnamicPartValue = featureinstanceValue;
            //                        inewcountervalue = newcounter.CounterValue + 1;
            //                        newcounter.CounterValue = inewcountervalue;
            //                        entity.AutoCodeCounter.Add(newcounter);
            //                        entity.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        if (!this.IsCounterResetRequired(autoCdCounter.LastResetDateTime, part.CounterResetBy))
            //                        {
            //                            autoCdCounter.CounterValue = autoCdCounter.CounterValue + 1; // this.GetCounterValue(autoCdCounter, counterresetby, counterstartvalue);
            //                            autoCdCounter.LastResetDateTime = DateTime.Now.Date;
            //                            inewcountervalue = autoCdCounter.CounterValue;
            //                            entity.SaveChanges();
            //                        }
            //                        else
            //                        {
            //                            AutoCodeCounter newcounter = this.CreateCounterObject(part, part.CounterStartValue, strSubOrgID);
            //                            inewcountervalue = part.CounterStartValue + 1;
            //                            newcounter.CounterValue = inewcountervalue;
            //                            entity.AutoCodeCounter.Add(newcounter);
            //                            entity.SaveChanges();
            //                        }
            //                    }
            //                }

            //                strNewCounterValue = string.Format("{0:d" + part.CounterLength.ToString() + "}", inewcountervalue);
            //                strAutoCode = strAutoCode + strNewCounterValue + autocode.Separator;
            //                break;
            //                #endregion
            //        }
            //    }

            //    #endregion

            //    // removing the last separator from the autocode string.
            //    strAutoCode = strAutoCode.Substring(0, strAutoCode.Length - autocode.Separator.Length);
            //}

            //return strAutoCode;
            return string.Empty;
        }

        /// <summary>
        /// Returns the AutoCode object if found for supplied data, otherwise throws exception.
        /// </summary>
        /// <param name="organizationID">ID of the Parent Organization which the AutoCode belongs to.</param>
        /// <param name="suborganizationID">ID of the SubOrganization.</param>
        /// <param name="featureID">ID of the Feature.</param>
        /// <param name="featureinstanceValue">Instance value of the feature.</param>
        /// <returns>Returns Generated auto code for specified Parameters.</returns>
        public string GetAutoCodeUsingIds(string organizationID, string suborganizationID, string featureID, string featureinstanceValue, string periodID = null)
        {
            // stores and return the calculating auto code.
            string autoCodeValue = string.Empty;

            // stores the new counter value.
            int counterValue = 0;
            string counterString = string.Empty;


            //List<SAF.Core.Security.Feature> features = null;

            //List<SAF.Core.Security.Feature> features = SAF.Core.Security.SecurityManager.GetFeatures();
            //if (featureID != "2D1761DB-A438-46CA-9AF1-830FBF31EC8D") //For online admission 
            //{
            //    features = this.GetFeatures();
            //}

            //Saras.Framework.Entity.Feature tagfeature = null;
            //Saras.Framework.Entity.Feature feature = null;

            //using (Saras.Framework.Entity.FrameworkEntities entity = new Saras.Framework.Entity.FrameworkEntities())
            //{
            //    tagfeature = (from f in entity.Feature
            //                  where f.Id == featureID
            //                  select f).FirstOrDefault();

            //    feature = (from f in entity.Feature where f.Id == featureID select f).FirstOrDefault();
            //    if (feature.IsPeriodSpecific && periodID == null)
            //    {
            //        periodID = SAF.Core.ApplicationContext.UserContext.PeriodID;
            //    }
            //}

            //if (tagfeature != null && tagfeature.TaggedLevel == 12)
            //{
            //    suborganizationID = organizationID;
            //}

            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    var autocodes = from auto in entity.AutoCode.Include(Autocodepart).Include(Autcodepartdotautocodecounter)
            //                    where auto.OrganizationID == organizationID && auto.FeatureID == featureID && auto.RecordState == 0
            //                    select auto;

            //    if (autocodes.Count() == 0)
            //        throw new SAF.Exception.SarasException(SAF.Properties.Resources.ResourceManager.GetString(Autocodenotconfigure)) { ErrorCode = "AC0001" };

            //    byte? configValue = (from m in autocodes
            //                         select m.ConfigVersion).Max();

            //    var autocode = (from auto in autocodes
            //                    where auto.ConfigVersion == configValue
            //                    select auto).FirstOrDefault();



            //    if (suborganizationID == null || suborganizationID == string.Empty)
            //        suborganizationID = organizationID;

            //    foreach (AutoCodePart part in autocode.AutoCodePart)
            //    {
            //        switch (part.PartType)
            //        {
            //            case 1:
            //                autoCodeValue = autoCodeValue + part.Value + autocode.Separator;
            //                break;

            //            case 2:
            //                #region Dynamic Part

            //                string dynamicValue;
            //                if (part.DynamicType != 7)
            //                {
            //                    string businessunitcode = this.GetBusinessCode(suborganizationID);
            //                    dynamicValue = this.GetDynamicPartValue(part.DynamicType, part.Value, DateTime.Now, SAF.Common.OrganizationManager.GetCode(organizationID), businessunitcode);
            //                }
            //                else
            //                    dynamicValue = featureinstanceValue;

            //                autoCodeValue = autoCodeValue + dynamicValue + autocode.Separator;
            //                break;

            //                #endregion

            //            case 3: // Counter
            //                #region Counter Part
            //                byte type = 7;
            //                var partdynamic = from prt in autocode.AutoCodePart
            //                                  where prt.DynamicType == type
            //                                  select prt;

            //                // if (featureinstanceValue == null || featureinstanceValue == string.Empty)
            //                if (partdynamic.Count() == 0)
            //                {
            //                    var autoCdCounter = (from row in part.AutoCodeCounter
            //                                         where row.DnamicPartValue == string.Empty && row.BusinessUnitID == suborganizationID
            //                                         && (periodID == null ? true : row.PeriodId == periodID)
            //                                         orderby row.LastResetDateTime descending
            //                                         select row).FirstOrDefault();
            //                    if (autoCdCounter != null)
            //                    {
            //                        if (!this.IsCounterResetRequired((DateTime)autoCdCounter.LastResetDateTime, Convert.ToInt16(part.CounterResetBy)))
            //                        {
            //                            counterValue = autoCdCounter.CounterValue = autoCdCounter.CounterValue + 1;
            //                            autoCdCounter.LastResetDateTime = DateTime.Now.Date;
            //                            entity.SaveChanges();
            //                        }
            //                        else
            //                        {
            //                            // If reset is requierd.
            //                            AutoCodeCounter autoCodeCounter = this.CreateCounterObject(part, part.CounterStartValue, suborganizationID);
            //                            autoCodeCounter.CounterValue = counterValue = part.CounterStartValue + 1;
            //                            entity.AutoCodeCounter.Add(autoCodeCounter);
            //                            entity.SaveChanges();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        AutoCodeCounter newcounter = this.CreateCounterObject(part, part.CounterStartValue, suborganizationID);
            //                        if (feature.IsPeriodSpecific)
            //                        {
            //                            newcounter.PeriodId = SAF.Core.ApplicationContext.UserContext.PeriodID;
            //                        }
            //                        counterValue = newcounter.CounterValue = newcounter.CounterValue + 1;
            //                        newcounter.LastResetDateTime = DateTime.Now.Date;
            //                        entity.AutoCodeCounter.Add(newcounter);
            //                        entity.SaveChanges();
            //                    }
            //                }
            //                else
            //                {
            //                    var autoCdCounter = (from row in part.AutoCodeCounter
            //                                         where row.DnamicPartValue == featureinstanceValue && row.BusinessUnitID == suborganizationID
            //                                         && (periodID == null ? true : row.PeriodId == periodID)
            //                                         orderby row.LastResetDateTime descending
            //                                         select row).FirstOrDefault();

            //                    if (autoCdCounter == null || ((autoCdCounter.DnamicPartValue != featureinstanceValue) && autoCdCounter.DnamicPartValue != string.Empty))
            //                    {
            //                        AutoCodeCounter autoCodeCounter = this.CreateCounterObject(part, part.CounterStartValue, suborganizationID);
            //                        if (feature.IsPeriodSpecific)
            //                        {
            //                            autoCodeCounter.PeriodId = SAF.Core.ApplicationContext.UserContext.PeriodID;
            //                        }
            //                        entity.AutoCodeCounter.Add(autoCodeCounter);
            //                        autoCodeCounter.CounterValue = counterValue = part.CounterStartValue + 1;
            //                        autoCodeCounter.DnamicPartValue = featureinstanceValue;
            //                        entity.SaveChanges();
            //                    }
            //                    else
            //                    {
            //                        // Updating the new counter value in counter object.
            //                        if (!this.IsCounterResetRequired(autoCdCounter.LastResetDateTime, part.CounterResetBy))
            //                        {
            //                            autoCdCounter.CounterValue = autoCdCounter.CounterValue + 1;
            //                            autoCdCounter.LastResetDateTime = DateTime.Now.Date;
            //                            counterValue = autoCdCounter.CounterValue;
            //                        }
            //                        else
            //                        {
            //                            counterValue = this.GetCounterValue(autoCdCounter, part.CounterStartValue);
            //                        }
            //                        entity.SaveChanges();
            //                    }
            //                }

            //                counterString = string.Format("{0:d" + part.CounterLength.ToString() + "}", counterValue);
            //                autoCodeValue = autoCodeValue + counterString + autocode.Separator;
            //                break;
            //                #endregion
            //        }
            //    }

            //    // removing the last separator from the autocode string.
            //    autoCodeValue = autoCodeValue.Substring(0, autoCodeValue.Length - autocode.Separator.Length);
            //}
            //return autoCodeValue;
            return string.Empty;

        }


        #endregion

        #region IsAutoCodeConfigured

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="organizationCode">Organization Code.</param>
        /// <param name="featureCode">Feature Code Data.</param>
        /// <returns>true/false based on the configuration.</returns>
        public bool IsAutoCodeConfigured(string organizationCode, string featureCode)
        {
            bool result = false;
            List<AutoCodeView> views = null;
            AutoCodeView autocodeview = null;

            //views = Cache.CacheManager.GetType<List<AutoCodeView>>(SAF.Common.UtilityManager.OrganizationKey, Autocodeview, null);
            //if (views == null)
            //{
            //    using (FrameworkEntities entity = new FrameworkEntities())
            //    {
            //        views = (from v in entity.AutoCodeView
            //                 select v).ToList();
            //        Cache.CacheManager.AddType<List<AutoCodeView>>(SAF.Common.UtilityManager.OrganizationKey, Autocodeview, views, null);
            //    }
            //}

            //// temporarly changes organization code to organizatioid.
            //if (views != null)
            //    autocodeview = (from v in views
            //                    where v.OrganizationId == organizationCode && v.FeatureCode == featureCode
            //                    orderby v.LastDate descending
            //                    select v).FirstOrDefault();
            //if (autocodeview != null)
            //{
            //    result = (bool)autocodeview.IsCodeConfigured;
            //}
            return result;
        }

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="featureCode">Feature Code Data.</param>
        /// <returns>true/false based on the configuration.</returns>
        public bool IsAutoCodeConfigured(string featureCode)
        {
            bool result = false;
            List<AutoCodeView> views = null;
            AutoCodeView autocodeview = null;

            //views = Cache.CacheManager.GetType<List<AutoCodeView>>(SAF.Common.UtilityManager.OrganizationKey, Autocodeview, null);
            //if (views == null)
            //{
            //    using (FrameworkEntities entity = new FrameworkEntities())
            //    {
            //        views = (from v in entity.AutoCodeView
            //                 select v).ToList();
            //        Cache.CacheManager.AddType<List<AutoCodeView>>(SAF.Common.UtilityManager.OrganizationKey, Autocodeview, views, null);
            //    }
            //}

            //if (views != null)
            //    autocodeview = (from v in views
            //                    where v.FeatureCode == featureCode && v.IsCodeConfigured == true
            //                    orderby v.LastDate descending
            //                    select autocodeview).FirstOrDefault();
            //if (autocodeview != null)
            //{
            //    result = (bool)autocodeview.IsCodeConfigured;
            //}
            return result;
        }

        /// <summary>
        /// Confirms whether AutoCode has been configured or not.
        /// </summary>
        /// <param name="organizationId">Organization id.</param>
        /// <param name="featureId">Feature id.</param>
        /// <returns>true/false based on the configuration.</returns>
        /// <returns></returns>
        public bool IsAutoCodeConfiguredByID(string organizationId, string featureId)
        {
            bool result = false;
            List<AutoCodeView> views = null;
            AutoCodeView autocodeview = null;

            //views = Cache.CacheManager.GetType<List<AutoCodeView>>(SAF.Common.UtilityManager.OrganizationKey, Autocodeview, null);
            //if (views == null)
            //{
            //    using (FrameworkEntities entity = new FrameworkEntities())
            //    {
            //        views = (from v in entity.AutoCodeView
            //                 select v).ToList();
            //        Cache.CacheManager.AddType<List<AutoCodeView>>(SAF.Common.UtilityManager.OrganizationKey, Autocodeview, views, null);
            //    }
            //}

            //if (views != null)
            //    autocodeview = (from v in views
            //                    where v.OrganizationId == organizationId && v.FeatureId == featureId
            //                    orderby v.LastDate descending
            //                    select v).FirstOrDefault();
            //if (autocodeview != null)
            //{
            //    result = (bool)autocodeview.IsCodeConfigured;
            //}
            return result;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Feature> GetFeatures()
        {
            Feature securityfeature = null;
            //List<Feature> features = SecurityManager.GetFeatures();
            //List<SAF.Core.Security.Feature> tempfeatures = new List<SAF.Core.Security.Feature>();
            //foreach (SAF.Core.Security.Feature ff in features)
            //{
            //    tempfeatures.Add(ff);
            //}
            //string mfcode = string.Empty;
            //using (Saras.Framework.Entity.FrameworkEntities entity = new Saras.Framework.Entity.FrameworkEntities())
            //{
            //    foreach (SAF.Core.Security.Feature userfeatures in tempfeatures)
            //    {
            //        foreach (SAF.Core.Security.Permission usermiscfeature in userfeatures.MiscPermissions)
            //        {
            //            mfcode = usermiscfeature.PermissionName;
            //            var miscfeature = (from f in entity.Feature where f.Code == mfcode select f).FirstOrDefault();
            //            if (miscfeature != null)
            //            {
            //                securityfeature = new SAF.Core.Security.Feature();
            //                securityfeature.IsAutoCodeConfigurable = miscfeature.IsAutoCodeConfigurable.Value;
            //                securityfeature.FeatureCode = miscfeature.Code;
            //                securityfeature.FeatureId = miscfeature.Id;
            //                securityfeature.FeatureName = userfeatures.FeatureName + "-->" + miscfeature.Name;
            //                securityfeature.IsObjectSecurityApplicable = miscfeature.IsOLSApplicable;
            //                securityfeature.TaggedLevel = miscfeature.TaggedLevel;
            //                features.Add(securityfeature);
            //            }
            //        }
            //    }
            //}
            //return features;
            return null;
        }




        /// <summary>
        /// Returns value for dynamic type depending on the format type.
        /// </summary>
        /// <param name="formatID">Format ID.</param>
        /// <returns>Returns string.</returns>
        private string GetValueByFormat(string formatType, DateTime dtvalue)
        {
            //DateTime dtvalue = generationdate;
            string strReturnValue = string.Empty;

            switch (formatType.ToUpper())
            {
                case "MM":
                    strReturnValue = dtvalue.ToString("MM");
                    break;
                case "MMM":
                    strReturnValue = dtvalue.ToString("MMM");
                    break;
                case "MMMM":
                    strReturnValue = dtvalue.ToString("MMMM");
                    break;
                case "YYYY":
                    strReturnValue = dtvalue.ToString("yyyy");
                    break;
                case "YY":
                    strReturnValue = dtvalue.ToString("yy");
                    break;
                case "DDMMYY":
                    strReturnValue = dtvalue.ToString("dd/MM/yy");
                    break;
                case "DDMMYYYY":
                    strReturnValue = dtvalue.ToString("dd/MM/yyyy");
                    break;
                case "MMDDYYYY":
                    strReturnValue = dtvalue.ToString("MM/dd/yyyy");
                    break;
                case "YYYYMMDD":
                    strReturnValue = dtvalue.ToString("yyyy/MM/dd");
                    break;
                case "MMYYYY":
                    strReturnValue = dtvalue.ToString("MM/yyyy");
                    break;
                case "MMYY":
                    strReturnValue = dtvalue.ToString("MM/yy");
                    break;
                case "MMMMYYYY":
                    strReturnValue = dtvalue.ToString("MMMM/yyyy");
                    break;
                case "MMMYYYY":
                    strReturnValue = dtvalue.ToString("MMM/yyyy");
                    break;
                case "DDD":
                    strReturnValue = dtvalue.ToString("ddd");
                    break;
                case "DD":
                    strReturnValue = dtvalue.ToString("dd");
                    break;
                case "YEAR-WEEK":
                    strReturnValue = string.Format("{0:d2}", this.GetWeekNumber(dtvalue));
                    break;
                case "MONTH-WEEK":
                    strReturnValue = string.Format("{0:d2}", this.GetWeekOfMonth(dtvalue));
                    break;
            }
            strReturnValue.Replace("/", "");
            strReturnValue = strReturnValue.Replace("-", string.Empty);
            return strReturnValue;
        }

        /// <summary>
        /// Returns Counter value depending on reset option.
        /// </summary>
        /// <param name="counter">Current counter value.</param>
        /// <param name="resetOption">Reset option of counter.</param>
        /// <param name="counterstartvalue">Counter start value.</param>
        /// <returns>Returns integer.</returns>
        private int GetCounterValue(AutoCodeCounter counter, int counterstartvalue)
        {
            //using (FrameworkEntities entity1 = new FrameworkEntities())
            //{
            //    AutoCodeCounter cntr = new AutoCodeCounter();
            //    cntr.CounterId = Guid.NewGuid().ToString();
            //    cntr.AutoCodeID = counter.AutoCodeID;
            //    cntr.OrganizationGroupID = counter.OrganizationGroupID;
            //    cntr.OrganizationID = counter.OrganizationID;
            //    cntr.BusinessUnitID = counter.BusinessUnitID;
            //    cntr.DnamicPartValue = counter.DnamicPartValue;
            //    cntr.CounterValue = counterstartvalue + 1;
            //    cntr.LastResetDateTime = DateTime.Now;
            //    cntr.PartOrder = counter.PartOrder;

            //    // Default Columns;
            //    cntr.CreatedBy = Guid.NewGuid().ToString();
            //    cntr.CreatedDate = DateTime.Now;
            //    cntr.LastUpdatedBy = Guid.NewGuid().ToString();
            //    cntr.LastUpdatedDate = DateTime.Now;
            //    cntr.RecordState = 0;
            //    cntr.WorkflowState = 0;
            //    cntr.OBSCode = "1";
            //    cntr.LanguageId = counter.LanguageId;
            //    entity1.AutoCodeCounter.Add(cntr);
            //    entity1.SaveChanges();
            //    return cntr.CounterValue;
            //}
            return 0;
        }

        /// <summary>
        /// Returns Counter value depending on reset option.
        /// </summary>
        /// <param name="counter">Current counter value.</param>
        /// <param name="resetOption">Reset option of counter.</param>
        /// <param name="counterstartvalue">Counter start value.</param>
        /// <returns>Returns integer.</returns>
        private AutoCodeCounter CreateCounterObject(AutoCodePart part, int counterstartvalue, string suborgid)
        {
            AutoCodeCounter codeCounter = new AutoCodeCounter();
            codeCounter.CounterId = Guid.NewGuid().ToString();
            codeCounter.AutoCodeID = part.AutoCodeID;
            codeCounter.OrganizationGroupID = part.OrganizationGroupID;
            codeCounter.OrganizationID = part.OrganizationID;

            // if (part.BusinessUnitID == string.Empty)
            codeCounter.BusinessUnitID = suborgid;

            // else
            //  codeCounter.BusinessUnitID = part.BusinessUnitID;
            codeCounter.DnamicPartValue = string.Empty;
            codeCounter.CounterValue = counterstartvalue;
            codeCounter.LastResetDateTime = DateTime.Now;
            codeCounter.PartOrder = part.PartOrder;

            // Default Columns;
            //codeCounter.CreatedBy = UserContext.UserID;
            codeCounter.CreatedDate = DateTime.Now;
           // codeCounter.LastUpdatedBy = UserContext.UserID;
            codeCounter.LastUpdatedDate = DateTime.Now;
            codeCounter.RecordState = 0;
            codeCounter.WorkflowState = 0;
            codeCounter.OBSCode = "1";
            codeCounter.LanguageId = part.LanguageId;

            return codeCounter;
        }

        /// <summary>
        /// Returns true or false based on reset option.
        /// </summary>
        /// <param name="lastresetDate">Last rest date.</param>
        /// <param name="resetOption">Reset option.</param>
        /// <returns>Returns boolean.</returns>
        private bool IsCounterResetRequired(DateTime lastresetDate, int resetOption)
        {
            bool returnValue = false;
            switch (resetOption)
            {
                case 1:
                    returnValue = false;
                    break;
                case 2:
                    returnValue = lastresetDate.Year != DateTime.Now.Year ? true : false;
                    break;
                case 3:
                    returnValue = lastresetDate.Month != DateTime.Now.Month ? true : false;
                    break;
                case 4:
                    returnValue = this.GetWeekNumber(lastresetDate) != this.GetWeekNumber(DateTime.Now) ? true : false;
                    break;

                case 5:
                    returnValue = lastresetDate.Day != DateTime.Now.Day ? true : false;
                    break;
            }

            return returnValue;
        }

        /// <summary>
        /// Returns week number of year.
        /// </summary>
        /// <param name="date">Date for which week number is calculated.</param>
        /// <returns>Returns integer.</returns>
        private int GetWeekNumber(DateTime date)
        {
            // returns the week with respect to year according to local culture.
            return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstDay, (new DateTime(date.Year, 1, 1)).DayOfWeek);
        }

        /// <summary>
        /// Returns week number of month. 
        /// </summary>
        /// <param name="date">Date for which week number is calculated.</param>
        /// <returns>Returns integer.</returns>
        private int GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }

        /// <summary>
        /// Returns dynamic part value in format provided by format type.
        /// </summary>
        /// <param name="dynamictype">Dynamic type of part.</param>
        /// <param name="formattype">Format type of part.</param>
        /// <returns>Returns string.</returns>
        private string GetDynamicPartValue(byte dynamictype, string formattype, DateTime geneartiondate, string organizationCode, string suborganizationCode)
        {
            string strValue = string.Empty;
            switch (dynamictype)
            {
                case 1: // Year
                case 2: // Month
                case 3: // Week
                case 4: // Day
                case 5: // Date
                case 6: // Month-Year
                    strValue = this.GetValueByFormat(formattype, geneartiondate);
                    break;
                case 8: // Organization
                    strValue = organizationCode;
                    break;
                case 9: // SubOrganization
                    if (suborganizationCode == null || suborganizationCode == string.Empty)
                    {
                        strValue = organizationCode;
                    }
                    else
                    {
                        strValue = suborganizationCode;
                    }
                    break;
                case 10:
                    //strValue = ApplicationContext.UserContext.PeriodCode;
                    break;
            }

            return strValue;
        }

        /// <summary>
        /// Returns the Nearest generatiuon date.
        /// </summary>
        /// <param name="generationdate">Generation date.</param>
        /// <param name="counter">Counter value.</param>
        /// <param name="resetoption">Resetoption value.</param>
        /// <param name="fetureinstancevalue">Fetureinstancevalue value.</param>
        /// <returns>Returns the datetime object.</returns>
        private DateTime GetNearestDate(DateTime generationdate, string autocodeId, byte partOrder, byte resetoption, string fetureinstancevalue)
        {
            DateTime result = DateTime.Now;
            //string featurevalue = fetureinstancevalue != string.Empty ? fetureinstancevalue : string.Empty;

            string featurevalue = fetureinstancevalue;
            //using (FrameworkEntities entity = new FrameworkEntities())
            //{
            //    var dates = from cntr in entity.AutoCodeCounter
            //                where cntr.AutoCodeID == autocodeId && cntr.PartOrder == partOrder && cntr.DnamicPartValue == fetureinstancevalue
            //                select cntr.LastResetDateTime;
            //    foreach (DateTime date in dates)
            //    {
            //        switch (resetoption)
            //        {
            //            case 2: // year
            //                if (generationdate.Year == date.Year)
            //                    result = date;
            //                break;
            //            case 3: // month
            //                if (generationdate.Year == date.Year && generationdate.Month == date.Month)
            //                    result = date;
            //                break;
            //            case 4: // week
            //                if (generationdate.Year == date.Year && this.GetWeekNumber(generationdate) == this.GetWeekNumber(date))
            //                    result = date;
            //                break;
            //            case 5: // date
            //                if (generationdate == date)
            //                    result = date;
            //                break;
            //        }
            //    }
            //}
            return result;
        }

        /// <summary>
        /// Return business code.
        /// </summary>
        /// <param name="businessunitid">Business unit id</param>
        /// <returns>String value.</returns>
        private string GetBusinessCode(string businessunitid)
        {
            //List<BusinessUnit> lstbusinessunit = SAF.Core.Security.SecurityManager.GetBusinessUnits();
            //BusinessUnit businessunit = (from bu in lstbusinessunit where bu.Id == businessunitid select bu).FirstOrDefault();
            //if (businessunit != null)
            //    return businessunit.Code;
            //else
                return null;
        }

        #endregion
    }
}
