#region Header Info
//-----------------------------------------------------------------------
// <copyright file="DynamicMethodHandlerFactory.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Factory class for dynamic methods.</summary>
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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

#endregion

namespace Calendar.Framework.Runtime
{
    /// <summary>
    /// Delegate for a dynamic constructor method.
    /// </summary>
    /// <returns>Dynamic deleage for method.</returns>
    public delegate object DynamicCtorDelegate();

    /// <summary>
    /// Delegate for a dynamic method.
    /// </summary>
    /// <param name="target">
    /// Object containg method to invoke.
    /// </param>
    /// <param name="args">
    /// Parameters passed to method.
    /// </param>
    /// <returns>Dynamic deleage for method.</returns>
    public delegate object DynamicMethodDelegate(object target, object[] args);

    /// <summary>
    /// Delegate for getting a value.
    /// </summary>
    /// <param name="target">Target object.</param>
    /// <returns>Delegate for dynamic member.</returns>
    public delegate object DynamicMemberGetDelegate(object target);

    /// <summary>
    /// Delegate for setting a value.
    /// </summary>
    /// <param name="target">Target object.</param>
    /// <param name="arg">Argument value.</param>
    public delegate void DynamicMemberSetDelegate(object target, object arg);

    /// <summary>
    /// Factory class for dynamic methods.
    /// </summary>
    internal static class DynamicMethodHandlerFactory
    {
        #region Constants
        /// <summary>
        /// Local constatnt string method.
        /// </summary>
        private const string Method = "method";

        /// <summary>
        /// Local constatnt string Property.
        /// </summary>
        private const string Property = "property";

        /// <summary>
        /// Local constatnt string Field.
        /// </summary>
        private const string Field = "field";

        /// <summary>
        /// Local constatnt string Constructor.
        /// </summary>
        private const string Constructor = "constructor";
    
        #endregion

        /// <summary>
        /// Instanciate the object based on the constructor info.
        /// </summary>
        /// <param name="constructor">Constructor information.</param>
        /// <returns>Returns dynamic delegate for constructor.</returns>
        public static DynamicCtorDelegate CreateConstructor(ConstructorInfo constructor)
        {
            if (constructor == null)
                throw new ArgumentNullException(Constructor);
            if (constructor.GetParameters().Length > 0)
                throw new NotSupportedException("ConstructorsWithParametersNotSupported");

            Expression body = Expression.New(constructor);
            if (constructor.DeclaringType.IsValueType)
            {
                body = Expression.Convert(body, typeof(object));
            }

            return Expression.Lambda<DynamicCtorDelegate>(body).Compile();
        }

        /// <summary>
        /// Creates the Method.
        /// </summary>
        /// <param name="method">Method info object.</param>
        /// <returns>Dynamic deleage for method.</returns>
        public static DynamicMethodDelegate CreateMethod(System.Reflection.MethodInfo method)
        {
            if (method == null)
                throw new ArgumentNullException(Method);

            ParameterInfo[] pi = method.GetParameters();
            var targetExpression = Expression.Parameter(typeof(object));
            var parametersExpression = Expression.Parameter(typeof(object[]));

            Expression[] callParametrs = new Expression[pi.Length];
            for (int x = 0; x < pi.Length; x++)
            {
                callParametrs[x] =
                  Expression.Convert(
                    Expression.ArrayIndex(
                      parametersExpression,
                      Expression.Constant(x)),
                    pi[x].ParameterType);
            }

            Expression instance = Expression.Convert(targetExpression, method.DeclaringType);
            Expression body = pi.Length > 0
              ? Expression.Call(instance, method, callParametrs)
              : Expression.Call(instance, method);

            if (method.ReturnType == typeof(void))
            {
                var target = Expression.Label(typeof(object));
                var nullRef = Expression.Constant(null);
                body = Expression.Block(
                  body,
                   Expression.Return(target, nullRef),
                  Expression.Label(target, nullRef));
            }
            else if (method.ReturnType.IsValueType)
            {
                body = Expression.Convert(body, typeof(object));
            }

            var lambda = Expression.Lambda<DynamicMethodDelegate>(
              body,
              targetExpression,
              parametersExpression);

            return (DynamicMethodDelegate)lambda.Compile();
        }

        /// <summary>
        /// Process the property Get section.
        /// </summary>
        /// <param name="property">Property Information of the property.</param>
        /// <returns>Returns dynamci Member delegate.</returns>
        public static DynamicMemberGetDelegate CreatePropertyGetter(PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException(Property);

            if (!property.CanRead) return null;

            var target = Expression.Parameter(typeof(object));
            Expression body = Expression.Property(
              Expression.Convert(target, property.DeclaringType),
              property);

            if (property.PropertyType.IsValueType)
            {
                body = Expression.Convert(body, typeof(object));
            }

            var lambda = Expression.Lambda<DynamicMemberGetDelegate>(
              body,
              target);

            return lambda.Compile();
        }

        /// <summary>
        /// Process the property Set section.
        /// </summary>
        /// <param name="property">Property Information of the property.</param>
        /// <returns>Returns dynamci Member delegate.</returns>
        public static DynamicMemberSetDelegate CreatePropertySetter(PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException(Property);

            if (!property.CanWrite) return null;

            var target = Expression.Parameter(typeof(object));
            var val = Expression.Parameter(typeof(object));

            Expression body = Expression.Assign(
              Expression.Property(
                Expression.Convert(target, property.DeclaringType),
                property),
              Expression.Convert(val, property.PropertyType));

            var lambda = Expression.Lambda<DynamicMemberSetDelegate>(
              body,
              target,
              val);

            return lambda.Compile();
        }

        /// <summary>
        /// Process the Files Get section.
        /// </summary>
        /// <param name="field">Field Information of the field.</param>
        /// <returns>Returns dynamci Member delegate.</returns>
        public static DynamicMemberGetDelegate CreateFieldGetter(FieldInfo field)
        {
            if (field == null)
                throw new ArgumentNullException(Field);

            var target = Expression.Parameter(typeof(object));
            Expression body = Expression.Field(
              Expression.Convert(target, field.DeclaringType),
              field);

            if (field.FieldType.IsValueType)
            {
                body = Expression.Convert(body, typeof(object));
            }

            var lambda = Expression.Lambda<DynamicMemberGetDelegate>(
              body,
              target);

            return lambda.Compile();
        }

        /// <summary>
        /// Process the Field Set section.
        /// </summary>
        /// <param name="field">Field Information of the Field.</param>
        /// <returns>Returns dynamci Member delegate.</returns>
        public static DynamicMemberSetDelegate CreateFieldSetter(FieldInfo field)
        {
            if (field == null)
                throw new ArgumentNullException(Property);

            var target = Expression.Parameter(typeof(object));
            var val = Expression.Parameter(typeof(object));

            Expression body = Expression.Assign(
              Expression.Field(
                Expression.Convert(target, field.DeclaringType),
                field),
              Expression.Convert(val, field.FieldType));

            var lambda = Expression.Lambda<DynamicMemberSetDelegate>(
              body,
              target,
              val);

            return lambda.Compile();
        }

        /// <summary>
        /// Produces the Intermediate Language for the type.
        /// </summary>
        /// <param name="il">IL Generator.</param>
        /// <param name="type">Type of the object.</param>
        private static void EmitCastToReference(ILGenerator il, Type type)
        {
            if (type.IsValueType)
                il.Emit(OpCodes.Unbox_Any, type);
            else
                il.Emit(OpCodes.Castclass, type);
        }
    }
}