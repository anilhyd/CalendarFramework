#region Header Info
//-----------------------------------------------------------------------
// <copyright file="MethodCaller.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Instanciate the Method.</summary>
// <createdby>Desayya</createdby> 
// <createddate>11-July-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using Calendar.Framework.Utility;

#endregion

namespace Calendar.Framework.Runtime
{
    /// <summary>
    /// Provides methods to dynamically find and call methods.
    /// </summary>
    public static class MethodCaller
    {
        #region Declarations
        /// <summary>
        /// Dictionary for storing the cache data.
        /// </summary>
        private static readonly Dictionary<MethodCacheKey, DynamicMemberHandle> memberCache = new Dictionary<MethodCacheKey, DynamicMemberHandle>();

        /// <summary>
        /// Binding flags for methods.
        /// </summary>
        private const BindingFlags AllLevelFlags
          = BindingFlags.FlattenHierarchy
          | BindingFlags.Instance
          | BindingFlags.Public
          | BindingFlags.NonPublic;

        /// <summary>
        /// Binding flags for method.
        /// </summary>
        private const BindingFlags OneLevelFlags
          = BindingFlags.DeclaredOnly
          | BindingFlags.Instance
          | BindingFlags.Public
          | BindingFlags.NonPublic;
       
        /// <summary>
        /// Binding flags for constroctor.
        /// </summary>
        private const BindingFlags CtorFlags
          = BindingFlags.Instance
          | BindingFlags.Public
          | BindingFlags.NonPublic;

        /// <summary>
        /// Binding flags for factory.
        /// </summary>
        private const BindingFlags FactoryFlags =
          BindingFlags.Static |
          BindingFlags.Public |
          BindingFlags.FlattenHierarchy;

        /// <summary>
        /// Binding flags for private methods.
        /// </summary>
        private const BindingFlags PrivateMethodFlags =
          BindingFlags.Public |
          BindingFlags.NonPublic |
          BindingFlags.Instance |
          BindingFlags.FlattenHierarchy;

        /// <summary>
        /// Binding flags for properties.
        /// </summary>
        private const BindingFlags PropertyFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

        /// <summary>
        /// Binding flags for fields.
        /// </summary>
        private const BindingFlags FieldFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Dictionary for holds the reflection method handlers.
        /// </summary>
        private static Dictionary<MethodCacheKey, DynamicMethodHandle> methodCache = new Dictionary<MethodCacheKey, DynamicMethodHandle>();

        /// <summary>
        /// Static dictionary for holding the cache delegates.
        /// </summary>
        private static Dictionary<Type, DynamicCtorDelegate> ctorCache = new Dictionary<Type, DynamicCtorDelegate>();
        #endregion 

        #region GetType

        /// <summary>
        /// Gets a Type object based on the type name.
        /// </summary>
        /// <param name="typeName">Type name including assembly name.</param>
        /// <param name="throwOnError">True to throw an exception if the type can't be found.</param>
        /// <param name="ignoreCase">True for a case-insensitive comparison of the type name.</param>
        /// <returns>Returns the Type of the  object.</returns>
        public static Type GetType(string typeName, bool throwOnError, bool ignoreCase)
        {
            string fullTypeName;
#if SILVERLIGHT
      if (typeName.Contains("Version="))
        fullTypeName = typeName;
      else
        fullTypeName = typeName + ", Version=..., Culture=neutral, PublicKeyToken=null";
#else
            fullTypeName = typeName;
#endif
            return Type.GetType(fullTypeName, throwOnError, ignoreCase);
        }

        /// <summary>
        /// Gets a Type object based on the type name.
        /// </summary>
        /// <param name="typeName">Type name including assembly name.</param>
        /// <param name="throwOnError">True to throw an exception if the type can't be found.</param>
        /// <returns>Returns Type of the object.</returns>
        public static Type GetType(string typeName, bool throwOnError)
        {
            return GetType(typeName, throwOnError, false);
        }

        /// <summary>
        /// Gets a Type object based on the type name.
        /// </summary>
        /// <param name="typeName">Type name including assembly name.</param>
        /// <returns>Returns type of the object.</returns>
        public static Type GetType(string typeName)
        {
            return GetType(typeName, true, false);
        }

        #endregion

