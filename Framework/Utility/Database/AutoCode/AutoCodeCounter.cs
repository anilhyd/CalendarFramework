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
    using Microsoft.EntityFrameworkCore;

    using System.Runtime.Serialization;
    
     [DataContract(IsReference = true)]
     [Serializable]
     public partial class AutoCodeCounter : EntityBase
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
        public AutoCodeCounter Copy()
        {
            return (AutoCodeCounter)this.MemberwiseClone();
        }
        
        /// <summary>
        /// Creates the new copy of the entity.
        /// </summary>
        public AutoCodeCounter CreateObject()
        {
            return new AutoCodeCounter();
        }
    
        #endregion
    
    		[DataMember]
    		public string  CounterId
    		{
    			 get
    			{
    				return lcounterid;
    			}
    
    			 set
    			{
    				if (lcounterid != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("CounterId", new Tuple<object, object>(lcounterid, value));
         				if(value != null)
        					lcounterid = value.Trim();
        				else
        					lcounterid = string.Empty;
    				}
    			}
    		}
    		private string lcounterid = string.Empty;
    		
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
    		public byte  PartOrder
    		{
    			 get
    			{
    				return lpartorder;
    			}
    
    			 set
    			{
    					if (lpartorder != value)
    					{
    						if (base.EntityState == EntityState.Modified)
    							this.RecordStateValue("PartOrder", new Tuple<object, object>(lpartorder, value));
    						lpartorder = value;
    					}
    			}
    		}
    		private byte lpartorder = default(byte);
    		
    		[DataMember]
    		public System.DateTime  LastResetDateTime
    		{
    			 get
    			{
    				return llastresetdatetime;
    			}
    
    			 set
    			{
    					if (llastresetdatetime != value)
    					{
    						if (base.EntityState == EntityState.Modified)
    							this.RecordStateValue("LastResetDateTime", new Tuple<object, object>(llastresetdatetime, value));
    						llastresetdatetime = value;
    					}
    			}
    		}
    		private System.DateTime llastresetdatetime = default(System.DateTime);
    		
    		[DataMember]
    		public string  DnamicPartValue
    		{
    			 get
    			{
    				return ldnamicpartvalue;
    			}
    
    			 set
    			{
    				if (ldnamicpartvalue != value)
    				{
    					if (base.EntityState == EntityState.Modified)
    						base.RecordStateValue("DnamicPartValue", new Tuple<object, object>(ldnamicpartvalue, value));
         				if(value != null)
        					ldnamicpartvalue = value.Trim();
        				else
        					ldnamicpartvalue = string.Empty;
    				}
    			}
    		}
    		private string ldnamicpartvalue = string.Empty;
    		
    		[DataMember]
    		public int  CounterValue
    		{
    			 get
    			{
    				return lcountervalue;
    			}
    
    			 set
    			{
    					if (lcountervalue != value)
    					{
    						if (base.EntityState == EntityState.Modified)
    							this.RecordStateValue("CounterValue", new Tuple<object, object>(lcountervalue, value));
    						lcountervalue = value;
    					}
    			}
    		}
    		private int lcountervalue = default(int);
    		
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
    public virtual AutoCodePart AutoCodePart { get; set; }
    }
}
