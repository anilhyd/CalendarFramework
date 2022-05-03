#region Header Info
//-----------------------------------------------------------------------
// <copyright file="ReflectionManager.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Provides functionality to call methods/properties dynamically</summary>
// <createdby>Desayya</createdby> 
// <createddate>1-June-2012</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using Calendar.Framework.Utility;

#endregion

namespace Calendar.Framework.Runtime
{
    /// <summary>
    /// Provides functionality to call methods/properties dynamically.
    /// </summary>
    public class ReflectionManager
    {
        #region Create Instance
        /// <summary>
        /// Uses reflection to create an object using its 
        /// default constructor.
        /// </summary>
        /// <param name="objectType">Type of object to create.</param>
        /// <returns>Returns dynamic object.</returns>
        public static object CreateInstance(Type objectType)
        {
            return MethodCaller.CreateInstance(objectType);
        }

        /// <summary>
        /// Creates the dynamic instance.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Type name of the calss.</param>
        /// <returns>Return the instance of object.</returns>
        public static object CreateInstance(string assemblyName, string typeName)
        {
            return MethodCaller.CreateInstance(assemblyName, typeName);
        }

        #endregion

        #region Call Property
        /// <summary>
        /// Invokes a property getter using dynamic
        /// method invocation.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <param name="property">Property to invoke.</param>
        /// <returns>Returns the Dynamic Property.</returns>
        public static object CallPropertyGetter(object obj, string property)
        {
            return MethodCaller.CallPropertyGetter(obj, property);
        }

        /// <summary>
        /// Invokes a property setter using dynamic
        /// method invocation.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <param name="property">Property to invoke.</param>
        /// <param name="value">New value for property.</param>
        public static void CallPropertySetter(object obj, string property, object value)
        {
            MethodCaller.CallPropertySetter(obj, property, value);
        }

        #endregion

        #region Call Method

        /// <summary>
        /// Uses reflection to dynamically invoke a method
        /// if that method is implemented on the target object.
        /// </summary>
        /// <param name="obj">
        /// Object containing method.
        /// </param>
        /// <param name="method">
        /// Name of the method.
        /// </param>
        /// <param name="parameters">
        /// Parameters to pass to method.
        /// </param>
        /// <returns>Returns Dynamic object.</returns>
        public static object CallMethodIfImplemented(object obj, string method, params object[] parameters)
        {
            return MethodCaller.CallMethodIfImplemented(obj, method, parameters);
        }

        /// <summary>
        /// Detects if a method matching the name and parameters is implemented on the provided object.
        /// </summary>
        /// <param name="obj">The object implementing the method.</param>
        /// <param name="method">The name of the method to find.</param>
        /// <param name="parameters">The parameters matching the parameters types of the method to match.</param>
        /// <returns>True obj implements a matching method.</returns>
        public static bool IsMethodImplemented(object obj, string method, params object[] parameters)
        {
            return MethodCaller.IsMethodImplemented(obj, method, parameters);
        }

        /// <summary>
        /// Uses reflection to dynamically invoke a method,
        /// throwing an exception if it is not
        /// implemented on the target object.
        /// </summary>
        /// <param name="obj">
        /// Object containing method.
        /// </param>
        /// <param name="method">
        /// Name of the method.
        /// </param>
        /// <param name="parameters">
        /// Parameters to pass to method.
        /// </param>
        /// <returns>Returns Method for specifid conditions.</returns>
        public static object CallMethod(object obj, string method, params object[] parameters)
        {
            return MethodCaller.CallMethod(obj, method, parameters);
        }

        /// <summary>
        /// Uses reflection to dynamically invoke a method,
        /// throwing an exception if it is not
        /// implemented on the target object.
        /// </summary>
        /// <param name="obj">
        /// Object containing method.
        /// </param>
        /// <param name="info">
        /// System.Reflection.MethodInfo for the method.
        /// </param>
        /// <param name="parameters">
        /// Parameters to pass to method.
        /// </param>
        /// <returns>Calls Method for specifid conditions.</returns>
        public static object CallMethod(object obj, System.Reflection.MethodInfo info, params object[] parameters)
        {
            return MethodCaller.CallMethod(obj, info, parameters);
        }

        /// <summary>
        /// Invokes an instance method on an object.
        /// </summary>
        /// <param name="obj">Object containing method.</param>
        /// <param name="info">Method info object.</param>
        /// <returns>Any value returned from the method.</returns>
        public static object CallMethod(object obj, System.Reflection.MethodInfo info)
        {
            return MethodCaller.CallMethod(obj, info);
        }

        /// <summary>
        /// Invokes a static factory method.
        /// </summary>
        /// <param name="objectType">Business class where the factory is defined.</param>
        /// <param name="method">Name of the factory method.</param>
        /// <param name="parameters">Parameters passed to factory method.</param>
        /// <returns>Result of the factory method invocation.</returns>
        public static object CallFactoryMethod(Type objectType, string method, params object[] parameters)
        {
            return MethodCaller.CallFactoryMethod(objectType, method, parameters);
        }

        /// <summary>
        /// Allows late bound invocation of
        /// properties and methods.
        /// </summary>
        /// <param name="target">Object implementing the property or method.</param>
        /// <param name="methodName">Name of the property or method.</param>
        /// <param name="callType">Specifies how to invoke the property or method.</param>
        /// <param name="args">List of arguments to pass to the method.</param>
        /// <returns>The result of the property or method invocation.</returns>
        public static object CallByName(object target, string methodName, CallType callType, params object[] args)
        {
            return MethodCaller.CallByName(target, methodName, callType, args);
        }

