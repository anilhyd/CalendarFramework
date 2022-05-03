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
    
    using System.Runtime.Serialization;
    
     [DataContract(IsReference = true)]
     [Serializable]
     public partial class RuleFeatureOperation : EntityBase
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
        public RuleFeatureOperation Copy()
        {
            return (RuleFeatureOperation)this.MemberwiseClone();
        }
        
        /// <summary>
        /// Creates the new copy of the entity.
        /// </summary>
        public RuleFeatureOperation CreateObject()
        {
            return new RuleFeatureOperation();
        }
    
        #endregion
    
    		[DataMember]
    		public string  ID
    		{
    			 get
    			{
    				return lid;
    			}
    
    			 set
    			{
    				if (lid != value)
    				{
    					if (base.EntityState == Microsoft.EntityFrameworkCore.EntityState.Modified)
    						base.RecordStateValue("ID", new Tuple<object, object>(lid, value));
         				if(value != null)
        					lid = value.Trim();
        				else
        					lid = string.Empty;
    				}
    			}
    		}
    		private string lid = string.Empty;
    		
    		[DataMember]
    		public string  RuleId
    		{
    			 get
    			{
    				return lruleid;
    			}
    
    			 set
    			{
    				if (lruleid != value)
    				{
    					if (base.EntityState == Microsoft.EntityFrameworkCore.EntityState.Modified)
    						base.RecordStateValue("RuleId", new Tuple<object, object>(lruleid, value));
         				if(value != null)
        					lruleid = value.Trim();
        				else
        					lruleid = string.Empty;
    				}
    			}
    		}
    		private string lruleid = string.Empty;
    		
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
    					if (base.EntityState == Microsoft.EntityFrameworkCore.EntityState.Modified)
    						base.RecordStateValue("FeatureId", new Tuple<object, object>(lfeatureid, value));
         				if(value != null)
        					lfeatureid = value.Trim();
        				else
        					lfeatureid = string.Empty;
    				}
    			}
    		}
    		private string lfeatureid = string.Empty;
    		
    		[DataMember]
    		public int  OperationId
    		{
    			 get
    			{
    				return loperationid;
    			}
    
    			 set
    			{
    					if (loperationid != value)
    					{
    						if (base.EntityState == Microsoft.EntityFrameworkCore.EntityState.Modified)
    							this.RecordStateValue("OperationId", new Tuple<object, object>(loperationid, value));
    						loperationid = value;
    					}
    			}
    		}
    		private int loperationid = default(int);
    		
    
        [DataMember]
    public virtual Rule Rule { get; set; }
    //    [DataMember]
    //public virtual Permission Permission { get; set; }
    //    [DataMember]
    //public virtual Feature Feature { get; set; }
    }
}
