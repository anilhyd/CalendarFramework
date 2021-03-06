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
     public partial class AutoCode : EntityBase
    {
        public AutoCode()
        {
            this.AutoCodePart = new HashSet<AutoCodePart>();
        }
    
    
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
        public AutoCode Copy()
        {
            return (AutoCode)this.MemberwiseClone();
        }
        
        /// <summary>
        /// Creates the new copy of the entity.
        /// </summary>
        public AutoCode CreateObject()
        {
            return new AutoCode();
        }
    
        #endregion
    
    		[DataMember]
    		public string  AutoCodeID
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
    						base.RecordStateValue("AutoCodeID", new Tuple<object, object>(lautocodeid, value));
         				if(value != null)
        					lautocodeid = value.Trim();
        				else
        					lautocodeid = string.Empty;
    				}
    			}
    		}
    		private string lautocodeid = string.Empty;
    		
    		[DataMember]
    		public string  FeatureID
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
    						base.RecordStateValue("FeatureID", new Tuple<object, object>(lfeatureid, value));
         				if(value != null)
        					lfeatureid = value.Trim();
        				else
        					lfeatureid = string.Empty;
    				}
    			}
    		}
    		private string lfeatureid = string.Empty;
    		
    		[DataMember]
    		public byte  NumberOfParts
    		{
    			 get
    			{
    				return lnumberofparts;
    			}
    
    			 set
    			{
    					if (lnumberofparts != value)
    					{
    						if (base.EntityState == EntityState.Modified)
    							this.RecordStateValue("NumberOfParts", new Tuple<object, object>(lnumberofparts, value));
    						lnumberofparts = value;
    					}
    			}
    		}
    		private byte lnumberofparts = default(byte);
    		
    		[DataMember]
    		public string  Separator
    		{
    			 get
    			{
    				return lseparator;
    			}
    
    			 set
    			{
    				if (lseparator != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("Separator", new Tuple<object, object>(lseparator, value));
         				if(value != null)
        					lseparator = value.Trim();
        				else
        					lseparator = string.Empty;
    				}
    			}
    		}
    		private string lseparator = string.Empty;
    		
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
    		public string  CodeFormat
    		{
    			 get
    			{
    				return lcodeformat;
    			}
    
    			 set
    			{
    				if (lcodeformat != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("CodeFormat", new Tuple<object, object>(lcodeformat, value));
    					lcodeformat = value;
    				}
    			}
    		}
    		private string lcodeformat;
    		
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
    		public string  AppId
    		{
    			 get
    			{
    				return lappid;
    			}
    
    			 set
    			{
    				if (lappid != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("AppId", new Tuple<object, object>(lappid, value));
    					lappid = value;
    				}
    			}
    		}
    		private string lappid;
    		
    		[DataMember]
    		public string  COLUMNC16
    		{
    			 get
    			{
    				return lcolumnc16;
    			}
    
    			 set
    			{
    				if (lcolumnc16 != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("COLUMNC16", new Tuple<object, object>(lcolumnc16, value));
    					lcolumnc16 = value;
    				}
    			}
    		}
    		private string lcolumnc16;
    		
    		[DataMember]
    		public string  COLUMNC17
    		{
    			 get
    			{
    				return lcolumnc17;
    			}
    
    			 set
    			{
    				if (lcolumnc17 != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("COLUMNC17", new Tuple<object, object>(lcolumnc17, value));
    					lcolumnc17 = value;
    				}
    			}
    		}
    		private string lcolumnc17;
    		
    
        [DataMember]
    public virtual ICollection<AutoCodePart> AutoCodePart { get; set; }
    }
}
