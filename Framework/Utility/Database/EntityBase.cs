#region Header Info
//-----------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>This is the base class from which most business entities will be derived.</summary>
// <createdby>Desayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='N. Desayya' modifieddate='29-7-2011' revisionno='1.0'>Changed serialization type xmlserializtion to  NetDataContractSerializer in Copy method.</revision>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
//  <revision modifiedby='adla' modifieddate='14-02-2012' revisionno='1.1'> Change tracker added to workflow state</revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#endregion

namespace Calendar.Framework.Entity
{
    /// <summary>
    /// This is the base class from which most business entities
    /// will be derived.
    /// </summary>
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class EntityBase
    {
        #region Properties

        /// <summary>
        /// organizationID for setting the value.
        /// </summary>
        private string organizationID;

        /// <summary>
        /// organizationUnitID for setting the value.
        /// </summary>
        private string organizationGroupID;

        /// <summary>
        /// businessUnitID for setting the value.
        /// </summary>
        private string businessUnitID;

        /// <summary>
        /// obscode code for holding obs code.
        /// </summary>
        private string obscode;

        /// <summary>
        /// for maintaining the state of the record
        /// </summary>
        private short recordState;

        /// <summary>
        /// for maintaining the workflow state of the record
        /// </summary>
        private short workflowState;

        /// <summary>
        /// for maintaining the language id of the record
        /// </summary>
        private const string languageId = "en-US";

        /// <summary>
        /// for maintaining the editable mode of the record
        /// </summary>
        private bool iseditable = true;

        /// <summary>
        /// for maintaining the Version No. of the record
        /// </summary>
        private string versionno = "2012.08.13";

        /// <summary>
        /// for maintaining the Period Id of the record
        /// </summary>
        private string periodid = string.Empty;

        /// <summary>
        /// Stores the state entry values.
        /// </summary>
        private StateEntriesDictionary stateValues;

        ///// <summary>
        ///// Property for maintaining the ChangeTracker status.
        ///// </summary>
        //internal protected ObjectChangeTracker ChangeTrackerBase = null;

        /// <summary>
        /// for maintaining the page visiting of the entity.
        /// </summary>
        private bool isVisisted = false;

        /// <summary>
        /// Gets or sets the UserID.
        /// </summary>
        [DataMember]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the Created Date.
        /// </summary>
        [DataMember]
        public System.DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the Last Updadted user id.
        /// </summary>
        [DataMember]
        public string LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the Last Updated Date.
        /// </summary>
        [DataMember]
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the Organization ID.
        /// </summary>
        [DataMember]
        public string OrganizationID
        {
            get
            {
                return organizationID;
            }
            set
            {
                if (this.organizationID != value)
                {
                    this.RecordStateValue("OrganizationID", new Tuple<object, object>(OrganizationID, value));
                    if (value != null)
                        this.organizationID = value.Trim();
                    else
                        this.organizationID = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Organization ID.
        /// </summary>
        [DataMember]
        public string OrganizationGroupID
        {
            get
            {
                return organizationGroupID;
            }
            set
            {
                if (this.organizationGroupID != value)
                {
                    this.RecordStateValue("OrganizationGroupID", new Tuple<object, object>(organizationGroupID, value));
                    if (value != null)
                        this.organizationGroupID = value.Trim();
                    else
                        this.organizationGroupID = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the obs code.
        /// </summary>
        [DataMember]
        public string OBSCode
        {
            get
            {
                return obscode;
            }
            set
            {
                if (this.obscode != value)
                {
                    this.RecordStateValue("OBSCode", new Tuple<object, object>(obscode, value));
                    if (value != null)
                        this.obscode = value.Trim();
                    else
                        this.obscode = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the obs code.
        /// </summary>
        [DataMember]
        public string BusinessUnitID
        {
            get
            {
                return businessUnitID;
            }
            set
            {
                if (this.businessUnitID != value)
                {
                    this.RecordStateValue("BusinessUnitID", new Tuple<object, object>(businessUnitID, value));
                    if (value != null)
                        this.businessUnitID = value.Trim();
                    else
                        this.businessUnitID = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the record state.
        /// </summary>
        [DataMember]
        public short RecordState
        {
            get
            {
                return recordState;
            }
            set
            {
                if (this.recordState != value)
                {
                    this.RecordStateValue("RecordState", new Tuple<object, object>(recordState, value));
                        this.recordState = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the workflow state.
        /// </summary>
        [DataMember]
        public short WorkflowState
        {
            get
            {
                return workflowState;
            }
            set
            {
                if (this.workflowState != value)
                {
                    this.RecordStateValue("WorkflowState", new Tuple<object, object>(workflowState, value));
                    this.workflowState = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Language Id.
        /// </summary>
        [DataMember]
        public string LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the IsEditable state.
        /// </summary>
        [DataMember]
        public bool IsEditable
        {
            get
            {
                return iseditable;
            }
            set
            {
                if (this.iseditable != value)
                {
                    this.RecordStateValue("IsEditable", new Tuple<object, object>(iseditable, value));
                    this.iseditable = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Version No.
        /// </summary>
        [DataMember]
        public string VersionNo
        {
            get
            {
                return versionno;
            }
            set
            {
                if (this.versionno != value)
                {
                    this.RecordStateValue("VersionNo", new Tuple<object, object>(versionno, value));
                    if (value != null)
                        this.versionno = value.Trim();
                    else
                        this.versionno = string.Empty;
                } 
            }
        }

        /// <summary>
        /// Gets or sets the Period Id.
        /// </summary>
        [DataMember]
        public string PeriodId
        {
            get
            {
                return periodid;
            }
            set
            {
                if (this.periodid != value)
                {
                    this.RecordStateValue("PeriodId", new Tuple<object, object>(periodid, value));
                    if (value != null)
                        this.periodid = value.Trim();
                    else
                        this.periodid = string.Empty;
                } 
            }
        }

        /// <summary>
        /// Gets or sets the Visitited Info.
        /// </summary>
        public bool IsVisited
        {
            get
            {
                return isVisisted;
            }
            set
            {
                isVisisted = value;
            }
        }

        /// <summary>
        /// Gets the original values for properties that were changed. 
        /// </summary>
        internal StateEntriesDictionary StateValues
        {
            get
            {
                if (this.stateValues == null)
                {
                    this.stateValues = new StateEntriesDictionary();
                }

                return this.stateValues;
            }
        }
        #endregion

        #region Property : PageContext

        /// <summary>
        /// Gets the PageContext object.
        /// </summary>
        public Object PageContext { get; internal set; }

        #endregion

        #region Property : Criteria

        /// <summary>
        /// Gets the Criteria object.
        /// </summary>
        public Object Criteria { get; internal set; }

        /// <summary>
        /// Gets the Method Name.
        /// </summary>
        public string Mehtod { get; internal set; }

        #endregion

        #region Clone Object
        //        /// <summary>
        //        /// Clones an object.
        //        /// </summary>
        //        /// <typeparam name="T">Type of the object.</typeparam>
        //        /// <param name="obj">The object to clone.</param>
        //        /// <remarks>
        //        /// <para>The object to be cloned must be serializable.</para>
        //        /// <para>The serialization is to use the 
        //        /// <see cref="System.Xml.Serialization.XmlSerializer" />.
        //        /// </para>
        //        /// </remarks>
        //        /// <returns>Specified Type object.</returns>
        //        [Browsable(false)]
        //        [EditorBrowsable(EditorBrowsableState.Never)]
        //        protected T Copy<T>(T obj)
        //        {
        //#if POSTDEBUG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols
        //            DateTime dtStart = DateTime.Now;
        //#endif
        //            T entity = (T)SAF.Serialization.SerializationManager.Deserialize(SAF.Serialization.SerializationManager.Serialize(obj, Common.SerializationFormatter.NetDataContractSerializer));
        //#if POSTDEBUG //Executes this code only if you add POSTDEBUG to Conditiional Compilation Symbols

        //#endif

        //            return entity;
        //        }

        #endregion

        #region Entity Hierache
        /// <summary>
        /// Holds the hierache of objects.
        /// </summary>
        internal List<EntityBase> EntityObjects = new List<EntityBase>();

        /// <summary>
        /// Gets or sets the Stauts of the row. It can be Either Added, Modified, Deleted and Unchanged.
        /// </summary>
        public EntityState RowState
        {
            get
            {
                return rowState;
            }

            set
            {
                rowState = value;
            }
        }

        /// <summary>
        /// Holds the status of the row.
        /// </summary>
        private EntityState rowState = EntityState.Unchanged;

        /// <summary>
        /// Used for tracking the changes made in the entity in updated state.
        /// </summary>
        public EntityState EntityState = EntityState.Unchanged;

        #endregion

        /// <summary>
        /// Captures the original sate, and new value for a property that is changing.
        /// </summary>
        /// <param name="propertyName">Name of the Parameter.</param>
        /// <param name="value">Value of the Parameter.</param>
        protected void RecordStateValue(string propertyName, Tuple<object, object> value)
        {
            if (EntityState == EntityState.Modified)
            {
                if (this.StateValues.ContainsKey(propertyName))
                    this.StateValues[propertyName] = value;
                else
                    this.StateValues.Add(propertyName, value);
            }
        }

    }
}

/// <summary>
/// Dictionary object stores the property states into it.
/// </summary>
[CollectionDataContract(Name = "StateEntriesDictionary", ItemName = "StateEntries", KeyName = "Name", ValueName = "StateEntry")]
[Serializable]
public class StateEntriesDictionary : Dictionary<string, Tuple<object, object>>
{
    public StateEntriesDictionary()
    { }
    public StateEntriesDictionary(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
}