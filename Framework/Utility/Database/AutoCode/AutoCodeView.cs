//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Calendar.Framework.Entity
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using System.Runtime.Serialization;
    
     [DataContract(IsReference = true)]
     [Serializable]
     public partial class AutoCodeView : EntityBase
    {
    
    	#region Copy
    	/// <summary>
        /// Clones or copy an object.
        /// </summary>
        /// <remarks>
        /// <para>The object to be cloned must be serializable.</para>
        /// <para>The serialization is to use the 
        /// <see cref="System.Xml.Serialization.XmlSerializer" />.
        /// </para>
        /// </remarks>
        /// <returns>AuditUser  object.</returns>
        public AutoCodeView Copy()
        {
            return (AutoCodeView)this.MemberwiseClone();
        }
        
        /// <summary>
        /// Creates the new copy of the entity.
        /// </summary>
        public AutoCodeView CreateObject()
        {
            return new AutoCodeView();
        }
    
        #endregion
    
    		[DataMember]
    		public string  AutoCodeId
    		{
    			 get
    			{
    				return lautocodeid;
    			}
    
    			 set
    			{
    				if (lautocodeid != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("AutoCodeId", new Tuple<object, object>(lautocodeid, value));
         				if(value != null)
        					lautocodeid = value.Trim();
        				else
        					lautocodeid = string.Empty;
    				}
    			}
    		}
    		private string lautocodeid = string.Empty;
    		
    		[DataMember]
    		public string  OrganizationId
    		{
    			 get
    			{
    				return lorganizationid;
    			}
    
    			 set
    			{
    				if (lorganizationid != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("OrganizationId", new Tuple<object, object>(lorganizationid, value));
    					lorganizationid = value;
    				}
    			}
    		}
    		private string lorganizationid;
    		
    		[DataMember]
    		public string  OrganizationCode
    		{
    			 get
    			{
    				return lorganizationcode;
    			}
    
    			 set
    			{
    				if (lorganizationcode != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("OrganizationCode", new Tuple<object, object>(lorganizationcode, value));
    					lorganizationcode = value;
    				}
    			}
    		}
    		private string lorganizationcode;
    		
    		[DataMember]
    		public string  SubOrganizationId
    		{
    			 get
    			{
    				return lsuborganizationid;
    			}
    
    			 set
    			{
    				if (lsuborganizationid != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("SubOrganizationId", new Tuple<object, object>(lsuborganizationid, value));
    					lsuborganizationid = value;
    				}
    			}
    		}
    		private string lsuborganizationid;
    		
    		[DataMember]
    		public string  SubOrganizationCode
    		{
    			 get
    			{
    				return lsuborganizationcode;
    			}
    
    			 set
    			{
    				if (lsuborganizationcode != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("SubOrganizationCode", new Tuple<object, object>(lsuborganizationcode, value));
    					lsuborganizationcode = value;
    				}
    			}
    		}
    		private string lsuborganizationcode;
    		
    		[DataMember]
    		public string  FeatureId
    		{
    			 get
    			{
    				return lfeatureid;
    			}
    
    			 set
    			{
    				if (lfeatureid != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("FeatureId", new Tuple<object, object>(lfeatureid, value));
    					lfeatureid = value;
    				}
    			}
    		}
    		private string lfeatureid;
    		
    		[DataMember]
    		public string  FeatureCode
    		{
    			 get
    			{
    				return lfeaturecode;
    			}
    
    			 set
    			{
    				if (lfeaturecode != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("FeatureCode", new Tuple<object, object>(lfeaturecode, value));
    					lfeaturecode = value;
    				}
    			}
    		}
    		private string lfeaturecode;
    		
    		[DataMember]
    		public Nullable<byte>  ConfigVersion
    		{
    			 get
    			{
    				return lconfigversion;
    			}
    
    			 set
    			{
    					if (lconfigversion != value)
    					{
    						if (base.EntityState == EntityState.Modified)
    							this.RecordStateValue("ConfigVersion", new Tuple<object, object>(lconfigversion, value));
    						lconfigversion = value;
    					}
    			}
    		}
    		private Nullable<byte> lconfigversion = default(Nullable<byte>);
    		
    		[DataMember]
    		public Nullable<bool>  IsCodeConfigured
    		{
    			 get
    			{
    				return liscodeconfigured;
    			}
    
    			 set
    			{
    					if (liscodeconfigured != value)
    					{
    						if (base.EntityState == EntityState.Modified)
    							this.RecordStateValue("IsCodeConfigured", new Tuple<object, object>(liscodeconfigured, value));
    						liscodeconfigured = value;
    					}
    			}
    		}
    		private Nullable<bool> liscodeconfigured = default(Nullable<bool>);
    		
    		[DataMember]
    		public Nullable<System.DateTime>  LastDate
    		{
    			 get
    			{
    				return llastdate;
    			}
    
    			 set
    			{
    					if (llastdate != value)
    					{
    						if (base.EntityState == EntityState.Modified)
    							this.RecordStateValue("LastDate", new Tuple<object, object>(llastdate, value));
    						llastdate = value;
    					}
    			}
    		}
    		private Nullable<System.DateTime> llastdate = default(Nullable<System.DateTime>);
    		
    		[DataMember]
    		public string  PeriodCode
    		{
    			 get
    			{
    				return lperiodcode;
    			}
    
    			 set
    			{
    				if (lperiodcode != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("PeriodCode", new Tuple<object, object>(lperiodcode, value));
    					lperiodcode = value;
    				}
    			}
    		}
    		private string lperiodcode;
    		
    }
}
