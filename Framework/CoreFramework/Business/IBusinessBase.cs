#region Header Info
//-----------------------------------------------------------------------
// <copyright file="IBusinessBase.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary> Interface for providing the Attributes required for Business Logic.</summary>
// <createdby>Desayya</createdby> 
// <createddate>24-Jan-2011</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System.Collections.Generic;

#endregion

namespace Calendar.Framework
{
	/// <summary>
	/// Interface for providing the Attributes required for Business Logic.
	/// </summary>
	public interface IBusinessBase<T>
	{
		/// <summary>
		/// Gets or sets the Entity object.
		/// </summary>
		T Entity { get; set; }

		/// <summary>
		/// Gets or sets the Entity object.
		/// </summary>
		List<T> Entities { get; set; }

		/// <summary>
		/// Gets or sets the PageContext object.
		/// </summary>
		PageContext PageContext { get; set; }
	}
}
