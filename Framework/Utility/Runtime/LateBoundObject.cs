#region Header Info
//-----------------------------------------------------------------------
// <copyright file="LateBoundObject.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Handles the Late bound objects.</summary>
// <createdby>Desayya</createdby> 
// <createddate>11-July-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;

#endregion

namespace Calendar.Framework.Runtime
{
    /// <summary>
    /// Enables simple invocation of methods
    /// against the contained object using 
    /// late binding.
    /// </summary>
    public class LateBoundObject
    {
        /// <summary>
        /// Initializes a new instance of the LateBoundObject class
        /// Creates an instance of the specified
        /// type and contains it within a new
        /// LateBoundObject.
        /// </summary>
        /// <param name="objectType">
        /// Type of object to create.
        /// </param>
        /// <remarks>
        /// The specified type must implement a
        /// default constructor.
        /// </remarks>
        public LateBoundObject(Type objectType)
            : this(MethodCaller.CreateInstance(objectType))
        {
        }

        /// <summary>
        /// Initializes a new instance of the LateBoundObject class
        /// Contains the provided object within
        /// a new LateBoundObject.
        /// </summary>
        /// <param name="instance">
        /// Object to contain.
        /// </param>
        public LateBoundObject(object instance)
        {
            this.Instance = instance;
        }

        /// <summary>
        /// Gets Object instance managed by LateBoundObject.
        /// </summary>
        public object Instance { get; private set; }

        /// <summary>
        /// Uses reflection to dynamically invoke a method
        /// if that method is implemented on the target object.
        /// </summary>
        /// <param name="method">
        /// Name of the method.
        /// </param>
        /// <param name="parameters">
        /// Parameters to pass to method.
        /// </param>
        /// <returns>Returns Dynamic method.</returns>
        public object CallMethodIfImplemented(string method, params object[] parameters)
        {
            return MethodCaller.CallMethodIfImplemented(this.Instance, method, parameters);
        }

        /// <summary>
        /// Uses reflection to dynamically invoke a method,
        /// throwing an exception if it is not
        /// implemented on the target object.
        /// </summary>
        /// <param name="method">
        /// Name of the method.
        /// </param>
        /// <returns>Returns Dynamic method.</returns>
        public object CallMethod(string method)
        {
            return MethodCaller.CallMethod(this.Instance, method);
        }

        /// <summary>
        /// Uses reflection to dynamically invoke a method,
        /// throwing an exception if it is not
        /// implemented on the target object.
        /// </summary>
        /// <param name="method">
        /// Name of the method.
        /// </param>
        /// <param name="parameters">
        /// Parameters to pass to method.
        /// </param>
        /// <returns>Returns Dynamic method.</returns>
        public object CallMethod(string method, params object[] parameters)
        {
            return MethodCaller.CallMethod(this.Instance, method, parameters);
        }
    }
}