        #region Create Instance

        /// <summary>
        /// Uses reflection to create an object using its 
        /// default constructor.
        /// </summary>
        /// <param name="objectType">Type of object to create.</param>
        /// <returns>Returns dynamic object.</returns>
        public static object CreateInstance(Type objectType)
        {
            var ctor = GetCachedConstructor(objectType);
            if (ctor == null)
                throw new NotImplementedException("DefaultConstructor MethodNotImplemented");
            return ctor.Invoke();
        }

        /// <summary>
        /// Creates the dynamic instance.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Type name of the calss.</param>
        /// <returns>Return the instance of object.</returns>
        public static object CreateInstance(string assemblyName, string typeName)
        {
            Type type = Type.GetType(typeName + ", " + assemblyName);
            return Activator.CreateInstance(type);
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
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (string.IsNullOrEmpty(property))
                throw new ArgumentException("ArgumentIsNullOrEmpty", "property");

            var mh = GetCachedProperty(obj.GetType(), property);
            if (mh.DynamicMemberGet == null)
            {
                throw new NotSupportedException(string.Format(
                  CultureInfo.CurrentCulture,
                  "The property '{0}' on Type '{1}' does not have a public getter.",
                  property,
                  obj.GetType()));
            }

            return mh.DynamicMemberGet(obj);
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
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (string.IsNullOrEmpty(property))
                throw new ArgumentException("ArgumentIsNullOrEmpty", "property");

            var mh = GetCachedProperty(obj.GetType(), property);
            if (mh.DynamicMemberSet == null)
            {
                throw new NotSupportedException(string.Format(
                  CultureInfo.CurrentCulture,
                  "The property '{0}' on Type '{1}' does not have a public setter.",
                  property,
                  obj.GetType()));
            }

            mh.DynamicMemberSet(obj, value);
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
            var mh = GetCachedMethod(obj, method, parameters);
            if (mh == null || mh.DynamicMethod == null)
                return null;
            return CallMethod(obj, mh, parameters);
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
            var mh = GetCachedMethod(obj, method, parameters);
            return mh != null && mh.DynamicMethod != null;
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
            var mh = GetCachedMethod(obj, method, parameters);
            if (mh == null || mh.DynamicMethod == null)
                throw new NotImplementedException(method + " " + "MethodNotImplemented");
            return CallMethod(obj, mh, parameters);
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
            var mh = GetCachedMethod(obj, info, parameters);
            if (mh == null || mh.DynamicMethod == null)
                throw new NotImplementedException(info.Name + " " + "MethodNotImplemented");
            return CallMethod(obj, mh, parameters);
        }

        /// <summary>
        /// Invokes an instance method on an object.
        /// </summary>
        /// <param name="obj">Object containing method.</param>
        /// <param name="info">Method info object.</param>
        /// <returns>Any value returned from the method.</returns>
        public static object CallMethod(object obj, System.Reflection.MethodInfo info)
        {
            object result = null;
            try
            {
                result = info.Invoke(obj, null);
            }
            catch (System.Exception e)
            {
                System.Exception inner = null;
                if (e.InnerException == null)
                    inner = e;
                else
                    inner = e.InnerException;
                throw new CallMethodException(info.Name + " " + "MethodCallFailed", inner);
            }

            return result;
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
            object returnValue;
            System.Reflection.MethodInfo factory = objectType.GetMethod(method, FactoryFlags, null, MethodCaller.GetParameterTypes(parameters), null);

            if (factory == null)
            {
                // strongly typed factory couldn't be found
                // so find one with the correct number of
                // parameters 
                int parameterCount = parameters.Length;
                System.Reflection.MethodInfo[] methods = objectType.GetMethods(FactoryFlags);
                foreach (System.Reflection.MethodInfo oneMethod in methods)
                    if (oneMethod.Name == method && oneMethod.GetParameters().Length == parameterCount)
                    {
                        factory = oneMethod;
                        break;
                    }
            }

            if (factory == null)
            {
                // no matching factory could be found
                // so throw exception
                throw new InvalidOperationException(
                  string.Format("NoSuchFactoryMethod", method));
            }