        /// <summary>
        /// Gets a System.Reflection.MethodInfo object corresponding to a
        /// non-public method.
        /// </summary>
        /// <param name="objectType">Object containing the method.</param>
        /// <param name="method">Name of the method.</param>
        /// <returns>Returns Method information about the specified method.</returns>
        public static System.Reflection.MethodInfo GetNonPublicMethod(Type objectType, string method)
        {
            return MethodCaller.GetNonPublicMethod(objectType, method);
        }
        #endregion

        #region Get/Find Method

        /// <summary>
        /// Uses reflection to locate a matching method
        /// on the target object.
        /// </summary>
        /// <param name="objectType">
        /// Type of object containing method.
        /// </param>
        /// <param name="method">
        /// Name of the method.
        /// </param>
        /// <param name="parameters">
        /// Parameters to pass to method.
        /// </param>
        /// <returns>Returns Method Info for specifid conditions.</returns>
        public static System.Reflection.MethodInfo GetMethod(Type objectType, string method, params object[] parameters)
        {
            return MethodCaller.GetMethod(objectType, method, parameters);
        }

        /// <summary>
        /// Returns information about the specified
        /// method, even if the parameter types are
        /// generic and are located in an abstract
        /// generic base class.
        /// </summary>
        /// <param name="objectType">
        /// Type of object containing method.
        /// </param>
        /// <param name="method">
        /// Name of the method.
        /// </param>
        /// <param name="types">
        /// Parameter types to pass to method.
        /// </param>
        /// <returns>Returns Method Info for specifid conditions.</returns>
        public static System.Reflection.MethodInfo FindMethod(Type objectType, string method, Type[] types)
        {
            return MethodCaller.FindMethod(objectType, method, types);
        }

        /// <summary>
        /// Returns information about the specified
        /// method, finding the method based purely
        /// on the method name and number of parameters.
        /// </summary>
        /// <param name="objectType">
        /// Type of object containing method.
        /// </param>
        /// <param name="method">
        /// Name of the method.
        /// </param>
        /// <param name="parameterCount">
        /// Number of parameters to pass to method.
        /// </param>
        /// <returns>Returns Method Info for specified findings.</returns>
        public static System.Reflection.MethodInfo FindMethod(Type objectType, string method, int parameterCount)
        {
            return MethodCaller.FindMethod(objectType, method, parameterCount);
        }

        /// <summary>
        /// Returns information about the specified
        /// method.
        /// </summary>
        /// <param name="objType">Type of object.</param>
        /// <param name="method">Name of the method.</param>
        /// <param name="flags">Flag values.</param>
        /// <returns>Returns Method information about the specified method.</returns>
        public static System.Reflection.MethodInfo FindMethod(Type objType, string method, BindingFlags flags)
        {
            return MethodCaller.FindMethod(objType, method, flags);
        }

        #endregion

        #region Properties/ Fields
        /// <summary>
        /// Returns an array of Type objects corresponding
        /// to the type of parameters provided.
        /// </summary>
        /// <param name="parameters">
        /// Parameter values.
        /// </param>
        /// <returns>Returns Array of Types for type of parameters provide.</returns>
        public static Type[] GetParameterTypes(object[] parameters)
        {
            return MethodCaller.GetParameterTypes(parameters);
        }

#if !SILVERLIGHT
        /// <summary>
        /// Gets a property type descriptor by name.
        /// </summary>
        /// <param name="type">Type of object containing the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Returns Method property descriptor the specified property.</returns>
        public static PropertyDescriptor GetPropertyDescriptor(Type type, string propertyName)
        {
            return MethodCaller.GetPropertyDescriptor(type, propertyName);
        }
#endif

        /// <summary>
        /// Gets information about a property.
        /// </summary>
        /// <param name="objectType">Object containing the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Returns Property information about the specified type.</returns>
        public static PropertyInfo GetProperty(Type objectType, string propertyName)
        {
            return MethodCaller.GetProperty(objectType, propertyName);
        }

        /// <summary>
        /// Gets a property value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The value of the property.</returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            return MethodCaller.GetPropertyValue(obj, propertyName);
        }

        /// <summary>
        /// Gets a property value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="info">Property info object for the property.</param>
        /// <returns>The value of the property.</returns>
        public static object GetPropertyValue(object obj, PropertyInfo info)
        {
            return MethodCaller.GetPropertyValue(obj, info);
        }

        /// <summary>
        /// Gets a field value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="filedName">Name of the field.</param>
        /// <returns>The value of the field.</returns>
        public static object GetConstantValue(object obj, string filedName)
        {
            return MethodCaller.GetConstantValue(obj, filedName);
        }

        /// <summary>
        /// Gets a field value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="filedName">Name of the field.</param>
        /// <returns>The value of the field.</returns>
        public static object GetFieldValue(object obj, string filedName)
        {
            return MethodCaller.GetFieldValue(obj, filedName);
        }

        /// <summary>
        /// Gets a field value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="filedName">Name of the field.</param>
        /// <returns>The value of the field.</returns>
        public static object GetConstFieldValue(object obj, string filedName)
        {
            return MethodCaller.GetConstFieldValue(obj, filedName);
        }
        #endregion
    }
}