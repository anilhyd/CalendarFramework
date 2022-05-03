#region Header Info
//-----------------------------------------------------------------------
// <copyright file="Reflect.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Reflects the methods at runtime.</summary>
// <createdby>Desayya</createdby> 
// <createddate>11-July-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Linq.Expressions;
using System.Reflection;
//using ModuleResource = Properties.Resources;

#endregion

namespace Calendar.Framework.Runtime
{
    /// <summary>
    /// Provides strong-typed reflection of the <typeparamref name="TTarget"/> 
    /// type.
    /// </summary>
    /// <typeparam name="TTarget">Type to reflect.</typeparam>
    public static class Reflect<TTarget>
    {
        /// <summary>
        /// Gets the method represented by the lambda expression.
        /// </summary>
        /// <param name="method">Method to be called.</param>
        /// <returns>MethodInfo object.</returns>
        public static System.Reflection.MethodInfo GetMethod(Expression<Action<TTarget>> method)
        {
            return GetMethodInfo(method);
        }

        /// <summary>
        /// Gets the method represented by the lambda expression.
        /// </summary>
        /// <typeparam name="T1">Generice parameter.</typeparam>
        /// <param name="method">Method to be called.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="method"/> is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="method"/> is not a lambda expression or it does not represent a method invocation.</exception>
        /// <returns>MethodInfo object.</returns>
        public static System.Reflection.MethodInfo GetMethod<T1>(Expression<Action<TTarget, T1>> method)
        {
            return GetMethodInfo(method);
        }

        /// <summary>
        /// Gets the method represented by the lambda expression.
        /// </summary>
        /// <typeparam name="T1">Generice parameter.</typeparam>
        /// <typeparam name="T2">T2 enerice parameter.</typeparam>
        /// <param name="method">Method to be called.</param>
        /// <returns>MethodInfo object.</returns>
        public static System.Reflection.MethodInfo GetMethod<T1, T2>(Expression<Action<TTarget, T1, T2>> method)
        {
            return GetMethodInfo(method);
        }

        /// <summary>
        /// Gets the method represented by the lambda expression. 
        /// </summary>
        /// <typeparam name="T1">T1 Param for expression.</typeparam>
        /// <typeparam name="T2">T2 Param for expression.</typeparam>
        /// <typeparam name="T3">T3 Param for expression.</typeparam>
        /// <param name="method">Name of the method.</param>
        /// <returns>Returns the dynamic method.</returns>
        public static System.Reflection.MethodInfo GetMethod<T1, T2, T3>(Expression<Action<TTarget, T1, T2, T3>> method)
        {
            return GetMethodInfo(method);
        }

        /// <summary>
        /// Gets the property represented by the lambda expression.
        /// </summary>
        /// <param name="property">Property to be called.</param>
        /// <returns>PropertyInfo object.</returns>
        public static PropertyInfo GetProperty(Expression<Func<TTarget, object>> property)
        {
            var info = GetMemberInfo(property) as PropertyInfo;
            if (info == null) throw new ArgumentException("MemberIsNotAproperty");

            return info;
        }

        /// <summary>
        /// Gets the property represented by the lambda expression.
        /// </summary>
        /// <typeparam name="P">Type assigned to the property.</typeparam>
        /// <param name="property">Property Expression.</param>
        /// <returns>Returns Property Info object.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="property"/> is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="property"/> is not a lambda expression or it does not represent a property access.</exception>
        public static PropertyInfo GetProperty<P>(Expression<Func<TTarget, P>> property)
        {
            var info = GetMemberInfo(property) as PropertyInfo;
            if (info == null) throw new ArgumentException("MemberIsNotAproperty");

            return info;
        }

        /// <summary>
        /// Gets the field represented by the lambda expression.
        /// </summary>
        /// <param name="field">Filed info to be called.</param>
        /// <returns>FieldInfo object.</returns>
        public static FieldInfo GetField(Expression<Func<TTarget, object>> field)
        {
            var info = GetMemberInfo(field) as FieldInfo;
            if (info == null) throw new ArgumentException("MemberIsNotAfield");

            return info;
        }

        /// <summary>
        /// Gets the field represented by the expression.
        /// </summary>
        /// <param name="member">Member expression to be called.</param>
        /// <returns>MemberInfo object.</returns>
        private static MemberInfo GetMemberInfo(Expression member)
        {
            if (member == null) throw new ArgumentNullException("member");

            var lambda = member as LambdaExpression;
            if (lambda == null) throw new ArgumentException("NotALambdaExpression", "member");

            MemberExpression memberExpr = null;

            // The Func<TTarget, object> we use returns an object, so first statement can be either 
            // a cast (if the field/property does not return an object) or the direct member access.
            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                // The cast is an unary expression, where the operand is the 
                // actual member access expression.
                memberExpr = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null) throw new ArgumentException("NotAMemberAccess", "member");

            return memberExpr.Member;
        }

        /// <summary>
        /// Gets the Method based on the expression.
        /// </summary>
        /// <param name="method">Method Expression.</param>
        /// <returns>MethodInfo Object.</returns>
        private static System.Reflection.MethodInfo GetMethodInfo(Expression method)
        {
            if (method == null) throw new ArgumentNullException("method");

            var lambda = method as LambdaExpression;
            if (lambda == null) throw new ArgumentException("NotALambdaExpression", "method");
            if (lambda.Body.NodeType != ExpressionType.Call) throw new ArgumentException("NotAMethodCall", "method");

            return ((MethodCallExpression)lambda.Body).Method;
        }
    }
}