            try
            {
                returnValue = factory.Invoke(null, parameters);
            }
            catch (System.Exception ex)
            {
                System.Exception inner = null;
                if (ex.InnerException == null)
                    inner = ex;
                else
                    inner = ex.InnerException;
                throw new CallMethodException(factory.Name + " " + "MethodCallFailed", inner);
            }

            return returnValue;
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
            switch (callType)
            {
                case CallType.Get:
                    {
                        PropertyInfo p = target.GetType().GetProperty(methodName);
                        return p.GetValue(target, args);
                    }

                case CallType.GetFieldValue:
                    {
                        FieldInfo fieldinfo = target.GetType().GetField(methodName);
                        return fieldinfo.GetValue(target);
                    }

                case CallType.SetFieldValue:
                    {
                        FieldInfo fieldinfo = target.GetType().GetField(methodName);
                        fieldinfo.SetValue(target, args[0]);
                        return null;
                    }

                case CallType.Let:
                case CallType.Set:
                    {
                        PropertyInfo p = target.GetType().GetProperty(methodName);
                        p.SetValue(target, args[0], null);
                        return null;
                    }

                case CallType.Method:
                    MethodInfo m = GetMethod(target.GetType(), methodName);
                    return m.Invoke(target, args);
            }

            return null;
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
            System.Reflection.MethodInfo result = null;

            result = FindMethod(objectType, method, PrivateMethodFlags);

            return result;
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
            System.Reflection.MethodInfo result = null;

            object[] inParams = null;
            if (parameters == null)
                inParams = new object[] { null };
            else
                inParams = parameters;

            // try to find a strongly typed match

            // first see if there's a matching method
            // where all params match types
            result = FindMethod(objectType, method, GetParameterTypes(inParams));

            if (result == null)
            {
                // no match found - so look for any method
                // with the right number of parameters
                try
                {
                    result = FindMethod(objectType, method, inParams.Length);
                }
                catch (AmbiguousMatchException)
                {
                    // we have multiple methods matching by name and parameter count
                    result = FindMethodUsingFuzzyMatching(objectType, method, inParams);
                }
            }

            // no strongly typed match found, get default based on name only
            if (result == null)
            {
                result = objectType.GetMethod(method, AllLevelFlags);
            }

            return result;
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
            System.Reflection.MethodInfo info = null;
            do
            {
                // find for a strongly typed match
                info = objectType.GetMethod(method, AllLevelFlags, null, types, null);
                if (info != null)
                {
                    break; // match found
                }

                objectType = objectType.BaseType;
            }
            while (objectType != null);
            return info;
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
            // walk up the inheritance hierarchy looking
            // for a method with the right number of
            // parameters
            System.Reflection.MethodInfo result = null;
            Type currentType = objectType;
            do
            {
                System.Reflection.MethodInfo info = currentType.GetMethod(method, OneLevelFlags);
                if (info != null)
                {
                    var infoParams = info.GetParameters();
                    var paramCount = infoParams.Length;
                    if (paramCount > 0 &&
                       ((paramCount == 1 && infoParams[0].ParameterType.IsArray) ||
                       (infoParams[paramCount - 1].GetCustomAttributes(typeof(ParamArrayAttribute), true).Length > 0)))
                    {
                        // last param is a param array or only param is an array
                        if (parameterCount >= paramCount - 1)
                        {
                            // got a match so use it
                            result = info;
                            break;
                        }
                    }
                    else if (paramCount == parameterCount)
                    {
                        // got a match so use it
                        result = info;
                        break;
                    }
                }

                currentType = currentType.BaseType;
            }
            while (currentType != null);
            return result;
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
            System.Reflection.MethodInfo info = null;
            do
            {
                // find for a strongly typed match
                info = objType.GetMethod(method, flags);
                if (info != null)
                    break; // match found
                objType = objType.BaseType;
            }
            while (objType != null);
            return info;
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
            List<Type> result = new List<Type>();

            if (parameters == null)
            {
                result.Add(typeof(object));
            }
            else
            {
                foreach (object item in parameters)
                {
                    if (item == null)
                    {
                        result.Add(typeof(object));
                    }
                    else
                    {
                        result.Add(item.GetType());
                    }
                }
            }

            return result.ToArray();
        }

#if !SILVERLIGHT
        /// <summary>
        /// Gets a property type descriptor by name.
        /// </summary>
        /// <param name="t">Type of object containing the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Returns Method property descriptor the specified property.</returns>
        public static PropertyDescriptor GetPropertyDescriptor(Type t, string propertyName)
        {
            var propertyDescriptors = TypeDescriptor.GetProperties(t);
            PropertyDescriptor result = null;
            foreach (PropertyDescriptor desc in propertyDescriptors)
                if (desc.Name == propertyName)
                {
                    result = desc;
                    break;
                }

            return result;
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
            return objectType.GetProperty(propertyName, PropertyFlags);
        }

        public static object GetPropertyValue(object obj, string propertyName)
        {
            return GetPropertyValue(obj, GetProperty(obj.GetType(), propertyName));
            //return objectType.GetProperty(propertyName, PropertyFlags);
        }

        /// <summary>
        /// Gets a property value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="info">Property info object for the property.</param>
        /// <returns>The value of the property.</returns>
        public static object GetPropertyValue(object obj, PropertyInfo info)
        {
            object result = null;
            try
            {
                result = info.GetValue(obj, null);
            }
            catch (System.Exception e)
            {
                System.Exception inner = null;
                if (e.InnerException == null)
                    inner = e;
                else
                    inner = e.InnerException;
                throw new CallMethodException(info.Name + " " + "MethodCallFailed", inner);
            }

            return result;
        }
        
        /// <summary>
        /// Gets a field value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="filedName">Name of the field.</param>
        /// <returns>The value of the field.</returns>
        public static object GetConstantValue(object obj, string filedName)
        {
            object result = null;
            try
            {
                result = obj.GetType().GetField(filedName).GetValue(null);
            }
            catch (System.Exception e)
            {
                System.Exception inner = null;
                if (e.InnerException == null)
                    inner = e;
                else
                    inner = e.InnerException;
                throw new CallMethodException(filedName + " " + "MethodCallFailed", inner);
            }

            return result;
        }

        /// <summary>
        /// Gets a field value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="filedName">Name of the field.</param>
        /// <returns>The value of the field.</returns>
        public static object GetFieldValue(object obj, string filedName)
        {
            object result = null;
            try
            {
                result = obj.GetType().GetField(filedName, FieldFlags).GetValue(null);
            }
            catch (System.Exception e)
            {
                System.Exception inner = null;
                if (e.InnerException == null)
                    inner = e;
                else
                    inner = e.InnerException;
                throw new CallMethodException(filedName + " " + "MethodCallFailed", inner);
            }

            return result;
        }

        /// <summary>
        /// Gets a field value.
        /// </summary>
        /// <param name="obj">Object containing the property.</param>
        /// <param name="filedName">Name of the field.</param>
        /// <returns>The value of the field.</returns>
        public static object GetConstFieldValue(object obj, string filedName)
        {
            object result = null;
            try
            {
                result = obj.GetType().GetField(filedName, BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            }
            catch (System.Exception e)
            {
                System.Exception inner = null;
                if (e.InnerException == null)
                    inner = e;
                else
                    inner = e.InnerException;
                throw new CallMethodException(filedName + " " + "MethodCallFailed", inner);
            }

            return result;
        }
        #endregion

        #region Dynamic Method Cache

        /// <summary>
        /// Returns the Dynamic method from the cache.
        /// </summary>
        /// <param name="obj">Obejct to be cached or returned.</param>
        /// <param name="info">Method informantion.</param>
        /// <param name="parameters">Method Parameters arry.</param>
        /// <returns>Rerturns the Dynamic method handle.</returns>
        private static DynamicMethodHandle GetCachedMethod(object obj, System.Reflection.MethodInfo info, params object[] parameters)
        {
            var key = new MethodCacheKey(obj.GetType().FullName, info.Name, GetParameterTypes(parameters));
            DynamicMethodHandle mh = null;
            if (!methodCache.TryGetValue(key, out mh))
            {
                lock (methodCache)
                {
                    if (!methodCache.TryGetValue(key, out mh))
                    {
                        mh = new DynamicMethodHandle(info, parameters);
                        methodCache.Add(key, mh);
                    }
                }
            }

            return mh;
        }

        /// <summary>
        /// Returns the Dynamic method from the cache.
        /// </summary>
        /// <param name="obj">Obejct to be cached or returned.</param>
        /// <param name="method">Method informantion.</param>
        /// <param name="parameters">Method Parameters arry.</param>
        /// <returns>Rerturns the Dynamic method handle.</returns>
        private static DynamicMethodHandle GetCachedMethod(object obj, string method, params object[] parameters)
        {
            var key = new MethodCacheKey(obj.GetType().FullName, method, GetParameterTypes(parameters));
            DynamicMethodHandle mh = null;
            if (!methodCache.TryGetValue(key, out mh))
            {
                lock (methodCache)
                {
                    if (!methodCache.TryGetValue(key, out mh))
                    {
                        var info = GetMethod(obj.GetType(), method, parameters);
                        mh = new DynamicMethodHandle(info, parameters);
                        methodCache.Add(key, mh);
                    }
                }
            }

            return mh;
        }

        #endregion

        #region Dynamic Constructor Cache

        /// <summary>
        /// Returns the constructor for type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>DynamicCtorDelegate object.</returns>
        private static DynamicCtorDelegate GetCachedConstructor(Type objectType)
        {
            DynamicCtorDelegate result = null;
            if (!ctorCache.TryGetValue(objectType, out result))
            {
                lock (ctorCache)
                {
                    if (!ctorCache.TryGetValue(objectType, out result))
                    {
                        ConstructorInfo info = objectType.GetConstructor(CtorFlags, null, Type.EmptyTypes, null);
                        if (info == null)
                            throw new NotSupportedException(string.Format(
                              CultureInfo.CurrentCulture,
                              "Cannot create instance of Type '{0}'. No public parameterless constructor found.",
                              objectType));

                        result = DynamicMethodHandlerFactory.CreateConstructor(info);
                        ctorCache.Add(objectType, result);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Retursn the extra specified array elements.
        /// </summary>
        /// <param name="count">Array count.</param>
        /// <param name="arrayType">Type of the array.</param>
        /// <returns>Object array.</returns>
        private static object[] GetExtrasArray(int count, Type arrayType)
        {
            return (object[])System.Array.CreateInstance(arrayType.GetElementType(), count);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns dyanamic member handle from stored cache if available otherwise
        /// crates new and store it into cahce.
        /// </summary>
        /// <param name="objectType">Type of the obejct to be cached.</param>
        /// <param name="propertyName">Name of the Property.</param>
        /// <returns>Returns Dynamic method handler.</returns>
        internal static DynamicMemberHandle GetCachedProperty(Type objectType, string propertyName)
        {
            var key = new MethodCacheKey(objectType.FullName, propertyName, GetParameterTypes(null));
            DynamicMemberHandle mh = null;
            if (!memberCache.TryGetValue(key, out mh))
            {
                lock (memberCache)
                {
                    if (!memberCache.TryGetValue(key, out mh))
                    {
                        PropertyInfo info = objectType.GetProperty(propertyName, PropertyFlags);
                        if (info == null)
                            throw new InvalidOperationException(
                              string.Format("MemberNotFoundException", propertyName));
                        mh = new DynamicMemberHandle(info);
                        memberCache.Add(key, mh);
                    }
                }
            }

            return mh;
        }

        /// <summary>
        /// Returns dyanamic member handle from stored cache if available otherwise
        /// crates new and store it into cahce.
        /// </summary>
        /// <param name="objectType">Type of the obejct to be cached.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>Returns Dynamic method handler.</returns>
        internal static DynamicMemberHandle GetCachedField(Type objectType, string fieldName)
        {
            var key = new MethodCacheKey(objectType.FullName, fieldName, GetParameterTypes(null));
            DynamicMemberHandle mh = null;
            if (!memberCache.TryGetValue(key, out mh))
            {
                lock (memberCache)
                {
                    if (!memberCache.TryGetValue(key, out mh))
                    {
                        FieldInfo info = objectType.GetField(fieldName, FieldFlags);
                        if (info == null)
                            throw new InvalidOperationException(
                              string.Format("MemberNotFoundException", fieldName));
                        mh = new DynamicMemberHandle(info);
                        memberCache.Add(key, mh);
                    }
                }
            }

            return mh;
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
        /// <param name="parameters">
        /// Parameter types to pass to method.
        /// </param>
        /// <returns>Returns Method Info for specifid conditions.</returns>
        private static System.Reflection.MethodInfo FindMethodUsingFuzzyMatching(Type objectType, string method, object[] parameters)
        {
            System.Reflection.MethodInfo result = null;
            Type currentType = objectType;
            do
            {
                System.Reflection.MethodInfo[] methods = currentType.GetMethods(OneLevelFlags);
                int parameterCount = parameters.Length;

                if (parameterCount == 1 && parameters[0] == null)
                    parameterCount = 0;

                // Match based on name and parameter types and parameter arrays
                foreach (System.Reflection.MethodInfo m in methods)
                {
                    if (m.Name == method)
                    {
                        var infoParams = m.GetParameters();
                        var paramCount = infoParams.Length;
                        if (paramCount > 0)
                        {
                            if (paramCount == 1 && infoParams[0].ParameterType.IsArray)
                            {
                                // only param is an array
                                if (parameters.GetType().Equals(infoParams[0].ParameterType))
                                {
                                    // got a match so use it
                                    result = m;
                                    break;
                                }
                            }

                            if (infoParams[paramCount - 1].GetCustomAttributes(typeof(ParamArrayAttribute), true).Length > 0)
                            {
                                // last param is a param array
                                if (parameterCount == paramCount && parameters[paramCount - 1].GetType().Equals(infoParams[paramCount - 1].ParameterType))
                                {
                                    // got a match so use it
                                    result = m;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (result == null)
                {
                    // match based on parameter name and number of parameters
                    foreach (System.Reflection.MethodInfo m in methods)
                    {
                        if (m.Name == method && m.GetParameters().Length == parameterCount)
                        {
                            result = m;
                            break;
                        }
                    }
                }

                if (result != null)
                    break;
                currentType = currentType.BaseType;
            }
            while (currentType != null);
            return result;
        }

        /// <summary>
        /// Uses reflection to dynamically invoke a method,
        /// throwing an exception if it is not implemented
        /// on the target object.
        /// </summary>
        /// <param name="obj">
        /// Object containing method.
        /// </param>
        /// <param name="methodHandle">
        /// MethodHandle for the method.
        /// </param>
        /// <param name="parameters">
        /// Parameters to pass to method.
        /// </param>
        /// <returns>Returns Method object for specifid conditions.</returns>
        private static object CallMethod(object obj, DynamicMethodHandle methodHandle, params object[] parameters)
        {
            object result = null;
            var method = methodHandle.DynamicMethod;

            object[] inParams = null;
            if (parameters == null)
                inParams = new object[] { null };
            else
                inParams = parameters;

            if (methodHandle.HasFinalArrayParam)
            {
                // last param is a param array or only param is an array
                var paramCount = methodHandle.MethodParamsLength;
                var inCount = inParams.Length;
                if (inCount == paramCount - 1)
                {
                    // no paramter was supplied for the param array
                    // copy items into new array with last entry null
                    object[] paramList = new object[paramCount];
                    for (var pos = 0; pos <= paramCount - 2; pos++)
                        paramList[pos] = parameters[pos];
                    paramList[paramList.Length - 1] = null;

                    // use new array
                    inParams = paramList;
                }
                else if ((inCount == paramCount && !inParams[inCount - 1].GetType().IsArray) || inCount > paramCount)
                {
                    // 1 or more params go in the param array
                    // copy extras into an array
                    var extras = inParams.Length - (paramCount - 1);
                    object[] extraArray = GetExtrasArray(extras, methodHandle.FinalArrayElementType);
                    Array.Copy(inParams, paramCount - 1, extraArray, 0, extras);

                    // copy items into new array
                    object[] paramList = new object[paramCount];
                    for (var pos = 0; pos <= paramCount - 2; pos++)
                        paramList[pos] = parameters[pos];
                    paramList[paramList.Length - 1] = extraArray;

                    // use new array
                    inParams = paramList;
                }
            }

            try
            {
                result = methodHandle.DynamicMethod(obj, inParams);
            }
            catch (System.Exception ex)
            {
                throw new CallMethodException(methodHandle.MethodName + " " + "MethodCallFailed", ex);
            }

            return result;
        }
        #endregion
    }
}